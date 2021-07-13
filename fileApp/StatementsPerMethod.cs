using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace fileApp
{
    public partial class StatementsPerMethod : Form
    {
        public StatementsPerMethod()
        {
            InitializeComponent();
        }

        Process locProcess = new Process();
        public Main stm = new Main();
        public string filePath;
        public string fileName;
        public string extension;
        public float dividend;

        List<string> clterms = new List<string>();
        List<string> method_list = new List<string>();
        public struct Struct_Classes
        {
            public string class_name;
            public List<string> methods;
        }
        //SOURCE CODE FROM FILE 
        private void OpenSourceCode_Click(object sender, EventArgs e)
        {
            RtxtBoxSourceCodeData.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            RtxtBoxSourceCodeData.Text = "";

            //Open File Using Filter 
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            extension = FileSelect();
            if (extension != null)
            {
                FileStream fileStream = new FileStream(
                                    extension, FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite, FileShare.None);
                StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
                while (line != null)
                {
                    //ADD SELECTED SOURCE CODE to RICHBOX 
                    line = streamReader.ReadLine();

                    if (line != null)
                    {
                        RtxtBoxSourceCodeData.Text += line.ToString() + "\n";
                    }
                }
              
                fileStream.Close();             
            }
            else
            {
                MessageBox.Show("Data Not Found", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            //OPEN and SELECT FILE
        }
        public string FileSelect()
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
                // Selected File Properties
                filePath = file.FileName;
                fileName = file.SafeFileName;
            }
            return filePath;
        }
        //METRIC MEASUREMENT
        private void StatementsPerMeth_Click(object sender, EventArgs e)
        {
            if (extension != null)
            {
                if (extension.Contains(".cs") || extension.Contains(".CS") || extension.Contains(".Cs"))
                {
                    string find = ";";
                    int count = 0;
                    if (this.RtxtBoxSourceCodeData.Text.Contains(find))
                    {
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(RtxtBoxSourceCodeData.Text, matchString))
                        {
                            count++;
                        }
                        dividend = float.Parse(count.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Data Not Found", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    SyntaxTree tree = CSharpSyntaxTree.ParseText(RtxtBoxSourceCodeData.Text);
                    var root = (CompilationUnitSyntax)tree.GetRoot();
                    //to do: 
                    var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                    // DETECTION OF CLASS AND METHODS IN SOURCE CODE
                    foreach (var cl in myClass)
                    {
                        var methods = cl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                        clterms.Add(cl.ToString());

                    }
                    int clCount = clterms.Count;

                    if (clCount > 0)
                    {
                        string[] clpost = new string[clCount];
                        for (int i = 0; i < clCount; i++)
                        {
                            /* here you have key and value element */
                            string key = clterms[i];
                            clpost[i] = key.ToString();
                        }
                    }
                    // METHOD FETCHING OPERATIONS
                    List<Struct_Classes> list_struct_classes = new List<Struct_Classes>();
                    Struct_Classes struct_classes = new Struct_Classes();
                    List<string> method_list = new List<string>();
                    int counter = 0;
                    foreach (var cl in myClass)
                    {
                        //GETTING ALL POSSIBLE cs METHODS Using Syntax Analysis
                        var methods = cl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                        struct_classes.class_name = cl.Identifier.ToString();

                        foreach (var method in methods)
                        {
                            method_list.Add(method.Identifier.ToString());
                            counter++;
                        }

                        struct_classes.methods = new List<string>(method_list);
                        list_struct_classes.Add(struct_classes);
                        method_list.Clear();
                        struct_classes.class_name = "";
                    }
                    float value = 0.0f;
                    if (counter != 0)
                    {
                        counter = counter + 1;
                        // Statements per Method Value
                        value = dividend / float.Parse(counter.ToString());
                        float result = (float)Math.Round(value * 100f) / 100f;
                        TxtBox_metric.Text = result.ToString();
                        MessageBox.Show("Metric Value Has Been Measured", "Statements per Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Metric Value Not Found", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        TxtBox_metric.Text = "0";
                    }

                }
                else if (extension.Contains(".java") || extension.Contains(".JAVA") || extension.Contains(".Java"))
                {
                    string find = ";";
                    int count = 0;
                    if (this.RtxtBoxSourceCodeData.Text.Contains(find))
                    {
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(RtxtBoxSourceCodeData.Text, matchString))
                        {
                            count++;
                        }
                        dividend = float.Parse(count.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Data Not Found", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    //GETTING ALL POSSIBLE Java METHODS using REGEX
                    string pattern = @"((public|private|protected|static|final|native|synchronized|abstract|transient)+\s)+[\$_\w\<\>\w\s\[\]]*\s+[\$_\w]+\([^\)]*\)?\s*";                   
                    MatchCollection matches = Regex.Matches(RtxtBoxSourceCodeData.Text, pattern);
                    if (matches.Count == 0)
                    {
                        MessageBox.Show(" Appropriate code not found", "Methods per Class", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }        
                    float value = 0.0f;
                    if (matches.Count != 0)
                    {
                        
                        // Statements per Method Value
                        value = dividend / float.Parse(matches.Count.ToString());
                        float result = (float)Math.Round(value * 100f) / 100f;
                        TxtBox_metric.Text = result.ToString();
                        MessageBox.Show("Metric Value Has Been Measured ", "Statements per Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Metric Value Not Found", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        TxtBox_metric.Text = "0";
                    }
                }
            }
        }
        //SAVING ORIGINAL CODE METRIC
        private void Original_Code_Metric_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtBox_metric.Text))
            {              
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Statements per Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(TxtBox_metric.Text);
                stm.WriteOriginalCodeMetric(countMetric, 2, 11);
            }
        }
        //SAVING REFACTORED CODE METRIC
        private void StatementRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtBox_metric.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO MEASURE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Statements per Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float countMetric = float.Parse(TxtBox_metric.Text);
                stm.WriteRefaCodeMetricExcel(countMetric, row, 11);
            }
        }
        //CLEAR ALL CONTROLS
        private void Clear_Click(object sender, EventArgs e)
        {
            filePath = "";
            RtxtBoxSourceCodeData.Clear();
            TxtBox_metric.Clear();
        }
    }
}
