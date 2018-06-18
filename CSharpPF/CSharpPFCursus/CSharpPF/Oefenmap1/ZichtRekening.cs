using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class ZichtRekening : Rekening
    {
        private double MaxKredietValue;

        public ZichtRekening(string rekeningNummer, Klant eigenaar, decimal saldo, DateTime creatieDatum,double maxKrediet) : base(rekeningNummer, eigenaar, saldo, creatieDatum)
        {
            this.MaxKrediet = maxKrediet;
        }

        public double MaxKrediet
        {
            get
            {
                return MaxKredietValue;
            }
            set
            {
                if(value < 0)
                {
                    MaxKredietValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een negatieve waarde in te geven");
                }
            }
        }

        public override void Afbeelden()
        {
            Console.WriteLine("ZICHTREKENING");
            base.Afbeelden();
            Console.WriteLine("Maximum krediet: {0}", MaxKrediet);
        }

        

    }
}
