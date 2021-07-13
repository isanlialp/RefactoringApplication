namespace fileApp
{
    partial class LinesOfCode
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
            this.TxtMetricValue = new System.Windows.Forms.TextBox();
            this.BtnSaveOriginalCodeMetric = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.butonFile = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.CommentLineRefactorMetricSave = new System.Windows.Forms.Button();
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
            // TxtMetricValue
            // 
            this.TxtMetricValue.Location = new System.Drawing.Point(621, 252);
            this.TxtMetricValue.Name = "TxtMetricValue";
            this.TxtMetricValue.Size = new System.Drawing.Size(106, 20);
            this.TxtMetricValue.TabIndex = 6;
            // 
            // BtnSaveOriginalCodeMetric
            // 
            this.BtnSaveOriginalCodeMetric.Location = new System.Drawing.Point(621, 278);
            this.BtnSaveOriginalCodeMetric.Name = "BtnSaveOriginalCodeMetric";
            this.BtnSaveOriginalCodeMetric.Size = new System.Drawing.Size(106, 36);
            this.BtnSaveOriginalCodeMetric.TabIndex = 5;
            this.BtnSaveOriginalCodeMetric.Text = "Save Metric (Original Code)";
            this.BtnSaveOriginalCodeMetric.UseVisualStyleBackColor = true;
            this.BtnSaveOriginalCodeMetric.Click += new System.EventHandler(this.BtnSaveOriginalCodeMetric_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(63, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(386, 567);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // butonFile
            // 
            this.butonFile.Location = new System.Drawing.Point(63, 14);
            this.butonFile.Name = "butonFile";
            this.butonFile.Size = new System.Drawing.Size(79, 23);
            this.butonFile.TabIndex = 8;
            this.butonFile.Text = "Get Code";
            this.butonFile.UseVisualStyleBackColor = true;
            this.butonFile.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(374, 616);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 9;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // CommentLineRefactorMetricSave
            // 
            this.CommentLineRefactorMetricSave.Location = new System.Drawing.Point(610, 320);
            this.CommentLineRefactorMetricSave.Name = "CommentLineRefactorMetricSave";
            this.CommentLineRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.CommentLineRefactorMetricSave.TabIndex = 28;
            this.CommentLineRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.CommentLineRefactorMetricSave.UseVisualStyleBackColor = true;
            this.CommentLineRefactorMetricSave.Click += new System.EventHandler(this.LineOfCodeRefactorMetricSave_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(468, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 29;
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
            // LinesOfCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CommentLineRefactorMetricSave);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.butonFile);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TxtMetricValue);
            this.Controls.Add(this.BtnSaveOriginalCodeMetric);
            this.MaximizeBox = false;
            this.Name = "LinesOfCode";
            this.Text = "LOC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtMetricValue;
        private System.Windows.Forms.Button BtnSaveOriginalCodeMetric;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button butonFile;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button CommentLineRefactorMetricSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton R4;
        private System.Windows.Forms.RadioButton R3;
        private System.Windows.Forms.RadioButton R2;
        private System.Windows.Forms.RadioButton R1;
        private System.Windows.Forms.RadioButton R7;
        private System.Windows.Forms.RadioButton R6;
        private System.Windows.Forms.RadioButton R5;
    }
}