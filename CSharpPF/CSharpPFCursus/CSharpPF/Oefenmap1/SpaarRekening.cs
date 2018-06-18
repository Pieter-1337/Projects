using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class SpaarRekening : Rekening
    {
        private static double IntrestValue = 2;

        public SpaarRekening(string rekeningNummer, Klant eigenaar, decimal saldo, DateTime creatieDatum) : base(rekeningNummer, eigenaar, saldo, creatieDatum)
        {
            
        }

        public static double Intrest
        {
            get
            {
                return IntrestValue;
            }
            set
            {
                if(value >= 0)
                {
                    IntrestValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een positieve waarde in te geven");
                }
            }
        }

        public override void Afbeelden()
        {
            Console.WriteLine("SPAARREKENING");
            base.Afbeelden();
            Console.WriteLine("Intrest: {0} % intrest", Intrest);
        }
    }
}
