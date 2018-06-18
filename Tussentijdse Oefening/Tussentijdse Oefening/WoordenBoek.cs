using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorwerpen.Boeken.WoordenBoek
{
    class WoordenBoek: Boeken
    {
        private string TaalValue;
        

        public WoordenBoek(string titel, string auteur, Eigenaar eigenaar, double aankoopPrijs, string taal, Genre genre) : base(titel, auteur, eigenaar, aankoopPrijs, genre)
        {
            this.TaalValue = taal;
        }

        public string Taal
        {
            get
            {
                return TaalValue;
            }
            set
            {
                TaalValue = value;
            }
        }

        public override double Winst
        {
            get
            {
                return AankoopPrijs * 1.75;
            }
        }  

        public override void GegevensTonen()
        {
            base.GegevensTonen();
            Console.WriteLine($"Taal: {Taal}");
            Console.WriteLine($"Winst: {Winst} Euro");
        }
    }
}
