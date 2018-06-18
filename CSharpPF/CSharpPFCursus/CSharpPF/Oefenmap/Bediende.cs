using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Bediende : Werknemer
    {
        private double WeddeValue;

        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, double wedde) : base(naam, inDienst, geslacht)
        {
            this.Wedde = wedde;
        }

        private double Wedde
        {
            get
            {
                return WeddeValue;
            }
            set
            {
                if (value >= 0)
                {
                    WeddeValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Wedde: {0} Euro / Maand", Wedde);
        }

        public override string ToString()
        {
            Console.WriteLine("");
            return base.ToString() + ' ' + Wedde + " Euro / maand";
        }
    }
}
