using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace fileApp
{
    public partial class Complexity : Form
    {
        Process locProcess = new Process();
        public Main complex = new Main();
        public string filePath;
        public string fileName;
        public string yl = null;
        public Complexity()
        {
            InitializeComponent();
            this.dataGridView_Metric_Data.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(DataGridView_Metric_Data_RowStateChanged);
        }
        // CREATE EXCEL OBJECTS.
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;

        private void GetData_Click(object sender, EventArgs e)
        {
            RichtxBox_Data.Text = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\refactoring\";
            string line = "";
            RichtxBox_Data.Text = "";
            openFile.Filter = "code files (.cs)| *.cs|java files (*.java)|*.java";
            var content = String.Empty;
            try
            {
                yl = ButtonFileSelect();
                if (yl.Length > 0)
                {
                    // Open File
                    FileStream fileStream = new FileStream(
                                        yl, FileMode.OpenOrCreate,
                                           FileAccess.ReadWrite, FileShare.None);
                    if (fileStream.Length > 0)
                    {

                        StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);                        
                        while (line != null)
                        {
                            // Add Code To text
                            line = streamReader.ReadLine();

                            if (line != null)
                            {
                                RichtxBox_Data.Text += line.ToString() + "\n";
                            }
                        }
                    }
                    fileStream.Close();
                }
            }
            catch (NullReferenceException n)
            {
                // Do something with e, please.
                MessageBox.Show("Selected Null Path ", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string ButtonFileSelect()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = @"C:\refactoring\";
            file.Filter = "ode files (.cs)| *.cs|java files (*.java)|*.java";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Select File";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // SELECTED FILE ATRIBUTES
                filePath = file.FileName;
                fileName = file.SafeFileName;

            }
            return filePath;
        }
        private void LocMetrikOpen_Click(object sender, EventArgs e)
        {
            try
            {
                locProcess.StartInfo.UseShellExecute = true;
                // You can start any process, HelloWorld is a do-nothing example.
                locProcess.StartInfo.FileName = @"C:\Users\santo\Desktop\tezCalısma\code analiz(complexity)\locMetric\locMetrics\LocMetrics.exe";
                locProcess.StartInfo.CreateNoWindow = true;
                locProcess.Start();
                // This code assumes the process you are starting will terminate itself.
                // Given that is is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
                // locProcess.Kill();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
        }
        string sFileName;
        // OPEN FILE DIALOG AND SELECT AN EXCEL FILE.
        private void LocMetric_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Excel File to Edit";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Filter = "Excel File|*.xlsx;*.xls;*.csv";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = OpenFileDialog1.FileName;

                if (sFileName.Trim() != "")
                {
                    Excel2Grid(sFileName);
                }
            }
        }    
        // IMPORT DATA FROM EXCEL AND POPULATE THE GRID.
        private void Excel2Grid(string sFile)
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(sFile);               // WORKBOOK TO OPEN THE EXCEL FILE.
            xlWorkSheet = xlWorkBook.Worksheets[1];          // THE SHEET WITH THE DATA.
            dataGridView_Metric_Data.Rows.Clear();
            dataGridView_Metric_Data.Columns.Clear();
            int iRow, iCol;
            // FIRST, CREATE THE DataGridView COLUMN HEADERS.
            for (iCol = 1; iCol <= xlWorkSheet.Columns.Count; iCol++)
            {
                if (xlWorkSheet.Cells[1, iCol].value == null)
                {
                    break;      // BREAK LOOP.
                }
                else
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = xlWorkSheet.Cells[1, iCol].value;
                    int colIndex = dataGridView_Metric_Data.Columns.Add(col);        // ADD A NEW COLUMN.
                }
            }
            // ADD A BUTTON AT THE LAST COLUMN IN EVERY ROW.
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "";
            btn.Text = "Save Data";
            btn.Name = "btSave";
            btn.UseColumnTextForButtonValue = true;
            dataGridView_Metric_Data.Columns.Add(btn);
            // ADD ROWS TO THE GRID USING EXCEL DATA.
            for (iRow = 2; iCol <= xlWorkSheet.Rows.Count; iRow++)
            {
                if (xlWorkSheet.Cells[iRow, 1].value == null)
                {
                    break;      // BREAK LOOP.
                }
                else
                {
                    // CREATE A STRING ARRAY USING THE VALUES IN EACH ROW OF THE SHEET.
                    string[] row = new string[] { xlWorkSheet.Cells[iRow, 1].value.ToString(),
                    xlWorkSheet.Cells[iRow, 2].value.ToString(),
                    xlWorkSheet.Cells[iRow, 3].value.ToString(),xlWorkSheet.Cells[iRow, 4].value.ToString(),xlWorkSheet.Cells[iRow, 5].value.ToString(),
                    xlWorkSheet.Cells[iRow, 6].value.ToString(),xlWorkSheet.Cells[iRow, 7].value.ToString(),xlWorkSheet.Cells[iRow, 8].value.ToString(),
                    xlWorkSheet.Cells[iRow, 9].value.ToString(),xlWorkSheet.Cells[iRow, 10].value.ToString(),xlWorkSheet.Cells[iRow, 11].value.ToString()};
                    // ADD A NEW ROW TO THE GRID USING THE ARRAY DATA.
                    dataGridView_Metric_Data.Rows.Add(row);
                }
            }
            TxtBox_metric.Text = dataGridView_Metric_Data.Rows[0].Cells[4].Value.ToString();
            xlWorkBook.Close();
            xlApp.Quit();
            // CLEAN UP.
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");     // MOVE NEXT CELL WHEN YOU PRESS ENTER KEY.
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }    
        // SAVE MODIFIED OR NEW DATA TO THE EXCEL SHEET.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // EVERY ROW HAS A BUTTON AT THE LAST COLUMN. 
            // SAVE THE DATA IN EXCEL AFTER CLICKING THE BUTTON.

            var ourGrid = (DataGridView)sender;
            if (ourGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(sFileName);   // WORKBOOK TO OPEN THE EXCEL FILE.
                xlWorkSheet = xlWorkBook.Worksheets[1];  // THE SHEET WITH THE DATA.

                // CHECK IF THE FIRST COLUMN IS ReadOnly. 
                // THIS IS TO ENSURE THAT YOU MODIFY EXISTING DATA IN EXCEL.

                if (dataGridView_Metric_Data.Rows[e.RowIndex].Cells[0].ReadOnly == true)
                {
                    string sXL = xlWorkSheet.Cells[e.RowIndex + 2, 1].value;
                    string sGrid = dataGridView_Metric_Data.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (sXL == sGrid)
                    {
                        // MODIFY THE DATA.
                        xlWorkSheet.Cells[e.RowIndex + 2, 2].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[1].Value;  // SECOND COLUMN.
                        xlWorkSheet.Cells[e.RowIndex + 2, 3].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[2].Value;  // THIRD COLUMN.
                        xlWorkSheet.Cells[e.RowIndex + 2, 4].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[3].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 5].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[4].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 6].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[5].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 7].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[6].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 8].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[7].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 9].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[8].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 10].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[9].Value;
                        xlWorkSheet.Cells[e.RowIndex + 2, 11].value =
                            dataGridView_Metric_Data.Rows[e.RowIndex].Cells[10].Value;
                    }
                }
                else
                {
                    // ADD NEW DATA IN A NEW ROW IN EXCEL.
                    xlWorkSheet.Cells[e.RowIndex + 2, 1].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[0].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 2].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[1].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 3].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[2].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 4].value =
                    dataGridView_Metric_Data.Rows[e.RowIndex].Cells[2].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 5].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[3].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 6].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[4].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 7].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[5].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 8].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[6].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 9].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[7].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 10].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[8].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 11].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[9].Value;
                    xlWorkSheet.Cells[e.RowIndex + 2, 12].value =
                        dataGridView_Metric_Data.Rows[e.RowIndex].Cells[10].Value;
                }

                xlWorkBook.Close();
                xlApp.Quit();
                // CLEAN UP.
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            }
        }
        // CHANGE THE COLOR OF VALUES IN THE FIRST COLUMN. MAKE THE VALUES REALONLY (CANNOT CHANGE).
        private void DataGridView_Metric_Data_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Cells[0].Value != null)
            {
                e.Row.Cells[0].Style.ForeColor = Color.Gray;
                e.Row.Cells[0].ReadOnly = true;
            }
        }
        private void dataGridView_Metric_Data_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_Metric_Data.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView_Metric_Data.DefaultCellStyle.SelectionBackColor = Color.Aqua;

        }
        private void dataGridView_Metric_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtBox_metric.Text = dataGridView_Metric_Data.Rows[e.RowIndex].Cells[4].Value.ToString();
            // then perform your select statement according to that label.
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            RichtxBox_Data.Clear();
            TxtBox_metric.Clear();
            dataGridView_Metric_Data.Rows.Clear();
            dataGridView_Metric_Data.Columns.Clear();
        }
        private void Original_Code_Metric_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtBox_metric.Text))
            {
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE.", "Cyclomatic Complexity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                float complexNormData = float.Parse(TxtBox_metric.Text);
                complex.WriteOriginalCodeMetric(complexNormData, 2, 5);
            }
        }
        private void ComplexityRefactorMetricSave_Click(object sender, EventArgs e)
        {
            var allRadios = from RadioButton r in groupBox1.Controls where r.Checked == true select r.Name;
            var allRname = groupBox1.Controls.OfType<RadioButton>();
            bool anyChecked = allRname.Any(rb => rb.Checked);
            if (String.IsNullOrEmpty(TxtBox_metric.Text) || (anyChecked == false))
            {              
                MessageBox.Show("FAILED TO CALCULATE METRIC VALUE:\nPlease, Upload Source Code Using the Button named GET CODE and Select the Refactoring Technique you want to measure.", "Cyclomatic Complexity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                float refData = float.Parse(TxtBox_metric.Text);
                complex.WriteRefaCodeMetricExcel(refData, row, 5);
            }
        }
    }
}
