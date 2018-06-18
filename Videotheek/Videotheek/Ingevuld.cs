using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace Videotheek
{
    public class Ingevuld : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text;

            if (value == null || value.ToString() == string.Empty)
            {
                return new ValidationResult(false, "Dit veld moet Ingevuld zijn");
            }
            else
            {
                return ValidationResult.ValidResult;   
            }

        }
    }
}
