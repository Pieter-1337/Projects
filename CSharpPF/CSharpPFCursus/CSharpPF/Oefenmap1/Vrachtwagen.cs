using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Vrachtwagen : Voertuigen, IVervuiler
    {
        private float MaximumLadingValue;
        private double KyotoScore;

        public Vrachtwagen()
        {
            this.MaximumLading = 10000;
        }

        public Vrachtwagen(string polisHouder, decimal kostPrijs, int pk, double gemiddeldVerbruik, string nummerplaat, float maximumLading)
        : base(polisHouder, kostPrijs , pk, gemiddeldVerbruik, nummerplaat)
        {
            this.MaximumLading = maximumLading;
        }

        public Vrachtwagen(float maximimLading)
        {
            this.MaximumLading = maximimLading;
        }

        public float MaximumLading
        {
            get
            {
                return MaximumLadingValue;
            }
            set
            {
                if (value > 0)
                {
                    MaximumLadingValue = value;
                }
            }

        }

        

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Maximum lading: {0} Kg", MaximumLading);
            Console.WriteLine("KyotoScore: {0}", GetKyotoScore());
            Console.WriteLine("Vervuiling Score: {0}", GeefVervuiling());
        }

        public override double GetKyotoScore()
        {
            KyotoScore = (GemiddeldVerbruik * Pk) / (MaximumLading / 1000.0);
            return KyotoScore;
        }

        public double GeefVervuiling()
        {

            return KyotoScore * 20;
        }
    }
}
