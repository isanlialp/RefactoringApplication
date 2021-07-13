namespace fileApp
{
    partial class OperandAndOperator
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
            this.button_temizle = new System.Windows.Forms.Button();
            this.getData = new System.Windows.Forms.Button();
            this.richTextBox_Data = new System.Windows.Forms.RichTextBox();
            this.textBoxOperator = new System.Windows.Forms.TextBox();
            this.MetricSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOperand = new System.Windows.Forms.TextBox();
            this.OpMetricSave = new System.Windows.Forms.Button();
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
            // button_temizle
            // 
            this.button_temizle.Location = new System.Drawing.Point(398, 623);
            this.button_temizle.Name = "button_temizle";
            this.button_temizle.Size = new System.Drawing.Size(75, 23);
            this.button_temizle.TabIndex = 20;
            this.button_temizle.Text = "Clear";
            this.button_temizle.UseVisualStyleBackColor = true;
            this.button_temizle.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // getData
            // 
            this.getData.Location = new System.Drawing.Point(29, 24);
            this.getData.Name = "getData";
            this.getData.Size = new System.Drawing.Size(84, 23);
            this.getData.TabIndex = 19;
            this.getData.Text = "Get Code";
            this.getData.UseVisualStyleBackColor = true;
            this.getData.Click += new System.EventHandler(this.GetData_Click);
            // 
            // richTextBox_Data
            // 
            this.richTextBox_Data.Location = new System.Drawing.Point(29, 62);
            this.richTextBox_Data.Name = "richTextBox_Data";
            this.richTextBox_Data.Size = new System.Drawing.Size(444, 555);
            this.richTextBox_Data.TabIndex = 18;
            this.richTextBox_Data.Text = "";
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(633, 277);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.Size = new System.Drawing.Size(106, 20);
            this.textBoxOperator.TabIndex = 22;
            // 
            // MetricSave
            // 
            this.MetricSave.Location = new System.Drawing.Point(633, 359);
            this.MetricSave.Name = "MetricSave";
            this.MetricSave.Size = new System.Drawing.Size(106, 36);
            this.MetricSave.TabIndex = 21;
            this.MetricSave.Text = "Save Metric (Original Code)";
            this.MetricSave.UseVisualStyleBackColor = true;
            this.MetricSave.Click += new System.EventHandler(this.MetricSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Operator Count : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Operand Count : ";
            // 
            // textBoxOperand
            // 
            this.textBoxOperand.Location = new System.Drawing.Point(633, 319);
            this.textBoxOperand.Name = "textBoxOperand";
            this.textBoxOperand.Size = new System.Drawing.Size(106, 20);
            this.textBoxOperand.TabIndex = 25;
            // 
            // OpMetricSave
            // 
            this.OpMetricSave.Location = new System.Drawing.Point(621, 401);
            this.OpMetricSave.Name = "OpMetricSave";
            this.OpMetricSave.Size = new System.Drawing.Size(126, 36);
            this.OpMetricSave.TabIndex = 26;
            this.OpMetricSave.Text = "Save Metric (Refactored Code)";
            this.OpMetricSave.UseVisualStyleBackColor = true;
            this.OpMetricSave.Click += new System.EventHandler(this.OpMetricSave_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(479, 62);
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
            // OperandAndOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 657);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OpMetricSave);
            this.Controls.Add(this.textBoxOperand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOperator);
            this.Controls.Add(this.MetricSave);
            this.Controls.Add(this.button_temizle);
            this.Controls.Add(this.getData);
            this.Controls.Add(this.richTextBox_Data);
            this.Name = "OperandAndOperator";
            this.Text = "operandAndOperator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_temizle;
        private System.Windows.Forms.Button getData;
        private System.Windows.Forms.RichTextBox richTextBox_Data;
        private System.Windows.Forms.TextBox textBoxOperator;
        private System.Windows.Forms.Button MetricSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOperand;
        private System.Windows.Forms.Button OpMetricSave;
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