using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{   
    //**** het keyword value refereert naar de value die meegegeven wordt in door de constructor zowel bij een default als een geparametreerde constructor ****//
    //Create class Voertuigen
    public abstract class Voertuigen : IMilieu, IPrivaat
    {
        //Set basic class variables
        private string polisHouderValue;
        private decimal kostprijsValue;
        private int pkValue;
        private double gemiddeldVerbruikValue;
        private string nummerplaatValue;
        private double kyotoScoreValue;

        //Set getters and setters for class variables
        public string PolisHouder
        {
            get{ return polisHouderValue; }

            set{ polisHouderValue = value; }
        }

        public decimal Kostprijs
        {
            get{ return kostprijsValue; }

            set{
                //Check of negatief getal werd ingegeven als value
                if (checkNegative(Convert.ToDouble(value)))
                    {
                        kostprijsValue = value;
                    }
                else
                    {
                        kostprijsValue = 0;
                    }
               }
        }

        public int Pk
        {
            get{ return pkValue; }

            set{
                //Check of negatief getal werd ingegeven als value
                if (checkNegative(Convert.ToInt32(value)))
                    {
                        pkValue = value;
                    }
                else
                    {
                        pkValue = 0;
                    }
                }
        }

        public double GemiddeldVerbruik
        {
            get{ return gemiddeldVerbruikValue; }

            set{
                //Check of negatief getal werd ingegeven als value
                if (checkNegative(Convert.ToSingle(value)))
                    {
                        gemiddeldVerbruikValue = value;
                    }
                else
                    {
                        gemiddeldVerbruikValue = 0;
                    }
            }
        }

        public string Nummerplaat
        {
            get{ return nummerplaatValue; }

            set{ nummerplaatValue = value; }
        }

        //Create default constructor met preset values
        public Voertuigen()
        {
            this.PolisHouder = "Onbepaald";
            this.Kostprijs = 0;
            this.Pk = 0;
            this.GemiddeldVerbruik = 0;
            this.Nummerplaat = "Onbepaald";
        }

        //Create geaparametreerde contructor. Values worden doorgegeven aan de constructor bij aanmaak van het object
        public Voertuigen(string polisHouder, decimal kostPrijs, int pk, double gemiddeldVerbruik, string nummerplaat)
        {
            this.PolisHouder = polisHouder;
            this.Kostprijs = kostPrijs;
            this.Pk = pk;
            this.GemiddeldVerbruik = gemiddeldVerbruik;
            this.Nummerplaat = nummerplaat;
        }

        //Method Afbeelden om data te tonen
        public virtual void Afbeelden()
        {
            Console.WriteLine("Polishouder: {0}", PolisHouder);
            Console.WriteLine("Kostprijs: {0} Euro", Kostprijs);
            Console.WriteLine("Pk: {0}", Pk);
            Console.WriteLine("Gemiddeld verbruik: {0}l /100km", GemiddeldVerbruik);
            Console.WriteLine("Nummerplaat: {0}", Nummerplaat);
            
        }

       

        //Method checkNegative om te checken op negatieve getallen bij aanmaak van een nieuw object
        private bool checkNegative(double getal)
        {
            bool check = true;
            if(getal < 0)
            {
                check = false;
            }

            return check;
        }

        //Abstract method mag geen body declaren dus geen { }
        public abstract double GetKyotoScore();

        public string GeefPrivateData()
        {
            return string.Format($"Polishouder: {PolisHouder} - Nummerplaat: {Nummerplaat}");
            
        }

        public string GeefMilieuData()
        {
            return string.Format($"Pk: {Pk} - Kostprijs: {Kostprijs} - Gemiddeld verbruik: {GemiddeldVerbruik}");
        }

  
      
    }
}
