using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    class Arbeider : Werknemer
    {
        private double UurloonValue;
        private byte PloegenstelselValue;

        public Arbeider(string naam, DateTime inDienst, Geslacht geslacht, RegimeType regime, double uurloon, byte ploegenstelsel) : base (naam, inDienst, geslacht, regime)
        {
            this.Uurloon = uurloon;
            this.PloegenStelsel = ploegenstelsel;
        }

        public override double Bedrag
        {
            get
            {
                return Uurloon * 2000 + Premie;
            }     
        }

        private double Uurloon
        {
            get
            {
                return UurloonValue;
            }
            set
            {
                if(value >= 0)
                {
                    UurloonValue = value;
                }
            }
        }

        private byte PloegenStelsel
        {
            get
            {
                return PloegenstelselValue;
            }
            set
            {
                if(value >= 1 && value <= 3)
                {
                    PloegenstelselValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Uurloon: {0} Euro / uur", Uurloon);
            Console.WriteLine("Ploegenstelsel: Ploeg {0}", PloegenStelsel);
            Console.WriteLine("Premie: {0} Euro", Premie);
        }

        public override string ToString()
        {
            Console.WriteLine("");
            return base.ToString() + ' ' + Uurloon + " " +
                "Euro / uur";

        }

        public override double Premie
        {
            get
            {
                return Uurloon * 150;
            }
        }

    }
}
