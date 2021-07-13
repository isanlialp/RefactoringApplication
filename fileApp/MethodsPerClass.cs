using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace fileApp
{
    public partial class MethodsPerClass : Form
    {
        public Main functionNum = new Main();
        public string filePath;
        public string fileName;
        public string textInfo { get; set; }

        public MethodsPerClass()
        {
            InitializeComponent();
        }
        List<string> clterms = new List<string>();
        List<string> method_list = new List<string>();
        public struct Struct_Classes
        {
            public string class_name;
            public List<string> methods;
        }
        // List of Methods NOT Used in Another Class
        public struct Struct_Private
        {
            public string class_name;
            public string methodName;
        }
        //Open File, Get Source Code and Calculate Metric
        private void dataFetch_Click(object sender, EventArgs e)
        {

            RxTextBox_data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\refactoring\";
            string line = "";
            RxTextBox_data.Text = "";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            string yl = BtnFileSelect();
            if (yl != null)
            {
                if (yl.Contains(".cs") || yl.Contains(".CS") || yl.Contains(".Cs"))
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
                            RxTextBox_data.Text += line.ToString() + "\n";
                        }

                    }

                    SyntaxTree tree = CSharpSyntaxTree.ParseText(RxTextBox_data.Text);
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
                    List<Struct_Private> list_struct_private = new List<Struct_Private>();
                    Struct_Classes struct_classes = new Struct_Classes();
                    Struct_Private struct_private = new Struct_Private();
                    List<string> method_list = new List<string>();
                    int counter = 0;
                    foreach (var cl in myClass)
                    {
                        //ALL POSSIBLE METHODS 
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

                    if (counter != 0)
                    {
                        counter = counter + 1;
                        TxtFunctionNum.Text = counter.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Method Match Not Found ", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        TxtFunctionNum.Text = "0";
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
                            RxTextBox_data.Text += line.ToString() + "\n";
                        }
                    }
                    //ALL POSSIBLE METHODS 
                    string pattern = @"((public|private|protected|static|final|native|synchronized|abstract|transient)+\s)+[\$_\w\<\>\w\s\[\]]*\s+[\$_\w]+\([^\)]*\)?\s*";
                   
                    MatchCollection matches = Regex.Matches(RxTextBox_data.Text, pattern);
                    if (matches.Count == 0)
                    {
                        MessageBox.Show(" Appropriate code not found", "Methods per Class", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        TxtFunctionNum.Text = matches.Count.ToString();
                    }

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
        //Clear All Controls On The Form
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            RxTextBox_data.Clear();
            TxtFunctionNum.Clear();
        }
        //SAVING ORIGINAL CODE METRIC
        private void OriginalMethodNumMetricSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtFunctionNum.Text))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nUpload Source Code Using the Button named GET CODE.", "Methods per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float countMetric = float.Parse(TxtFunctionNum.Text);
                functionNum.WriteOriginalCodeMetric(countMetric, 2, 7);
            }
        }
        //SAVING REFACTORED CODE METRIC
        private void MethodNumRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtFunctionNum.Text) || (anyChecked == false))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Methods per Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);               
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
                float countMetric = float.Parse(TxtFunctionNum.Text);
                functionNum.WriteRefaCodeMetricExcel(countMetric, row, 7);
            }
        }
    }
}