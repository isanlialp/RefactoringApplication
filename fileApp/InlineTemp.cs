using System;
using System.Windows.Forms;

namespace fileApp
{
    public partial class InlineTemp : Form
    {
        public Main inline;

        public InlineTemp()
        {
            InitializeComponent();
            inline = new Main();
        }

        public string inlineVariableName { get; set; }
        public string inlineVariableType { get; set; }
        public object SelectedItem { get; set; }
        public string variableName { get; set; }
        public int inlineIndex { get; set; }
        public string filePath { get; set; }
        public string searched { get; set; }

        public void Apply_Click(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Variable Name...");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select Variable Type!!!");
            }
            else if ((comboBox1.SelectedIndex != -1) && (textBox1.Text != null))
            {
                inlineVariableName = textBox1.Text.Trim();
                inlineVariableType = comboBox1.SelectedItem.ToString().Trim();
                searched = (inlineVariableType + " " + inlineVariableName);
                inline.inlineSplit(searched, inlineVariableName.Trim());
            }
           
        }
        private void InlineTemp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CODE TO SHOW WHEN YOU WANT TO CLOSE THE FORM
            if (MessageBox.Show("Do you want to Close the Form?", "Closing the Form",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Canceling the closing event
                e.Cancel = true;
            }           
        }

    }
}
