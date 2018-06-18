using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorwerpen.Boekenrek
{
    class BoekenRek : IVoorwerpen
    {
        private double HoogteValue;
        private double BreedteValue;
        private double AankoopPrijsValue;
       

        public BoekenRek(double hoogte, double breedte, double aankoopPrijs)
        {
            this.Hoogte = hoogte;
            this.Breedte = breedte;
            this.AankoopPrijs = aankoopPrijs;
        }

        public double Hoogte
        {
            get
            {
                return HoogteValue;
            }
            set
            {
                if (value >= 0)
                {
                    HoogteValue = value;
                }
            }
        }

        public double Breedte
        {
            get
            {
                return BreedteValue;
            }
            set
            {
                if(value >= 0)
                {
                    BreedteValue = value;
                }
            }
        }

        public double AankoopPrijs
        {
            get
            {
                return AankoopPrijsValue;
            }
            set
            {
                if(value >= 0)
                {
                    AankoopPrijsValue = value;
                }
            }
        }

        public double Winst
        {
            get
            {
                return AankoopPrijs * 2;
            }
          
        }


        public virtual void GegevensTonen()
        {
            Console.WriteLine($"Hoogte: {Hoogte} cm");
            Console.WriteLine($"Breedte: {Breedte} cm");
            Console.WriteLine($"Aankoopprijs: {AankoopPrijs} Euro");
            Console.WriteLine($"Winst: {Winst} Euro");
            
        }




    }
}
