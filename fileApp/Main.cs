using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OfficeOpenXml;

namespace fileApp
{

    public partial class Main : Form
    {
        int say = 0;
        public string identify { get; set; }
        public bool CheckBoxChecked;
        public int indexField { get; set; }
        public int counterJavaEF;
        public int indexStart;
        public int indexFinish;
        public int indexStart2;
        public int indexFinish2;
        public int indexStartLast;
        public int indexFinishLast;
        public int lengthTxt;
        public string patternElseTryCatch;
        public string getPath { get; set; }
        public string fieldName { get; set; }
        public string fileNameFromPath { get; set; }
        public string typeDec { get; set; }
        public string newText { get; set; }
        public string lastText { get; set; }
        public string downCode { get; set; }
        public string upCode { get; set; }
        public string loop;
        public string nestedLoop;
        public string detection;
        public string TrimString { get; set; }
        public string statementName;
        public string conditionValue;
        public string initTypeName;
        public string searchedLine;
        public string findingMagicNumber;
        public string strLog { get; set; }
        public string dublicate;
        public string passingCode;
        public string content;
        public bool encapsulateCounter;
        public bool consolidateCounter;
        public int loopStartIndex;
        public int loopFinishIndex;
        public int loopStartIndex2;
        public int loopFinishIndex2;
        public int currentPos = 1;
        public string item { get; set; }
        public string textDoc { get; set; }
        public string removeString2;
        public int indexDifference;
        public string equalText;
        public string ret;
        public string msg;
        public string lang;
        public string ext;
        public EncapsulateField f2;
        public EncapsulateFieldJava fieldJava;
        public InlineTemp tp;
        public MagicNumber mN;
        public HideMethod hd;
        public LogicalLineNumber logicalLineNum;
        public LinesOfCode lineNumber;
        public MethodsPerClass functionNo;
        public CallsPerMethod functionCallNo;
        public DepthOfInheritance inheritLevel;
        public OperandAndOperator transactionNo;
        public Complexity codeComplexity;
        public Coupling relation;
        public CouplingJava relationJava;
        public StatementsPerMethod state;
        public MaintainabilityIndex mainIndex;
        public MaintainabilityIndexForJava mainIndexJ;
        public AppliedRefactoringTechniques rf;
        public R draw;
        Process myProcess = new Process();
        List<string> firstLoop = new List<string>();
        List<string> secondLoop = new List<string>();
        List<string> firstLoop1 = new List<string>();
        List<string> secondLoop2 = new List<string>();
        List<string> detectedDublicate = new List<string>();
        List<string> finalResult = new List<string>();
        List<string> finalResultChange = new List<string>();

        public Main()
        {
            InitializeComponent();
            this.menuStrip1.Enabled = false;
            label2.Visible = false;
        }
        //CREATE AND WRITE LOG FILE
        public void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
            string takePath = listBox1.SelectedItem.ToString();
            string filename = Path.GetFileName(takePath);
            string[] arr = filename.Split('.');
            string newNLogFileName="-";
            foreach (string itemName in arr)
            {
                newNLogFileName += itemName.ToString();
            }

            string logFilePath = @"C:\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + newNLogFileName + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog); //STARTED TO KEEP LOG
            log.Close();
        }

