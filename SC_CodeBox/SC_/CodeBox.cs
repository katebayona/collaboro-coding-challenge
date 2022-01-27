using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SCCodeBox
{
    public class CodeBox
    {
        public Dictionary<string, string> CodeByValue = new Dictionary<string, string>();
        public string codeBoxValues { get; set; }
        public string result { get; set; }
        public string validationMessage { get; set; }

        public bool Add(string input)
        {
            bool isAdd = false;
            
            validationMessage = string.Empty;

            if (input.Length > 1)
            {
                //split digits and characters
                var addTokens = Regex.Matches(input, @"\D+|\d+")
                 .Cast<Match>()
                 .Select(m => m.Value)
                 .ToArray();

                if (addTokens == null || addTokens.Count() != 2)
                {
                    validationMessage = "Code box value should be in the format of <code><value>.\n For example: 1C";
                    isAdd = false;
                }
                else
                {
                    if (addTokens[0].All(char.IsDigit) && (addTokens[1].All(char.IsLetter) && addTokens[1].Length == 1))
                    {
                        isAdd = true;
                        string code = addTokens[0];
                        string val = addTokens[1].ToUpper();
                        if (!CodeByValue.ContainsValue(val) && !CodeByValue.ContainsKey(code)) CodeByValue.Add(code, val);
                        else validationMessage = "Code box value already exists.";
                    }
                    else
                    {
                        validationMessage = "Code box value should be in the format of <code><value> separated by <space>.\n For example: 1C";
                    }
                }  
            }
            if (!string.IsNullOrEmpty(validationMessage))
            {
                isAdd = false;
            }
            else
            {
                var cbValues = CodeByValue.Select(kvp => "(" + kvp.Key + "," + kvp.Value + ")".ToString());
                codeBoxValues = string.Join(",", cbValues);
            }

            return isAdd;
        }

        public bool Decode(string input)
        {
            bool isDecode = false;

            if (input.Length > 0)
            {
                var decodeTokens = Regex.Matches(input, @"^\d+(,\d+)*$")
                 .Cast<Match>()
                 .Select(m => m.Value)
                 .ToArray();
                            
                if (decodeTokens == null || decodeTokens.Count() == 0)
                {
                    isDecode = false;
                    validationMessage = "Code value should be in the format of <code> separated by a comma.\n For example: 11,3,7,8";
                }
                else
                {              
                        isDecode = true;
                        string[] tokens = input.Trim().Split(',');

                    foreach (var x in tokens)
                    {
                        if (CodeByValue.ContainsKey(x)) result += CodeByValue[x];
                        else
                        {
                            isDecode = false;
                            validationMessage = "Code value does not exist in the code box.";
                        }
                    }                    
                }      
            }
            
            return isDecode;
        }
    }
}
