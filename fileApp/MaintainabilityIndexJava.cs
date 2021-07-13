using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace fileApp
{
    public partial class MaintainabilityIndexForJava : Form
    {
        Process maiProcess = new Process();
        public Main maintainIndexJ = new Main();
        public string Javapath = null;
        public string filePath;
        public string fileName;
        public MaintainabilityIndexForJava()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        private void JHawkOpen_Click(object sender, EventArgs e)
        {
            MaintainabilityIndexForJava frm = new MaintainabilityIndexForJava();
            var proc2 = new ProcessStartInfo();
            string anyCommand3 = @"""java -jar JHawkDemo.jar""";
            string anyCommand4 = @"cd\";
            string output;
            proc2.UseShellExecute = false;
            proc2.WorkingDirectory = @"C:\java\";
            proc2.FileName = @"C:\Windows\System32\cmd.exe";
            proc2.Verb = "runas";
            proc2.Arguments = "/K " + anyCommand3;
            proc2.WindowStyle = ProcessWindowStyle.Minimized;
            CenterToScreen();
            try
            {
                var process = new Process();
                process.StartInfo = proc2;
                //hidden the CMD window
                process.StartInfo.CreateNoWindow = false;     
                process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                process.StartInfo.UseShellExecute = false;
                process.Start();               
                process.WaitForExit();
                process.Close();
            }
     
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }

        private void FileFetch_Click(object sender, EventArgs e)
        {
            RichTextBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\refactoring\";
            string line = "";
            RichTextBox_Data.Text = "";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            try
            {
                Javapath = FileSelection();
                if (Javapath.Length > 0)
                {
                    FileStream fileStream = new FileStream(
                                        Javapath, FileMode.OpenOrCreate,
                                           FileAccess.ReadWrite, FileShare.None);
                    if (fileStream.Length > 0)
                    {
                        // fileStream isn't empty.
                        StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
                        while (line != null)
                        {

                             line = streamReader.ReadLine();
                           if (line != null)
                            {
                                RichTextBox_Data.Text += line.ToString() + "\n";
                            }
                        }
                    }
                    fileStream.Close();
                }
            }
            catch (NullReferenceException n)
            {
                MessageBox.Show("Selected Null Path ", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string FileSelection()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\Users\santo\Desktop\sampleProject";
            file.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Please Select File";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // File selected
                filePath = file.FileName;
                fileName = file.SafeFileName;
            }
            return filePath;
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            RichTextBox_Data.Clear();
            TextBox_metric.Clear();
        }
        private void Original_Code_Metric_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox_metric.Text))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float complexNormData = float.Parse(TextBox_metric.Text);
                maintainIndexJ.WriteOriginalCodeMetric(complexNormData, 2, 5);
            }
        }
        private void ComplexityRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRadi = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRadi.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TextBox_metric.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float refData = float.Parse(TextBox_metric.Text);
                maintainIndexJ.WriteRefaCodeMetricExcel(refData, row, 12);
            }           
        }
    }
}