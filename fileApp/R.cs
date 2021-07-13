using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Microsoft.CodeAnalysis;
using Syncfusion.Pdf.Parsing;
using System.Drawing.Imaging;


namespace fileApp
{
    public partial class R : Form
    {
        public Main imge = new Main();
        Process myProcess = new Process();
        
        public R()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(1600, 749);
           
        }
        public string transferData;
        public string nestedLoop;
        public int indexStart;
        public int indexFinish;
        public int indexStart1;
        public int indexFinish1;
        public int clCount;
        public string pathR;
        public string[] clpost;
        public string TrimString { get; set; }
        List<string> listterms = new List<string>();
        List<string> weight = new List<string>();
        //  Checking R Script
        public string RunRScript(string rpath, string scriptpath)
        {
            string result = string.Empty;
            string error = "";
            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = rpath,
                    WorkingDirectory = Path.GetDirectoryName(scriptpath),
                    Arguments = scriptpath,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (var proc = new Process { StartInfo = info })
                {
                    proc.Start();
                    return proc.StandardOutput.ReadToEnd();

                }
                return result + " " + error;
            }
            catch (Exception ex)
            {
                throw new Exception("R Script failed: " + result, ex);
            }
        }
        //Run R GUI
        private void Script_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            pathR = ListBox3.SelectedItem.ToString();
            var rpath = @"C:\Program Files\R\R-3.6.2\bin\Rscript.exe";
            var scriptpath = pathR;
            var output = RunRScript(rpath, scriptpath);
            RichTextBox1.Text = output.ToString();
            transferData = RichTextBox1.Text;
        }

        private void Plot_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Gets the full extension of the file 
                string filePath = openFileDialog.FileName;
                //Gets the file's extension and name
                string filename = Path.GetFileName(filePath);
                //Gets only the name of the file without the extension
                string name = Path.GetFileNameWithoutExtension(filePath);
                //Loaded input PDF file
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(filePath);
                //Exporting specify page index as image
                Bitmap image = loadedDocument.ExportAsImage(0);
                try
                {
                    if (image != null)
                    {
                        //Save the image as PNG format
                        var files = Directory.GetFiles(@"C:\RScript\", name+"*");
                         var newFileName = string.Format(@"C:\RScript\" + name +"{0}"+".png", files.Length + 1);
                        image.Save(newFileName, ImageFormat.Png);
                        //Close the document
                        loadedDocument.Close(true);
                        PictureBox1.Image = Image.FromFile(newFileName);
                    }
                    image.Dispose();
                    image = null;
                }
                catch (Exception)
                {
                    MessageBox.Show("There was a problem saving the file." +
                        "Check the file path permissions.");
                }
            }
        }
        //Get Saved R Script
        private void Bring_Script_Click(object sender, EventArgs e)
        {
            Rscript.Enabled = true;
            RichTextBox1.BackColor = Color.White;
            ListBox3.Items.Clear();
            ListBox1.Items.Clear();
            RichTextBox1.Clear();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                ListBox3.Items.Clear();
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.R");
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath, "*.R");

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    string savedFileName = fileInfo.Name;
                    long byteLenght = fileInfo.Length;

                    DateTime createDate = fileInfo.CreationTime;
                    ListViewItem item = new ListViewItem(savedFileName);
                    ListBox3.Items.Add(file);

                }
            }
        }
        //Identifying Optimal ORDER of Refactoring Techniques
        private void Order_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(RichTextBox1.Text)))
                {
                    MessageBox.Show(" Not Found Weight for Proposed Algorithm", "Optimal Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Detecting Number of Applied Nodes from Minimum Spanning Tree Script                  
                    string pattern = @"weight";
                    MatchCollection matches = Regex.Matches(transferData, pattern);           
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            RichTextBox1.Select(match.Index, match.Length);
                            indexStart = match.Index;
                            indexFinish = indexStart + match.Length;
                        }
                    }
                    string pattern1 = @"Total";
                    MatchCollection match1 = Regex.Matches(transferData, pattern1);
                    if (match1 != null && match1.Count > 0)
                    {
                        foreach (Match matchT in match1)
                        {
                            RichTextBox1.Select(matchT.Index, matchT.Length);
                            indexStart1 = matchT.Index;
                            indexFinish1 = indexStart1 + matchT.Length;
                            RichTextBox1.SelectionColor = Color.Green;
                            nestedLoop = RichTextBox1.Text.Substring(indexStart + 6, indexFinish1 - indexStart);
                        }
                    }
                    string[] lines = Regex.Split(nestedLoop, "\n");
                    foreach (string item in lines)
                    {
                        ListBox1.Items.Add(item);

                    }
                    ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                    ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                    int count = ListBox1.Items.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        if (ListBox1.Items[i].ToString() == " ")
                        {
                            ListBox1.Items.RemoveAt(i);
                        }
                    }
                    listterms.Clear();
                    foreach (string item in ListBox1.Items)
                    {
                        listterms.Add(item as string);
                    }

                    clCount = listterms.Count;
                    if (clCount > 0)
                    {
                        ListBox1.Items.Clear();
                        clpost = new string[clCount];
                        for (int i = 0; i < clCount; i++)
                        {
                            /* here you have key and value element */
                            string key = listterms[i];
                            clpost[i] = key.ToString();
                            string[] split = key.Split(' ');
                            // empty 
                            foreach (string item in split)
                            {
                                char[] charSeparators = new char[] { ' ' };
                                // using the method 
                                string[] wordSearched = item.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                for (int ctWords = 0; ctWords < wordSearched.Length; ++ctWords)
                                {

                                    ListBox1.Items.Add(wordSearched[ctWords]);
                                }
                            }
                        }

                    }
                    int num = ListBox1.Items.Count;
                    for (int k = num - 1; k >= 0; k = k - 3)
                    {

                        ListBox1.Items.RemoveAt(k);

                    }
                    string[] arr = new string[ListBox1.Items.Count];
                    ListBox1.Items.CopyTo(arr, 0);
                    //DETECTING THE SAME NODES and ADDING DIFFERENT NODES TO THE ARRAY
                    var arr2 = arr.Distinct();                    
                    ListBox1.Items.Clear();
                    foreach (string s in arr2)
                    {
                        ListBox1.Items.Add(s);
                    }
                    int last = ListBox1.Items.Count;
                    int[] newdizi= new int[last];
                    int y = 0;
                    foreach (string arrayNo in arr2)
                    {
                        int a = Convert.ToInt32(arrayNo);
                        newdizi[y] = a;
                        y++;
                    }                                    
                    int[] refArray = new int[last];
                    string[] refArrayName = new string[last];
                    int m = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        if (imge.rf.array[i] != 0)
                        {
                            //RefArray[m] = Index of Array Obtained from AppliedRefactoringTechniques Class ;
                            refArray[m] = i+1; 
                            switch (refArray[m])
                            {
                                case 1:
                                    refArrayName[m] = "Encapsulate Field";
                                    m++;
                                    break;
                                case 2:
                                    refArrayName[m] = "Simplify Nested Loop";
                                    m++;
                                    break;
                                case 3:
                                    refArrayName[m] = "Inline Temp";
                                    m++;
                                    break;
                                case 4:
                                    refArrayName[m] = "Introduce Explaining Variable";
                                    m++;
                                    break;
                                case 5:
                                    refArrayName[m] = "Replace Magic Number Symbolic Constant";
                                    m++;
                                    break;
                                case 6:
                                    refArrayName[m] = "Consolidate Duplicate Conditional Fragments";
                                    m++;
                                    break;
                                case 7:
                                    refArrayName[m] = "Hide Method";
                                    m++;
                                    break;
                                
                            }
                        }
                    }
                    //Displaying the OPTIMAL ORDER obtained to the USER
                    List<string> refOrderMessage = new List<string>();
                    List<string> refOrderSave = new List<string>();
                    for (int i = 0; i < m; i++)
                    {
                        refOrderMessage.Add("R" + refArray[newdizi[i] - 1].ToString() + " ");
                        refOrderSave.Add("R" + refArray[newdizi[i] - 1].ToString() + " " + refArrayName[newdizi[i] - 1].ToString() + "\n");
                    }
                    var message = string.Join(" ", refOrderMessage);
                    var orderList = string.Join("",refOrderSave);
                    if (message != null)
                    {
                        MessageBox.Show(message);
                        string filenameR = Path.GetFileName(pathR);
                        string[] arrR = filenameR.Split('.');
                        string resultR = arrR[0];

                        string refPath = @"C:\refactoring\";
                        string pathName = resultR;
                        string newPathRefCode = refPath + pathName + "." + "txt";
                        FileInfo fi = new FileInfo(newPathRefCode);
                        // Check if file already exists. If yes, delete it.     
                        if (fi.Exists)
                        {
                            fi.Delete();
                        }
                        // Create a Optimal Order file     
                        using (FileStream fs = fi.Create())
                        {
                            MessageBox.Show("Optimal Order Has Been Saved.");

                            fs.Flush();
                            fs.Close();
                            fs.Dispose();
                        }
                        File.WriteAllText(newPathRefCode, orderList);
                    }
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        //Clear All Controls
        private void Clear_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            ListBox3.Items.Clear();
            RichTextBox1.Clear();
            PictureBox1.Image = null;
            pathR = " ";
        }
    }
}
