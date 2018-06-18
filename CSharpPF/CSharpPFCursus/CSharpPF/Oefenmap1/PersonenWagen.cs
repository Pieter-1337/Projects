using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class PersonenWagen : Voertuigen, IVervuiler
    {
        private int AantalDeurenValue;
        private int AantalPassagiersValue;
        private double KyotoScore;

        public PersonenWagen()
        {
            this.AantalDeuren = 4;
            this.AantalPassagiers = 5;
        }

        public PersonenWagen(string polisHouder, decimal kostPrijs, int pk, double gemiddeldVerbruik, string nummerplaat, int aantalDeuren, int aantalPassagiers) 
        : base(polisHouder, kostPrijs, pk, gemiddeldVerbruik, nummerplaat)
        {
            this.AantalDeuren = aantalDeuren;
            this.AantalPassagiers = aantalPassagiers;
        }

        public int AantalDeuren
        {
            get
            {
                return AantalDeurenValue;
            }
            set
            {
                if(value > 0)
                {
                    AantalDeurenValue = value;
                }
            }
        }

        public int AantalPassagiers
        {
            get
            {
                return AantalPassagiersValue;
            }
            set
            {
                if(value > 0)
                {
                    AantalPassagiersValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Aantal deuren: {0}", AantalDeuren);
            Console.WriteLine("Aantal passagiers {0}", AantalPassagiers);
            Console.WriteLine("KyotoScore: {0}", GetKyotoScore());
            Console.WriteLine("Vervuiling Score: {0}", GeefVervuiling());
      
        }

        public override double GetKyotoScore()
        {
            KyotoScore = GemiddeldVerbruik * Pk / AantalPassagiers;
            return KyotoScore;
        }

        public double GeefVervuiling()
        {
            return KyotoScore * 5;
        }
    }
}
