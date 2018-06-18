using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DbManagers;

namespace Videotheek
{
    public class IngevuldGroterDanNul : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal getal;

           if(value == null || value.ToString() == string.Empty)
            {
                return new ValidationResult(false, "Dit veld moet Ingevuld zijn");
            }

            if (!decimal.TryParse(value.ToString(), out getal))
            {
                return new ValidationResult(false, "Waarde moet een getal zijn");
            }

            if (getal <= 0)
            {
                return new ValidationResult(false, "Getal moet groter zijn dan 0");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }
}
