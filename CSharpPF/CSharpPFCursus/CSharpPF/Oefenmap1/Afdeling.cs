using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Afdeling
    {
        public const int verdiepingen = 10;
        private string afdelingNaamValue;
        private int afdelingVerdiepingValue;


        public Afdeling(string afdeling, int verdieping)
        {
            this.AfdelingNaam = afdeling;
            this.AfdelingVerdieping = verdieping;
        }


        public string AfdelingNaam
        {
            get
            {
                return afdelingNaamValue;
            }
            set
            {
                afdelingNaamValue = value;
            }
        }

        public int AfdelingVerdieping
        {
            get
            {
                return afdelingVerdiepingValue;
            }
            set
            {
                if (value <= verdiepingen) {
                    afdelingVerdiepingValue = value;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Afdeling: {0} op verdieping {1} ", AfdelingNaam, AfdelingVerdieping);

        }
    }
}
