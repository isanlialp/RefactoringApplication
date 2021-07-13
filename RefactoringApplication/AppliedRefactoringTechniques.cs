using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using ExcelApp = Microsoft.Office.Interop.Excel;


namespace fileApp
{
    public partial class AppliedRefactoringTechniques : Form
    {
        public Main randomRefTech  = new Main();
        public string fileLogPath;
        public int indexStart;
        public int indexFinish;
        public string item { get; set; }
        public string rText;
        public string RText;
        public string filePath;
        public string fileName;
        bool log = false;
        bool adjacency = false;
        public double[] array = new double[7];
        List<string> logR = new List<string>();
        List<string> refArrayName = new List<string>();
        public AppliedRefactoringTechniques()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(740, 680);
        }
        //GET LOG DATA FROM FILE
        private void GetData_Click(object sender, EventArgs e)
        {
            AppliedRefTech.Enabled = true;
            RichTextBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            string line = "";
            RichTextBox_Data.Text = "";
            openFile.InitialDirectory = @"C:";
            openFile.Filter = "txt files (.txt)| *.txt";
            var content = String.Empty;
            string yl = BtnFileSelect();
            if(yl == null)
                {
                MessageBox.Show("Selected File Not Found", "Closing Form", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
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
                        RichTextBox_Data.Text += line.ToString() + "\n";
                    }
                }
                fileStream.Flush();
                fileStream.Close();
                fileStream.Dispose();
            }       
        }
        //OPEN and SELECT CUSTOM FILE FOR LOG
        public string BtnFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\";
            file.Filter = "txt files (.txt)| *.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select Log File..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // SELECTED FILE 
                fileLogPath = file.FileName;
                string fileLogName = file.SafeFileName;

            }
            return fileLogPath;
        }
        //CLEAR ALL CONTROLS
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            RichTextBox_Data.Clear();
            ListBox1.Items.Clear();
        }

        // Open Excel File and Create Adjacency Matrix 
        private void AdjacencyMatrix_Click(object sender, EventArgs e)
        {
            AppliedRefTech.Enabled = false;
            log = false;
            adjacency = true;
            RichTextBox_Data.Clear();
            ListBox1.Items.Clear();
            if (FileSelect() != null)
            {
                string pathOfExcelFile = filePath;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.DisplayAlerts = false; //Don't want Excel to display error messageboxes  
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(pathOfExcelFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //This opens the file
                Microsoft.Office.Interop.Excel.Worksheet sheet = (ExcelApp.Worksheet)workbook.Worksheets.get_Item(1);//workbook.Sheets[1]; //Get the first sheet in the file
                                                                                                                     // Microsoft.Office.Interop.Excel.Range OColumn = sheet.get_Range("O", null);
                                                                                                                     //ExcelApp.Range bColumn = sheet.UsedRange.Columns[4, Type.Missing].Columns.Count;
                //Create Adjacency Matrix
                double[,] adjacency = new double[7, 7];
                Array.Clear(adjacency, 0, array.Length);
                int count = 0, node;

                for (int i = 0; i < 7; i++)
                {
                    var cell = (ExcelApp.Range)sheet.Cells[i + 3, 16];
                    array[i] = cell.Value2;
                    if (array[i] <= 0)
                    {
                        array[i] = 0;
                        count++;
                    }

                }

                for (int i = 0; i < 6; i++)
                {
                    for (int j = i + 1; j < 7; j++)
                    {
                        //adjacency matrix
                        if (array[i] != 0 && array[j] != 0)
                        {
                            adjacency[i, j] = (array[i] + array[j]) / 2;
                            adjacency[j, i] = adjacency[i, j];
                        }
                        else continue;
                    }
                }
                node = 7 - count;
                Random random = new Random();
                int sayi = random.Next(1, node);
                //Create R Script for Adjacency Matrix
                RText = "library (optrees)\nnodes<-1:" + node.ToString() + "\narcs <- matrix(c(";
                rText = "";
                int k = (node * (node - 1)) / 2;
                double[] ad2 = new double[k];
                int l = 0;
              
                for (int i = 0; i < 6; i++)
                {
                    for (int j = i + 1; j < 7; j++)
                    {
                        if (array[i] != 0 && array[j] != 0)
                        {
                            ad2[l] = adjacency[i, j];
                            l++;
                        }
                    }
                }
                l = 0;
                for (int i = 0; i < node - 1; i++)
                {
                    for (int j = i + 1; j < node; j++)
                    {
                        rText += (i + 1).ToString() + "," + (j + 1).ToString() + "," + ad2[l].ToString() + ",";
                        l++;
                    }
                }
                // Creating the Minimum Spanning Tree Algorithm Script
                int rLength = rText.LastIndexOf(',');
                rText = rText.Remove(rText.LastIndexOf(','));
                RText += rText;
                RText += "), byrow = TRUE, ncol = 3)\ngetMinimumSpanningTree(nodes, arcs, algorithm = \"Prim\", start.node =" + sayi.ToString() + ")";
                RichTextBox_Data.Text = RText;
            }
            else
            {
                MessageBox.Show("File is Not Selected ...", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                FileSelect();
            }
        }
        internal System.Windows.Forms.TextBox refactoredCode;
        public string RCodeSave()
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
            refactoredCode.Text = "";
            form.Controls.Add(refactoredCode);


            Button btn = new Button();
            btn.Left = left;
            btn.Top = top;
            btn.Text = "Save";
            form.Controls.Add(btn);       

            btn.Click += new EventHandler(Ref_Click);
            form.ShowDialog(); // Shows the form with added controls
            item = refactoredCode.Text;
 
            if (form == null)
            {
                return null;
            }
            else
            {
                return item;
            }

            // In event method.              
        }
        private void Ref_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("File Name Saved.", "Finding the Code Refactoring Technique and Adjacency Matrix", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //SAVING DATA
        private void Save_Click(object sender, EventArgs e)
        {
            if (adjacency == true)
            {
                string filename = RCodeSave();
                if (filename == "")
                {
                    filename = RCodeSave();
                }
                else
                {
                    string path = @"C:\RScript\" + filename + ".R";
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        fs.Flush();
                        fs.Close();
                        fs.Dispose();
                    }

                    File.WriteAllLines(path, this.RichTextBox_Data.Lines);
                }
                MessageBox.Show("R Script Has Been Saved.\nTo Find the Optimal Order, GO to the Submenu Named \n'Finding the Optimal Order of Refactoring Techniques'.", "R", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(log == true && ListBox1.Items.Count != 0)
            {
                foreach (var item in logR )
                {
                    refArrayName.Add(item);
                }
                MessageBox.Show("Refactoring Techniques Have Been Saved.\nTo Find the Optimal Order, GO to the Submenu Named \n'Finding the Optimal Order of Refactoring Techniques'.", "Refactoring Techniques", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else if (log == false && adjacency==false)
            {
                MessageBox.Show("Saving Data Not Found", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }               
        }
        //SELECT CUSTOM FILE FOR ADJACENCY MATRIX
        public string FileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls;*‌​.xml;";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select Excel File..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // file selected
                filePath = file.FileName;
                fileName = file.SafeFileName;

            }
            return filePath;
        }
        //DETERMINING APPLIED REFACTORING TECHNIQUES
        private void AppliedRefTech_Click(object sender, EventArgs e)
        {
            log = true;
            adjacency = false;
            ListBox1.Items.Clear();
            if(RichTextBox_Data.Text!=String.Empty)
            {
                //R1: Encapsulate Field
                string findVariable = @"Encapsulate Field";
                var matchString = Regex.Escape(findVariable);
                if (this.RichTextBox_Data.Text.Contains(findVariable))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;
                    };
                    ListBox1.Items.Add("R1");
                }
                //R2: Simplify Nested Loop
                string findVariable2 = @"Simplify Nested Loop";
                var matchString2 = Regex.Escape(findVariable2);
                if (this.RichTextBox_Data.Text.Contains(findVariable2))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable2.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R2");
                }
                // R3: Inline Temp
                string findVariable3 = @"Inline Temp";
                var matchString3 = Regex.Escape(findVariable3);
                if (this.RichTextBox_Data.Text.Contains(findVariable3))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable3.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R3");
                }
                //R4: Introduce Explaining Variable
                string findVariable4 = @"Introduce Explaining Variable";
                var matchString4 = Regex.Escape(findVariable4);
                if (this.RichTextBox_Data.Text.Contains(findVariable4))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable4.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R4");
                }
                //R5: Replace Magic Number with Symbolic Constant
                    string findVariable5 = @"Replace Magic Number";
                var matchString5 = Regex.Escape(findVariable5);
                if (this.RichTextBox_Data.Text.Contains(findVariable5))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable5.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R5");
                }
                //R6: Consolidate Duplicate Conditional Fragments
                string findVariable6 = @"Consolidate Duplicate";
                var matchString6 = Regex.Escape(findVariable6);
                if (this.RichTextBox_Data.Text.Contains(findVariable6))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable6.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R6");
                }
                // R7: Hide Method
                string findVariable7 = @"Hide Method";
                var matchString7 = Regex.Escape(findVariable7);
                if (this.RichTextBox_Data.Text.Contains(findVariable7))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariable7.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R7");
                }
                if (ListBox1.Items.Count == 0)
                {
                    MessageBox.Show("Applied Refactoring Technique Not Found ", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                string findVariableR7 = @"Hide method";
                var matchStringR7 = Regex.Escape(findVariableR7);
                if (this.RichTextBox_Data.Text.Contains(findVariableR7))
                {
                    foreach (Match match1 in Regex.Matches(RichTextBox_Data.Text, matchString))
                    {
                        indexStart = 0;
                        indexFinish = 0;
                        RichTextBox_Data.Select(match1.Index, findVariableR7.Length);
                        indexStart = match1.Index;
                        indexFinish = indexStart + match1.Length;

                    };
                    ListBox1.Items.Add("R7");
                }
                if (ListBox1.Items.Count == 0)
                {
                    MessageBox.Show("Applied Refactoring Technique Not Found ", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {

                    string str = null;
                    foreach (var item in ListBox1.Items)
                    {
                        logR.Add(item.ToString());
                        str += item + " ";
                    }
                   
                    MessageBox.Show(str, "Applied Ref Tech", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                }

            }
            else
            {
                MessageBox.Show("Log Data Not Found ", "Important NOTE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
    }
}