namespace fileApp
{
    partial class Complexity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtBox_metric = new System.Windows.Forms.TextBox();
            this.RichtxBox_Data = new System.Windows.Forms.RichTextBox();
            this.getFileData = new System.Windows.Forms.Button();
            this.Raw_Code_Metric = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.dataGridView_Metric_Data = new System.Windows.Forms.DataGridView();
            this.locMetric = new System.Windows.Forms.Button();
            this.locMetrikOpen = new System.Windows.Forms.Button();
            this.ComplexityRefactorMetrikSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.R7 = new System.Windows.Forms.RadioButton();
            this.R6 = new System.Windows.Forms.RadioButton();
            this.R5 = new System.Windows.Forms.RadioButton();
            this.R4 = new System.Windows.Forms.RadioButton();
            this.R3 = new System.Windows.Forms.RadioButton();
            this.R2 = new System.Windows.Forms.RadioButton();
            this.R1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Metric_Data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtBox_metric
            // 
            this.TxtBox_metric.Location = new System.Drawing.Point(1303, 248);
            this.TxtBox_metric.Name = "TxtBox_metric";
            this.TxtBox_metric.Size = new System.Drawing.Size(106, 20);
            this.TxtBox_metric.TabIndex = 8;
            // 
            // RichtxBox_Data
            // 
            this.RichtxBox_Data.Location = new System.Drawing.Point(30, 44);
            this.RichtxBox_Data.Name = "RichtxBox_Data";
            this.RichtxBox_Data.Size = new System.Drawing.Size(444, 555);
            this.RichtxBox_Data.TabIndex = 7;
            this.RichtxBox_Data.Text = "";
            // 
            // getFileData
            // 
            this.getFileData.Location = new System.Drawing.Point(30, 15);
            this.getFileData.Name = "getFileData";
            this.getFileData.Size = new System.Drawing.Size(80, 23);
            this.getFileData.TabIndex = 6;
            this.getFileData.Text = "Get Code";
            this.getFileData.UseVisualStyleBackColor = true;
            this.getFileData.Click += new System.EventHandler(this.GetData_Click);
            // 
            // Raw_Code_Metric
            // 
            this.Raw_Code_Metric.Location = new System.Drawing.Point(1303, 274);
            this.Raw_Code_Metric.Name = "Raw_Code_Metric";
            this.Raw_Code_Metric.Size = new System.Drawing.Size(106, 36);
            this.Raw_Code_Metric.TabIndex = 5;
            this.Raw_Code_Metric.Text = "Save Metric (Original Code)";
            this.Raw_Code_Metric.UseVisualStyleBackColor = true;
            this.Raw_Code_Metric.Click += new System.EventHandler(this.Original_Code_Metric_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(1070, 613);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 9;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // dataGridView_Metric_Data
            // 
            this.dataGridView_Metric_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Metric_Data.Location = new System.Drawing.Point(492, 44);
            this.dataGridView_Metric_Data.Name = "dataGridView_Metric_Data";
            this.dataGridView_Metric_Data.Size = new System.Drawing.Size(653, 555);
            this.dataGridView_Metric_Data.TabIndex = 10;
            this.dataGridView_Metric_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Metric_Data_CellClick);
            this.dataGridView_Metric_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView_Metric_Data.SelectionChanged += new System.EventHandler(this.dataGridView_Metric_Data_SelectionChanged);
            // 
            // locMetric
            // 
            this.locMetric.Location = new System.Drawing.Point(1019, 12);
            this.locMetric.Name = "locMetric";
            this.locMetric.Size = new System.Drawing.Size(126, 23);
            this.locMetric.TabIndex = 11;
            this.locMetric.Text = "LocMetrics Fetch Data";
            this.locMetric.UseVisualStyleBackColor = true;
            this.locMetric.Click += new System.EventHandler(this.LocMetric_Click);
            // 
            // locMetrikOpen
            // 
            this.locMetrikOpen.Location = new System.Drawing.Point(492, 12);
            this.locMetrikOpen.Name = "locMetrikOpen";
            this.locMetrikOpen.Size = new System.Drawing.Size(102, 23);
            this.locMetrikOpen.TabIndex = 12;
            this.locMetrikOpen.Text = "Open LockMetrics ";
            this.locMetrikOpen.UseVisualStyleBackColor = true;
            this.locMetrikOpen.Click += new System.EventHandler(this.LocMetrikOpen_Click);
            // 
            // ComplexityRefactorMetrikSave
            // 
            this.ComplexityRefactorMetrikSave.Location = new System.Drawing.Point(1292, 316);
            this.ComplexityRefactorMetrikSave.Name = "ComplexityRefactorMetrikSave";
            this.ComplexityRefactorMetrikSave.Size = new System.Drawing.Size(126, 36);
            this.ComplexityRefactorMetrikSave.TabIndex = 27;
            this.ComplexityRefactorMetrikSave.Text = "Save Metric (Refactored Code)";
            this.ComplexityRefactorMetrikSave.UseVisualStyleBackColor = true;
            this.ComplexityRefactorMetrikSave.Click += new System.EventHandler(this.ComplexityRefactorMetricSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.R7);
            this.groupBox1.Controls.Add(this.R6);
            this.groupBox1.Controls.Add(this.R5);
            this.groupBox1.Controls.Add(this.R4);
            this.groupBox1.Controls.Add(this.R3);
            this.groupBox1.Controls.Add(this.R2);
            this.groupBox1.Controls.Add(this.R1);
            this.groupBox1.Location = new System.Drawing.Point(1151, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refactoring Techniques";
            // 
            // R7
            // 
            this.R7.AutoSize = true;
            this.R7.Location = new System.Drawing.Point(17, 162);
            this.R7.Name = "R7";
            this.R7.Size = new System.Drawing.Size(86, 17);
            this.R7.TabIndex = 6;
            this.R7.TabStop = true;
            this.R7.Text = "Hide Method";
            this.R7.UseVisualStyleBackColor = true;
            // 
            // R6
            // 
            this.R6.AutoSize = true;
            this.R6.Location = new System.Drawing.Point(17, 135);
            this.R6.Name = "R6";
            this.R6.Size = new System.Drawing.Size(235, 17);
            this.R6.TabIndex = 5;
            this.R6.TabStop = true;
            this.R6.Text = "Consolidate Duplicate Conditional Fragments";
            this.R6.UseVisualStyleBackColor = true;
            // 
            // R5
            // 
            this.R5.AutoSize = true;
            this.R5.Location = new System.Drawing.Point(17, 112);
            this.R5.Name = "R5";
            this.R5.Size = new System.Drawing.Size(249, 17);
            this.R5.TabIndex = 4;
            this.R5.TabStop = true;
            this.R5.Text = "Replace Magic Number with Symbolic Constant";
            this.R5.UseVisualStyleBackColor = true;
            // 
            // R4
            // 
            this.R4.AutoSize = true;
            this.R4.Location = new System.Drawing.Point(17, 89);
            this.R4.Name = "R4";
            this.R4.Size = new System.Drawing.Size(162, 17);
            this.R4.TabIndex = 3;
            this.R4.TabStop = true;
            this.R4.Text = "Introduce Explaining Variable";
            this.R4.UseVisualStyleBackColor = true;
            // 
            // R3
            // 
            this.R3.AutoSize = true;
            this.R3.Location = new System.Drawing.Point(17, 66);
            this.R3.Name = "R3";
            this.R3.Size = new System.Drawing.Size(80, 17);
            this.R3.TabIndex = 2;
            this.R3.TabStop = true;
            this.R3.Text = "Inline Temp";
            this.R3.UseVisualStyleBackColor = true;
            // 
            // R2
            // 
            this.R2.AutoSize = true;
            this.R2.Location = new System.Drawing.Point(17, 43);
            this.R2.Name = "R2";
            this.R2.Size = new System.Drawing.Size(124, 17);
            this.R2.TabIndex = 1;
            this.R2.TabStop = true;
            this.R2.Text = "Simplify Nested Loop";
            this.R2.UseVisualStyleBackColor = true;
            // 
            // R1
            // 
            this.R1.AutoSize = true;
            this.R1.Location = new System.Drawing.Point(17, 19);
            this.R1.Name = "R1";
            this.R1.Size = new System.Drawing.Size(109, 17);
            this.R1.TabIndex = 0;
            this.R1.TabStop = true;
            this.R1.Text = "Encapsulate Field";
            this.R1.UseVisualStyleBackColor = true;
            // 
            // Complexity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 648);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComplexityRefactorMetrikSave);
            this.Controls.Add(this.locMetrikOpen);
            this.Controls.Add(this.locMetric);
            this.Controls.Add(this.dataGridView_Metric_Data);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.TxtBox_metric);
            this.Controls.Add(this.RichtxBox_Data);
            this.Controls.Add(this.getFileData);
            this.Controls.Add(this.Raw_Code_Metric);
            this.MaximizeBox = false;
            this.Name = "Complexity";
            this.Text = "complexity";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Metric_Data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBox_metric;
        private System.Windows.Forms.RichTextBox RichtxBox_Data;
        private System.Windows.Forms.Button getFileData;
        private System.Windows.Forms.Button Raw_Code_Metric;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.DataGridView dataGridView_Metric_Data;
        private System.Windows.Forms.Button locMetric;
        private System.Windows.Forms.Button locMetrikOpen;
        private System.Windows.Forms.Button ComplexityRefactorMetrikSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton R7;
        private System.Windows.Forms.RadioButton R6;
        private System.Windows.Forms.RadioButton R5;
        private System.Windows.Forms.RadioButton R4;
        private System.Windows.Forms.RadioButton R3;
        private System.Windows.Forms.RadioButton R2;
        private System.Windows.Forms.RadioButton R1;
    }
}