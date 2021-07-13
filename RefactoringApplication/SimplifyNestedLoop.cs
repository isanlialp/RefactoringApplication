using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileApp
{
    class SimplifyNestedLoop : Main
    {      
        public Main m1;
        public string loopString { get; set; }

        public static string TextSplit(string searchTxt, string value)
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

        public static string TextLoopSplit(string searchTxt, string value)
        {
            if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value))
            {
                int index = searchTxt.IndexOf(value);
                if (-1 < index)
                {
                    int start = index + value.Length;
                    if (start <= searchTxt.Length)
                    {
                       string for2Parca = searchTxt.Substring(start);
                        int last = for2Parca.IndexOf(";");
                        string condition2Name = for2Parca.Substring(0, last);
                        return condition2Name;
                    }
                }
            }
            return null;
        }

        public static string LoopReturnValue(string searchTxt, string value)
        {
            if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value))
            {
                int index = searchTxt.IndexOf(value);
                if (-1 < index)
                {
                    int start = index + value.Length;
                    if (start <= searchTxt.Length)
                    {
                        string for2Part = searchTxt.Substring(start);
                        int last = for2Part.IndexOf("=");
                        string statementName = for2Part.Substring(0, last);
                        return statementName;
                    }
                }
            }
            return null;
        }

        public string Split()
        {
            loopString = m1.TrimString;
            if (loopString.Contains("int") == true)
            {
                if (loopString.Contains("<=") == true)
                {
                    string condition = TextSplit(loopString, "<=");
                    int first = condition.IndexOf(";");
                    string conditionName1 = condition.Substring(0, first);
                    string conditionName2 = TextLoopSplit(condition, "<=");
                    string statementSplit = TextSplit(condition, "for");
                    string statementName = LoopReturnValue(statementSplit, ")\n{");
                    string conditionFull = conditionName1 + "*" + conditionName2;
                    string initType = "int";
                    string donusDeger = statementName + "," + initType +","+ conditionFull;
                    return donusDeger;
                }else if(loopString.Contains("=>") == true)
                {
                    return null;
                }
            }else if (loopString.Contains("double") == true)
            {
                if (loopString.Contains("<=") == true)
                {
                    string condition = TextSplit(loopString, "<=");
                    int first = condition.IndexOf(";");
                    string conditionName1 = condition.Substring(0, first);
                    string conditionName2 = TextLoopSplit(condition, "<=");
                    string statementSplit = TextSplit(condition, "for");
                    string statementName = LoopReturnValue(statementSplit, "){");
                    string conditionFull = conditionName1 + "*" + conditionName2;
                    string returnValue = statementName + "," + conditionFull;
                    return returnValue;
                }
                else if (loopString.Contains("=>") == true)
                {
                    return null;
                }
            }
            return loopString;
        }
        
    }
}
