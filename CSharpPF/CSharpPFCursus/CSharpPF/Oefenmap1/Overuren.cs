using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public class Overuren
    {
        //Maak een int array om de overuren per maand bij te houden <-> Zelfde principe als string array hieronder maar dan met int om op te vragen
        private int[] OverurenValue = new int[12];

        //Maak een string array om de overuren per maand bij te houden <-> Zelfde principe als int array hierboven maar den met string om op te vragen
        private readonly string[] maanden = { "jan", "feb", "maa", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec" };

        public int this[int maand] // public indexer met int als return type, this slaat op het object overuren, [int maand] is opzoeken op nummer van de maand
        {
            get
            {
                return OverurenValue[maand];
            }
            set
            {
                OverurenValue[maand] = value;

            }
        }

        public int this[string maand]//public indexer met int als return type, this slaat op het object overuren, [string maand] is opzoeken op de naam van de maand
        {

            get
            {
                return OverurenValue[WelkeMaand(maand)]; //Gebruik method WelkeMaand om het maandnr te returnen
            }
            set
            {
                OverurenValue[WelkeMaand(maand)] = value; //Set OverurenValue gelijk aan het maandnummer
            }
        }

        private int WelkeMaand(string maand)//Method om te bepalen of de gekozen maand een geldige maand is returnt het maandnr naar de array met met de maandnamen
        {
            int maandNr = Array.IndexOf(maanden, maand);
            if (maandNr == -1)
            {
                throw new IndexOutOfRangeException("Ongeldige maand: " + maand);
            }
            else
            {
                return maandNr;
            }

        }

        public int Totaal
        {
            get
            {
                int totaal = 0;
                foreach(int overuur in OverurenValue)
                {
                    totaal += overuur;  
                }
                return totaal;
            }
        }


    }
}
