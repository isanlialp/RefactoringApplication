using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace fileApp
{
    public partial class CouplingJava : Form
    {
        public string Javapath = null;
        public string couplingJavaFilePath;
        public string couplingJavaFileName;
        public Main couplingJava = new Main();
        Process locProcess = new Process();
        public CouplingJava()
        {
            InitializeComponent();
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            RichTextBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\refactoring\";
            string line = "";
            RichTextBox_Data.Text = "";
            openFile.Filter = "java files (*.java)|*.java|txt files (*.txt)|*.txt|xml Files|*.xml|html Files|*.html";
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
                // warning
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
                couplingJavaFilePath = file.FileName;
                couplingJavaFileName = file.SafeFileName;

            }
            return couplingJavaFilePath;
        }
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
        private void CouplingOriginalMetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtCoupling.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(TxtCoupling.Text);
                couplingJava.WriteOriginalCodeMetric(countMetric, 2, 10);
            }
        }
        private void CouplingRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRadi = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRadi.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtCoupling.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float countMetric = float.Parse(TxtCoupling.Text);
                couplingJava.WriteRefaCodeMetricExcel(countMetric, row, 10);
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            RichTextBox_Data.Clear();
            TxtCoupling.Clear();
        }
    }
}
