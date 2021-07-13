using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileApp
{
    public partial class MagicNumber : Form
    {
        public Main magic;
        
        public MagicNumber()
        {
            InitializeComponent();
            magic = new Main();
        }

        public string magicNum { get; set; }
        public string magicVariableType { get; set; }       
        public object SelectedItem { get; set; }
        public string variableName { get; set; }
        public int magicIndex { get; set; }
        public string dosyaPath { get; set; }
        public string araMagic { get; set; }
        public string magicNumberName;

        public void apply_Click(object sender, EventArgs e)
        {
           
            Object selectedItem = comboBox1.SelectedItem;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Magic Number...");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select Constant Variable Type!!!");
            }
            else if ((comboBox1.SelectedIndex != -1) && (textBox1.Text != null))
            {
                //magicDegiskenAdi = textBox1.Text.Trim();
                //magicDegiskenTipi = comboBox1.SelectedItem.ToString().Trim();
                ////MessageBox.Show(inlineDegiskenTipi + " " + inlineDegiskenAdi);
                ////ana.inlineTemp(inlineDegiskenAdi);
                //aranan = (inlineDegiskenTipi + " " + inlineDegiskenAdi);
                //MessageBox.Show(aranan);
                //ana.inlineParcala(aranan, inlineDegiskenAdi.Trim());
                //  MessageBox.Show("tamam");
                magicNum = textBox1.Text.Trim();

                //ana.inlineTemp(inlineDegiskenAdi);
                araMagic = magicNum;
                magicVariableType = comboBox1.SelectedItem.ToString();
                magic.FindMagicNumber(araMagic);
                magicNumberName = textBox2.Text.Trim();
                string yeniMagic = (magicVariableType.Trim() + " " + magicNumberName + "="+ magicNum.Trim()+";"+"\n");

                MessageBox.Show(yeniMagic);
                magic.MagicRefApply(yeniMagic);
            }
        }
        public void temizle()
        {
                MessageBox.Show("Searched number not found!!! Enter new number...",
                     "WARNING",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button1);
            textBox1.Clear();
        }
        private void magicNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            // FORMU KAPATMAK İSTEDIGINDE GOSTERİLECEK KOD
            if (MessageBox.Show("Do you want to close the Form?", "Form Closing",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Closing eventi iptal etme
                e.Cancel = true;
            }
        }

        public void indexAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Magic Number...");
            }         
            else if (textBox1.Text != null)
            {
                magicNum = textBox1.Text.Trim();
                //magic = new Main();
                magic.FindMagicNumber(magicNum);
               
                //ana.inlineTemp(inlineDegiskenAdi);
                // araMagic = magicDegiskenAdi;
                // MessageBox.Show(araMagic);
                
            }
        }


    }
}
