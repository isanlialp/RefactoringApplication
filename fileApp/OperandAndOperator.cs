using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace fileApp
{
    public partial class OperandAndOperator : Form
    {
        public Main operandOperatorNum = new Main();
        public string filePath;
        public string fileName;

        public OperandAndOperator()
        {
            InitializeComponent();
        }

        private void GetData_Click(object sender, EventArgs e)
        {
            richTextBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            openFile.InitialDirectory = @"C:\Users\santo\Desktop\sampleProject";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            string yl = BtnFileSelect();
            if (yl != null)
            {
                FileStream fileStream = new FileStream(
                                yl, FileMode.OpenOrCreate,
                                FileAccess.ReadWrite, FileShare.None);

                StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);

                while (line != null)
                {

                    line = streamReader.ReadLine();

                    if (line != null)
                    {
                        richTextBox_Data.Text += line.ToString() + "\n"; 

                    }

                }
                string passingData = richTextBox_Data.Text;
                string find = @"([\*\+\-\%\=]|==|\!-|\<|\>|\>=|\<=|\&&|\!|\||\^|\~|<<|\+=|\-=|\*=|\/=|\%=|\<<=|\>>=|\&=|\^=|\|=|\++|\--)";
                MatchCollection matches = Regex.Matches(passingData, find);
                int count = 0;
                if (matches != null && matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        count++;
                    }
                    textBoxOperand.Text = count.ToString();
                    textBoxOperator.Text = (2 * count).ToString();
                }
                else
                {
                    MessageBox.Show("Miras alma işlemi bulunamadı...", "Önemli Not", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                fileStream.Close();
            }
        }
        public string BtnFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\Users\santo\Desktop\sampleProject";
            file.Filter = "ccode files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Dosya Seçiniz..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // dosya seçildi ise
                filePath = file.FileName;
                fileName = file.SafeFileName;

            }
            return filePath;
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            richTextBox_Data.Clear();
            textBoxOperator.Clear();
            textBoxOperand.Clear();
        }

        private void MetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxOperand.Text) || String.IsNullOrEmpty(textBoxOperator.Text))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Operand and Operator Count per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int operandData = int.Parse(textBoxOperand.Text);
                int row = 2;
                MessageBox.Show("Select Excel File to Save OPERAND COUNT", "Operand and Operator Count per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                operandOperatorNum.WriteOriginalCodeMetric(operandData, row, 3);
                int operatorData = int.Parse(textBoxOperator.Text);
                MessageBox.Show("Select Excel File to save OPERATOR COUNT", "Operand and Operator Count per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                operandOperatorNum.WriteOriginalCodeMetric(operatorData, row, 4);
            }
        }

        private void OpMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(textBoxOperand.Text) || String.IsNullOrEmpty(textBoxOperator.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Operand and Operator Count per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int operandData = int.Parse(textBoxOperand.Text);
                int row = 3;
                if (allRadios.Contains("R1"))
                {
                    row = 3;
                }
                else if (allRadios.Contains("R2"))
                {
                    row = 4;
                }
                else if (allRadios.Contains("R3"))
                {
                    row = 5;
                }
                else if (allRadios.Contains("R4"))
                {
                    row = 6;
                }
                else if (allRadios.Contains("R5"))
                {
                    row = 7;
                }
                else if (allRadios.Contains("R6"))
                {
                    row = 8;
                }
                else if (allRadios.Contains("R7"))
                {
                    row = 9;
                }
                operandOperatorNum.WriteRefaCodeMetricExcel(operandData, row, 3);
                int operatorData = int.Parse(textBoxOperator.Text);
                operandOperatorNum.WriteRefaCodeMetricExcel(operatorData, row, 4);
            }
        }

    }
}
