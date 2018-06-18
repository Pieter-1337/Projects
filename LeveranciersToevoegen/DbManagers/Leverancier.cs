using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagers
{
    public class Leverancier
    {
        private int LevNrValue;
        private string NaamValue;
        private string AdresValue;
        private string PostcodeValue;
        private string PlaatsValue;

        public bool Changed { get; set; }

        public Leverancier(int Levnr,string naam, string adres, string postcode, string plaats)
        {
            this.Naam = naam;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Plaats = plaats;
            this.LevNrValue = Levnr;
            this.Changed = false;
        }

        public Leverancier(string naam, string adres, string postcode, string plaats)
        {
            this.Naam = naam;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Plaats = plaats;
            this.Changed = false;
           
        }

        public Leverancier() { }

        public int LevNr
        {
            get { return LevNrValue; }
            
        }

        public string Naam
        {
            get { return NaamValue; }
            set
            {
                NaamValue = value;
                Changed = true;
            }
        }

        public string Adres
        {
            get { return AdresValue; }
            set
            {
                AdresValue = value;
                Changed = true;
            }
        } 

        public string Postcode
        {
            get { return PostcodeValue; }
            set
            {
                PostcodeValue = value;
                Changed = true;
            }
        }

        public string Plaats
        {
            get { return PlaatsValue; }
            set
            {
                PlaatsValue = value;
                Changed = true;
            }
        }
    }
}
