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
    public class MyCell : DataGridViewTextBoxCell
    {
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

        public MyTable() : base() 
        {
            
        }

        public MyTable(int n, int m) : base()
        {
            AddColumn(3*m);
            AddRow(3*n - 5);
            AddRow(3);
            AddRow(2);
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
                col.HeaderCell.Value = GetColTitle(M);
                Columns.Add(col);
            }
        }

        public void DeleteRow(int num)
        {
            
        }

        public void DeleteColumn(int num)
        {

        }

        public void Recalculate()
        {

        }

        public string GetColTitle(int num)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string title = "";
            while(num > 0)
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
            Controls.Add(Table);
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
