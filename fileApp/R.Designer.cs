namespace fileApp
{
    partial class R
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
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Rscript = new System.Windows.Forms.Button();
            this.Plot = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.Bring_Rscript = new System.Windows.Forms.Button();
            this.Order = new System.Windows.Forms.Button();
            this.ListBox3 = new System.Windows.Forms.ListBox();
            this.Save = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Location = new System.Drawing.Point(646, 56);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(278, 253);
            this.RichTextBox1.TabIndex = 0;
            this.RichTextBox1.Text = "";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Location = new System.Drawing.Point(983, 56);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(579, 589);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // Rscript
            // 
            this.Rscript.Location = new System.Drawing.Point(722, 23);
            this.Rscript.Name = "Rscript";
            this.Rscript.Size = new System.Drawing.Size(126, 23);
            this.Rscript.TabIndex = 2;
            this.Rscript.Text = "RUN R SCRIPT ";
            this.Rscript.UseVisualStyleBackColor = true;
            this.Rscript.Click += new System.EventHandler(this.Script_Click);
            // 
            // Plot
            // 
            this.Plot.Location = new System.Drawing.Point(1215, 23);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(132, 23);
            this.Plot.TabIndex = 3;
            this.Plot.Text = "R PLOT WINDOW ";
            this.Plot.UseVisualStyleBackColor = true;
            this.Plot.Click += new System.EventHandler(this.Plot_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(649, 376);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.ScrollAlwaysVisible = true;
            this.ListBox1.Size = new System.Drawing.Size(275, 264);
            this.ListBox1.TabIndex = 4;
            // 
            // Bring_Rscript
            // 
            this.Bring_Rscript.Location = new System.Drawing.Point(221, 23);
            this.Bring_Rscript.Name = "Bring_Rscript";
            this.Bring_Rscript.Size = new System.Drawing.Size(126, 23);
            this.Bring_Rscript.TabIndex = 5;
            this.Bring_Rscript.Text = "OPEN R PATH";
            this.Bring_Rscript.UseVisualStyleBackColor = true;
            this.Bring_Rscript.Click += new System.EventHandler(this.Bring_Script_Click);
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(711, 337);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(137, 23);
            this.Order.TabIndex = 6;
            this.Order.Text = "OPTIMAL ORDER";
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Click += new System.EventHandler(this.Order_Click);
            // 
            // ListBox3
            // 
            this.ListBox3.FormattingEnabled = true;
            this.ListBox3.Location = new System.Drawing.Point(12, 56);
            this.ListBox3.Name = "ListBox3";
            this.ListBox3.ScrollAlwaysVisible = true;
            this.ListBox3.Size = new System.Drawing.Size(576, 589);
            this.ListBox3.TabIndex = 12;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(849, 664);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(1487, 664);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 14;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(199, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "...";
            // 
            // R
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 710);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ListBox3);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.Bring_Rscript);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.Rscript);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.RichTextBox1);
            this.Name = "R";
            this.Text = "R";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBox1;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button Rscript;
        private System.Windows.Forms.Button Plot;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button Bring_Rscript;
        private System.Windows.Forms.Button Order;
        private System.Windows.Forms.ListBox ListBox3;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label7;
    }
}