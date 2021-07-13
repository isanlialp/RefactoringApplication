using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace fileApp
{
    public partial class CallsPerMethod : Form
    {
        public Main call = new Main();
        public string filePath;
        public string fileName;
        public float divisor;
        public CallsPerMethod()
        {
            InitializeComponent();
        }

        private void GetData_Click(object sender, EventArgs e)
        {           
            richTextBox_data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            richTextBox_data.Text = "";
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
                        richTextBox_data.Text += line.ToString() + "\n";

                    }
                }
                //All Possible methods
                string pattern = @"((public|private|protected|static|final|native|synchronized|abstract|transient)+\s)+[\$_\w\<\>\w\s\[\]]*\s+[\$_\w]+\([^\)]*\)?\s*";                
                MatchCollection matches = Regex.Matches(richTextBox_data.Text, pattern);
                if (matches.Count == 0)
                {
                    MessageBox.Show(" Appropriate code not found", "Methods per Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    divisor = float.Parse(matches.Count.ToString());
                }
                string textData = richTextBox_data.Text;
                //All possible method calls 
                string find = @"([.]\S*\([(a-zA-Z0-9)]*\;)|(\([(a-zA-Z0-9)]*\;)";                
                MatchCollection matches1 = Regex.Matches(textData, find);
                int count1 = 0;
                float value = 0.0f;
                if (matches1 != null && matches1.Count > 0)
                {
                    foreach (Match match1 in matches1)
                    {
                        count1++;
                    }
                    // Calls per method
                    value = float.Parse(count1.ToString())/ divisor ;
                    float result = (float)Math.Round(value * 100f) / 100f;                  
                    TxtCallMethod.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Method call not exist...", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    TxtCallMethod.Text = "0";
                }

                fileStream.Close();
            }
        }
        public string BtnFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\Users\santo\Desktop\sampleProject";
            file.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select File..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // Selected File Properties
                filePath = file.FileName;
                fileName = file.SafeFileName;
            }
            return filePath;
        }
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            richTextBox_data.Clear();
            TxtCallMethod.Clear();
        }
        private void OriginalCodeMetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtCallMethod.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "ECOMRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(TxtCallMethod.Text);
                call.WriteOriginalCodeMetric(countMetric, 2, 9);
            }
        }

        private void MethodNumRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtCallMethod.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Calls per Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float countMetric = float.Parse(TxtCallMethod.Text);
                call.WriteRefaCodeMetricExcel(countMetric, row, 9);
            }
        }
    }
}
