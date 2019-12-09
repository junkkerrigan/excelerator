using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Excelerator
{
    public static class console
    {
        public static void log(object obj)
        {
            Debug.WriteLine(obj);
        }
    }
    // mod div
    // inc dec
    // power
    // max, min
    // java -jar antlr-4.7.2-complete.jar -Dlanguage=CSharp.\ArithmeticGrammar.g4 -visitor
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
                Top = textLabel.Bottom + 5, 
                Width = 300
            };
            Button confirmation = new Button()
            {
                Text = "Submit",
                Left = textBox.Right - 115,
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
        public static string NumberToColumnTitle(int num)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string title = "";
            //if (num <= 0) throw new ArgumentException();
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

        public static int ColumnTitleToNumber(string title)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int num = 0, pow = 1;
            for(int i = title.Length - 1; i >= 0;  i--)
            {
                num += (alphabet.IndexOf(title[i]) + 1) * pow;
                pow *= 26;
            }
            return num;
        }
    }

    public class MyParsErrListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            console.log("SE");
            throw new Exception();
        }
    }

    public class MyCell : DataGridViewTextBoxCell
    {
        public string Expression { get; set; } = "";

        public bool Recalculated { get; set; } = false;

        public HashSet<MyCell> Depended { get; set; } = new HashSet<MyCell>();
        
        public HashSet<MyCell> Dependencies { get; set; } = new HashSet<MyCell>();
        
        public MyCell() : base()
        {
        }

        public int EvaluateExpression(HashSet<string> usedCells)
        {
            if (Expression == "")
            {
                var ex = new Exception();
                ex.Data.Add("Type", "reference to empty cell");
                throw ex;
            }
            if (Recalculated)
            {
                return (int)Value;
            }
            try
            {
                var inputStream = new AntlrInputStream(Expression);
                var lexer = new ArithmeticGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(lexer);
                var parser = new ArithmeticGrammarParser(commonTokenStream);
                parser.RemoveErrorListeners();
                parser.AddErrorListener(new MyParsErrListener());
                var expr = parser.expression();
                int val = 
                    (new MyVisitor(DataGridView as MyTable, usedCells, this))
                    .Visit(expr);
                Recalculated = true;
                return val;
            }
            catch 
            {
                throw;
            }            
        }

        public override object Clone()
        {
            var clone = base.Clone() as MyCell;
            clone.Expression = Expression;
            return clone;
        }
    }

    public class MyVisitor : ArithmeticGrammarBaseVisitor<int>
    {
        MyTable Table;

        MyCell Evaluating;

        HashSet<string> UsedCells;

        public MyVisitor(MyTable table, HashSet<string> usedCells, MyCell evaluating) : base()
        {
            Table = table;
            Evaluating = evaluating;
            UsedCells = usedCells;
            console.log($"Evaluating: {evaluating}");
            console.log("Dependecies:");
            foreach (var d in evaluating.Dependencies)
            {
                console.log(d);
            }
            console.log("Depended:");
            foreach (var d in evaluating.Depended)
            {
                console.log(d);
            }
        }
        
        public override int VisitExpression(ArithmeticGrammarParser.ExpressionContext context)
        {
            try
            {
                Debug.WriteLine(context.GetText());
                int ans = Visit(context.component());
                Debug.WriteLine($"{ans}");
                return ans;
            }
            catch 
            {
                throw;
            }
        }

        public override int VisitNumber([NotNull] ArithmeticGrammarParser.NumberContext context)
        {
            int ans = int.Parse(context.GetText());
            Debug.WriteLine($"num {ans}");
            return ans;
        }

        public override int VisitAddition(ArithmeticGrammarParser.AdditionContext context)
        {
            int l = WalkLeft(context), r = WalkRight(context);
            int ans;
            if (context.operatorToken.Type == ArithmeticGrammarLexer.PLUS)
            {
                ans = l + r;
                Debug.WriteLine($"plus {ans}");
            }
            else
            {
                ans = l - r;
                Debug.WriteLine($"minus {ans}");
            }
            return ans;
        }

        public override int VisitMultiplication(ArithmeticGrammarParser.MultiplicationContext context)
        {
            int l = WalkLeft(context), r = WalkRight(context);
            int ans;
            if (context.operatorToken.Type == ArithmeticGrammarLexer.MULT)
            {
                ans = l * r;
                Debug.WriteLine($"mult {ans}");
            }
            else
            {
                if (r == 0)
                {
                    var ex = new Exception();
                    ex.Data.Add("Type", "division by 0");
                    throw ex;
                }
                ans = l / r;
                Debug.WriteLine($"div {ans}");
            }
            return ans;
        }

        public override int VisitModulo([NotNull] ArithmeticGrammarParser.ModuloContext context)
        {
            var l = WalkLeft(context);
            var r = WalkRight(context);
            if (r == 0)
            {
                var ex = new DivideByZeroException(); 
                ex.Data.Add("Type", "modulo by zero");
                throw ex;
            }
            int ans = l % r;
            Debug.WriteLine($"mod {ans}");
            return ans;
        }

        public override int VisitPower([NotNull] ArithmeticGrammarParser.PowerContext context)
        {
            var l = WalkLeft(context);
            var r = WalkRight(context);
            if (r < 0)
            {
                var ex = new ArgumentOutOfRangeException();
                ex.Data.Add("Type", "negative power");
                throw ex;
            }
            if (r == 0 && l == 0)
            {
                var ex = new ArgumentOutOfRangeException();
                ex.Data.Add("Type", "0^0");
                throw ex;
            }
            int ans = (int)Math.Pow(l, r);
            Debug.WriteLine($"pow {ans}");
            return ans;
        }

        public override int VisitUnaryMinus([NotNull] ArithmeticGrammarParser.UnaryMinusContext context)
        {
            int ans = -1 * Visit(context.component());
            Debug.WriteLine($"unMin {ans}");
            return ans;
        }

        public override int VisitParenthesis([NotNull] ArithmeticGrammarParser.ParenthesisContext context)
        {
            int ans = Visit(context.component());
            Debug.WriteLine($"par {ans}");
            return ans;
        }

        public override int VisitMaximum([NotNull] ArithmeticGrammarParser.MaximumContext context)
        {
            int ans = int.MinValue;
            foreach (var op in context.component())
            {
                ans = Math.Max(Visit(op), ans);
            }
            Debug.WriteLine($"max {ans}");
            return ans;
        }

        public override int VisitMinimum([NotNull] ArithmeticGrammarParser.MinimumContext context)
        {
            int ans = int.MaxValue;
            foreach (var op in context.component())
            {
                ans = Math.Min(Visit(op), ans);
            }
            Debug.WriteLine($"min {ans}");
            return ans;
        }

        public override int VisitNegativeNumber([NotNull] ArithmeticGrammarParser.NegativeNumberContext context)
        {
            int ans = int.Parse(context.GetText());
            console.log($"neg {ans}");
            return ans;
        }
        
        public override int VisitCell([NotNull] ArithmeticGrammarParser.CellContext context)
        {
            try
            {
                string cellPosition = context.GetText();
                if (UsedCells.Contains(cellPosition))
                {
                    var ex = new Exception();
                    ex.Data.Add("Type", "reference loop");
                    throw ex;
                }
                UsedCells.Add(cellPosition);
                int titleLen = 0;
                while (65 <= (int)cellPosition[titleLen] && (int)cellPosition[titleLen] <= 90)
                    titleLen++;
                int colNum = Converter.ColumnTitleToNumber(cellPosition.Substring(0, titleLen)) - 1;
                int rowNum = int.Parse(cellPosition.Substring(titleLen)) - 1;
                MyCell cell = Table.GetCell(rowNum, colNum);
                cell.Depended.Add(Evaluating);
                Evaluating.Dependencies.Add(cell);
                int ans = cell.EvaluateExpression(UsedCells);
                UsedCells.Remove(cellPosition);
                Debug.WriteLine($"{cellPosition} {ans}");
                return ans;
            }
            catch
            {
                throw;
            }
        }

        public override int VisitRest([NotNull] ArithmeticGrammarParser.RestContext context)
        {
            throw new Exception();
        }

        private int WalkLeft(ArithmeticGrammarParser.ComponentContext context)
        {
            return Visit(context.GetRuleContext<ArithmeticGrammarParser.ComponentContext>(0));
        }

        private int WalkRight(ArithmeticGrammarParser.ComponentContext context)
        {
            return Visit(context.GetRuleContext<ArithmeticGrammarParser.ComponentContext>(1));
        }
    }

    public class MyTable : DataGridView
    {
        int N = 0;
        int M = 0;

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
            AllowUserToAddRows = false;
            MultiSelect = false;
            AddColumn(m);
            AddRow(n);
            RowHeadersWidth = 60;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                col.HeaderCell.Value = Converter.NumberToColumnTitle(M);
                Columns.Add(col);
            }
        }

        private void ResetDepended(MyCell cur)
        {
            cur.Value = cur.Expression = "";
            foreach (var d in cur.Depended)
            {
                ResetDepended(d);
            }
            cur.Depended.Clear();
            cur.Dependencies.Clear();
        }

        public void DeleteRow(int idx)
        {
            idx--;
            bool canDelete = true;
            for (int i = 0; i < M; i++)
            {
                var cell = GetCell(idx, i);
                foreach (var d in cell.Depended)
                {
                    if (d.RowIndex == idx) continue;
                    canDelete = false;
                    break;
                }
            }
            if (canDelete)
            {
                ShiftRowTitles(idx);
                Rows.RemoveAt(idx);
                N--;
                return;
            }
            var isDelete = MessageBox.Show("If you delete this row, some cells" +
                " will be cleared. Delete this row?", "Danger",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (isDelete == DialogResult.No) return;
            try
            {
                for (int i = 0; i < M; i++)
                {
                    var cell = GetCell(idx, i);
                    ResetDepended(cell);
                }
                ShiftRowTitles(idx);
                Rows.RemoveAt(idx);
                N--;
            }
            catch (Exception ex)
            {
                console.log($"in DelRow: {ex.Message}");
            }
        }

        private void ShiftRowTitles(int to)
        {
            for (int i = N - 1; i > to; i--)
            {
                Rows[i].HeaderCell.Value = Rows[i - 1].HeaderCell.Value;
            }
        }

        public void DeleteColumn(string title)
        {
            int idx = Converter.ColumnTitleToNumber(title);
            idx--;
            bool canDelete = true;
            for (int i = 0; i < N; i++)
            {
                var cell = GetCell(i, idx);
                foreach (var d in cell.Depended)
                {
                    if (d.ColumnIndex == idx) continue;
                    canDelete = false;
                    break;
                }
            }
            if (canDelete)
            {
                ShiftColTitles(idx);
                Columns.RemoveAt(idx);
                M--;
                return;
            }
            var isDelete = MessageBox.Show("If you delete this column, some cells" +
                " will be cleared. Delete this column?", "Danger",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (isDelete == DialogResult.No) return;
            try
            {
                for (int i = 0; i < N; i++)
                {
                    var cell = GetCell(i, idx);
                    ResetDepended(cell);
                }
                ShiftColTitles(idx);
                Columns.RemoveAt(idx);
                M--;
            }
            catch (Exception ex)
            {
                console.log($"in DelCol: {ex.Message}");
            }
        }

        private void ShiftColTitles(int to)
        {
            for(int i = M - 1; i > to; i--)
            {
                Columns[i].HeaderCell.Value = Columns[i - 1].HeaderCell.Value;
            }
        }

        public MyCell GetCell(int r, int c)
        {
            return Rows[r].Cells[c] as MyCell;
        }
        
        private void ResetRecalculated()
        {
            foreach (DataGridViewRow r in Rows)
            {
                foreach (MyCell c in r.Cells)
                {
                    c.Recalculated = false;
                }
            }
        }
        
        public string GetExpressionInCell(int r, int c)
        {
            if (r < 0 || c < 0) throw new IndexOutOfRangeException();
            return (Rows[r].Cells[c] as MyCell).Expression;
        }

        public MyTable Clone()
        {
            MyTable clone = new MyTable(N, M);
            for (int i = 0; i < Rows.Count; i++)
            {
                int Index = 0;
                foreach (MyCell cell in Rows[i].Cells)
                {
                    clone.Rows[i].Cells[Index] = cell.Clone() as MyCell;
                    Index++;
                }
            }
            return clone;
        }

        public string Serialize()
        {
            string data = $"{N} {M}\n";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    data += GetCell(i, j).Expression + '\n';
                }
            }
            return data;
        }

        public static MyTable CreateFromSerialized(string data)
        {
            try 
            {
                var reader = new StringReader(data);
                var sizes = reader.ReadLine();
                var n = int.Parse(sizes.Substring(0, sizes.IndexOf(' ')));
                var m = int.Parse(sizes.Substring(sizes.IndexOf(' ') + 1));
                console.log($"created table with sizes {n} and {m}");
                MyTable table = new MyTable(n, m);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        table.GetCell(i, j).Expression = reader.ReadLine();
                        console.log($"in cell ({i},{j}) now {table.GetCell(i, j).Expression}");
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        table.Recalculate(table.GetCell(i, j));
                        console.log($"value of ({i},{j}) now {table.GetCell(i, j).Value}");
                    }
                }
                return table;
            }
            catch
            {
                throw;
            }
        }

        private void CalculateCell(MyCell cell)
        {
            try
            {
                var inputStream = new AntlrInputStream(cell.Expression);
                var lexer = new ArithmeticGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(lexer);
                var parser = new ArithmeticGrammarParser(commonTokenStream);
                parser.RemoveErrorListeners();
                parser.AddErrorListener(new MyParsErrListener());
                var expr = parser.expression();
                cell.Value =
                    (new MyVisitor(this, new HashSet<string>(), cell))
                    .Visit(expr);
            }
            catch
            {
                throw;
            }
            cell.Recalculated = true;
            foreach (var dep in cell.Depended)
            {
                CalculateCell(dep);
            }
        }

        public void Recalculate(MyCell changed)
        {
            ResetRecalculated();
            foreach (var d in changed.Dependencies)
            {
                d.Depended.Remove(changed);
            }
            changed.Dependencies.Clear();
            if (string.IsNullOrWhiteSpace(changed.Expression))
            {
                ResetDepended(changed);
                return;
            }
            try
            {
                CalculateCell(changed);
            }
            catch
            {
                throw;
            }
        } 
    }

    public partial class Form1 : Form
    {
        public MyTable Table { get; set; }
        bool UpToDate = true;
        MenuStrip MainMenu;
        ToolStripMenuItem Save, Open;
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
            FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpToDate) return; 
            var isSave = MessageBox.Show("You have unsaved changes, they will be lost if you" +
                " close the application. Save changes?", "Danger", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (isSave == DialogResult.Yes)
            {
                Save.PerformClick();
            }
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

        void InitializeTable(MyTable existing = null)
        {
            if (existing == null)
            {
                Table = new MyTable(10, 10)
                {
                    Location = new Point(30, Toolbar.Bottom + 30),
                    Size = new Size(ClientSize.Width - 60,
                        ClientSize.Height - Toolbar.Bottom - 60),
                };
            }
            else
            {
                Table.SuspendLayout();
                Controls.Remove(Table);
                existing.Location = new Point(30, Toolbar.Bottom + 30);
                existing.Size = new Size(ClientSize.Width - 60,
                    ClientSize.Height - Toolbar.Bottom - 60);
                Table = existing;
            }

            Table.CellEnter += (s, e) =>
            {
                MyCell selected = Table.GetCell(e.RowIndex, e.ColumnIndex) as MyCell;
                ExpressionInCell.Text = Table.GetCell(e.RowIndex, e.ColumnIndex).Expression;
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
                MyCell changed = Table.GetCell(e.RowIndex, e.ColumnIndex);
                string oldExpr = changed.Expression;
                changed.Expression = (string)changed.Value;
                try
                {
                    Table.Recalculate(changed);
                }
                catch (Exception ex)
                {
                    if (ex.Data.Contains("Type"))
                    {
                        MessageBox.Show($"Invalid expression: {ex.Data["Type"]}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid expression",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    changed.Expression = oldExpr;
                    Table.Recalculate(changed);
                }
                UpToDate = false;
            };
            Controls.Add(Table);
            Table.ResumeLayout();
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
            ExpressionInCell.Leave += (s, e) =>
            {
                if (Table.SelectedCell == null) return;
                string oldExpr = Table.SelectedCell.Expression;
                Table.SelectedCell.Expression = ExpressionInCell.Text;
                try
                {
                    Table.Recalculate(Table.SelectedCell);
                }
                catch (Exception ex)
                { 
                    if (ex.Data.Contains("Type"))
                    {
                        MessageBox.Show($"Invalid expression: {ex.Data["Type"]}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid expression",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Table.SelectedCell.Expression = oldExpr;
                    Table.Recalculate(Table.SelectedCell);
                }
                UpToDate = false;
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
                string input = Prompt.ShowDialog("Enter title of column to delete:", "");
                if (input == "") return;
                try
                {
                    Table.DeleteColumn(input);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Invalid title of column", "Error",
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
                string input = Prompt.ShowDialog("Enter number of row to delete:", "");
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
            Save = new ToolStripMenuItem("Save to");
            Save.Click += (s, e) =>
            {
                var saveTo = new SaveFileDialog()
                {
                    Filter = "Excelerator files (*.xclr)|*.xclr",
                };
                if (saveTo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveTo.FileName, Table.Serialize());
                }
                UpToDate = true;
            };
            Open = new ToolStripMenuItem("Open from");
            Open.Click += (s, e) =>
            {
                if (!UpToDate)
                {
                    var isSave = MessageBox.Show("You have unsaved changes in current table, " +
                        "they will be lost if you open other. Save changes?", "Danger", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (isSave == DialogResult.Yes)
                    {
                        Save.PerformClick();
                    }
                }
                var openFrom = new OpenFileDialog()
                {
                    Filter = "Excelerator files (*.xclr)|*.xclr",
                };
                if (openFrom.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        InitializeTable(
                            MyTable.CreateFromSerialized(
                                File.ReadAllText(openFrom.FileName)));
                    }
                    catch
                    {
                        MessageBox.Show($"Impossible to open: {openFrom.FileName} is not valid" +
                            $" .xclr file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
            file.DropDownItems.Add(Save);
            file.DropDownItems.Add(Open);
            MainMenu.Items.Add(file);
            Controls.Add(MainMenu);
        }

    }
}