        //CODE BLOCKS THAT Get CODE EXTENSIONS AND CODES FROM FILE TO RICHTEXTBOX
        //*************************************************************************************************************************************
        private void Browse_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            listBox1.Items.Clear();
            listView1.Items.Clear();
            listBox2.Items.Clear();
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            ButtonExcelCreate.Enabled = true;
            SaveOriginalAndRefactored.Enabled = true;
            Clear.Enabled = true;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\refactoring\";
      
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.*");
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath, "*.*");

                                            chart1.Visible = true;
                                            chart1.Titles.Add("File Size");
                                            chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
                                            chart1.Titles[0].BackColor = Color.Turquoise;
                                            chart1.Titles[0].Font = new Font("Arial", 10, FontStyle.Bold);

                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (extension == ".Cs" || extension == ".cs" || extension == ".CS" || extension == ".java" || extension == ".Java" || extension == ".JAVA")
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string fileName = fileInfo.Name;
                        long byteLenght = fileInfo.Length;
                        //TRANSFERRING THE PROPERTIES OF THE SELECTED FILES TO A CHART
                        chart1.Series["FileInformation"].IsValueShownAsLabel = true;
                        this.chart1.Series[0]["PieLabelStyle"] = "Outside";
                        // Set these other two properties so that you can see the connecting lines
                        this.chart1.Series[0].BorderWidth = 1;
                        this.chart1.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
                        //Set the pie label as well as legend text to be displayed as percentage
                        // The P2 indicates a precision of 2 decimals
                        this.chart1.Series[0].Label = "#VALX";
                        this.chart1.Series[0].LegendText = "#VALX (#PERCENT)";
                        this.chart1.Series["FileInformation"].Points.AddXY(fileName, byteLenght);
                        //CHART FINISH!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        DateTime createDate = fileInfo.CreationTime;
                        ListViewItem item = new ListViewItem(fileName);
                        item.SubItems.Add("File");
                        item.SubItems.Add(byteLenght.ToString());
                        item.SubItems.Add(createDate.ToString("dd.MM.yyyy HH:mm"));
                        listView1.Items.Add(item);
                        listBox1.Items.Add(file);
                    }
                }
                RestartEncapsulate();
                RestartEncapsulate2();
                tp = new InlineTemp();
                tp.inline = this;
                mN = new MagicNumber();
                mN.magic = this;
                hd = new HideMethod();
                hd.mainhide = this;
                logicalLineNum = new LogicalLineNumber();
                logicalLineNum.line = this;
                lineNumber = new LinesOfCode();
                lineNumber.codeLine = this;
                functionNo = new MethodsPerClass();
                functionNo.functionNum = this;
                functionCallNo = new CallsPerMethod();
                functionCallNo.call = this;
                inheritLevel = new DepthOfInheritance();
                inheritLevel.inheritanceCountNumber = this;
                transactionNo = new OperandAndOperator();
                transactionNo.operandOperatorNum = this;
                codeComplexity = new Complexity();
                codeComplexity.complex = this;
                state = new StatementsPerMethod();
                state.stm = this;
                relation = new Coupling();
                relation.cop = this;
                relationJava = new CouplingJava();
                relationJava.couplingJava = this;
                mainIndex = new MaintainabilityIndex();
                mainIndex.mtbIndex = this;
                mainIndexJ = new MaintainabilityIndexForJava();
                mainIndexJ.maintainIndexJ = this;
                draw = new R();
                draw.imge = this;
                rf = new AppliedRefactoringTechniques();
            }
        }
        public void RestartEncapsulate()
        {
            f2 = new EncapsulateField();
            f2.newEncapsulate = this;
        }
        public void RestartEncapsulate2()
        {
            fieldJava = new EncapsulateFieldJava();
            fieldJava.newEncapsulate2 = this;
        }
        private void RefactoringLinkStripMenuItem1_Click(object sender, EventArgs e)
        {
            string url = "https://refactoring.com/";
            gotoSite(url);//open url in default browser
        }
        private void RefactoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemText = (sender as ToolStripMenuItem).Text;
        }
        public void RefToolStripDropDownItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs refName)
        {
             msg = String.Format("Item clicked: {0}", refName.ClickedItem.Text);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            richTextBox2.Clear();
            tableLayoutPanel1.Visible = true;

            if (listBox1.SelectedItem != null)
            {
                string path = listBox1.SelectedItem.ToString();
                         chart1.Visible = false;
                         chart1.Series["FileInformation"].Points.Clear();
                         chart1.Titles.Clear();
                GetCs(path);
                hd = new HideMethod();
                hd.mainhide = this;
                this.menuStrip1.Enabled = true;
                richTextBox1.BackColor = Color.White;
            }
        }
        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(hd.hideSelected==true)
          {
                //Hide Method for Java Code
                richTextBox2.Clear();
                richTextBox2.Text = richTextBox1.Text;
                if (listBox2.SelectedItem != null)
                {
                    string takePattern = listBox2.SelectedItem.ToString();
                    string finder = takePattern.Trim();
                    if (richTextBox1.Text.Contains(finder) && !finder.Contains("private"))
                    {
                        int Start, End;
                        Start = richTextBox1.Text.IndexOf(finder, 0);
                        End = richTextBox1.Text.IndexOf(finder, Start);
                        richTextBox2.Select(Start, finder.Length);
                        richTextBox2.SelectionColor = Color.Red;
                        string modify1 = "public";
                        string modify2 = "private";
                        this.richTextBox2.Text = this.richTextBox2.Text.Remove(Start, modify1.Length);
                        this.richTextBox2.Text = this.richTextBox2.Text.Insert(Start - 1, modify2);
                        richTextBox2.Select(Start - 1, finder.Length + 2);
                        richTextBox2.SelectionColor = Color.Red;
                        MessageBox.Show("The Hide Method is Properly Applied", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hide Method Not Available for this Access Modifier", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (hd.IsDisposed)
                {
                    hd = new HideMethod();
                }
          }
          else if(encapsulateCounter==true)
          {                                      
                SyntaxTree tree = CSharpSyntaxTree.ParseText(content);
                var root = (CompilationUnitSyntax)tree.GetRoot();
                var firstMember = root.Members[0];
                var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
                var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];                                     
                var fieldDetect = root.DescendantNodes().OfType<FieldDeclarationSyntax>();
                foreach (var fields in fieldDetect)
                {
                    if (listBox2.SelectedItem.ToString() == fields.ToString())
                    {
                        var type = fields.Declaration.Type;
                        fieldName = fields.ToString();
                        f2.fieldName = fieldName;
                        typeDec = type.ToString();
                        f2.typeName = typeDec;
                        foreach (var variable in fields.Declaration.Variables)
                        {
                            lengthTxt = variable.ToString().Length;
                        }
                        int index = 0;
                        richTextBox1.Find(fields.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        while (index < richTextBox1.Text.LastIndexOf(fields.ToString()))
                        {
                            richTextBox1.Find(fields.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                            richTextBox1.SelectionBackColor = Color.Yellow;
                            index = richTextBox1.Text.IndexOf(fields.ToString(), index) + 1;
                        }
                        indexField = index;
                        f2.indexField = indexField;
                        identify = fields.Declaration.Variables.First().ToString();
                        f2.varName = identify;
                    }
                }
                if (f2.IsDisposed)
                {
                    f2 = new EncapsulateField();
                }                
          } else if (consolidateCounter == true)
              {
                int counter = 0;
                string richTextBox1Get = richTextBox1.Text;
                string item = listBox2.SelectedItem.ToString();
                indexStart2 = 0;              
                string find = item.Trim();
                var matchString = Regex.Escape(find);
                int indexStart3;
                int indexFinish3;
                int indexStartCon;
                int indexFinishCon;
                if (this.richTextBox1.Text.Contains(find))
                {
                    int i = 0;
                    foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
                    {
                        MatchCollection matchOnCodition = Regex.Matches(richTextBox1.Text, patternElseTryCatch);
                        if (matchOnCodition != null && matchOnCodition.Count > 0)
                        {
                            foreach (Match matchCond in matchOnCodition)
                            {
                                richTextBox1.Select(matchCond.Index, match.Length);
                                indexStartCon = matchCond.Index;
                                indexFinishCon = indexStartCon + matchCond.Length;
                                if (match.Index > indexStartCon && match.Index < indexFinishCon)
                                {
                                    indexStart2 = 0;
                                    indexFinish2 = 0;
                                    richTextBox1.Select(match.Index, find.Length);
                                    indexStart2 = match.Index - (i * match.Length);
                                    indexFirst.Add(indexStart2);
                                    indexFinish2 = indexStart2 + match.Length;
                                    indexLast.Add(indexFinish2);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox2.Text = richTextBox1.Text.Remove(indexStart2, match.Length);
                                    richTextBox1.Text = richTextBox2.Text;
                                    i++;      
                                }
                            }
                        }

                    };
                    richTextBox2.Text = richTextBox1.Text;
                    string pattern2 = @"if.([^{}]+)\{[^{}]+\}\s*(?:else([^{}]+)\{[^{}]+\})";
                    MatchCollection matchess = Regex.Matches(richTextBox1Get, patternElseTryCatch);
                    if (matchess != null && matchess.Count > 0)
                    {
                        foreach (Match match in matchess)
                        {
                            richTextBox1.Select(match.Index, match.Length);
                            indexStart = match.Index;
                            indexFinish = indexStart + match.Length;
                            if (indexLast[0] < indexFinish && indexStart < indexFirst[0]) //kontrol edilecek
                            {
                                loopStartIndex = indexStart;
                                loopFinishIndex = indexFinish;
                                int toplam = find.Length + loopStartIndex;
                                richTextBox2.Text = richTextBox2.Text.Insert(loopFinishIndex - toplam - find.Length + loopStartIndex, find); //+ loopStartIndex
                                int index = 0;
                                richTextBox2.Select(loopStartIndex, loopFinishIndex - toplam);
                                richTextBox2.SelectionBackColor = Color.LightYellow;
                                richTextBox2.Find(find.ToString(), index, richTextBox2.TextLength, RichTextBoxFinds.None);
                                richTextBox1.Text = richTextBox1Get;
                                richTextBox1.Select(loopStartIndex, loopFinishIndex - toplam);
                                richTextBox1.SelectionBackColor = Color.LightYellow;
                                while (index < richTextBox1.Text.LastIndexOf(find.ToString()))
                                {
                                    richTextBox1.Find(find.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);

                                    richTextBox1.SelectionBackColor = Color.Red;
                                    index = richTextBox1.Text.IndexOf(find.ToString(), index) + 1;
                                }
                                counter++;
                            }

                        }
                    }

                }

            }
            
        }
        public void GetCs(string yl)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            richTextBox1.Text = "";
            openFile.Filter = "code files (.cs)| *.cs";
            var content = String.Empty;
            FileStream fileStream = new FileStream(
                                yl, FileMode.OpenOrCreate,
                                   FileAccess.ReadWrite, FileShare.None);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            while (line != null)
            {
                line = streamReader.ReadLine();
                if (line != null)
                {
                    richTextBox1.Text += line.ToString()+ "\n";
                }
            }
            textDoc= this.richTextBox1.Text;
            SyntaxTree tree = CSharpSyntaxTree.ParseText(richTextBox1.Text);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            //FIND ROOT TREE 
            var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var fields = tree.GetRoot().DescendantNodes().OfType<FieldDeclarationSyntax>();
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }
        public void SendData(string text)
        {
            richTextBox2.Text = text;
        }
        //ENCAPSULATE FIELD
        //**************************************************************************************************************************************************************
        public void EncapsulateFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            encapsulateCounter = true;
            string pathForEncapsul = listBox1.SelectedItem.ToString();
            if (f2.IsDisposed)
            {
                f2 = new EncapsulateField();
            }
            f2.filePath = pathForEncapsul;
            fieldJava.filePath= pathForEncapsul;
            FileStream file = new FileStream(
                               pathForEncapsul, FileMode.OpenOrCreate,
                                  FileAccess.ReadWrite, FileShare.None);
            content = String.Empty;
            using (StreamReader str = new StreamReader(file, Encoding.UTF8))
            {
                content = str.ReadToEnd();
            }
            string filename = Path.GetFileName(pathForEncapsul);
            string[] arr = filename.Split('.');
            string result = arr[1];
            if (result == "Cs" || result == "CS" || result == "cs")
            {                
                SyntaxTree tree = CSharpSyntaxTree.ParseText(content);
                var root = (CompilationUnitSyntax)tree.GetRoot();
                var firstMember = root.Members[0];
                var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
                var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
                var fieldEmpty= root.DescendantNodes().OfType<FieldDeclarationSyntax>().FirstOrDefault();
                if (fieldEmpty == null)
                {
                    MessageBox.Show("Searched field not found!!! Open new code...",
                      "WARNING",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation,
                      MessageBoxDefaultButton.Button1);
                }
                else
                {
                    var fieldDetect = root.DescendantNodes().OfType<FieldDeclarationSyntax>();
                    foreach (var fields in fieldDetect)
                    {
                        listBox2.Items.Add(fields.ToString());                       
                    }
                    var field = root.DescendantNodes().OfType<FieldDeclarationSyntax>().First();
                    var type = field.Declaration.Type;
                    fieldName = field.ToString();
                    f2.fieldName = fieldName;
                    typeDec = type.ToString();
                    f2.typeName = typeDec;
                    foreach (var variable in field.Declaration.Variables)
                    {
                        lengthTxt = variable.ToString().Length;
                    }
                    int index = 0;
                    richTextBox1.Find(field.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    while (index < richTextBox1.Text.LastIndexOf(field.ToString()))
                    {
                        richTextBox1.Find(field.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        index = richTextBox1.Text.IndexOf(field.ToString(), index) + 1;
                    }
                    indexField = index;
                    f2.indexField = indexField;
                    identify = field.Declaration.Variables.First().ToString();
                    f2.varName = identify;
                    f2.Show();
                    ///Fınd Class Declaration                 
                }
            }
            else if (result == "Java" || result == "JAVA" || result == "java")
            {
                if (fieldJava.IsDisposed)
                {
                    fieldJava = new EncapsulateFieldJava();
                }
                fieldJava.Show();
            }
            else
            {
                MessageBox.Show("Programming Language Not Suitable for Refactoring Technique!");
            }
        }
        int start2 = 0;
        int indexOfSearchText2 = 0;
        public void searchJava(string find)
        {
            listBox2.Items.Clear();
            if (richTextBox1.Text.Contains(find))
            {
                string[] parcala = richTextBox1.Text.Split(';');
                int n = -1;
                counterJavaEF = 0;
                foreach (string item in parcala)
                {
                    listBox2.Items.Add(item);
                    if (item.ToString().Contains(find))
                    {
                        counterJavaEF++;
                    }
                }
                if (counterJavaEF != 0)
                {
                    MessageBox.Show(" The Defined Field Was Found.", "Encapsulate Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Enter the FULL Definition of the Field to Encapsulate...",
                     "WARNING",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Definition of the Field to Encapsulate...",
                      "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
            }
        }
        public void ApplyEncapsulField(string k1, string k2, string accessk3, string pName, string pathEF, int indexF, string fName, string typeName)
        {
            string filenameJava = Path.GetFileName(pathEF);
            string[] arrJava = filenameJava.Split('.');
            string resultJava = arrJava[1];
            if (resultJava == "Java" || resultJava == "java" || resultJava == "JAVA")
            {
                identify = fieldJava.encapsulate2VariableName;
            }
            if (accessk3 == "private")
            {
                if ((k2 == true.ToString()) && (k1 == true.ToString()))
                {
                    GetCs(pathEF);
                    Settings1.Default.passingData = this.richTextBox1.Text;
                    this.richTextBox2.Text = Settings1.Default.passingData;

                    // Finding fields called Property with Regex
                    string pattern = String.Format(@"\b(\w*{0})\b", identify);
                    MatchCollection matches = Regex.Matches(richTextBox2.Text, pattern);
                    int counter = 1;
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match matchh in matches)
                        {
                            if (counter != 1)
                            {
                                richTextBox2.Select(matchh.Index, matchh.Length);
                                indexStart = matchh.Index;
                                indexFinish = indexStart + matchh.Length;
                                //delete variables other than field in richtextbox
                                this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);
                                this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexStart, pName.Trim());
                            }
                            counter++;
                        }

                    }
                    string encapsulate = @"private " + typeName + " " + identify + ";\n public " + typeName + " " + pName + @"{
                                      get{
                                            return " + identify + @";
                                          }
                                          set{
                                             " + identify + @"= value; }
                                          } ";

                    this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexF - 1, fName.Length);//deletes field from richtextbox
                    this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexF - 1, encapsulate);//new field is added from richtextbox
                    richTextBox2.Select(indexF - 1, encapsulate.Length - fName.Length);
                    richTextBox2.SelectionColor = Color.Green;
                    richTextBox1.Select(indexF - 1, fName.Length);
                    richTextBox1.SelectionColor = Color.Green;
                    if (this.richTextBox2.Text.Contains(pName))
                    {
                        string find = pName;
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(richTextBox2.Text, matchString))
                        {
                            richTextBox2.Select(match.Index, find.Length);
                            richTextBox2.SelectionColor = Color.Green;
                            richTextBox2.Select(richTextBox1.TextLength, 0);
                            richTextBox2.SelectionColor = richTextBox2.ForeColor;
                        };
                    }
                }

                if ((k2 != true.ToString()) && (k1 == true.ToString()))
                {
                    GetCs(pathEF);
                    Settings1.Default.passingData = this.richTextBox1.Text;
                    this.richTextBox2.Text = Settings1.Default.passingData;
                    // Finding fields called Property with Regex
                    string desen = String.Format(@"\b(\w*{0})\b", identify);
                    MatchCollection matches = Regex.Matches(richTextBox2.Text, desen);
                    if (matches != null && matches.Count > 0)
                    {
                        int counter = 1;
                        foreach (Match matchh in matches)
                        {
                            if (counter != 1)
                            {
                                richTextBox2.Select(matchh.Index, matchh.Length);
                                indexStart = matchh.Index;
                                indexFinish = indexStart + matchh.Length;
                                //delete variables other than field in richtextbox
                                this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);
                                this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexStart, pName.Trim());
                            }
                            counter++;
                        }

                    }
                    string encapsulate = @"private " + typeName + " " + identify + ";\n public " + typeName + " " + pName + @"{
                                        get
                                       {
                                         return " + identify + @";
                                          }
                                          } ";

                    this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexF - 1, fName.Length);
                    this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexF - 1, encapsulate);
                    richTextBox2.Select(indexF - 1, encapsulate.Length - fName.Length);
                    richTextBox2.SelectionColor = Color.Green;
                    richTextBox1.Select(indexF - 1, fName.Length);
                    richTextBox1.SelectionColor = Color.Green;
                    if (this.richTextBox2.Text.Contains(pName))
                    {
                        string find = pName;
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(richTextBox2.Text, matchString))
                        {
                            richTextBox2.Select(match.Index, find.Length);
                            richTextBox2.SelectionColor = Color.Green;
                            richTextBox2.Select(richTextBox1.TextLength, 0);
                            richTextBox2.SelectionColor = richTextBox2.ForeColor;
                        };
                    }
                    string metin = richTextBox1.Text;
                    richTextBox1.Text = "";
                    richTextBox1.Text = metin;
                    File.WriteAllText(pathEF, richTextBox2.Text.Trim());// write to file from richtextbox
                }
                if ((k2 == true.ToString()) && (k1 != true.ToString()))
                {
                    GetCs(pathEF);
                    Settings1.Default.passingData = this.richTextBox1.Text;
                    this.richTextBox2.Text = Settings1.Default.passingData;
                    string desen = String.Format(@"\b(\w*{0})\b", identify);
                    MatchCollection matches = Regex.Matches(richTextBox2.Text, desen);
                    if (matches != null && matches.Count > 0)
                    {
                        int counter = 1;
                        foreach (Match matchh in matches)
                        {
                            if (counter != 1)
                            {
                                richTextBox2.Select(matchh.Index, matchh.Length);
                                indexStart = matchh.Index;
                                indexFinish = indexStart + matchh.Length;
                                this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);//richtextboxdan field haricindeki variable değişkenlerini silme komudu
                                this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexStart, pName.Trim());
                            }
                            counter++;
                        }

                    }
                    string encapsulate = @"private " + typeName + " " + identify + ";\n public " + typeName + " " + pName + @"{                                   
                                         set
                                          {
                                             " + identify + @"= value;
                                           }
                                          } ";

                    this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexF - 1, fName.Length);
                    this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexF - 1, encapsulate);
                    richTextBox2.Select(indexF - 1, encapsulate.Length - fName.Length);
                    richTextBox2.SelectionColor = Color.Green;
                    richTextBox1.Select(indexF - 1, fName.Length);
                    richTextBox1.SelectionColor = Color.Green;
                    if (this.richTextBox2.Text.Contains(pName))
                    {
                        string find = pName;
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(richTextBox2.Text, matchString))
                        {
                            richTextBox2.Select(match.Index, find.Length);
                            richTextBox2.SelectionColor = Color.Green;
                            richTextBox2.Select(richTextBox1.TextLength, 0);
                            richTextBox2.SelectionColor = richTextBox2.ForeColor;
                        };

                    }
                }
                if ((k2 != true.ToString()) && (k1 != true.ToString()))
                {
                    GetCs(pathEF);

                    Settings1.Default.passingData = this.richTextBox1.Text;
                    this.richTextBox2.Text = Settings1.Default.passingData;

                    string encapsulate = @"private " + typeName + " " + identify + ";\n";

                    this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexF - 1, fName.Length);
                    this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexF - 1, encapsulate);
                    richTextBox2.Select(indexF - 1, encapsulate.Length - fName.Length);
                    richTextBox2.SelectionColor = Color.Green;
                    richTextBox1.Select(indexF - 1, fName.Length);
                    richTextBox1.SelectionColor = Color.Green;
                    if (this.richTextBox2.Text.Contains(pName))
                    {
                        string find = pName;
                        var matchString = Regex.Escape(find);
                        foreach (Match match in Regex.Matches(richTextBox2.Text, matchString))
                        {
                            richTextBox2.Select(match.Index, find.Length);
                            richTextBox2.SelectionColor = Color.Green;
                            richTextBox2.Select(richTextBox1.TextLength, 0);
                            richTextBox2.SelectionColor = richTextBox2.ForeColor;
                        };
                    }
                }
                strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                strLog += "R1: Encapsulate Field refactoring technique is applied" + "\n";
                strLog += "-------------------------------------------------------------------------" + "\n";
                WriteLog(strLog);
            }
            encapsulateCounter = false;
        }        
        public override string ToString()
        {
            string retString = String.Empty;

            var bindingFlags = System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public;
            List<object> listValues = this.GetType().GetFields(bindingFlags).Select(field => field.GetValue(this)).Where(value => value != null).ToList();

            foreach (var item in listValues)
            {
                retString += item.GetType().Name + ": " + item.ToString() + ";";
            }
            return retString;
        }
        public void ParsePublic(string passingCode, int index)
        {
            listBox1.Items.Add(passingCode);

            string[] parsing = passingCode.Split(' ');

            foreach (string item in parsing)
            {
                listBox1.Items.Add(item);
            }
        }
        public void parseProtected(string passingCode, int index)
        {
            MessageBox.Show(index.ToString());
        }

        // SAVING REFACTORED CODE 
        //***************************************************************************************************************************************************
        internal System.Windows.Forms.TextBox refactoredCode;
        public string refCodeSave()
        {
            Form form = new Form();
            int top = 200;
            int left = 150;
            form.Text = "Saving File Name";

            Label l1 = new Label();
            l1.Left = 50;
            l1.Top = 50;
            l1.Text = "File Name: ";
            form.Controls.Add(l1);

            refactoredCode = new TextBox();
            refactoredCode.Location = new Point(150, 50);
            refactoredCode.Size = new Size(100, 15);
            refactoredCode.Text = "nameee";
            form.Controls.Add(refactoredCode);

            Button btn = new Button();
            btn.Left = left;
            btn.Top = top;
            btn.Text = "Save";
            form.Controls.Add(btn);
  
            btn.Click += new EventHandler(Ref_Click);
            form.ShowDialog(); // show form with added controls
            item = refactoredCode.Text;                 
            return item;         
        }
        private void Ref_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(" File Name Saved.", "STORAGE DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveOriginalAndRefactored_Click(object sender, EventArgs e)
        {
            string refTechName=" ";
            try
            {              
                string path = listBox1.SelectedItem.ToString();
                string filename = Path.GetFileName(path);
                string[] arr = filename.Split('.');
                string result = arr[0];
                string result2 = arr[1];
                if (result2.Contains("Designer"))
                {
                    MessageBox.Show("Please  Select a different class!!!", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {                 
                    File.WriteAllLines(path, this.richTextBox2.Lines);
                    MessageBox.Show("Refactoring Has Been SAVED.", "SAVE PROCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }      
        // SIMPLIFY NESTED LOOP 
        //***********************************************************************************************************************************************************************************************************
        public void SimpNestedLoopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string textData = richTextBox1.Text;
            //pattern for loop
            string pattern = @"for(\s*)\(\w*\s*\w*\s*\=\s*\w*\s*\;\w*\s*\w*\s*(\<|\>|\>\=|\<\=|\=\=)\s*\w*\s*\;\s*\w*\s*(\+\+|\-\-\s*|\+\=\s*\w*|\-\=\s*\w*|\=\s*\w*)\s*\)\s*.\s*.+.\s*.\s*.+({\s*[a-z A-Z 0-9]*=\s[a-z A-Z 0-9]*\W*[a-z A-Z 0-9]*[a-z A-Z 0-9]*;\s*}\s*})";
            MatchCollection matches = Regex.Matches(textData, pattern);
            MessageBox.Show("Number of code blocks found : " + matches.Count.ToString(), "Simplify Nested Loop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (matches != null && matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    richTextBox1.Select(match.Index, match.Length);
                    indexStart = match.Index;
                    indexFinish = indexStart + match.Length;
                    richTextBox1.SelectionColor = Color.Green;
                    nestedLoop = richTextBox1.Text.Substring(indexStart, match.Length);
                    TrimString = nestedLoop.Trim().Replace(" ", string.Empty);
                    listBox2.Items.Add(TrimString);
                }
                SimplifyNestedLoop s1 = new SimplifyNestedLoop();
                s1.m1 = this;
                string getLoopString = s1.Split();
                if (!String.IsNullOrEmpty(getLoopString))
                {
                    string[] words = getLoopString.Split(',');
                    foreach (var word in words)
                    {
                        if (words.First() == word)
                            statementName = word;
                        else if (words.Last() == word)
                            conditionValue = word;
                        else if (words.First() != word || words.First() != word)
                        {
                            initTypeName = word;
                        }
                    }
                }
                string nestedLoopNew = @" for (" + initTypeName + " k = 0; k<=" + conditionValue + @"; k++)
                {
                     " + statementName + @"= k;
                }";
                MessageBox.Show(nestedLoopNew);
                richTextBox2.Text = richTextBox1.Text;
                this.richTextBox2.Text = this.richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);
                this.richTextBox2.Text = this.richTextBox2.Text.Insert(indexStart, nestedLoopNew);
                richTextBox2.Select(indexStart, nestedLoopNew.Length);

                richTextBox2.SelectionColor = Color.Green;
                strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                strLog += "R2: Simplify Nested Loop refactoring technique is applied" + "\n";
                strLog += "-------------------------------------------------------------------------" + "\n";
                WriteLog(strLog);
            }
            else
            {
                MessageBox.Show("Simplify Nested Loop can not be applied in the selected Code Blog!!!!! ", "WARNING",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation,
                  MessageBoxDefaultButton.Button1); 
            }
          
        }
        //Intel Power Gadget Tool 
        //****************************************************************************************************************************************************************
        public void EnergyEstimateToolOpen_Click(object sender, EventArgs e)
        {
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                // You can start any process
                myProcess.StartInfo.FileName = @"C:\Program Files\Intel\Power Gadget 3.5\IntelPowerGadget.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                // This code assumes the process you are starting will terminate itself.
                // Given that is is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        private void EnergyEstimateCloseMenuItem_Click(object sender, EventArgs e)
        {
            myProcess.Kill();
        }

        //INLINE TEMP 
        //********************************************************************************************************************************
        private void InlineTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contentData = richTextBox1.Text;
            string path = listBox1.SelectedItem.ToString();

            tp.filePath = path;
            int lastIndex = path.LastIndexOf('.');
            var name = path.Substring(0, lastIndex);
            ext = path.Substring(lastIndex + 1);

            if (ext=="cs"|| ext == "Cs" || ext == "CS")
            {
                FileStream file = new FileStream(
                                   path, FileMode.OpenOrCreate,
                                      FileAccess.ReadWrite, FileShare.None);
                var content = String.Empty;
                using (StreamReader str = new StreamReader(file, Encoding.UTF8))
                {
                    content = str.ReadToEnd();
                }
                SyntaxTree tree = CSharpSyntaxTree.ParseText(content);
                var root = (CompilationUnitSyntax)tree.GetRoot();
                var firstMember = root.Members[0];
                var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
                var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
                var fieldEmpty = root.DescendantNodes().OfType<FieldDeclarationSyntax>().FirstOrDefault();
                if (fieldEmpty == null)
                {
                    MessageBox.Show("Searched Temp not found!!! Please, Try new code...",
                      "WARNING",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation,
                      MessageBoxDefaultButton.Button1);
                }
                else
                {
                    var field = root.DescendantNodes().OfType<FieldDeclarationSyntax>().First();
                    var type = field.Declaration.Type;
                    fieldName = field.ToString();
                    f2.fieldName = fieldName;
                    typeDec = type.ToString();
                    f2.typeName = typeDec;
                    int index = 0;
                    richTextBox1.Find(field.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    while (index < richTextBox1.Text.LastIndexOf(field.ToString()))
                    {
                        richTextBox1.Find(field.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        index = richTextBox1.Text.IndexOf(field.ToString(), index) + 1;
                    }
                    indexField = index;
                    tp.inlineIndex = indexField;
                    identify = field.Declaration.Variables.First().ToString();
                    tp.variableName = identify;
                    if (tp.IsDisposed) //Closes and Reopens the Inline Form
                        tp = new InlineTemp();
                    tp.Show();
                }
            }
            if (ext == "java" || ext == "Java" || ext == "JAVA")
            {
                if (tp.IsDisposed) //Closes and Reopens the Inline Form 
                    tp = new InlineTemp();
                tp.Show();
            }
        }
        int start = 0;
        int indexOfSearchText = 0;
        public void inlineSplit(string findText, string textName)
        {
            listBox2.Items.Clear();
            if(richTextBox1.Text.Contains(findText))
            {
                string[] parsing = richTextBox1.Text.Split(';');
                int n = -1;
                foreach (string item in parsing)
                {
                    listBox2.Items.Add(item);
                    if (item.ToString().Contains(findText))
                    {
                        int startIndex = item.ToString().IndexOf(findText);
                        string x = item.ToString();
                        foreach (string y in x.Split(' '))
                        {
                            richTextBox2.Text += y + " ";
                        }
                        if (richTextBox2.Text.Length > 0)
                        {
                            int index = richTextBox2.Text.LastIndexOf(" ");
                            //MessageBox.Show(index.ToString());
                            int startindex = 0;
                            startindex = FindMyText(findText.Trim(), start, richTextBox2.Text.Length);
                            // If string was found in the RichTextBox, highlight it
                            if (startindex >= 0)
                            {
                                // Set the highlight color as red
                                richTextBox2.SelectionColor = Color.Red;
                                // Find the end index. End Index = number of characters in textbox
                                int endindex = index;
                                // Highlight the search string
                                richTextBox2.Select(startindex, endindex);
                                searchedLine = richTextBox2.Text.Substring(startindex, index - startIndex);
                                if (searchedLine != null)
                                {
                                    int indexEqual = searchedLine.IndexOf('=');
                                    if (indexEqual > 0)
                                    {
                                        int lenght = searchedLine.Length;
                                        lastText = searchedLine.Substring(indexEqual + 1, lenght - (indexEqual + 1));
                                        downCode = searchedLine + ";";
                                        upCode = lastText.Trim();
                                        richTextBox2.Text = downCode;
                                        if (!string.IsNullOrEmpty(downCode))
                                        {
                                            if (richTextBox1.Text.Contains(downCode))
                                            {
                                                richTextBox1.SelectionBackColor = Color.DimGray;
                                                string find = downCode;
                                                var matchString = Regex.Escape(find);
                                                foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
                                                {
                                                    richTextBox1.Select(match.Index, find.Length);
                                                    richTextBox1.SelectionBackColor = Color.LightYellow;
                                                    richTextBox1.Select(richTextBox1.TextLength, 0);
                                                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
                                                    richTextBox2.Clear();
                                                    this.richTextBox2.Text = this.richTextBox1.Text.Remove(match.Index, find.Length);
                                                }
                                                var matchDeger = Regex.Escape(textName);
                                                foreach (Match match in Regex.Matches(richTextBox1.Text, matchDeger))
                                                {
                                                    richTextBox1.BackColor = Color.Aqua;
                                                    richTextBox1.Select(match.Index, textName.Length);
                                                    richTextBox1.SelectionBackColor = Color.Red;
                                                    richTextBox1.Select(richTextBox1.TextLength, 0);
                                                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
                                                }
                                                var matchNewValue = Regex.Escape(textName);
                                                foreach (Match match in Regex.Matches(richTextBox2.Text, matchNewValue))
                                                {
                                                    richTextBox2.Select(match.Index, textName.Length);
                                                    this.richTextBox2.Text = this.richTextBox2.Text.Remove(match.Index, textName.Length);
                                                    this.richTextBox2.Text = this.richTextBox2.Text.Insert(match.Index, upCode );
                                                    richTextBox2.Select(match.Index, upCode.Length);
                                                    richTextBox2.SelectionBackColor = Color.LightGreen;
                                                    richTextBox2.Select(richTextBox2.TextLength, 0);
                                                    richTextBox2.SelectionColor = richTextBox2.ForeColor;
                                                }
                                            }
                                        }
                                    }
                                    // mark the start position after the position of
                                    // last search string
                                    start = startindex + endindex;
                                }

                            }

                        }

                    }

                }
                MessageBox.Show("Inline Temp Has Applied", "Inline Temp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                strLog += "R3: Inline Temp refactoring technique is applied" + "\n";
                strLog += "-------------------------------------------------------------------------" + "\n";
                WriteLog(strLog);
            }
            else
            {
                MessageBox.Show("Inline Temp Not Found. Try Again..", "Inline Temp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
        {
            // Unselect the previously searched string
            if (searchStart > 0 && searchEnd > 0 && indexOfSearchText >= 0)
            {
                richTextBox2.Undo();
            }
            // Set the return value to -1 by default.
            int retVal = -1;
            // A valid starting index should be specified.
            // if indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && indexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = richTextBox2.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                    // Determine whether the text was found in richTextBox1.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }
                }
            }
            return retVal;
        }
        public void reset()
        {
            if (listBox2 != null)
            {
                listBox2.Items.Clear();
            }
        }

        //REPLACE MAGIC NUMBER WITH SYMBOLİC CONSTANT 
        //**********************************************************************************************************************************************
        public void replaceMagicNumberItem_Click(object sender, EventArgs e)
        {
            if (mN.IsDisposed) // Close and Reopen the Magic Number Form         
                mN = new MagicNumber();
            mN.magic = this;
            mN.Show();
        }
        public void FindMagicNumber(string magicFind)
        {
            findingMagicNumber = magicFind;
            int yer = 0;
            int indexOfSearch;
            indexOfSearch = richTextBox1.Find(findingMagicNumber, yer, richTextBox1.TextLength, RichTextBoxFinds.None);
            // Returns -1 if the searched number is not found.
            if (indexOfSearch != -1)
            {
                richTextBox1.SelectionBackColor = Color.Yellow;
                MessageBox.Show(" Magic Number Found ", "Replace Magic Number with Symbolic Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (mN.IsDisposed) // Close and Reopen the Magic Number Form  
                    mN = new MagicNumber();
                   mN.magic = this;
                  mN.temizle();
                MessageBox.Show(" Magic Number Not Found ", "Replace Magic Number with Symbolic Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void MagicRefApply(string newMagicNumber)
        {
            int counter = 0;
            string path = listBox1.SelectedItem.ToString();
            int lastIndex = path.LastIndexOf('.');
            var name = path.Substring(0, lastIndex);
            ext = path.Substring(lastIndex + 1);
            if (ext == "cs" || ext == "CS" || ext == "Cs")
            {
                FileStream file = new FileStream(
                              path, FileMode.OpenOrCreate,
                                 FileAccess.ReadWrite, FileShare.None);
                var content = String.Empty;
                using (StreamReader str = new StreamReader(file, Encoding.UTF8))
                {
                    content = str.ReadToEnd();
                }

                SyntaxTree tree = CSharpSyntaxTree.ParseText(content);
                var root = (CompilationUnitSyntax)tree.GetRoot();
                var firstMember = root.Members[0];
                var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
                var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
                var field = root.DescendantNodes().OfType<FieldDeclarationSyntax>().First();
                var type = field.Declaration.Type;
                var firstClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
                var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                // getting all classes and methods
                foreach (var cl in myClass)
                {
                    if (cl.ToString().Contains(findingMagicNumber))
                    {
                        field = cl.DescendantNodes().OfType<FieldDeclarationSyntax>().First();
                        MessageBox.Show("field : " + field.ToString());
                        fieldName = field.ToString();
                        f2.fieldName = fieldName;// first field declaration name
                        MessageBox.Show("type : " + type.ToString());
                        typeDec = type.ToString();
                        f2.typeName = typeDec;
                        foreach (var variable in field.Declaration.Variables)
                        {
                            MessageBox.Show("variable : " + variable.ToString());

                        }
                        int index = 0;
                        richTextBox1.Find(field.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        string code = richTextBox1.Text;
                        richTextBox1.Text = "";
                        richTextBox1.Text = code;
                        string ara = findingMagicNumber;
                        string newName = mN.magicNumberName;
                        int result1;
                        result1 = code.LastIndexOf(ara, code.Length - 1, code.Length);
                        MessageBox.Show("Searched term starts from index " + result1.ToString());
                        richTextBox2.Text = richTextBox1.Text.Remove(result1, findingMagicNumber.Length);//richtextboxdan field alanını siler
                        richTextBox2.Text = richTextBox2.Text.Insert(result1, newName);
                        richTextBox1.Find(ara.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;

                        while (index < richTextBox2.Text.LastIndexOf(field.ToString()))
                        {
                            richTextBox2.Find(field.ToString(), index, richTextBox2.TextLength, RichTextBoxFinds.None);

                            richTextBox2.SelectionBackColor = Color.Yellow;
                            index = richTextBox2.Text.IndexOf(field.ToString(), index) + 1;
                        }
                        richTextBox2.Text = richTextBox2.Text.Insert(index - 1, newMagicNumber);
                        while (index < richTextBox2.Text.LastIndexOf(newName.ToString()))
                        {
                            richTextBox2.Find(newName.ToString(), index, richTextBox2.TextLength, RichTextBoxFinds.None);
                            richTextBox2.SelectionBackColor = Color.Yellow;
                            index = richTextBox2.Text.IndexOf(newName.ToString(), index) + 1;
                        }
                        counter++;
                        strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                        strLog += "R5: Replace Magic Number with Symbolic Constant refactoring technique is applied" + "\n";
                        strLog += "-------------------------------------------------------------------------" + "\n";
                        WriteLog(strLog);
                    }
                }
            }
            else if (ext == "java" || ext == "Java" || ext == "JAVA")
            {
                try
                {                    
                    string intro = richTextBox1.Text;
                    string aranan = "return";
                    string pattern = @"((public|private|protected|static|final|native|synchronized|abstract|transient)+\s)+[\$_\w]+\([^\)]*\)?\s*";
                    MatchCollection matches = Regex.Matches(intro, pattern);
                    if (matches.Count != 0)
                    {
                        if (matches != null && matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                int index = 0;
                                string metin = richTextBox1.Text;
                                richTextBox1.Text = "";
                                richTextBox1.Text = metin;
                                string search = findingMagicNumber;//magic number is searched in code 
                                string newName = mN.magicNumberName;
                                int result;
                                result = metin.LastIndexOf(search, metin.Length - 1, metin.Length);
                                MessageBox.Show("Searched term starts from index " + result.ToString());
                                richTextBox2.Text = richTextBox1.Text.Remove(result, findingMagicNumber.Length);//the number is removed from the old field
                                richTextBox2.Text = richTextBox2.Text.Insert(result, newName);// new variable name is added
                                richTextBox1.Find(search.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                                richTextBox1.SelectionBackColor = Color.Yellow;
                                //Finding the constructor function
                                richTextBox2.Select(match.Index, match.Length);
                                indexStart = match.Index;
                                indexFinish = indexStart + match.Length;
                                indexList.Add(indexStart);
                                indexList.Add(indexFinish);
                                // The new code snippet is added above the constructor function.
                                richTextBox2.SelectionColor = Color.Magenta;                             
                                richTextBox2.Text = richTextBox2.Text.Insert(indexStart - 1, newMagicNumber);
                                while (indexStart < richTextBox2.Text.LastIndexOf(newName.ToString()))
                                {
                                    richTextBox2.Find(newName.ToString(), indexStart, richTextBox2.TextLength, RichTextBoxFinds.None);
                                    richTextBox2.SelectionBackColor = Color.Yellow;
                                    indexStart = richTextBox2.Text.IndexOf(newName.ToString(), indexStart) + 1;
                                }
                                counter++;
                                strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                                strLog += "R5: Replace Magic Number with Symbolic Constant refactoring technique is applied" + "\n";
                                strLog += "-------------------------------------------------------------------------" + "\n";
                                WriteLog(strLog);
                            }
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           else if (counter !=0)
            {
                MessageBox.Show(" Appropriate code not found for Refactoring Technique ", "Replace Magic Number with Symbolic Constant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }         
        }
        static void gotoSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        //INTRODUCE EXPLAINING VARIABLE 
        //**********************************************************************************************************************************************
        private void introduceExVartem_Click(object sender, EventArgs e)
        {
            // Now after refactoring it’s clear and simple. Introduce explaining variable refactoring simplifies, clarifies, reduce comments need and reduce debugging time.
            try
            {                
                IntroduceExplainingVariable yeni = new IntroduceExplainingVariable();
                string intro = richTextBox1.Text;
                string aranan = "return";
                int deneme = 0;
                int sayac = 0;
                string pattern = @"return";
                MatchCollection matches = Regex.Matches(intro, pattern);
                if (matches.Count != 0)
                {                   
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            deneme = match.Index;
                            ret = yeni.TextLoopDivide(intro, aranan, deneme);

                            if (!String.IsNullOrEmpty(ret))
                            {
                                if (ret.Contains("*") || ret.Contains("-") || ret.Contains("+") || ret.Contains("/") || ret.Contains("%")) //OPERATOR KONTROLÜ YAPILIYOR
                                {
                                    sayac++;                                   
                                    string findVariable = ret;
                                    var matchString = Regex.Escape(findVariable);
                                    if (this.richTextBox1.Text.Contains(ret))
                                    {
                                        foreach (Match match1 in Regex.Matches(richTextBox1.Text, matchString))
                                        {
                                            indexStart = 0;
                                            indexFinish = 0;
                                            richTextBox1.Select(match1.Index, findVariable.Length);
                                            indexStart = match1.Index;
                                            indexFinish = indexStart + match1.Length;
                                            richTextBox1.SelectionColor = Color.Magenta;
                                            indexDifference = indexFinish - indexStart;
                                        };
                                    }

                                }

                            }
                        }                   
                        if (sayac == 0)
                        {
                            MessageBox.Show(" Appropriate code not found for Refactoring Technique ", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(" Code Block is found for Refactoring Technique", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string passingCode = formCreate();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(" Appropriate code not found", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        internal System.Windows.Forms.ComboBox m_input;
        internal System.Windows.Forms.TextBox txt;
        internal System.Windows.Forms.TextBox txt2;
        Form frm = new Form();
        public string formCreate()
        {
            
            if (frm.IsDisposed)// Close the Form and Open it Again
                frm = new Form();

            int top = 200;
            int left = 150;
            frm.Text = "Introduce explaining variable";

            Label l1 = new Label();
            l1.Left = 50;
            l1.Top = 50;
            l1.Text = "Name of Variable: ";
            frm.Controls.Add(l1);

            Label l2 = new Label();
            l2.Left = 50;
            l2.Top = 75;
            l2.Text = "Type of Variable: ";
            frm.Controls.Add(l2);

            Label l3 = new Label();
            l3.Left = 50;
            l3.Top = 100;
            l3.Text = "Find Changing Variable: ";
            frm.Controls.Add(l3);

            txt = new TextBox();
            txt.Location = new Point(150, 50);
            txt.Size = new Size(100, 15);
            txt.Text = "newName";
            frm.Controls.Add(txt);

            m_input = new ComboBox();
            m_input.Location = new Point(150, 75);
            m_input.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            m_input.Size = new Size(100, 15);
            m_input.Items.Add("int");
            m_input.Items.Add("double");
            m_input.Items.Add("char");
            m_input.Items.Add("string");
            m_input.Items.Add("long");
            m_input.Items.Add("float");
            m_input.Items.Add("bool");
            m_input.Items.Add("short");
            m_input.Items.Add("const int");
            m_input.Items.Add("const string");
            m_input.Items.Add("const double");
            m_input.Items.Add("const short");
            m_input.Items.Add("const byte");
            m_input.Items.Add("const float");
            m_input.DropDownStyle = ComboBoxStyle.DropDownList;

            txt2 = new TextBox();
            txt2.Location = new Point(150, 100);
            txt2.Size = new Size(100, 15);
            txt2.Text = "find";
            frm.Controls.Add(txt2);

            frm.Controls.Add(m_input);
            Button btn = new Button();
            btn.Left = left;
            btn.Top = top;
            btn.Text = "Apply";
            frm.Controls.Add(btn);
            m_input.SelectedIndexChanged +=
             new System.EventHandler(ComboBox1_SelectedIndexChanged);

            btn.Click += new EventHandler(NewButton_Click);
            txt.MouseClick += new MouseEventHandler(Txt_MouseClick);
            txt2.MouseClick += new MouseEventHandler(Txt2_MouseClick);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true;
            frm.Show(); // show form with added controls
            item = m_input.GetItemText(m_input.SelectedItem);                      
            return item;           
        }
        private void Txt_MouseClick(object sender, MouseEventArgs e)
        {
            txt.Text = " ";
        }
        private void Txt2_MouseClick(object sender, MouseEventArgs e)
        {
            txt2.Text = " ";
        }
        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            equalText = m_input.Text;
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            try
            {               
                IntroduceExplainingVariable yeni = new IntroduceExplainingVariable();
                string intro = richTextBox1.Text;
                string aranan = "return";
                int deneme = 0;
                int counter2 = 0;
                string pattern = @"return";
                MatchCollection matches = Regex.Matches(intro, pattern);
                if (matches != null && matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        deneme = match.Index;
                        ret = yeni.TextLoopDivide(intro, aranan, deneme);
                        if (!String.IsNullOrEmpty(ret))
                        {
                            string txtMetin2 = txt2.Text;
                           
                            if (ret.Contains(txtMetin2) && !ret.Contains("==")) //OPERATOR CONTROL
                            {
                                counter2++;
                                string txtMetin = txt.Text;
                                string added = equalText + " " + txtMetin + "=" + ret + ";";
                                string findVariableEx = ret;
                                richTextBox2.Text = richTextBox1.Text;
                                indexStart = 0;
                                indexFinish = 0;
                                richTextBox2.Select(deneme+7, findVariableEx.Length);
                                      indexStart = deneme;
                                      indexFinish = indexStart+7 + findVariableEx.Length;
                                      richTextBox2.SelectionColor = Color.Magenta;
                                      removeString2 = richTextBox2.Text.Remove(indexStart, indexFinish - indexStart);
                                richTextBox2.Text = removeString2;
                                string newAdded ="\n" + "return " + txtMetin +";";
                                removeString2 = richTextBox2.Text.Insert(indexStart, added);
                                richTextBox2.Text = removeString2;
                                int indexSon = indexStart + added.Length;
                                removeString2 = richTextBox2.Text.Insert(indexSon, newAdded);
                                richTextBox2.Text = removeString2;
                                richTextBox2.Select(indexStart, added.Length);
                                richTextBox2.SelectionColor = Color.Green;
                                richTextBox2.Select(indexSon, newAdded.Length);
                                richTextBox2.SelectionColor = Color.Magenta;                               
                            }                           
                        }
                    }
                    if(counter2==0)
                    {
                        MessageBox.Show("The search term for the refactor operation contains an invalid operator or is not appropriate. Enter New Term... ", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        frm.Close();
                        formCreate();
                    }
                    else
                    {
                        MessageBox.Show(" Refactoring technique was applied successfully. ", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                        strLog += "R4: Introduce Explaining Variable refactoring technique is applied" + "\n";
                        strLog += "-------------------------------------------------------------------------" + "\n";
                        WriteLog(strLog);
                    }
                }
                else
                {
                    MessageBox.Show("Search term not found.", "Introduce Explaining Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        List<int> indexList = new List<int>();
        List<string> doubleCode = new List<string>();
        List<int> indexFirst = new List<int>();
        List<int> indexLast = new List<int>();
        //index for first match
        int matchFirst = 0;

        //CONSOLIDATE DUPLICATE CONDITIONAL FRAGMENTS 
        //**********************************************************************************************************************************************
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string takePath = listBox1.SelectedItem.ToString();
            string filename = Path.GetFileName(takePath);
            string[] arr = filename.Split('.');
            string extension = arr[1];
            if (extension == "Cs" || extension == "CS" || extension == "cs")
            {
                string passingCode = richTextBox1.Text;
                int sayac = 0;
                string pattern = @"if.([^{}]+)\{[^{}]+\}\s*(?:else([^{}]+)\{[^{}]+\})"; // Fınd if-else condition
                MatchCollection matches = Regex.Matches(passingCode, pattern);
                if (matches.Count == 0)
                {
                    MessageBox.Show(" Appropriate code not found", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(matches.Count.ToString() + " adet Condition bloğu bulundu", "Consolidate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            richTextBox1.Select(match.Index, match.Length);
                            indexStart = match.Index;
                            indexFinish = indexStart + match.Length;
                            indexList.Add(indexStart);
                            indexList.Add(indexFinish);
                            richTextBox1.SelectionColor = Color.Green;
                            nestedLoop = richTextBox1.Text.Substring(indexStart, match.Length);
                            richTextBox2.Text = nestedLoop;
                            string patternConsolidateMethod = @"\w.+\(+\);|\w.+\([^ ()] +\)"; //\w.+\(+\);|\w.+\([^()]+\); send(id)
                                                                           // only send() finder RegEx=>  \\\w.+\(+\);|\w.+\([^ ()] +\)
                            MatchCollection matchMethod = Regex.Matches(richTextBox2.Text, patternConsolidateMethod);        
                            if (matchMethod != null && matchMethod.Count > 0)
                            {
                                foreach (Match similar in matchMethod)
                                {
                                    if (similar.ToString() != "ToString();")
                                    {
                                        richTextBox2.Select(similar.Index, similar.Length);
                                        indexStart = similar.Index;
                                        indexFinish = indexStart + similar.Length;
                                        richTextBox1.SelectionColor = Color.Red;
                                        detection = richTextBox2.Text.Substring(indexStart, similar.Length);
                                        listBox2.Items.Add(detection.ToString());
                                    }
                                }
                            }
                            richTextBox2.Clear();
                        }

                        Hashtable hash = new Hashtable();
                        int cnt = 0;
                        string[] wordArray = new string[listBox2.Items.Count]; ;
                        for (int j = 0; j < listBox2.Items.Count; j++)
                        {
                            for (int k = 1; k < listBox2.Items.Count; k++)
                            {
                                if (listBox2.Items[j].ToString() == listBox2.Items[k].ToString())
                                {
                                   doubleCode.Add(listBox2.Items[j].ToString());
                                }
                            }
                        }
                        foreach (string same in doubleCode)
                        {
                            string find = same;
                            var matchString = Regex.Escape(find);
                            int indexStart3;
                            int indexFinish3;
                            if (this.richTextBox1.Text.Contains(same))
                            {
                                int i = 0;
                                foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
                                {
                                    indexStart2 = 0;
                                    indexFinish2 = 0;
                                    richTextBox1.Select(match.Index, find.Length);
                                    indexStart2 = match.Index - (i * match.Length);
                                    indexFirst.Add(indexStart2);
                                    indexFinish2 = indexStart2 + match.Length;
                                    indexLast.Add(indexFinish2);
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox2.Text = richTextBox1.Text.Remove(indexStart2, match.Length);
                                    richTextBox1.Text = richTextBox2.Text;
                                    i++;
                                };
                                richTextBox2.Text = richTextBox1.Text;
                                string pattern2 = @"if.([^{}]+)\{[^{}]+\}\s*(?:else([^{}]+)\{[^{}]+\})";
                                MatchCollection matchess = Regex.Matches(passingCode, pattern2);
                                if (matchess != null && matchess.Count > 0)
                                {
                                    foreach (Match match in matchess)
                                    {
                                        richTextBox1.Select(match.Index, match.Length);
                                        indexStart = match.Index;
                                        indexFinish = indexStart + match.Length;
                                        if (indexLast[0] < indexFinish && indexStart < indexFirst[0]) //checked?
                                        {
                                            loopStartIndex = indexStart;
                                            loopFinishIndex = indexFinish;
                                            int total = find.Length + loopStartIndex;
                                            richTextBox2.Text = richTextBox2.Text.Insert(loopFinishIndex - total - find.Length + loopStartIndex, find); //+ loopStartIndex
                                            int index = 0;
                                            richTextBox2.Select(loopStartIndex, loopFinishIndex - total);
                                            richTextBox2.SelectionBackColor = Color.LightYellow;
                                            richTextBox2.Find(find.ToString(), index, richTextBox2.TextLength, RichTextBoxFinds.None);
                                            richTextBox2.SelectionBackColor = Color.LightGreen;
                                            richTextBox1.Text = passingCode;
                                            richTextBox1.Select(loopStartIndex, loopFinishIndex - total);
                                            richTextBox1.SelectionBackColor = Color.LightYellow;
                                            while (index < richTextBox1.Text.LastIndexOf(find.ToString()))
                                            {
                                                richTextBox1.Find(find.ToString(), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                                                richTextBox1.SelectionBackColor = Color.Red;
                                                index = richTextBox1.Text.IndexOf(find.ToString(), index) + 1;
                                            }
                                            sayac++;
                                        }

                                    }
                                }

                            }
                        }

                    }
                    if (sayac != 0)
                    {
                        MessageBox.Show(" Refactoring technique has applied successfully.", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                        strLog += "R6: Consolidate Duplicate Conditional Fragments refactoring technique is applied" + "\n";
                        strLog += "-------------------------------------------------------------------------" + "\n";
                        WriteLog(strLog);
                    }
                }
            }
            else if(extension == "Java" || extension == "java" || extension == "JAVA")
            {
                string data = richTextBox1.Text;
                richTextBox2.Text = data;
                int step = 0;
                finalResult.Clear();            
                patternElseTryCatch = @"if.([^{}]+)\{[^{}]+{([^}]*)}+\s+?catch\s+?\(\s*?Exception\s*?ex\w.*\s*{([^}]*)}\s*}.else.if.([^{}]+)\{[^{}]+{([^}]*)}+\s+?catch\s+?\(\s*?Exception\s*?ex\w.*\s*{([^}]*)}\s*}|if.([^{}]+)\{[^{}]+\}\s*(?:else([^{}]+)\{[^{}]+\})";
                MatchCollection matches = Regex.Matches(data, patternElseTryCatch);
                if (matches.Count == 0)
                {
                    MessageBox.Show(" Appropriate code not found", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            firstLoop.Clear();
                            secondLoop.Clear();
                            richTextBox1.Select(match.Index, match.Length);
                            indexStart = match.Index;
                            indexFinish = indexStart + match.Length;
                            indexList.Add(indexStart);
                            indexList.Add(indexFinish);
                            richTextBox1.SelectionColor = Color.Green;
                            nestedLoop = richTextBox1.Text.Substring(indexStart, match.Length);
                            richTextBox2.Text = nestedLoop;

                            string denemeTryCatch = @"if.([^{}]+)\{[^{}]+{([^}]*)}+\s+?catch\s+?\(\s*?Exception\s*?ex\w.*\s*{([^}]*)}\s*}|if.([^{}]+)\{[^{}]+\}\s*";
                            var test = match.ToString();
                            string[] stringSeparators = new string[] { "else " };
                            string firstNames = test.Split(stringSeparators, StringSplitOptions.None).First();
                            MatchCollection eslesen = Regex.Matches(firstNames, denemeTryCatch);
                            if (eslesen != null && eslesen.Count > 0)
                            {
                                foreach (Match ayni in eslesen)
                                {
                                    if (ayni.ToString() != "ToString();")
                                    {
                                        richTextBox2.Select(ayni.Index, ayni.Length);
                                        indexStart = ayni.Index;
                                        indexFinish = indexStart + ayni.Length;
                                        richTextBox1.SelectionColor = Color.Red;
                                        detection = richTextBox2.Text.Substring(indexStart, ayni.Length);
                                        firstLoop.Add(detection.ToString());
                                    }
                                }
                            }
                            string elseTryCatch = @"else([^{}]+)\{[^{}]+\}|else([^{}]+)\{[^{}]+\}|.else.if.([^{}]+)\{[^{}]+{([^}]*)}+\s+?catch\s+?\(\s*?Exception\s*?ex\w.*\s*{([^}]*)}\s*}";
                            MatchCollection eslesenY = Regex.Matches(richTextBox2.Text, elseTryCatch);
                            if (eslesenY != null && eslesenY.Count > 0)
                            {
                                foreach (Match ayni in eslesenY)
                                {
                                    if (ayni.ToString() != "ToString();")
                                    {
                                        richTextBox2.Select(ayni.Index, ayni.Length);
                                        indexStart = ayni.Index;
                                        indexFinish = indexStart + ayni.Length;
                                        richTextBox1.SelectionColor = Color.Red;
                                        detection = richTextBox2.Text.Substring(indexStart, ayni.Length);
                                        secondLoop.Add(detection.ToString());
                                    }
                                }
                            }
                            foreach (string dublicate1 in firstLoop)
                            {
                                string patternLoopDublicate = @"\w.+\(+\);|\w.+\([^()]+\);|\w.+\([^\)]*\)(\.[^\)]*\))?\);|\w.+=*;"; // send(),|vo.send(id),| vo.get(a.set())| x=y;
                                MatchCollection eslesenK = Regex.Matches(dublicate1, patternLoopDublicate);                            
                                if (eslesenK != null && eslesenK.Count > 0)
                                {
                                    foreach (Match ayni in eslesenK)
                                    {
                                        if (ayni.ToString() != "ToString();")
                                        {
                                            firstLoop1.Add(ayni.ToString());
                                        }

                                    }
                               }
                            }
                            foreach (string dublicate2 in secondLoop)
                            {
                                string patternLoopDublicate2 = @"\w.+\(+\);|\w.+\([^()]+\);|\w.+\([^\)]*\)(\.[^\)]*\))?\);|\w.+=*;"; // send(),|vo.send(id),| vo.get(a.set())| x=y;

                                MatchCollection matchesLoopDublicate = Regex.Matches(dublicate2, patternLoopDublicate2);          
                                if (matchesLoopDublicate != null && matchesLoopDublicate.Count > 0)
                                {
                                    foreach (Match ayni2 in matchesLoopDublicate)
                                    {
                                        if (ayni2.ToString() != "ToString();")
                                        {
                                            secondLoop2.Add(ayni2.ToString());
                                        }
                                    }
                                }
                            }
                            for (int j = 0; j < firstLoop1.Count; j++)
                            {
                                for (int k = 0; k < secondLoop2.Count; k++)
                                {
                                    if (firstLoop1[j].ToString() == secondLoop2[k].ToString())
                                    {
                                        finalResult.Add(firstLoop1[j].ToString());
                                    }
                                }
                            }
                            richTextBox2.Clear();
                            firstLoop1.Clear();
                            secondLoop2.Clear();
                        }                      
                    }
                    foreach (string finalMatch in finalResult.ToList())
                    {
                        listBox2.Items.Add(finalMatch + "\n");
                        finalResultChange.Add(finalMatch);
                    }                   
                    finalResultChange = finalResult;
                    richTextBox2.Text = "";
                }
                richTextBox2.Text = data;
                MessageBox.Show("SELECT the DUBLICATE code from the CODE SEPARATION PROCESS list for refactoring technique", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                MatchCollection matches1 = Regex.Matches(richTextBox1.Text, patternElseTryCatch);
                if (matches1.Count == 0)
                {
                    MessageBox.Show(" Appropriate code not found", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {                   
                    if (matches1 != null && matches1.Count > 0)
                    {
                        foreach (Match match1 in matches1)
                        {
                            richTextBox1.Select(match1.Index, match1.Length);
                            indexStart = match1.Index;
                            indexFinish = indexStart + match1.Length;
                            foreach (string finalMatch in finalResultChange)
                            {
                                string find = finalMatch;
                                var matchString = Regex.Escape(find);
                                MatchCollection finalDublicate = Regex.Matches(richTextBox1.Text, matchString);
                                if (finalDublicate != null && finalDublicate.Count > 0)
                                {
                                    int counter = 1;
                                    foreach (Match matchh in finalDublicate)
                                    {
                                        richTextBox1.Select(matchh.Index, matchh.Length);
                                        indexStartLast = matchh.Index;
                                        indexFinishLast = indexStartLast + matchh.Length;
                                        if (indexStart < indexStartLast && indexFinish > indexFinishLast)
                                        {
                                            richTextBox1.SelectionBackColor = Color.Yellow;                             
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                consolidateCounter = true;
            }
            else
            {
                MessageBox.Show("The file is not suitable for applying the technique!!! Select a different path.", "Consolidate Duplicate Conditional Fragments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }
        private void hideMethodMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string takePath = listBox1.SelectedItem.ToString();
                string filename = Path.GetFileName(takePath);
                string[] arr = filename.Split('.');
                string extension = arr[1];
                if (extension == "Java" || extension == "java" || extension == "JAVA"|| extension == "Cs" || extension == "CS" || extension == "cs")
                {
                    if (hd.IsDisposed)//Close and Reopen HideMethod Form
                        hd = new HideMethod();
                    hd.Show();
                    hd.getPath = takePath;
                    //Save Log
                    strLog = "------------------" + System.DateTime.Now.ToString() + "-----------------\n";
                    strLog += "R7: Hide Method refactoring technique is applied" + "\n";
                    strLog += "-------------------------------------------------------------------------" + "\n";
                    WriteLog(strLog);
                }
                else
                {
                    MessageBox.Show("Inappropriate file format selected for Hide Method", "Hide Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }    
        }
        public string TextInformation()
        {
            textDoc = this.richTextBox1.Text;
            return textDoc;
        }
        private void LogicalLineOfCodeMenuItem_Click(object sender, EventArgs e)
        {
            if (logicalLineNum.IsDisposed)// Close the Form and Open it Again
                logicalLineNum = new LogicalLineNumber();
            logicalLineNum.Text = "Statements (SLOC-L)";
            logicalLineNum.Show();

        }

        private void LinesOfCodeMenuItem_Click(object sender, EventArgs e)
        {
            if (lineNumber.IsDisposed)// Close the Form and Open it Again
                lineNumber = new LinesOfCode();
            lineNumber.Text = "Lines Of Code";
            lineNumber.Show();
        }

        private void MethodCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (functionNo.IsDisposed)// Close the Form and Open it Again
                functionNo = new MethodsPerClass();
            functionNo.Text = "Method per Class";
            functionNo.Show();
        }

        private void CallsPerMethNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (functionCallNo.IsDisposed)// Close the Form and Open it Again
                functionCallNo = new CallsPerMethod();
            functionCallNo.Text = "Calls per Method";
            functionCallNo.Show();
        }

        private void InhertanceLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inheritLevel.IsDisposed)// Close the Form and Open it Again
                inheritLevel = new DepthOfInheritance();
            inheritLevel.Text = "Depth of Inheritance Tree";
            inheritLevel.Show();
        }
        private void StatementOfMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (state.IsDisposed)// Close the Form and Open it Again
                    state = new StatementsPerMethod();
                state.Text = "Statements per Method";
                state.Show();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }

        private void OperandAndOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transactionNo.IsDisposed)// Close the Form and Open it Again
                transactionNo = new OperandAndOperator();
            transactionNo.Text = "Operand and Operator Count per Class";
            transactionNo.Show();
        }

        private void ComplexityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                codeComplexity = new Complexity();
                codeComplexity.Text = "Cyclomatic Complexity";
                codeComplexity.Show();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }

        private void CohesionVeCouplingSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {              
                string parameter = formLanguageCreate();
                if (parameter == "Java")
                {
                    if (relationJava.IsDisposed)// Close the Form and Open it Again                     
                        relationJava = new CouplingJava();
                    relationJava.Text = "Coupling Metric";
                    relationJava.Show();
                }
                else if (parameter == "Cs")
                {
                    if (relation.IsDisposed)// Close the Form and Open it Again                       
                        relation = new Coupling();
                    relation.Text = "Coupling Metric";
                    relation.Show();
                }
                else
                {
                    MessageBox.Show("Programming Language not found.");
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        private void MaintainabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string parameter = formLanguageCreate();
                if(parameter == "Java")
                {
                    if (mainIndexJ.IsDisposed)// Close the Form and Open it Again
                        mainIndexJ = new MaintainabilityIndexForJava();
                    mainIndexJ.Text = "Maintainability Index";
                    mainIndexJ.Show();
                }
                else if (parameter == "Cs")
                {
                    if (mainIndex.IsDisposed)// Close the Form and Open it Again
                        mainIndex = new MaintainabilityIndex();
                    mainIndex.Text = "Maintainability Index";
                    mainIndex.Show();
                }
                else
                {
                    MessageBox.Show("Programming Language not found.");
                }              
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        //Create EXCEL File
        private void ButtonExcelCreate_Click(object sender, EventArgs e)
        {
            string ad = formExcelCreate();
            try
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        excel.Workbook.Worksheets.Add("Worksheet" + i);
                    }
                    var headerRow = new List<string[]>()
                     {
                          new string[] {" ", "SLOC-L", "Operand Count per Class ", "Operator Count per Class", "Cyclomatic Complexity", "Lines of Code(LOC)", "Methods per Class", "Depth of Inheritance Tree", "Calls per Method","Class Coupling", "Statements per Method", "Maintainability Index", "Mathematical Model-Numerator", "Mathematical Model-Denominator", "Mathematical Model-Result" }
                                };
                    // Determine the header range (e.g. A1:D1)
                    string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                    // Target a worksheet
                    var worksheet = excel.Workbook.Worksheets["Worksheet1"];
                    // Popular header row data
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                    var cellData = new List<object[]>()
                        {
                          new object[] {"Original Code"},
                          new object[] {"R1"},
                          new object[] {"R2"},
                          new object[] {"R3"},
                          new object[] {"R4"},
                          new object[] {"R5"},
                          new object[] {"R6"},
                          new object[] {"R7"}
                                };
                    for (int i = 2; i < 10; i++)
                    {
                        worksheet.Cells["M" + i.ToString()].Formula = "SUM(E" + i.ToString() + ",F" + i.ToString() + ",H" + i.ToString() + ",PRODUCT(G" + i.ToString() + ",I" + i.ToString() + "))";
                        worksheet.Cells["N" + i.ToString()].Formula = "SUM(L" + i.ToString() + ")";
                        worksheet.Cells["O" + i.ToString()].Formula = "M" + i.ToString() + "/N" + i.ToString() ;
                        worksheet.Cells["P" + i.ToString()].Formula = "ROUND(O" + i.ToString() + ",2)";
                    }                   
                    worksheet.Cells[2, 1].LoadFromArrays(cellData);
                    FileInfo excelFile = new FileInfo(@"C:\refactoring\" + ad + ".xlsx");
                    excel.SaveAs(excelFile);
                    MessageBox.Show(" Excel file has been created.", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        Form formLang = new Form();
        Button btn = new Button();
        Button btn1 = new Button();
        //Create FORM for Java or Cs selection
        public string formLanguageCreate()
        {           
            int top = 150;
            int left = 150;
            formLang.Text = "Programming Language Selection";
            formLang.MaximizeBox = false;
            Label l1 = new Label();
            l1.Left = 100;
            l1.Top = 70;
            l1.Size = new Size(120, 80);
            l1.Text = " Please select programming language for Maintainability Metric ";
            formLang.Controls.Add(l1);
            
            btn.Left = left;
            btn.Top = top;
            btn.Text = "Java";
            formLang.Controls.Add(btn);
           
            btn1.Left = 50;
            btn1.Top = top;
            btn1.Text = "Cs";
            formLang.Controls.Add(btn1);          
            btn.Click += new EventHandler(Java_Click);
            btn1.Click += new EventHandler(Cs_Click);
            formLang.ShowDialog();
            return lang;            
        }
        private void Java_Click(object sender, System.EventArgs e)
        {
            lang = "Java";            
            formLang.Close();          
        }
        private void Cs_Click(object sender, System.EventArgs e)
        {
            lang = "Cs";
            formLang.Close();
        }
        //Creating the Form and Getting the Excel file name to be created 
        internal System.Windows.Forms.TextBox txtExcel;
        public string formExcelCreate()
        {
            Form form = new Form();
            int top = 200;
            int left = 150;
            form.Text = "Saving File Name";

            Label l1 = new Label();
            l1.Left = 50;
            l1.Top = 50;
            l1.Text = "File Name: ";
            form.Controls.Add(l1);

            txtExcel = new TextBox();
            txtExcel.Location = new Point(150, 50);
            txtExcel.Size = new Size(100, 15);
            txtExcel.Text = "nameee";
            form.Controls.Add(txtExcel);

            Button btn = new Button();
            btn.Left = left;
            btn.Top = top;
            btn.Text = "Save";
            form.Controls.Add(btn);   
            btn.Click += new EventHandler(New_Click);
            form.ShowDialog(); // show form with added controls
            item = txtExcel.Text;                  
            return item;           
        }
        private void New_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(" File Name Saved.", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //CODE BLOCK SAVING Original and Refactored Code Metric Values 
        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;

        public void WriteRefaCodeMetricExcel(int metric, int x, int y)
        {
            string path = GetFilePath();
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            if (oXL == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            else
            {
                try
                {
                    oXL.DisplayAlerts = false;
                    mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    //Get all the sheets in the workbook
                    mWorkSheets = mWorkBook.Worksheets;
                    //Get the allready exists sheet
                    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("WorkSheet1");
                    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                    int colCount = range.Columns.Count;
                    int rowCount = range.Rows.Count;
                    mWSheet1.Cells[x, y] = metric;
                    mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
                    mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
                    mWSheet1 = null;
                    mWorkBook = null;
                    oXL.Quit();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            
            }
           
        }

        public void WriteRefaCodeMetricExcel(float metric, int x, int y)
        {
            string path = GetFilePath();
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            if (oXL == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            else
            {
                oXL.DisplayAlerts = false;
                mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Get all the sheets in the workbook
                mWorkSheets = mWorkBook.Worksheets;
                //Get the allready exists sheet
                mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("WorkSheet1");
                Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                int colCount = range.Columns.Count;
                int rowCount = range.Rows.Count;

                mWSheet1.Cells[x, y] = metric;
                mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
                mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
                mWSheet1 = null;
                mWorkBook = null;
                oXL.Quit();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
          
        }

        public void WriteOriginalCodeMetric(int metric, int a, int b)
        {
            string path = GetFilePath();
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            if (oXL == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            else
            {
                oXL.DisplayAlerts = false;
                mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Get all the sheets in the workbook
                mWorkSheets = mWorkBook.Worksheets;
                //Get the allready exists sheet
                mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("WorkSheet1");
                Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                int colCount = range.Columns.Count;
                int rowCount = range.Rows.Count;

                mWSheet1.Cells[a, b] = metric;
                mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
                mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
                mWSheet1 = null;
                mWorkBook = null;
                oXL.Quit();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
      
        }

        public void WriteOriginalCodeMetric(float metric, int a, int b)
        {
            string path = GetFilePath();
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            if (oXL == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("WorkSheet1");
            Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
            int colCount = range.Columns.Count;
            int rowCount = range.Rows.Count;

            mWSheet1.Cells[a, b] = metric;
            mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            mWSheet1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        //Getting EXCEL FILE PATH
        public string GetFilePath()
        {
            OpenFileDialog dr = new OpenFileDialog();
            dr.InitialDirectory= @"C:\refactoring\";
            //dr.Multiselect = true;
            dr.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls;*‌​.xml;";
            string str = "";
            if (dr.ShowDialog() == DialogResult.OK)
            {
                str = dr.FileName;
            }
            return str;
        }
        //R Studio and OPTIMAL SEQUENCE Obtaining Codes

        private void CombinatorialOrderUsingR_Click(object sender, EventArgs e)
        {
            try
            {
                if (draw.IsDisposed)//Allows us to Close the Form and Open it Again
                    draw = new R();
                draw.Text = "Finding the Optimal Order of Refactoring Techniques";
                draw.Show();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        //  Getting and Saving Energy values from Intel Power Gadget
        internal System.Windows.Forms.TextBox energy;
        public string pathEnergy;
        List<string> newList = new List<string>();
        List<CsvRow> consumption = new List<CsvRow>();
        public string newPath;
        private void GetEnergyEstimationResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dr = new OpenFileDialog();
            dr.InitialDirectory = @"C:\Documents\";
            dr.Filter = "CSV Files (*.csv)|*.csv";
            string str = "";
            if (dr.ShowDialog() == DialogResult.OK)
            {
                str = dr.FileName;
            }

            if (str != null)
            {
                Form form = new Form();

                int top = 200;
                int left = 150;
                form.Text = "Saving Energy Estimation Result";

                Label l1 = new Label();
                l1.Left = 50;
                l1.Top = 50;
                l1.Text = "File Name: ";
                form.Controls.Add(l1);

                energy = new TextBox();
                energy.Location = new Point(150, 50);
                energy.Size = new Size(100, 15);
                energy.Text = str.ToString();
                form.Controls.Add(energy);


                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Text = "Save";
                form.Controls.Add(btn);
    
                pathEnergy = energy.Text;
                btn.Click += new EventHandler(BtnEESaving_Click);
                // Shows the form with added controls
                form.ShowDialog();          
            }
        }
        // Saving Energy Consumption Result in event method
        private void BtnEESaving_Click(object sender, System.EventArgs e)
        {
            if(energy!= null)
            {
                string extension = ".csv";
                if (energy.Text.Contains(extension))
                {
                    string filename = Path.GetFileName(pathEnergy);
                    string[] arr = filename.Split('.');
                    string newEEResultFileName = "-";
                    foreach (string item in arr)
                    {
                        if (item != "csv")
                        {
                            newEEResultFileName += item.ToString();
                        }
                    }
                    ReadTest();
                    newPath = @"C:\refactoring\" + newEEResultFileName + ".csv";

                    WriteTest(newPath, consumption);
                    MessageBox.Show("Energy Consumption Result Saved.", "STORAGE DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }             
            }
            else
            {
                MessageBox.Show("Please Select Energy Consumption Result File!!!",
                      "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        //READandWRITE CSV FILE
        /// Class to store one CSV row
        public class CsvRow : List<string>
        {
            public string LineText { get; set; }
        }
        /// Class to write data to a CSV file
        public class CsvFileWriter : StreamWriter
        {
            public CsvFileWriter(Stream stream)
                : base(stream)
            {
            }

            public CsvFileWriter(string filename)
                : base(filename)
            {
            }
            /// Writes a single row to a CSV file.
            /// <param name="row">The row to be written</param>
            public void WriteRow(CsvRow row)
            {
                StringBuilder builder = new StringBuilder();
                bool firstColumn = true;
                foreach (string value in row)
                {
                    // Add separator if this isn't the first value
                    if (!firstColumn)
                        builder.Append(',');
                    // Implement special handling for values that contain comma or quote
                    // Enclose in quotes and double up any double quotes
                    if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                        builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    else
                        builder.Append(value);
                    firstColumn = false;
                }
                row.LineText = builder.ToString();
                WriteLine(row.LineText);
            }
        }
        /// Class to read data from a CSV file
        public class CsvFileReader : StreamReader
        {
            public CsvFileReader(Stream stream)
                : base(stream)
            {
            }

            public CsvFileReader(string filename)
                : base(filename)
            {
            }
            /// Reads a row of data from a CSV file
            /// <param name="row"></param>
            /// <returns></returns>
            public bool ReadRow(CsvRow row)
            {
                row.LineText = ReadLine();
                if (String.IsNullOrEmpty(row.LineText))
                    return false;

                int pos = 0;
                int rows = 0;

                while (pos < row.LineText.Length)
                {
                    string value;

                    // Special handling for quoted field
                    if (row.LineText[pos] == '"')
                    {
                        // Skip initial quote
                        pos++;

                        // Parse quoted value
                        int start = pos;
                        while (pos < row.LineText.Length)
                        {
                            // Test for quote character
                            if (row.LineText[pos] == '"')
                            {
                                // Found one
                                pos++;

                                // If two quotes together, keep one
                                // Otherwise, indicates end of value
                                if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                                {
                                    pos--;
                                    break;
                                }
                            }
                            pos++;
                        }
                        value = row.LineText.Substring(start, pos - start);
                        value = value.Replace("\"\"", "\"");
                    }
                    else
                    {
                        // Parse unquoted value
                        int start = pos;
                        while (pos < row.LineText.Length && row.LineText[pos] != ',')
                            pos++;
                        value = row.LineText.Substring(start, pos - start);
                    }
                    // Add field to list
                    if (rows < row.Count)
                        row[rows] = value;
                    else
                        row.Add(value);
                    rows++;
                    // Eat up to and including next comma
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    if (pos < row.LineText.Length)
                        pos++;
                }
                // Delete any unused items
                while (row.Count > rows)
                    row.RemoveAt(rows);

                // Return true if any columns read
                return (row.Count > 0);
            }
        }
        void ReadTest()
        {
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(pathEnergy))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    CsvRow csv = new CsvRow();
                    List<string> cons = new List<string>();
                    foreach (string s in row)
                    {
                        cons.Add(s);                       
                    }
                    foreach (var ss in cons) { 
                        csv.Add(ss.ToString());
                    }
                    consumption.Add(csv);               
                }
            }
        }
        void WriteTest(string path, List<CsvRow> item)
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter(path))
            {
                    foreach (var data in item)
                    {
                        CsvRow row = new CsvRow();
                        foreach (var d in data)
                        {
                            row.Add(d.ToString());
                        }
                        writer.WriteRow(row);
                    }
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox2.BackColor = Color.White;
            listBox2.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Text = "";

        }
        private void RandomRefTechnique_Click(object sender, EventArgs e)
        {
            try
            {
                if (rf.IsDisposed)//Close the Form and Open it again
                    rf = new AppliedRefactoringTechniques();
                rf.Text = "Finding the Code Refactoring Technique Applied Using Log";
                rf.Show();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }       
    }
}