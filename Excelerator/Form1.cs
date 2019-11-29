using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelerator
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() 
            {
                Left = 50, 
                Top = 20, 
                Text = text, 
                Width = 300 
            };
            TextBox textBox = new TextBox() 
            { 
                Left = 50, 
                Top = textLabel.Bottom + 10, 
                Width = 300
            };
            Button confirmation = new Button()
            {
                Text = "Submit",
                Left = textBox.Right - 100,
                Width = 100,
                Height = 30,
                Top = textBox.Bottom + 10, 
                DialogResult = DialogResult.OK 
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

    public static class Converter
    {
        public static string ToColumnTitle(int num)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string title = "";
            while (num > 0)
            {
                if (num % 26 == 0)
                {
                    num /= 26;
                    num--;
                    title = "Z" + title;
                }
                else
                {
                    title = alphabet[num % 26 - 1] + title;
                    num /= 26;
                }
            }
            return title;
        }
    }

    public class MyCell : DataGridViewTextBoxCell
    {
        public string Expression { get; set; } = "";

        public MyCell() : base()
        {
        }

        public override object Clone()
        {
            var clone = (MyCell)base.Clone();
            return clone;
        }
    }


    public class MyTable : DataGridView
    {
        int N = 0;
        int M = 0;
        public bool AutoSelected { get; set; } = true;

        public MyCell SelectedCell {
            get {
                if (SelectedCells.Count == 0) return null;
                return SelectedCells[SelectedCells.Count - 1] as MyCell;
            }
        }

        public MyTable() : this(0, 0)
        {
        }

        public MyTable(int n, int m) : base()
        {
            MultiSelect = false;
            AddColumn(m);
            AddRow(n);
        }

        public void AddRow(int num = 1)
        {
            for (int i = 0; i < num; i++)
            {
                N++;
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = N.ToString();
                Rows.Add(row);
            }
        }

        public void AddColumn(int num = 1)
        {
            for (int i = 0; i < num; i++)
            {
                M++;
                DataGridViewColumn col = new DataGridViewColumn(new MyCell());
                col.HeaderCell.Value = Converter.ToColumnTitle(M);
                Columns.Add(col);
            }
        }

        public void DeleteRow(int num)
        {
            Rows.RemoveAt(num - 1);
        }

        public void DeleteColumn(int num)
        {
            Columns.RemoveAt(num - 1);
        }

        public string GetExpressionInCell(int r, int c)
        {
            if (r < 0 || c < 0) throw new IndexOutOfRangeException();
            return (Rows[r].Cells[c] as MyCell).Expression;
        }

        public void Recalculate()
        {
            Debug.WriteLine(SelectedCell);
            SelectedCell.Value = $"{SelectedCell.Expression}val";
        }
    }

    public partial class Form1 : Form
    {
        MyTable Table;
        MenuStrip MainMenu;
        TextBox ExpressionInCell;
        Panel Toolbar;
        Button AddRow, AddCol, DelRow, DelCol;

        public Form1()
        {
            InitializeComponent();
            InitializeMainMenu();
            InitializeToolbar();
            InitializeTable();
            Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Toolbar.Width = ClientSize.Width - 120;
            AddCol.Location = new Point(
                    Math.Max(330, (Toolbar.Width - 270) / 2), 5);
            DelCol.Location = new Point(AddCol.Bounds.Right + 30, 5);
            AddRow.Location = new Point(DelCol.Bounds.Right + 30, 5);
            DelRow.Location = new Point(AddRow.Bounds.Right + 30, 5);
            Table.Size = new Size(ClientSize.Width - 60,
                    ClientSize.Height - Toolbar.Bottom - 60);
        }

        void InitializeTable()
        {
            Table = new MyTable(10, 10)
            {
                Location = new Point(30, Toolbar.Bottom + 30),
                Size = new Size(ClientSize.Width - 60, 
                    ClientSize.Height - Toolbar.Bottom - 60),
                AllowUserToAddRows = false,
            };
            
            Table.CellClick += (s, e) =>
            {
                ExpressionInCell.Text = Table.SelectedCell.Expression;
            };
            Table.CellBeginEdit += (s, e) =>
            {
                try
                {
                    Table.SelectedCell.Value = ExpressionInCell.Text =
                        Table.GetExpressionInCell(e.RowIndex, e.ColumnIndex);
                }
                catch (IndexOutOfRangeException)
                {
                }
            };
            Table.CellEndEdit += (s, e) =>
            {
                MyCell changed = Table.Rows[e.RowIndex].Cells[e.ColumnIndex] as MyCell;
                changed.Expression = (string)changed.Value;
                Table.SelectedCell.Expression = (string)Table.SelectedCell.Value;
                Table.Recalculate();
            };
            //Table.CellLeave += (s, e) =>
            //{
            //    Table.SelectedCell.Value = Table.SelectedCell.Expression;
            //};
            Controls.Add(Table);
            //Table.CurrentCell.Selected = false;
        }

        void InitializeToolbar()
        {
            Toolbar = new Panel()
            {
                Location = new Point(60, MainMenu.Bottom + 30),
                Size = new Size(ClientSize.Width - 120, 40),
            };
            ExpressionInCell = new TextBox()
            {
                Location = new Point(0, 0),
                Font = new Font("Times New Roman", 16),
                Width = 300,
            };
            ExpressionInCell.TextChanged += (s, e) =>
            {
                if (Table.SelectedCell != null)
                {
                    Table.SelectedCell.Expression = ExpressionInCell.Text;
                }
            };
            ExpressionInCell.Leave += (s, e) =>
            {
                if (Table.AutoSelected)
                {
                    Table.AutoSelected = false;
                    return;
                }
                Table.SelectedCell.Value = ExpressionInCell.Text;
                Table.Recalculate();
            };
            Toolbar.Controls.Add(ExpressionInCell);
            InitializeButtons();
            Controls.Add(Toolbar);
        }

        void InitializeButtons()
        {
            AddCol = new Button()
            {
                Text = "Add column",
                Location = new Point(
                    Math.Max(330, (Toolbar.Width - 270) / 2), 5),
                Size = new Size(120, 30),
            };
            AddCol.Click += (s, e) => Table.AddColumn();

            DelCol = new Button()
            {
                Text = "Delete column",
                Location = new Point(AddCol.Bounds.Right + 30, 5),
                Size = new Size(120, 30),
            };
            DelCol.Click += (s, e) =>
            {
                string input = Prompt.ShowDialog("Enter number of column to delete:", "");
                if (input == "") return;
                try
                {
                    int num = Convert.ToInt32(input);
                    Table.DeleteColumn(num);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Invalid number of column", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Invalid input", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            AddRow = new Button()
            {
                Text = "Add row",
                Location = new Point(DelCol.Bounds.Right + 30, 5),
                Size = new Size(120, 30),
            };
            AddRow.Click += (s, e) => Table.AddRow();

            DelRow = new Button()
            {
                Text = "Delete row",
                Location = new Point(AddRow.Bounds.Right + 30, 5),
                Size = new Size(120, 30),
            };
            DelRow.Click += (s, e) =>
            {
                string input = Prompt.ShowDialog("Enter number of column to delete:", "");
                if (input == "") return;
                try
                {
                    int num = Convert.ToInt32(input);
                    Table.DeleteRow(num);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Invalid number of row", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Invalid input", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Toolbar.Controls.Add(AddCol);
            Toolbar.Controls.Add(DelCol);
            Toolbar.Controls.Add(AddRow);
            Toolbar.Controls.Add(DelRow);
        }

        void InitializeMainMenu()
        {
            MainMenu = new MenuStrip()
            {
                BackColor = this.BackColor,
                Font = new Font("Times New Roman", 12)
            };
            var file = new ToolStripMenuItem("File");
            var save = new ToolStripMenuItem("Save");
            var open = new ToolStripMenuItem("Open");
            file.DropDownItems.Add(save);
            file.DropDownItems.Add(open);
            MainMenu.Items.Add(file);
            Controls.Add(MainMenu);
        }
    }
}
