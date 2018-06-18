using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbManagers
{
    public class Soort
    {
        public Soort(string soortNaam, int soortNummer)
        {
            this.SoortNaam = soortNaam;
            this.SoortNr = soortNummer;
        }

        public int SoortNr { get; set; }
        public string SoortNaam { get; set; }


        public override string ToString()
        {
            return SoortNaam;
        }

    }
}
