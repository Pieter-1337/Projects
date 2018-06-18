using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public sealed class Manager : Bediende
    {

        public void OnderhoudNoteren(Firma.Materiaal.Fotokopiemachine machine)
        {
            Console.WriteLine($"{Naam} registeert het onderhoud van machine {machine.SerieNr} in het logboek");
            Console.WriteLine("");
        }

        private double BonusValue;

        public Manager(string naam, DateTime inDienst, Geslacht geslacht, RegimeType regime , double wedde, double bonus) : base(naam, inDienst, geslacht, regime , wedde)
        {
            this.Bonus = bonus;
        }

        public override double Bedrag
        {
            get
            {
                return base.Bedrag + Bonus;
            }
        }


        private double Bonus
        {
            get
            {
                return BonusValue;
            }
            set
            {
                if(value > 0)
                {
                    BonusValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Bonus: {0} Euro", Bonus);
           
        }

        public override string ToString()
        {
            
            return base.ToString() + " ---- " + Bonus + " Euro Bonus";
        }

        public override double Premie
        {
            get
            {
                return Bonus * 3;
            }
        }
    }
}
