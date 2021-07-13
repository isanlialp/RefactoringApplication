using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;


namespace fileApp
{
    public partial class LogicalLineNumber : Form
    {
        public Main line = new Main();
        public string filePath;
        public string fileName;
        public LogicalLineNumber()
        {
            InitializeComponent();
        }

        private void GetData_Click(object sender, EventArgs e)
        {
             RtxtBoxSourceCodeData.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            RtxtBoxSourceCodeData.Text = "";
            
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            string yl = FileSelect();
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
                        RtxtBoxSourceCodeData.Text += line.ToString() + "\n";

                    }

                }
                string find = ";";
                int count = 0;
                if (this.RtxtBoxSourceCodeData.Text.Contains(find))
                {
                    var matchString = Regex.Escape(find);
                    foreach (Match match in Regex.Matches(RtxtBoxSourceCodeData.Text, matchString))
                    {
                        count++;
                    }
                    Txt_Value.Text = count.ToString();
                }
                else
                {
                    MessageBox.Show("Logical lines of code not found...", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                fileStream.Close();

            }
        }
       public string FileSelect()
       {
                OpenFileDialog file = new OpenFileDialog();
                 file.InitialDirectory = @"C:\Users\santo\Desktop\sampleProject";
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

        private void Clear_Click(object sender, EventArgs e)
        {
            RtxtBoxSourceCodeData.Clear();
            Txt_Value.Clear();
          
        }

        private void OriginalCodeSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Txt_Value.Text))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "SLOC-L", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int data = int.Parse(Txt_Value.Text);               
                line.WriteOriginalCodeMetric(data,2,2);
            }
        }

        private void RefMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(Txt_Value.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "SLOC-L", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                int data = int.Parse(Txt_Value.Text);
                line.WriteRefaCodeMetricExcel(data, row, 2);
            }
        }      
    }
}
