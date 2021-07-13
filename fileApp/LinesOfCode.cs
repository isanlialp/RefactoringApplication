using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fileApp
{
    public partial class LinesOfCode : Form
    {
        public Main codeLine = new Main();
        public string filePath;
        public string fileName;
        public LinesOfCode()
        {
            InitializeComponent();
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            richTextBox1.Text = "";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            string yl = FileSelect();
            if (yl != null)
            {
                // Open File
                FileStream fileStream = new FileStream(
                                yl, FileMode.OpenOrCreate,
                                   FileAccess.ReadWrite, FileShare.None);

                StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);

                int linecount = 0;

                while (line != null)
                {

                    line = streamReader.ReadLine();
                    linecount++;
                    if (line != null)
                    {
                        //Add code lines to text
                        richTextBox1.Text += line.ToString() + "\n";
                    }

                }
                if (this.richTextBox1.TextLength != 0)
                {
                    linecount = linecount - 1;
                    TxtMetricValue.Text = linecount.ToString();
                }
                else
                {
                    MessageBox.Show("Not Found Lines of Code...", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    TxtMetricValue.Text = "0";
                }
                fileStream.Close();
            }
        }

        public string FileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select File";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // file selected
                filePath = file.FileName;
                fileName = file.SafeFileName;

            }
            return filePath;
        }   
        //Save Metric Value 
        private void BtnSaveOriginalCodeMetric_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtMetricValue.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Lines Of Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int countMetric = int.Parse(TxtMetricValue.Text);
                codeLine.WriteOriginalCodeMetric(countMetric, 2, 6);
            }
        }
        //Clear Path, Code Lines, 
        private void BtnClear_Click(object sender, EventArgs e)
        {
            filePath = "";
            richTextBox1.Clear();
            TxtMetricValue.Clear();
            
        }
        private void LineOfCodeRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtMetricValue.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Lines Of Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {               
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
                int countMetric = int.Parse(TxtMetricValue.Text);
                codeLine.WriteRefaCodeMetricExcel(countMetric, row, 6);
            }
        }
    }
}
