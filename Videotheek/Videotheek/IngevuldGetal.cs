using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace Videotheek
{
    public class IngevuldGetal : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal getal;

            if (value == null || value.ToString() == string.Empty)
            {
                return new ValidationResult(false, "Dit veld moet Ingevuld zijn");
            }

            if (!decimal.TryParse(value.ToString(), out getal))
            {
                return new ValidationResult(false, "Waarde moet een getal zijn");
            }
            else
            {
                return ValidationResult.ValidResult;
            }



        }
    }
}
