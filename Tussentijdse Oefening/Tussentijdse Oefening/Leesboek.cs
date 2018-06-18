using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorwerpen.Boeken.LeesBoek 
{
    class Leesboek: Boeken
    {
        private string OnderwerpValue;
        

        public Leesboek(string titel, string auteur, Eigenaar eigenaar, double aankoopPrijs, string onderwerp, Genre genre) : base(titel, auteur, eigenaar, aankoopPrijs, genre)
        {
            this.Onderwerp = onderwerp;
        }

        public string Onderwerp
        {
            get
            {
                return OnderwerpValue;
            }
            set
            {
                OnderwerpValue = value;
            }
        }

        public override double Winst
        {
            get
            {
                return AankoopPrijs * 1.5;
            }
            
        }

        public override void GegevensTonen()
        {
            base.GegevensTonen();
            Console.WriteLine($"Onderwerp: {Onderwerp}");
            Console.WriteLine($"Winst: {Winst} Euro");
          
        }





    }
}
