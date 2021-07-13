namespace fileApp
{
    partial class CouplingJava
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
            this.CouplingRefactorMetricSave = new System.Windows.Forms.Button();
            this.TxtCoupling = new System.Windows.Forms.TextBox();
            this.CouplingRawMetricSave = new System.Windows.Forms.Button();
            this.JHawkOpen = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.RichTextBox_Data = new System.Windows.Forms.RichTextBox();
            this.fileFetch = new System.Windows.Forms.Button();
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
            // CouplingRefactorMetricSave
            // 
            this.CouplingRefactorMetricSave.Location = new System.Drawing.Point(607, 328);
            this.CouplingRefactorMetricSave.Name = "CouplingRefactorMetricSave";
            this.CouplingRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.CouplingRefactorMetricSave.TabIndex = 36;
            this.CouplingRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.CouplingRefactorMetricSave.UseVisualStyleBackColor = true;
            this.CouplingRefactorMetricSave.Click += new System.EventHandler(this.CouplingRefactorMetricSave_Click);
            // 
            // TxtCoupling
            // 
            this.TxtCoupling.Location = new System.Drawing.Point(618, 260);
            this.TxtCoupling.Name = "TxtCoupling";
            this.TxtCoupling.Size = new System.Drawing.Size(106, 20);
            this.TxtCoupling.TabIndex = 35;
            // 
            // CouplingRawMetricSave
            // 
            this.CouplingRawMetricSave.Location = new System.Drawing.Point(618, 286);
            this.CouplingRawMetricSave.Name = "CouplingRawMetricSave";
            this.CouplingRawMetricSave.Size = new System.Drawing.Size(106, 36);
            this.CouplingRawMetricSave.TabIndex = 34;
            this.CouplingRawMetricSave.Text = "Save Metric (Original Code)";
            this.CouplingRawMetricSave.UseVisualStyleBackColor = true;
            this.CouplingRawMetricSave.Click += new System.EventHandler(this.CouplingOriginalMetricSave_Click);
            // 
            // JHawkOpen
            // 
            this.JHawkOpen.Location = new System.Drawing.Point(354, 20);
            this.JHawkOpen.Name = "JHawkOpen";
            this.JHawkOpen.Size = new System.Drawing.Size(102, 23);
            this.JHawkOpen.TabIndex = 40;
            this.JHawkOpen.Text = "Open JHawk";
            this.JHawkOpen.UseVisualStyleBackColor = true;
            this.JHawkOpen.Click += new System.EventHandler(this.JHawkOpen_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(381, 610);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 39;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // RichTextBox_Data
            // 
            this.RichTextBox_Data.Location = new System.Drawing.Point(12, 49);
            this.RichTextBox_Data.Name = "RichTextBox_Data";
            this.RichTextBox_Data.Size = new System.Drawing.Size(444, 555);
            this.RichTextBox_Data.TabIndex = 38;
            this.RichTextBox_Data.Text = "";
            // 
            // fileFetch
            // 
            this.fileFetch.Location = new System.Drawing.Point(12, 20);
            this.fileFetch.Name = "fileFetch";
            this.fileFetch.Size = new System.Drawing.Size(75, 23);
            this.fileFetch.TabIndex = 37;
            this.fileFetch.Text = "Get Code";
            this.fileFetch.UseVisualStyleBackColor = true;
            this.fileFetch.Click += new System.EventHandler(this.FileOpen_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(470, 49);
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
            // CouplingJava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.JHawkOpen);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.RichTextBox_Data);
            this.Controls.Add(this.fileFetch);
            this.Controls.Add(this.CouplingRefactorMetricSave);
            this.Controls.Add(this.TxtCoupling);
            this.Controls.Add(this.CouplingRawMetricSave);
            this.MaximizeBox = false;
            this.Name = "CouplingJava";
            this.Text = "CouplingJava";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CouplingRefactorMetricSave;
        private System.Windows.Forms.TextBox TxtCoupling;
        private System.Windows.Forms.Button CouplingRawMetricSave;
        private System.Windows.Forms.Button JHawkOpen;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.RichTextBox RichTextBox_Data;
        private System.Windows.Forms.Button fileFetch;
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