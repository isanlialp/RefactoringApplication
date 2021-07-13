using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace fileApp
{
    public partial class HideMethod : Form
    {
        public Main mainhide;
      
        public HideMethod()
        {
            InitializeComponent();
            mainhide = new Main();
        }

        public string getPath;
        public string filePath;
        public string fileName;
        public int indexStart;
        public int indexFinish;
        public string possibleMethod;
        public string chosenMethod;
        public bool hideSelected;
        public string textInfo { get; set; }

        List<int> indexList = new List<int>();
        List<string> methodterms = new List<string>();
        List<string> clterms = new List<string>();
        List<string> metodPrivate = new List<string>(); //List of Methods to Apply Hide Method

        public struct Struct_Classes
        {
            public string class_name;
            public List<string> methods;
        }
        public struct Struct_Private// List of Methods Not Used by Other Classes
        {
            public string class_name;
            public string methodName;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(getPath);
            int lastIndex = getPath.LastIndexOf('.');
            var name = getPath.Substring(0, lastIndex);
            string result2 = getPath.Substring(lastIndex + 1);

            if (result2 == "CS" || result2 == "Cs" || result2 == "cs")
            {
                FindClass();
            }
            else
            {
                MessageBox.Show("Choose different file extension", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public void FindClass()
        {
            // OPEN File Containing "C#" Source File
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            mainhide.richTextBox1.Text = "";
            openFile.Filter = "code files (.cs)| *.cs";
            var content = String.Empty;
            FileStream fileStream = new FileStream(
                                getPath, FileMode.OpenOrCreate,
                                   FileAccess.ReadWrite, FileShare.None);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            while (line != null)
            {
                line = streamReader.ReadLine();
                if (line != null)
                {
                    mainhide.richTextBox1.Text += line.ToString()+ "\n";
                }
            }
             //streamReader.Close();
            SyntaxTree tree = CSharpSyntaxTree.ParseText(mainhide.richTextBox1.Text);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            // Get class's methods
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
            // Get method names
            List<Struct_Classes> list_struct_classes = new List<Struct_Classes>();
            List<Struct_Private> list_struct_private = new List<Struct_Private>();
            Struct_Classes struct_classes = new Struct_Classes();
            Struct_Private struct_private = new Struct_Private();
            List<string> method_list = new List<string>();
            foreach (var cl in myClass)
            {
                var methods = cl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                struct_classes.class_name = cl.Identifier.ToString();
                foreach (var method in methods)
                {
                    method_list.Add(method.Identifier.ToString());
                }
                struct_classes.methods = new List<string>(method_list);
                list_struct_classes.Add(struct_classes);
                method_list.Clear();
                struct_classes.class_name = "";
            }
            bool isUsedAnOtherClass = false;
            for (int i = 0; i < list_struct_classes.Count; i++)//top class loop
            {
                for (int j = 0; j < list_struct_classes[i].methods.Count; j++)// methods loop of top class
                {
                    for (int k = i + 1; k < list_struct_classes.Count; k++)// subclass loop
                    {
                        for (int m = 0; m < list_struct_classes[k].methods.Count; m++)// loop of subclass methods
                        {
                            if (list_struct_classes[i].methods[j] == list_struct_classes[k].methods[m])
                            {  
                                struct_private.class_name = list_struct_classes[i].class_name;
                                struct_private.methodName = list_struct_classes[i].methods[j];
                                list_struct_private.Add(struct_private);
                                isUsedAnOtherClass = true;
                            }

                        }
                    }
                }
            }
            string passingData = "";
            List<string> metodLast = new List<string>();
            foreach (var cl in myClass)
            {
                var methods = cl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                struct_classes.class_name = cl.Identifier.ToString();
                foreach (var method in methods)
                {
                    metodLast.Add(method.Identifier.ToString());
                }

            }
            List<string> distinctMetod = metodLast.Distinct().ToList();// Get one of the same methods.
            distinctMetod.Remove("Main");
            distinctMetod.Remove("bool");
            foreach (var item in list_struct_private)
            {
                distinctMetod.Remove(item.methodName);
            }

            metodPrivate = distinctMetod;
            HideMethodApply();
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();

        }
        
        public void HideMethodApply()
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(mainhide.richTextBox1.Text);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            Settings1.Default.passingData = mainhide.richTextBox1.Text;
            mainhide.richTextBox2.Text = Settings1.Default.passingData;
            List<int> sayilar = new List<int>();
            int indexStart;
            string find = "public";
            string modify = "private";
            try
            {
                foreach (var cl in myClass)
                {
                    var methods = cl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                    foreach (var method in methods)
                    {
                        foreach (var item in metodPrivate)
                        {
                            if (method.Identifier.ToString() == item)
                            {
                                mainhide.listBox2.Items.Add(method.ToString());
                                string tip = method.ReturnType.ToString();
                                string erisim = method.Modifiers.ToString();
                                string tanim = method.Identifier.ToString();
                                string aranan = erisim+" "+tip+" "+tanim+"";
                                int indexOfSearch=0;
                                int indexOfSearch2=0;
                                int start = 0;
                                int indexFinish = 0;
                                indexOfSearch = mainhide.richTextBox2.Find(aranan, start, mainhide.richTextBox2.TextLength, RichTextBoxFinds.None);
                                indexOfSearch2 = mainhide.richTextBox1.Find(aranan, start, mainhide.richTextBox1.TextLength, RichTextBoxFinds.None);
                                indexStart = indexOfSearch;
                                if (indexOfSearch != -1)
                                {

                                    sayilar.Add(indexStart);
                                    indexFinish = indexStart + method.Modifiers.ToString().Length ;
                                    mainhide.richTextBox1.SelectionBackColor = Color.Yellow;
                                    mainhide.richTextBox2.Text = mainhide.richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);
                                    mainhide.richTextBox2.Text = mainhide.richTextBox2.Text.Insert(indexStart, modify);
                                    mainhide.richTextBox2.SelectionBackColor = Color.Yellow;                                 
                                }                                                             
                                else
                                {
                                    MessageBox.Show(" Code Block Not Found for Refactoring. Try Again...", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }                               
                            }
                        }

                    }
                    for (int i = 0; i < sayilar.Count; i++)
                    {
                        int gelen = sayilar[i];
                        mainhide.richTextBox2.Select(gelen, modify.Length);
                        mainhide.richTextBox2.SelectionColor = Color.Red;
                        mainhide.richTextBox2.SelectionBackColor = Color.MintCream;
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void JavaApply_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(getPath);
            int lastIndex = getPath.LastIndexOf('.');
            var name = getPath.Substring(0, lastIndex);
            string result2 = getPath.Substring(lastIndex + 1);
            if (result2 == "Java" || result2 == "JAVA" || result2 == "java")
            {  
            textInfo = mainhide.TextInformation();
            int sayac = 0;
            //The Regex below will detect all possible java method definitions
            string pattern = @"((public|private|protected|static|final|native|synchronized|abstract|transient)+\s)+[\$_\w\<\>\w\s\[\]]*\s+[\$_\w]+\([^\)]*\)?\s*";
            MatchCollection matches = Regex.Matches(textInfo, pattern);
            if (matches.Count == 0)
            {
                MessageBox.Show(" Appropriate code not found", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("The number of methods is " + matches.Count.ToString(), "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hideSelected = true;
                if (matches != null && matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        mainhide.richTextBox1.Select(match.Index, match.Length);
                        indexStart = match.Index;
                        indexFinish = indexStart + match.Length;
                        indexList.Add(indexStart);
                        indexList.Add(indexFinish);
                        mainhide.richTextBox1.SelectionColor = Color.Green;
                        possibleMethod = mainhide.richTextBox1.Text.Substring(indexStart, match.Length);
                        mainhide.listBox2.Items.Add(possibleMethod + "\n");  
                    }
                }
            }
            }
            else
            {
                MessageBox.Show("Choose different file extension", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void hideMethod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Close the Form?", "Closing the Form",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Canceling the closing event
                e.Cancel = true;
            }
        }
    }
}        