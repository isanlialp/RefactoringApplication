namespace fileApp
{
    partial class MaintainabilityIndexForJava
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
            this.ComplexityRefactorMetricSave = new System.Windows.Forms.Button();
            this.JHawkOpen = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.TextBox_metric = new System.Windows.Forms.TextBox();
            this.RichTextBox_Data = new System.Windows.Forms.RichTextBox();
            this.fileFetch = new System.Windows.Forms.Button();
            this.normal_code_metrik = new System.Windows.Forms.Button();
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
            // ComplexityRefactorMetricSave
            // 
            this.ComplexityRefactorMetricSave.Location = new System.Drawing.Point(615, 326);
            this.ComplexityRefactorMetricSave.Name = "ComplexityRefactorMetricSave";
            this.ComplexityRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.ComplexityRefactorMetricSave.TabIndex = 36;
            this.ComplexityRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.ComplexityRefactorMetricSave.UseVisualStyleBackColor = true;
            this.ComplexityRefactorMetricSave.Click += new System.EventHandler(this.ComplexityRefactorMetricSave_Click);
            // 
            // JHawkOpen
            // 
            this.JHawkOpen.Location = new System.Drawing.Point(359, 19);
            this.JHawkOpen.Name = "JHawkOpen";
            this.JHawkOpen.Size = new System.Drawing.Size(102, 23);
            this.JHawkOpen.TabIndex = 35;
            this.JHawkOpen.Text = "Open JHawk";
            this.JHawkOpen.UseVisualStyleBackColor = true;
            this.JHawkOpen.Click += new System.EventHandler(this.JHawkOpen_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(386, 609);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 32;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // textBox_metric
            // 
            this.TextBox_metric.Location = new System.Drawing.Point(625, 258);
            this.TextBox_metric.Name = "textBox_metric";
            this.TextBox_metric.Size = new System.Drawing.Size(106, 20);
            this.TextBox_metric.TabIndex = 31;
            // 
            // RichTextBox_Data
            // 
            this.RichTextBox_Data.Location = new System.Drawing.Point(17, 48);
            this.RichTextBox_Data.Name = "RichTextBox_Data";
            this.RichTextBox_Data.Size = new System.Drawing.Size(444, 555);
            this.RichTextBox_Data.TabIndex = 30;
            this.RichTextBox_Data.Text = "";
            // 
            // fileFetch
            // 
            this.fileFetch.Location = new System.Drawing.Point(17, 19);
            this.fileFetch.Name = "fileFetch";
            this.fileFetch.Size = new System.Drawing.Size(75, 23);
            this.fileFetch.TabIndex = 29;
            this.fileFetch.Text = "Get Code";
            this.fileFetch.UseVisualStyleBackColor = true;
            this.fileFetch.Click += new System.EventHandler(this.FileFetch_Click);
            // 
            // normal_code_metrik
            // 
            this.normal_code_metrik.Location = new System.Drawing.Point(625, 284);
            this.normal_code_metrik.Name = "normal_code_metrik";
            this.normal_code_metrik.Size = new System.Drawing.Size(106, 36);
            this.normal_code_metrik.TabIndex = 28;
            this.normal_code_metrik.Text = "Save Metric (Original Code)";
            this.normal_code_metrik.UseVisualStyleBackColor = true;
            this.normal_code_metrik.Click += new System.EventHandler(this.Original_Code_Metric_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(475, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 42;
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
            // MaintainabilityIndexForJava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComplexityRefactorMetricSave);
            this.Controls.Add(this.JHawkOpen);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.TextBox_metric);
            this.Controls.Add(this.RichTextBox_Data);
            this.Controls.Add(this.fileFetch);
            this.Controls.Add(this.normal_code_metrik);
            this.MaximizeBox = false;
            this.Name = "MaintainabilityIndexForJava";
            this.Text = "Maintainability Index For Java";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ComplexityRefactorMetricSave;
        private System.Windows.Forms.Button JHawkOpen;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox TextBox_metric;
        private System.Windows.Forms.RichTextBox RichTextBox_Data;
        private System.Windows.Forms.Button fileFetch;
        private System.Windows.Forms.Button normal_code_metrik;
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