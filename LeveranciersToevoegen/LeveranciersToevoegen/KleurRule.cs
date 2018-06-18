﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using DbManagers;

namespace LeveranciersToevoegen
{
    public class KleurRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == string.Empty)
            {
                return new ValidationResult(false, "Gelieve een kleur in te vullen");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
