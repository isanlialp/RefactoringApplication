using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace fileApp
{
    
    public partial class Coupling : Form
    {
        public Main cop = new Main();
        Process processCoupling = new Process();
        public string fileCCPath;
        public string fileCCName;
        public Coupling()
        {
            InitializeComponent();
        }

        string GetAttribute(XElement gelen, string attribute)
        {
            try
            {
                return gelen.Element(attribute).Value.Trim();
            }
            catch
            {
                return string.Empty;
            }
        }
        private void ButtonXml_Click(object sender, EventArgs e)
        {
            RtxCoupling.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            RtxCoupling.Text = "";
            //OPEN File Using Filter 
            openFile.Filter = "All files (*.*)|*.*";
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
                        RtxCoupling.Text += line.ToString() + "\n";
                    }
                }           
                fileStream.Close();
            }
        }
        public string BtnFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "code files (.cs)| *.cs|txt files (*.txt)|*.txt|xml Files|*.xml|html Files|*.html";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select File..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // Selected File Properties
                fileCCPath = file.FileName;
                fileCCName = file.SafeFileName;
            }
            return fileCCPath;
        }
            private void Button_Clear_Click(object sender, EventArgs e)
        {
            RtxCoupling.Clear();
            TxtCoupling.Clear();
            ListBox1.Items.Clear();
            TxtFileName.Clear();
        }    
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFileName.Clear();

            if (ListBox1.SelectedItem != null)
            {
                string yol = ListBox1.SelectedItem.ToString();
                TxtFileName.Text = yol;
            }
        }
        //Code block that retrieves Coupling Metric value from xml file
        public void GetMetric(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XDocument xDoc = doc.ToXDocument();
            var gelen = (from p in xDoc.Elements("CodeMetricsReport").Elements("Targets").Elements("Target").Elements("Assembly").Elements("Metrics").Elements("Metric") select p).ToList();
            for (int i = 0; i < gelen.Count; i++)
            {
                if (gelen[i].FirstAttribute.Value == "ClassCoupling")
                {
                    TxtCoupling.Text = gelen[i].LastAttribute.Value.ToString();
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Select the FOLDER PATH used for the developer command prompt and Get the CLASS NAME for which you want the metric value measured.", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"C:\refactoring\";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                ListBox1.Items.Clear();
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.cs");
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath, "*.cs");
                foreach (string file in files)
                {
                    try
                    {
                        if (file != string.Empty)
                        {
                            //ADD THE NAMES OF THE FOLDERS TO LISTBOX1
                            FileInfo fileInfo = new FileInfo(file);
                            string dosyaAdi = fileInfo.Name;
                            string ad = Path.GetFileNameWithoutExtension(fileInfo.Name);
                            long byteBoyut = fileInfo.Length;
                            DateTime olsTarihi = fileInfo.CreationTime;
                            ListBox1.Items.Add(ad);
                        }
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        MessageBox.Show(ex.Message + " Coupling", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message + " Coupling", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                }
            }
        }
        //GETTING A COUPLING METRIC VALUE FROM XML ACCORDING TO THE GIVEN PATH
        private void BtnGet_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Select the XML File produced via the DEVELOPER COMMAND PROMPT", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (string.IsNullOrEmpty(TxtFileName.Text) || string.IsNullOrWhiteSpace(TxtFileName.Text))
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
                            if (lv1.Header == TxtFileName.Text.Trim())
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
                                    if (m1.Type.ToString() == "ClassCoupling")
                                        result.AppendLine(m1.Deger.ToString());

                                }


                            }

                        }
                        TxtCoupling.Text = result.ToString();
                    }

                    catch (Exception exp)
                    {
                        MessageBox.Show("An error occurred : " + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);

                        throw;
                    }
                }

            }
        }
        //SAVING THE METRIC OF THE ORIGINAL CODE
        private void CouplingOriginalMetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtCoupling.Text))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Class Coupling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(TxtCoupling.Text);
                cop.WriteOriginalCodeMetric(countMetric, 2, 10);
            }
        }
        //SAVING THE METRIC OF THE REFACTORED CODE
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
                cop.WriteRefaCodeMetricExcel(countMetric, row, 10);
            }
        }
        // Open DEVELOPER COMMAND PROMPT
        private void DevCommandProCoupling_Click(object sender, EventArgs e)
        {
            var procCoupling = new ProcessStartInfo();
            string anyCommand3 = @"""C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat""";
            string anyCommand4 = @"cd\";
            string output;
            procCoupling.UseShellExecute = false;
            procCoupling.WorkingDirectory = @"C:\Windows\System32";
            procCoupling.FileName = @"C:\Windows\System32\cmd.exe";
            procCoupling.Verb = "runas";
            procCoupling.Arguments = "/K " + anyCommand3;
            procCoupling.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                var process = new Process();
                process.StartInfo = procCoupling;
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
                //If you are here the user clicked decline to grant admin privileges (or he's not administrator)
            }

        }
    }
    //XDOCUMENT 2 XMLDOCUMENT
    public static class DocumentExtensions
    {

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
