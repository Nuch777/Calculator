using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private double EndValue;
        private string OpType = "";
        private bool OpPassed;
        private readonly OperationHistory _log;


        public MainForm()
        {
            InitializeComponent();
            _log = OperationHistory.GetInstance;
        }
        public double Value;
        public double firstValue;
        private void Form1_Load(object sender, EventArgs e)
        {
            lbHistory.DataSource = _log;
            lbHistory.DisplayMember = "AsString";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (OpPassed || tbResult.Text == "0")
                tbResult.Clear();

            OpPassed = false;
            var btn = sender as Button;
            tbResult.Text = tbResult.Text + btn.Text;
        }

        public void operation_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            OpType = btn.Text;

            double.TryParse(tbResult.Text, out Value);
            EndValue = Value;

            lblOperation.Text = $"{EndValue} {OpType}";
            OpPassed = true;
        }

        public void btnEqual_Click(object sender, EventArgs e)
        {
            Double.TryParse(tbResult.Text, out firstValue);
            var op = new Operation { Op = OpType, DigSource = firstValue, DigResult = EndValue };

            switch (OpType)
            {
                case "+":
                    tbResult.Text = (EndValue + firstValue).ToString();
                    break;

                case "-":
                    tbResult.Text = (EndValue - firstValue).ToString();
                    break;

                case "*":
                    tbResult.Text = (EndValue * firstValue).ToString();
                    break;

                case "/":
                    tbResult.Text = (EndValue / firstValue).ToString();
                    break;

                case "√":
                    tbResult.Text = Math.Sqrt(firstValue).ToString();
                    break;
            }
            EndValue = Double.Parse(tbResult.Text);
            lblOperation.Text = "";

            _log.Add(op);
            op.Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!tbResult.Text.Contains(","))
                tbResult.Text += ",";
        }

        private void lbHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbHistory.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches && lbHistory.Items[index] != null)
            {
                var item = lbHistory.Items[index] as Operation;

                lblOperation.Text = item.DigResult + " " + item.Op;

                OpType = item.Op;
                OpPassed = true;

                EndValue = item.DigResult;
                tbResult.Text = item.DigSource.ToString();
            }
        }
    }
}