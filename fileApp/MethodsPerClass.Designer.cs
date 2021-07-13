namespace fileApp
{
    partial class MethodsPerClass
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
            this.GetCodeData = new System.Windows.Forms.Button();
            this.RxTextBox_data = new System.Windows.Forms.RichTextBox();
            this.TxtFunctionNum = new System.Windows.Forms.TextBox();
            this.OriginalMethodNumMetricSave = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.MethodNumRefactorMetricSave = new System.Windows.Forms.Button();
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
            // GetCodeData
            // 
            this.GetCodeData.Location = new System.Drawing.Point(12, 33);
            this.GetCodeData.Name = "GetCodeData";
            this.GetCodeData.Size = new System.Drawing.Size(79, 23);
            this.GetCodeData.TabIndex = 12;
            this.GetCodeData.Text = "Get Code ";
            this.GetCodeData.UseVisualStyleBackColor = true;
            this.GetCodeData.Click += new System.EventHandler(this.dataFetch_Click);
            // 
            // RxTextBox_data
            // 
            this.RxTextBox_data.Location = new System.Drawing.Point(12, 62);
            this.RxTextBox_data.Name = "RxTextBox_data";
            this.RxTextBox_data.Size = new System.Drawing.Size(444, 555);
            this.RxTextBox_data.TabIndex = 11;
            this.RxTextBox_data.Text = "";
            // 
            // TxtFunctionNum
            // 
            this.TxtFunctionNum.Location = new System.Drawing.Point(614, 273);
            this.TxtFunctionNum.Name = "TxtFunctionNum";
            this.TxtFunctionNum.Size = new System.Drawing.Size(106, 20);
            this.TxtFunctionNum.TabIndex = 10;
            // 
            // OriginalMethodNumMetricSave
            // 
            this.OriginalMethodNumMetricSave.Location = new System.Drawing.Point(614, 299);
            this.OriginalMethodNumMetricSave.Name = "OriginalMethodNumMetricSave";
            this.OriginalMethodNumMetricSave.Size = new System.Drawing.Size(106, 36);
            this.OriginalMethodNumMetricSave.TabIndex = 9;
            this.OriginalMethodNumMetricSave.Text = "Save Metric (Original Code)";
            this.OriginalMethodNumMetricSave.UseVisualStyleBackColor = true;
            this.OriginalMethodNumMetricSave.Click += new System.EventHandler(this.OriginalMethodNumMetricSave_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(381, 623);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Clear.TabIndex = 13;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // MethodNumRefactorMetricSave
            // 
            this.MethodNumRefactorMetricSave.Location = new System.Drawing.Point(603, 341);
            this.MethodNumRefactorMetricSave.Name = "MethodNumRefactorMetricSave";
            this.MethodNumRefactorMetricSave.Size = new System.Drawing.Size(126, 36);
            this.MethodNumRefactorMetricSave.TabIndex = 29;
            this.MethodNumRefactorMetricSave.Text = "Save Metric (Refactored Code)";
            this.MethodNumRefactorMetricSave.UseVisualStyleBackColor = true;
            this.MethodNumRefactorMetricSave.Click += new System.EventHandler(this.MethodNumRefactorMetricSave_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(462, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 190);
            this.groupBox1.TabIndex = 30;
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
            // MethodsPerClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 664);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MethodNumRefactorMetricSave);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.GetCodeData);
            this.Controls.Add(this.RxTextBox_data);
            this.Controls.Add(this.TxtFunctionNum);
            this.Controls.Add(this.OriginalMethodNumMetricSave);
            this.MaximizeBox = false;
            this.Name = "MethodsPerClass";
            this.Text = "functionNumber";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetCodeData;
        private System.Windows.Forms.RichTextBox RxTextBox_data;
        private System.Windows.Forms.TextBox TxtFunctionNum;
        private System.Windows.Forms.Button OriginalMethodNumMetricSave;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button MethodNumRefactorMetricSave;
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