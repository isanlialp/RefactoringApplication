namespace fileApp
{
    partial class MaintainabilityIndex
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
            this.mainIndex = new System.Windows.Forms.Button();
            this.statementRefactorMetrikSave = new System.Windows.Forms.Button();
            this.Tx_Bx_Metric = new System.Windows.Forms.TextBox();
            this.normal_code_metrik = new System.Windows.Forms.Button();
            this.ButtonBring = new System.Windows.Forms.Button();
            this.rtxMtbIndex = new System.Windows.Forms.RichTextBox();
            this.fileName = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            // mainIndex
            // 
            this.mainIndex.Location = new System.Drawing.Point(594, 12);
            this.mainIndex.Name = "mainIndex";
            this.mainIndex.Size = new System.Drawing.Size(158, 23);
            this.mainIndex.TabIndex = 4;
            this.mainIndex.Text = "Developer Command Prompt";
            this.mainIndex.UseVisualStyleBackColor = true;
            this.mainIndex.Click += new System.EventHandler(this.MainIndex_Click);
            // 
            // statementRefactorMetrikSave
            // 
            this.statementRefactorMetrikSave.Location = new System.Drawing.Point(1184, 345);
            this.statementRefactorMetrikSave.Name = "statementRefactorMetrikSave";
            this.statementRefactorMetrikSave.Size = new System.Drawing.Size(126, 36);
            this.statementRefactorMetrikSave.TabIndex = 39;
            this.statementRefactorMetrikSave.Text = "Save Metric (Refactored Code)";
            this.statementRefactorMetrikSave.UseVisualStyleBackColor = true;
            this.statementRefactorMetrikSave.Click += new System.EventHandler(this.MIRefactorMetricSave_Click);
            // 
            // Tx_Bx_Metric
            // 
            this.Tx_Bx_Metric.Location = new System.Drawing.Point(1196, 271);
            this.Tx_Bx_Metric.Name = "Tx_Bx_Metric";
            this.Tx_Bx_Metric.Size = new System.Drawing.Size(106, 20);
            this.Tx_Bx_Metric.TabIndex = 38;
            // 
            // normal_code_metrik
            // 
            this.normal_code_metrik.Location = new System.Drawing.Point(1196, 303);
            this.normal_code_metrik.Name = "normal_code_metrik";
            this.normal_code_metrik.Size = new System.Drawing.Size(106, 36);
            this.normal_code_metrik.TabIndex = 37;
            this.normal_code_metrik.Text = "Save Metric (Original Code)";
            this.normal_code_metrik.UseVisualStyleBackColor = true;
            this.normal_code_metrik.Click += new System.EventHandler(this.Original_Code_Metric_Click);
            // 
            // ButtonBring
            // 
            this.ButtonBring.Location = new System.Drawing.Point(839, 493);
            this.ButtonBring.Name = "ButtonBring";
            this.ButtonBring.Size = new System.Drawing.Size(130, 23);
            this.ButtonBring.TabIndex = 40;
            this.ButtonBring.Text = "Maintainability Index  ";
            this.ButtonBring.UseVisualStyleBackColor = true;
            this.ButtonBring.Click += new System.EventHandler(this.BtnGetMetric_Click);
            // 
            // rtxMtbIndex
            // 
            this.rtxMtbIndex.Location = new System.Drawing.Point(12, 54);
            this.rtxMtbIndex.Name = "rtxMtbIndex";
            this.rtxMtbIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtxMtbIndex.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtxMtbIndex.Size = new System.Drawing.Size(740, 477);
            this.rtxMtbIndex.TabIndex = 42;
            this.rtxMtbIndex.Text = "";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(856, 23);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(75, 23);
            this.fileName.TabIndex = 43;
            this.fileName.Text = "File Name";
            this.fileName.UseVisualStyleBackColor = true;
            this.fileName.Click += new System.EventHandler(this.FileName_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(771, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(255, 368);
            this.listBox1.TabIndex = 44;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(836, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Selected Name for Metric ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(815, 453);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Open Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(1042, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 49;
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
            // MaintainabilityIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 570);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.rtxMtbIndex);
            this.Controls.Add(this.ButtonBring);
            this.Controls.Add(this.statementRefactorMetrikSave);
            this.Controls.Add(this.Tx_Bx_Metric);
            this.Controls.Add(this.normal_code_metrik);
            this.Controls.Add(this.mainIndex);
            this.MaximizeBox = false;
            this.Name = "MaintainabilityIndex";
            this.Text = "maintainabilityIndex";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mainIndex;
        private System.Windows.Forms.Button statementRefactorMetrikSave;
        private System.Windows.Forms.TextBox Tx_Bx_Metric;
        private System.Windows.Forms.Button normal_code_metrik;
        private System.Windows.Forms.Button ButtonBring;
        public System.Windows.Forms.RichTextBox rtxMtbIndex;
        private System.Windows.Forms.Button fileName;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
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