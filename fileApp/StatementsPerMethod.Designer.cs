namespace fileApp
{
    partial class StatementsPerMethod
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
            this.OpenSourceCode = new System.Windows.Forms.Button();
            this.StatementRefactorMetricSave = new System.Windows.Forms.Button();
            this.TxtBox_metric = new System.Windows.Forms.TextBox();
            this.Original_Code_Metric = new System.Windows.Forms.Button();
            this.StatementsPerMeth = new System.Windows.Forms.Button();
            this.RtxtBoxSourceCodeData = new System.Windows.Forms.RichTextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.R7 = new System.Windows.Forms.RadioButton();
            this.R6 = new System.Windows.Forms.RadioButton();
            this.R5 = new System.Windows.Forms.RadioButton();
            this.R4 = new System.Windows.Forms.RadioButton();
            this.R3 = new System.Windows.Forms.RadioButton();
            this.R2 = new System.Windows.Forms.RadioButton();
            this.R1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenSourceCode
            // 
            this.OpenSourceCode.Location = new System.Drawing.Point(33, 29);
            this.OpenSourceCode.Name = "OpenSourceCode";
            this.OpenSourceCode.Size = new System.Drawing.Size(84, 23);
            this.OpenSourceCode.TabIndex = 13;
            this.OpenSourceCode.Text = "Get Code";
            this.OpenSourceCode.UseVisualStyleBackColor = true;
            this.OpenSourceCode.Click += new System.EventHandler(this.OpenSourceCode_Click);
            // 
            // StatementRefactorMetricSave
            // 
            this.StatementRefactorMetricSave.Location = new System.Drawing.Point(628, 333);
            this.StatementRefactorMetricSave.Name = "StatementRefactorMetricSave";
            this.StatementRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.StatementRefactorMetricSave.TabIndex = 30;
            this.StatementRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.StatementRefactorMetricSave.UseVisualStyleBackColor = true;
            this.StatementRefactorMetricSave.Click += new System.EventHandler(this.StatementRefactorMetricSave_Click);
            // 
            // TxtBox_metric
            // 
            this.TxtBox_metric.Location = new System.Drawing.Point(639, 265);
            this.TxtBox_metric.Name = "TxtBox_metric";
            this.TxtBox_metric.Size = new System.Drawing.Size(106, 20);
            this.TxtBox_metric.TabIndex = 29;
            // 
            // Original_Code_Metric
            // 
            this.Original_Code_Metric.Location = new System.Drawing.Point(639, 291);
            this.Original_Code_Metric.Name = "Original_Code_Metric";
            this.Original_Code_Metric.Size = new System.Drawing.Size(106, 36);
            this.Original_Code_Metric.TabIndex = 28;
            this.Original_Code_Metric.Text = "Save Metric (Original Code)";
            this.Original_Code_Metric.UseVisualStyleBackColor = true;
            this.Original_Code_Metric.Click += new System.EventHandler(this.Original_Code_Metric_Click);
            // 
            // StatementsPerMeth
            // 
            this.StatementsPerMeth.Location = new System.Drawing.Point(351, 29);
            this.StatementsPerMeth.Name = "StatementsPerMeth";
            this.StatementsPerMeth.Size = new System.Drawing.Size(126, 23);
            this.StatementsPerMeth.TabIndex = 32;
            this.StatementsPerMeth.Text = "Statements per Method";
            this.StatementsPerMeth.UseVisualStyleBackColor = true;
            this.StatementsPerMeth.Click += new System.EventHandler(this.StatementsPerMeth_Click);
            // 
            // RtxtBoxSourceCodeData
            // 
            this.RtxtBoxSourceCodeData.Location = new System.Drawing.Point(33, 58);
            this.RtxtBoxSourceCodeData.Name = "RtxtBoxSourceCodeData";
            this.RtxtBoxSourceCodeData.Size = new System.Drawing.Size(444, 555);
            this.RtxtBoxSourceCodeData.TabIndex = 33;
            this.RtxtBoxSourceCodeData.Text = "";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(402, 619);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 34;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(486, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 35;
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
            // StatementsPerMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 647);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.RtxtBoxSourceCodeData);
            this.Controls.Add(this.StatementsPerMeth);
            this.Controls.Add(this.StatementRefactorMetricSave);
            this.Controls.Add(this.TxtBox_metric);
            this.Controls.Add(this.Original_Code_Metric);
            this.Controls.Add(this.OpenSourceCode);
            this.Name = "StatementsPerMethod";
            this.Text = "Statements per Method";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenSourceCode;
        private System.Windows.Forms.Button StatementRefactorMetricSave;
        private System.Windows.Forms.TextBox TxtBox_metric;
        private System.Windows.Forms.Button Original_Code_Metric;
        private System.Windows.Forms.Button StatementsPerMeth;
        private System.Windows.Forms.RichTextBox RtxtBoxSourceCodeData;
        private System.Windows.Forms.Button Clear;
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