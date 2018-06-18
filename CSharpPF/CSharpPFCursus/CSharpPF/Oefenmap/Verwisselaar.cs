using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Verwisselaar
    {
        public void Verwissel(ref int getal1, ref int getal2)
        {
            int tussen = getal1;
            getal1 = getal2;
            getal2 = tussen;
        }
    }
}
