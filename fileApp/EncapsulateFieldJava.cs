using System;
using System.Drawing;
using System.Windows.Forms;

namespace fileApp
{
    public partial class EncapsulateFieldJava : Form
    {
        public Main newEncapsulate2;
        public EncapsulateFieldJava()
        {
            InitializeComponent();
            newEncapsulate2 = new Main();
            applyJava.Enabled = false;
        }

        public string encapsulate2VariableName { get; set; }
        public string encapsulate2VariableType { get; set; }
        public object encapsulate2AccessModifier{ get; set; }
        public int indexField { get; set; }
        public string filePath { get; set; }
        public int lengthText;
        public string propertyName;
        public string controlGet;
        public string controlSet;
        public string accessControl;
        public string searchingField2 { get; set; }
        public string searchingFieldFull { get; set; }

        private void Search_Click(object sender, EventArgs e)
        {
            Object selectedItem = comboBox2.SelectedItem;
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter Variable Name...");
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Select Variable Type!!!");
            }
            else if ((comboBox2.SelectedIndex != -1) && (textBox2.Text != null))
            {
                if (comboBox3.SelectedIndex == -1)
                {
                    encapsulate2VariableName = textBox2.Text.Trim();
                    encapsulate2VariableType = comboBox2.SelectedItem.ToString().Trim();
                    searchingField2 = (encapsulate2VariableType + " " + encapsulate2VariableName);
                    searchingFieldFull = (encapsulate2VariableType + " " + encapsulate2VariableName + ";");
                    MessageBox.Show(searchingField2);
                    newEncapsulate2.searchJava(searchingField2);              
                }
                else
                {
                    encapsulate2VariableName = textBox2.Text.Trim();
                    encapsulate2VariableType = comboBox2.SelectedItem.ToString().Trim();
                    searchingField2 = (encapsulate2AccessModifier + " " + encapsulate2VariableType + " " + encapsulate2VariableName);
                    searchingFieldFull = (encapsulate2AccessModifier + " " + encapsulate2VariableType + " " + encapsulate2VariableName + ";");
                    MessageBox.Show(searchingField2);
                    newEncapsulate2.searchJava(searchingField2);                 
                }
                if (newEncapsulate2.counterJavaEF != 0)
                {
                    applyJava.Enabled = true;
                }
            }
        }
        private void Encapsulate2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display a MsgBox asking the user to close the form.
            if (MessageBox.Show("Do you want to close the form?", "Form Closing",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Cancel the Closing event
                e.Cancel = true;
            }
        }
        public void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            controlGet = checkBox1.Checked.ToString();
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            controlSet = checkBox2.Checked.ToString();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            accessControl = comboBox1.SelectedItem.ToString();
        }
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            encapsulate2AccessModifier = comboBox3.SelectedItem.ToString();
        }
        public void ApplyJava_Click(object sender, EventArgs e)
        {                      
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter the property name....");
            }
            else if (textBox1.Text == encapsulate2VariableName)
            {
                MessageBox.Show("Enter different property name!!!");
            }
            else if ((textBox1.Text != encapsulate2VariableName) && (textBox1.Text != null))
            {
                lengthText = encapsulate2VariableName.ToString().Length;
                if (textBox1.Text.Length > lengthText)
                {
                    MessageBox.Show(textBox1.Text + " Property Name is Long", "Property Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox1.Text.Length < lengthText)
                {
                    MessageBox.Show(textBox1.Text + " Property Name is Short", "Property Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox1.Text.Length == lengthText)
                {
                    int index = 0;
                    newEncapsulate2.richTextBox1.Find(searchingFieldFull.ToString(), index, newEncapsulate2.richTextBox1.TextLength, RichTextBoxFinds.None);
                    newEncapsulate2.richTextBox1.SelectionBackColor = Color.Yellow;
                    while (index < newEncapsulate2.richTextBox1.Text.LastIndexOf(searchingFieldFull.ToString()))
                    {
                        newEncapsulate2.richTextBox1.Find(searchingFieldFull.ToString(), index, newEncapsulate2.richTextBox1.TextLength, RichTextBoxFinds.None);
                        newEncapsulate2.richTextBox1.SelectionBackColor = Color.Yellow;
                        index = newEncapsulate2.richTextBox1.Text.IndexOf(searchingFieldFull.ToString(), index) + 1;
                    }
                    indexField = index;
                    propertyName = textBox1.Text;
                    newEncapsulate2.ApplyEncapsulField(controlGet, controlSet, accessControl, propertyName, filePath, indexField, searchingFieldFull, encapsulate2VariableType);
                    newEncapsulate2.RestartEncapsulate2();
                }
            }
        }
        private void EncapsulateField2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please Enter the FULL Definition of the Field to Encapsulate for Search...",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }
    }
}