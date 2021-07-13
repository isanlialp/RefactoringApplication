using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace fileApp
{
    public partial class DepthOfInheritance : Form
    {
        public Main inheritanceCountNumber = new Main();
        public string filePath;
        public string fileName;
        public DepthOfInheritance()
        {
            InitializeComponent();
        }

        private void DataFetch_Click(object sender, EventArgs e)
        {
            RtxtBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            RtxtBox_Data.Text = "";
            openFile.InitialDirectory = @"C:\refactoring\";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            string yl = BtnFileSelect();
            if (yl != null)
            {
                if (yl.Contains(".cs") || yl.Contains(".Cs") || yl.Contains(".CS"))
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
                            RtxtBox_Data.Text += line.ToString() + "\n";
                        }
                    }
                    string passingData = RtxtBox_Data.Text;
                    string find = @"(class\s*[a-zA-Z0-9]*\s*:)";
                    MatchCollection matches = Regex.Matches(passingData, find);
                    int count = 0;
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            count++;
                        }
                        Txtinheritance.Text = count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Metric value not found...", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        Txtinheritance.Text = "0";
                    }
                    fileStream.Close();
                }
                else if (yl.Contains(".java") || yl.Contains(".JAVA") || yl.Contains(".Java"))
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
                            RtxtBox_Data.Text += line.ToString() + "\n";
                        }
                    }
                    string info = RtxtBox_Data.Text;
                    string find = "extends";
                    MatchCollection matches = Regex.Matches(info, find);
                    int count = 0;
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            count++;
                        }
                        Txtinheritance.Text = count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Metric value not found...", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        Txtinheritance.Text = "";
                    }
                    fileStream.Close();
                }
            }
        }
        public string BtnFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Please Select File";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // Selected File Properties
                filePath = file.FileName;
               fileName = file.SafeFileName;
            }
            return filePath;
        }
        private void Btn_clear_Click(object sender, EventArgs e)
        {
            RtxtBox_Data.Clear();
            Txtinheritance.Clear();
        }
        private void InheritanceOriginalMetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Txtinheritance.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Depth of Inheritance Tree", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int operandData = int.Parse(Txtinheritance.Text);
                inheritanceCountNumber.WriteOriginalCodeMetric(operandData, 2, 8);
            }
        }
        private void InheritanceNumRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(Txtinheritance.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Depth of Inheritance Tree", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                int operandData = int.Parse(Txtinheritance.Text);
                inheritanceCountNumber.WriteRefaCodeMetricExcel(operandData, row, 8);
            }
        }
    }
}