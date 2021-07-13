using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace fileApp
{
    public partial class MaintainabilityIndex : Form
    {
        public Main mtbIndex = new Main();
        Process locProcess = new Process();
        public string filePath;
        public string fileMIpath;
        public string fileMIname;
        public MaintainabilityIndex()
        {
            InitializeComponent();
        }

        private void MainIndex_Click(object sender, EventArgs e)
        {        
            var proc2 = new ProcessStartInfo();
            string anyCommand3 = @"""C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat""";
            string anyCommand4 = @"cd\";
            string output;
            proc2.UseShellExecute = false;
            proc2.WorkingDirectory = @"C:\Windows\System32";
            proc2.FileName = @"C:\Windows\System32\cmd.exe";
            proc2.Verb = "runas";
            proc2.Arguments = "/K " + anyCommand3;
            proc2.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                var process = new Process();
                process.StartInfo = proc2;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();                
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + System.Environment.NewLine + ex.ToString() + System.Environment.NewLine);
                throw;
            }
       
        }
        private void BtnGetMetric_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Select the XML File produced via the DEVELOPER COMMAND PROMPT", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Not Selected File Name!!! Select File...",
                                  "WARNING",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation,
                                     MessageBoxDefaultButton.Button1);
            }
            else
            {
                StringBuilder result = new StringBuilder();
                OpenFileDialog OpenFDB = new OpenFileDialog();
                OpenFDB.InitialDirectory = "@C:\\refactoring\\";
                OpenFDB.Filter = "xml Files|*.xml|html Files|*.html|All Files|*.*";
                OpenFDB.FilterIndex = 3;
                if (OpenFDB.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourceFile = OpenFDB.FileName;

                        XDocument xdoc = XDocument.Load(sourceFile);

                        var lv1s = from lv1 in xdoc.Descendants("NamedType")
                                   select new
                                   {
                                       Header = lv1.Attribute("Name").Value,
                                       Children = lv1.Descendants("Metrics"),
                                       Sonraki = lv1.Descendants("Metric"),
                                       Ad = lv1.Attribute("Name").Value,
                                       deneme = lv1.Element("Metrics").FirstNode
                                   };

                        foreach (var lv1 in lv1s)
                        {
                            if (lv1.Header == textBox1.Text.Trim())
                            {
                                XDocument doc = XDocument.Parse(lv1.deneme.Parent.ToString());
                                var metric = from m1 in doc.Descendants("Metric")
                                             select new
                                             {
                                                 Type = m1.Attribute("Name").Value,
                                                 Deger = m1.Attribute("Value").Value
                                             };
                                foreach (var m1 in metric)
                                {
                                    if (m1.Type.ToString() == "MaintainabilityIndex")
                                        result.AppendLine(m1.Deger.ToString());

                                }
                            }
                        }
                        Tx_Bx_Metric.Text = result.ToString();
                    }

                    catch (Exception exp)
                    {
                        MessageBox.Show("An error occurred : " + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);

                        throw;
                    }
                }
 
            }
        }

        private void FileName_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Select the FOLDER PATH used for the developer command prompt and Get the CLASS NAME for which you want the metric value measured.", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"C:\";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.cs");//FILE FORMATS
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath, "*.cs");//FILE NAMES
                foreach (string file in files)
                {
                    try
                    {
                        if (file != string.Empty)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            string name = Path.GetFileNameWithoutExtension(fileInfo.Name);
                            long byteBoyut = fileInfo.Length;
                            DateTime olsTarihi = fileInfo.CreationTime;
                            // ADDING THE NAMES OF FOLDERS TO THE LISTBOX
                            listBox1.Items.Add(name);
                        }
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        MessageBox.Show(ex.Message + " , attention please", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message + " ,attention please", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                }
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (listBox1.SelectedItem != null)
            {
                string codeClassName = listBox1.SelectedItem.ToString();
                textBox1.Text = codeClassName;
                
                rtxMtbIndex.BackColor = Color.White;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {           
            rtxMtbIndex.Text = " ";
            OpenFileDialog openFilex = new OpenFileDialog();
            string line = "";
            rtxMtbIndex.Text = " ";

            openFilex.Filter = "code files (.cs)| *.cs|All Files|*.*";
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
                        rtxMtbIndex.Text += line.ToString() + "\n";
                    }
                }
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("Selected Source Code File Not Found", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        public string BtnFileSelect()
        {

            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "code files (.cs)|*.cs|txt files (*.txt)|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select File";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // File Selected
                fileMIpath = file.FileName;
                fileMIname = file.SafeFileName;

            }
            return fileMIpath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtxMtbIndex.Clear();
            textBox1.Clear();
            listBox1.Items.Clear();
            Tx_Bx_Metric.Clear();
        }

        private void Original_Code_Metric_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Tx_Bx_Metric.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(Tx_Bx_Metric.Text);
                mtbIndex.WriteOriginalCodeMetric(countMetric, 2, 12);
            }
        }
        private void MIRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(Tx_Bx_Metric.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Maintainability Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float countMetric = float.Parse(Tx_Bx_Metric.Text);
                mtbIndex.WriteRefaCodeMetricExcel(countMetric, row, 12);
            }
        }
    }
}