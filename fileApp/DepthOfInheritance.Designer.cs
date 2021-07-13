namespace fileApp
{
    partial class DepthOfInheritance
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
            this.dataFetch = new System.Windows.Forms.Button();
            this.RtxtBox_Data = new System.Windows.Forms.RichTextBox();
            this.Txtinheritance = new System.Windows.Forms.TextBox();
            this.inheritanceNormalMetricSave = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.inheritanceNumRefactorMetricSave = new System.Windows.Forms.Button();
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
            // dataFetch
            // 
            this.dataFetch.Location = new System.Drawing.Point(24, 22);
            this.dataFetch.Name = "dataFetch";
            this.dataFetch.Size = new System.Drawing.Size(78, 23);
            this.dataFetch.TabIndex = 16;
            this.dataFetch.Text = "Get Code";
            this.dataFetch.UseVisualStyleBackColor = true;
            this.dataFetch.Click += new System.EventHandler(this.DataFetch_Click);
            // 
            // RtxtBox_Data
            // 
            this.RtxtBox_Data.Location = new System.Drawing.Point(24, 60);
            this.RtxtBox_Data.Name = "RtxtBox_Data";
            this.RtxtBox_Data.Size = new System.Drawing.Size(444, 555);
            this.RtxtBox_Data.TabIndex = 15;
            this.RtxtBox_Data.Text = "";
            // 
            // txtinheritance
            // 
            this.Txtinheritance.Location = new System.Drawing.Point(629, 267);
            this.Txtinheritance.Name = "txtinheritance";
            this.Txtinheritance.Size = new System.Drawing.Size(106, 20);
            this.Txtinheritance.TabIndex = 14;
            // 
            // inheritanceNormalMetricSave
            // 
            this.inheritanceNormalMetricSave.Location = new System.Drawing.Point(629, 299);
            this.inheritanceNormalMetricSave.Name = "inheritanceNormalMetricSave";
            this.inheritanceNormalMetricSave.Size = new System.Drawing.Size(106, 36);
            this.inheritanceNormalMetricSave.TabIndex = 13;
            this.inheritanceNormalMetricSave.Text = "Save Metric (Original Code)";
            this.inheritanceNormalMetricSave.UseVisualStyleBackColor = true;
            this.inheritanceNormalMetricSave.Click += new System.EventHandler(this.InheritanceOriginalMetricSave_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(393, 621);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 17;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.Btn_clear_Click);
            // 
            // inheritanceNumRefactorMetricSave
            // 
            this.inheritanceNumRefactorMetricSave.Location = new System.Drawing.Point(619, 341);
            this.inheritanceNumRefactorMetricSave.Name = "inheritanceNumRefactorMetricSave";
            this.inheritanceNumRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.inheritanceNumRefactorMetricSave.TabIndex = 30;
            this.inheritanceNumRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.inheritanceNumRefactorMetricSave.UseVisualStyleBackColor = true;
            this.inheritanceNumRefactorMetricSave.Click += new System.EventHandler(this.InheritanceNumRefactorMetricSave_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(477, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 31;
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
            // DepthOfInheritance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.inheritanceNumRefactorMetricSave);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.dataFetch);
            this.Controls.Add(this.RtxtBox_Data);
            this.Controls.Add(this.Txtinheritance);
            this.Controls.Add(this.inheritanceNormalMetricSave);
            this.MaximizeBox = false;
            this.Name = "DepthOfInheritance";
            this.Text = "inheritanceCount";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dataFetch;
        private System.Windows.Forms.RichTextBox RtxtBox_Data;
        private System.Windows.Forms.TextBox Txtinheritance;
        private System.Windows.Forms.Button inheritanceNormalMetricSave;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button inheritanceNumRefactorMetricSave;
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