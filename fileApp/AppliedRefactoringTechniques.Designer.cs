namespace fileApp
{
    partial class AppliedRefactoringTechniques
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
            this.Button_Clear = new System.Windows.Forms.Button();
            this.GetData = new System.Windows.Forms.Button();
            this.RichTextBox_Data = new System.Windows.Forms.RichTextBox();
            this.AdjacencyMatrix = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.AppliedRefTech = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Clear
            // 
            this.Button_Clear.Location = new System.Drawing.Point(395, 594);
            this.Button_Clear.Name = "Button_Clear";
            this.Button_Clear.Size = new System.Drawing.Size(75, 23);
            this.Button_Clear.TabIndex = 23;
            this.Button_Clear.Text = "Clear";
            this.Button_Clear.UseVisualStyleBackColor = true;
            this.Button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // GetData
            // 
            this.GetData.Location = new System.Drawing.Point(36, 36);
            this.GetData.Name = "GetData";
            this.GetData.Size = new System.Drawing.Size(108, 23);
            this.GetData.TabIndex = 22;
            this.GetData.Text = "Open Log Data";
            this.GetData.UseVisualStyleBackColor = true;
            this.GetData.Click += new System.EventHandler(this.GetData_Click);
            // 
            // RichTextBox_Data
            // 
            this.RichTextBox_Data.Location = new System.Drawing.Point(36, 70);
            this.RichTextBox_Data.Name = "RichTextBox_Data";
            this.RichTextBox_Data.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RichTextBox_Data.Size = new System.Drawing.Size(434, 514);
            this.RichTextBox_Data.TabIndex = 21;
            this.RichTextBox_Data.Text = "";
            // 
            // AdjacencyMatrix
            // 
            this.AdjacencyMatrix.Location = new System.Drawing.Point(348, 36);
            this.AdjacencyMatrix.Name = "AdjacencyMatrix";
            this.AdjacencyMatrix.Size = new System.Drawing.Size(122, 23);
            this.AdjacencyMatrix.TabIndex = 24;
            this.AdjacencyMatrix.Text = "Adjacency Matrix";
            this.AdjacencyMatrix.UseVisualStyleBackColor = true;
            this.AdjacencyMatrix.Click += new System.EventHandler(this.AdjacencyMatrix_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(505, 70);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(198, 251);
            this.ListBox1.TabIndex = 25;
            // 
            // AppliedRefTech
            // 
            this.AppliedRefTech.Enabled = false;
            this.AppliedRefTech.Location = new System.Drawing.Point(535, 36);
            this.AppliedRefTech.Name = "AppliedRefTech";
            this.AppliedRefTech.Size = new System.Drawing.Size(133, 23);
            this.AppliedRefTech.TabIndex = 26;
            this.AppliedRefTech.Text = "Applied Ref-Tech";
            this.AppliedRefTech.UseVisualStyleBackColor = true;
            this.AppliedRefTech.Click += new System.EventHandler(this.AppliedRefTech_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(628, 331);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 28;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // AppliedRefactoringTechniques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 641);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.AppliedRefTech);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.AdjacencyMatrix);
            this.Controls.Add(this.Button_Clear);
            this.Controls.Add(this.GetData);
            this.Controls.Add(this.RichTextBox_Data);
            this.MaximizeBox = false;
            this.Name = "AppliedRefactoringTechniques";
            this.Text = "Applied Refactoring Techniques";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Clear;
        private System.Windows.Forms.Button GetData;
        private System.Windows.Forms.RichTextBox RichTextBox_Data;
        private System.Windows.Forms.Button AdjacencyMatrix;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button AppliedRefTech;
        private System.Windows.Forms.Button Save;
    }
}