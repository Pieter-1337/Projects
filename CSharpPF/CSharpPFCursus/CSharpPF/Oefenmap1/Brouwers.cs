using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public class Brouwers
    {
        public List<Brouwer> GetBrouwers()
        {
            Brouwer palm = new Brouwer { BrouwerNr = 1, BrouwerNaam = "Palm", Belgisch = true};
            palm.Bieren = new List<Bier>
            {
                new Bier{ BierNr = 1, BierNaam="Palm Dobbel", Alcohol = 6.2F, Brouwer = palm },
                new Bier{ BierNr = 2, BierNaam="Palm Green", Alcohol = 0.1F, Brouwer = palm },
                new Bier{ BierNr = 3, BierNaam="Palm Royale", Alcohol = 7.5F, Brouwer = palm },
            };

            Brouwer HertogJan = new Brouwer { BrouwerNr = 2, BrouwerNaam = "Hertog Jan", Belgisch = false };
            HertogJan.Bieren = new List<Bier>
            {
                new Bier{ BierNr = 4, BierNaam="Hertog Jan Dubbel", Alcohol = 7.0F, Brouwer = HertogJan},
                new Bier{ BierNr = 5, BierNaam="Hertog Jan Grand Prestige", Alcohol = 10.0F, Brouwer = HertogJan}
            };

            Brouwer InBev = new Brouwer { BrouwerNr = 3, BrouwerNaam = "Inbev", Belgisch = true };
            InBev.Bieren = new List<Bier>
            {
                new Bier{ BierNr = 6, BierNaam="Belle-vue kriek L.A", Alcohol = 1.2F, Brouwer = InBev},
                new Bier{ BierNr = 7, BierNaam="Belle-vue Kriek", Alcohol = 5.2F, Brouwer = InBev},
                new Bier{ BierNr = 8, BierNaam="Leffe Radieuse", Alcohol = 8.2F, Brouwer = InBev},
                new Bier{ BierNr = 9, BierNaam="Leffe Triple", Alcohol = 8.5F, Brouwer = InBev}
            };

            return new List<Brouwer> { palm, HertogJan, InBev };
        }
    }
}
