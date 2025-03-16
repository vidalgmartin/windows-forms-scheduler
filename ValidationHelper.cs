using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public static class ValidationHelper
    {
        public static bool ValidateFields(TextBox[] inputFields)
        {
            bool validInput = true;

            foreach (TextBox field in inputFields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {                  
                    validInput  = false;
                }
            }
            
            if (!validInput)
            {
                MessageBox.Show("Fields cannot be empty");
            }
            
            return validInput;
        }

        public static bool ValidatePhone(string phoneInput)
        {       
            string pattern = @"^[\d-]+$";
            return Regex.IsMatch(phoneInput, pattern);
        }
    }
}
