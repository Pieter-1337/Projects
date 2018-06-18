using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Omzetter
    {
        public const double CentimetersPerInch = 2.54d;
        public double CmNaarInch(double cm)
        {
            return cm / CentimetersPerInch;
        }

        public double InchNaarCm(double inch)
        {
            return inch * CentimetersPerInch;
        }

    }
}
