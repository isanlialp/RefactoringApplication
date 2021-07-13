namespace fileApp
{
    partial class Coupling
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
            this.RtxCoupling = new System.Windows.Forms.RichTextBox();
            this.ButtonXml = new System.Windows.Forms.Button();
            this.CouplingRefactorMetricSave = new System.Windows.Forms.Button();
            this.TxtCoupling = new System.Windows.Forms.TextBox();
            this.CouplingOriginalMetricSave = new System.Windows.Forms.Button();
            this.Button_Clear = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.MetricName = new System.Windows.Forms.Label();
            this.TxtFileName = new System.Windows.Forms.TextBox();
            this.BtnGet = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.DevCommandProCoupling = new System.Windows.Forms.Button();
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
            // RtxCoupling
            // 
            this.RtxCoupling.Location = new System.Drawing.Point(34, 41);
            this.RtxCoupling.Name = "RtxCoupling";
            this.RtxCoupling.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RtxCoupling.Size = new System.Drawing.Size(740, 477);
            this.RtxCoupling.TabIndex = 4;
            this.RtxCoupling.Text = "";
            // 
            // ButtonXml
            // 
            this.ButtonXml.Location = new System.Drawing.Point(34, 12);
            this.ButtonXml.Name = "ButtonXml";
            this.ButtonXml.Size = new System.Drawing.Size(74, 23);
            this.ButtonXml.TabIndex = 3;
            this.ButtonXml.Text = "Get Code";
            this.ButtonXml.UseVisualStyleBackColor = true;
            this.ButtonXml.Click += new System.EventHandler(this.ButtonXml_Click);
            // 
            // CouplingRefactorMetricSave
            // 
            this.CouplingRefactorMetricSave.Location = new System.Drawing.Point(1195, 323);
            this.CouplingRefactorMetricSave.Name = "CouplingRefactorMetricSave";
            this.CouplingRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.CouplingRefactorMetricSave.TabIndex = 33;
            this.CouplingRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.CouplingRefactorMetricSave.UseVisualStyleBackColor = true;
            this.CouplingRefactorMetricSave.Click += new System.EventHandler(this.CouplingRefactorMetricSave_Click);
            // 
            // TxtCoupling
            // 
            this.TxtCoupling.Location = new System.Drawing.Point(1205, 246);
            this.TxtCoupling.Name = "TxtCoupling";
            this.TxtCoupling.Size = new System.Drawing.Size(106, 20);
            this.TxtCoupling.TabIndex = 32;
            // 
            // CouplingOriginalMetricSave
            // 
            this.CouplingOriginalMetricSave.Location = new System.Drawing.Point(1205, 281);
            this.CouplingOriginalMetricSave.Name = "CouplingOriginalMetricSave";
            this.CouplingOriginalMetricSave.Size = new System.Drawing.Size(106, 36);
            this.CouplingOriginalMetricSave.TabIndex = 31;
            this.CouplingOriginalMetricSave.Text = "Save Metric (Original Code)";
            this.CouplingOriginalMetricSave.UseVisualStyleBackColor = true;
            this.CouplingOriginalMetricSave.Click += new System.EventHandler(this.CouplingOriginalMetricSave_Click);
            // 
            // Button_Clear
            // 
            this.Button_Clear.Location = new System.Drawing.Point(700, 524);
            this.Button_Clear.Name = "Button_Clear";
            this.Button_Clear.Size = new System.Drawing.Size(75, 23);
            this.Button_Clear.TabIndex = 34;
            this.Button_Clear.Text = "Clear";
            this.Button_Clear.UseVisualStyleBackColor = true;
            this.Button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.HorizontalScrollbar = true;
            this.ListBox1.Location = new System.Drawing.Point(786, 40);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.ScrollAlwaysVisible = true;
            this.ListBox1.Size = new System.Drawing.Size(255, 368);
            this.ListBox1.TabIndex = 35;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // MetricName
            // 
            this.MetricName.AutoSize = true;
            this.MetricName.Location = new System.Drawing.Point(849, 425);
            this.MetricName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MetricName.Name = "MetricName";
            this.MetricName.Size = new System.Drawing.Size(133, 13);
            this.MetricName.TabIndex = 36;
            this.MetricName.Text = "Selected Name for Metric  ";
            // 
            // TxtFileName
            // 
            this.TxtFileName.Location = new System.Drawing.Point(838, 450);
            this.TxtFileName.Multiline = true;
            this.TxtFileName.Name = "TxtFileName";
            this.TxtFileName.Size = new System.Drawing.Size(158, 20);
            this.TxtFileName.TabIndex = 37;
            // 
            // BtnGet
            // 
            this.BtnGet.Location = new System.Drawing.Point(878, 494);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(75, 23);
            this.BtnGet.TabIndex = 38;
            this.BtnGet.Text = "Coupling";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(880, 11);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(63, 23);
            this.Button2.TabIndex = 39;
            this.Button2.Text = "File";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DevCommandProCoupling
            // 
            this.DevCommandProCoupling.Location = new System.Drawing.Point(617, 12);
            this.DevCommandProCoupling.Name = "DevCommandProCoupling";
            this.DevCommandProCoupling.Size = new System.Drawing.Size(158, 23);
            this.DevCommandProCoupling.TabIndex = 40;
            this.DevCommandProCoupling.Text = "Developer Command Prompt";
            this.DevCommandProCoupling.UseVisualStyleBackColor = true;
            this.DevCommandProCoupling.Click += new System.EventHandler(this.DevCommandProCoupling_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(1052, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 41;
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
            // Coupling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 556);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DevCommandProCoupling);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.BtnGet);
            this.Controls.Add(this.TxtFileName);
            this.Controls.Add(this.MetricName);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Button_Clear);
            this.Controls.Add(this.CouplingRefactorMetricSave);
            this.Controls.Add(this.TxtCoupling);
            this.Controls.Add(this.CouplingOriginalMetricSave);
            this.Controls.Add(this.RtxCoupling);
            this.Controls.Add(this.ButtonXml);
            this.MaximizeBox = false;
            this.Name = "Coupling";
            this.Text = "coupling";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtxCoupling;
        private System.Windows.Forms.Button ButtonXml;
        private System.Windows.Forms.Button CouplingRefactorMetricSave;
        private System.Windows.Forms.TextBox TxtCoupling;
        private System.Windows.Forms.Button CouplingOriginalMetricSave;
        private System.Windows.Forms.Button Button_Clear;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Label MetricName;
        private System.Windows.Forms.TextBox TxtFileName;
        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button DevCommandProCoupling;
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