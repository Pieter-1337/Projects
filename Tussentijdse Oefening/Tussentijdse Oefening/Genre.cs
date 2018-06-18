using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Voorwerpen.Boeken
{
    public class Genre 
    {
        
        private string NaamValue;
        private Doelgroep DoelGroepValue;
        

        public Genre(string naam, Doelgroep doelgroep)
        {
            this.Naam = naam;
            this.DoelGroep = doelgroep;
        }

        public string Naam
        {
            get
            {
                return NaamValue;
            }
            set
            {
                NaamValue = value;
            }
        }

        public Doelgroep DoelGroep
        {
            get
            {
                return DoelGroepValue;
            }
            set
            {
                DoelGroepValue = value;
            }
        }
    }
}
