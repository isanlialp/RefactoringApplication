﻿namespace fileApp
{
    partial class HideMethod
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
            this.csApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.javaApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // csApply
            // 
            this.csApply.Location = new System.Drawing.Point(45, 67);
            this.csApply.Name = "csApply";
            this.csApply.Size = new System.Drawing.Size(70, 23);
            this.csApply.TabIndex = 0;
            this.csApply.Text = "Cs";
            this.csApply.UseVisualStyleBackColor = true;
            this.csApply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click for Hide Method....";
            // 
            // javaApply
            // 
            this.javaApply.Location = new System.Drawing.Point(241, 67);
            this.javaApply.Name = "javaApply";
            this.javaApply.Size = new System.Drawing.Size(75, 23);
            this.javaApply.TabIndex = 2;
            this.javaApply.Text = "Java";
            this.javaApply.UseVisualStyleBackColor = true;
            this.javaApply.Click += new System.EventHandler(this.JavaApply_Click);
            // 
            // HideMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 119);
            this.Controls.Add(this.javaApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.csApply);
            this.MaximizeBox = false;
            this.Name = "HideMethod";
            this.Text = "Hide Method";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hideMethod_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button csApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button javaApply;
    }
}