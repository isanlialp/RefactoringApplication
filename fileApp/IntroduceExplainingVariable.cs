using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileApp
{
    class IntroduceExplainingVariable : Main
    {
        public Main m2;
        public string loopString { get; set; }

        public  string TextDilimle(string searchTxt, string value)
        {
            if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value))
            {
                int index = searchTxt.IndexOf(value);
                if (-1 < index)
                {
                    int start = index + value.Length;
                    if (start <= searchTxt.Length)
                    {
                        return searchTxt.Substring(start);
                    }
                }
            }
            return null;
        }
        //public string TextLoopParcala(string searchTxt, string value)
        //{
        //    if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value))
        //    {

        //        int index = searchTxt.IndexOf(value);
        //        if (-1 < index)
        //        {
        //            int start = index + value.Length;
        //            if (start <= searchTxt.Length)
        //            {
        //                string for2Parca = searchTxt.Substring(start);
        //                int last = for2Parca.IndexOf(";");
        //                string condition2Ad = for2Parca.Substring(0, last);
        //                return condition2Ad;
        //            }
        //        }
        //    }
        //    return null;
        //}

        public string TextLoopDivide(string searchTxt, string value, int indis)
        {
            if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value) && (indis !=null))
            {

                int index = indis;
                if (-1 < index)
                {
                    int start = index + value.Length;
                    if (start <= searchTxt.Length)
                    {
                        string for2Parca = searchTxt.Substring(start);
                        int last = for2Parca.IndexOf(";");
                        string condition2Ad = for2Parca.Substring(0, last);
                        return condition2Ad;
                    }
                }
            }
            return null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // introduceExplainingVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1034, 594);
            this.Name = "introduceExplainingVariable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
