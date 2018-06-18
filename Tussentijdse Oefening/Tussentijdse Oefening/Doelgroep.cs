using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorwerpen.Boeken
{
    public class Doelgroep
    {
        private int LeeftijdValue;
       
        public Doelgroep(int leeftijd)
        {
            this.Leeftijd = leeftijd;
        }

        public int Leeftijd
        {
            get
            {
                return LeeftijdValue;
            }
            set
            {
                LeeftijdValue = value;
            }
        }

        public string Categorie
        {
            get
            {
                if(Leeftijd < 18)
                {
                    return "Jeugd";
                }
                else
                {
                    return "Volwassen";
                }
            }
            
        }


    }
}
