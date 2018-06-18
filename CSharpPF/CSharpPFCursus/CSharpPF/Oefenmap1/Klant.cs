using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    public class Klant
    {
        private string voornaamValue;
        private string achternaamValue;

        public Klant(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }

        public string Voornaam
        {
            get
            {
                return voornaamValue;
            }
            set
            {
                voornaamValue = value;
            }
        }

        public string Achternaam
        {
            get
            {
                return achternaamValue;
            }
            set
            {
                achternaamValue = value;
            }
        }

        public void Afbeelden()
        {
            Console.WriteLine("Voornaam: {0}", Voornaam);
            Console.WriteLine("Achternaam {0}", Achternaam);
        }
    }
}
