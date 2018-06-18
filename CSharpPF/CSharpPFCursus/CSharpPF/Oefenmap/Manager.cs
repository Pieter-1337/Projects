using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Manager : Bediende
    {
        private double BonusValue;

        public Manager(string naam, DateTime inDienst, Geslacht geslacht, double wedde, double bonus) : base(naam, inDienst, geslacht, wedde)
        {
            this.Bonus = bonus;
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
            
            return base.ToString() + ' ' + Bonus + " Bonus";
        }
    }
}
