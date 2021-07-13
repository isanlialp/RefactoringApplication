using System;
using System.Windows.Forms;

namespace fileApp
{
    public partial class EncapsulateField : Form
    {
        public Main newEncapsulate;

        public EncapsulateField()
        {          
            InitializeComponent();
            newEncapsulate = new Main();
        } 
        public string varName { get; set; }
        public int indexField { get; set; }
        public int lengthText;
        public string filePath { get; set; }
        public string fieldName { get; set; }
        public string typeName { get; set; }
        public string controlGet;
        public string controlSet;
        public string accessControl;
        public string propertyName;

        private void Form2_Load(object sender, EventArgs e)
        {           
            textBox1.Text = varName;           
            newEncapsulate.encapsulateCounter = true;
        }
        // Start to Apply Encapsulate Field Technique given parameters
        public void button1_Click(object sender, EventArgs e)
        {
             if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select Access Modifier!!!");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter the property name....");
            }
            else if(textBox1.Text == varName)
            {                
                MessageBox.Show("Enter different property name!!!"); 
            }
            else if((textBox1.Text!= varName) && (textBox1.Text!=null) ) 
            {
                lengthText = newEncapsulate.lengthTxt;             
                if(textBox1.Text.Length > lengthText)
                {
                    MessageBox.Show(textBox1.Text + " Property Name is Long", "Property Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox1.Text.Length < lengthText)
                {
                    MessageBox.Show(textBox1.Text + " Property Name is Short", "Property Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(textBox1.Text.Length == lengthText)
                {
                    propertyName = textBox1.Text;
                    newEncapsulate.ApplyEncapsulField(controlGet, controlSet, accessControl, propertyName, filePath, indexField, fieldName, typeName);
                    newEncapsulate.RestartEncapsulate();
                }             
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
               newEncapsulate.encapsulateCounter = false;
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
    }
}