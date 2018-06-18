using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public class PuntenLeerlingen
    {
        private int[] LeerlingNummerValue = new int[5];
        private readonly string[] LeerlingNamenValue = { "Pieter", "Maarten", "Eline", "Marc", "Ilse" };
        

      

        public int this[int LeerlingNummer]
        {
            get
            {
                return LeerlingNummerValue[LeerlingNummer];
            }
            set
            {
                LeerlingNummerValue[LeerlingNummer] = value;
            }
        }

        public int this[string LeerlingNummer]
        {
            get
            {
                return LeerlingNummerValue[WelkeLeerling(LeerlingNummer)];
            }
            set
            {
                LeerlingNummerValue[WelkeLeerling(LeerlingNummer)] = value;
            }

        }

        private int WelkeLeerling(string LeerlingNummer)
        {
            int leerling = Array.IndexOf(LeerlingNamenValue, LeerlingNummer);
            if(leerling == -1)
            {
                throw new IndexOutOfRangeException("Onbestaande Leerling: " + LeerlingNummer);
            }
            return leerling;
        }

       public int Gemiddelde
        {
            get
            {
                int gemiddelde = 0;
                foreach (int leerling in LeerlingNummerValue)
                {
                    gemiddelde += leerling; 
                }
                gemiddelde = gemiddelde / LeerlingNummerValue.Length;
                return gemiddelde;
            }
        }
    }
}
