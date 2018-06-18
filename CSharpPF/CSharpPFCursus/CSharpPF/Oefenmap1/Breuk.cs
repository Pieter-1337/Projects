using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Breuk
    {
        private int TellerValue;
        private int NoemerValue;

        public Breuk(int teller, int noemer)
        {
            this.Teller = teller;
            this.Noemer = noemer;
        }

        public int Teller
        {
            get
            {
                return TellerValue;
            }
            set
            {
                if(value > 0)
                {
                    TellerValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een getal groter dan 0 in te geven.");
                }
            }
        }

        public int Noemer
        {
            get
            {
                return NoemerValue;
            }
            set
            {
                if(value != 0)
                {
                    NoemerValue = value;
                }
                else
                {
                    throw new Exception("Noemer mag niet nul zijn.");
                }
            }
        }

        public override string ToString()
        {
            return Teller + "/" + Noemer;
        }

        public override bool Equals(object obj)
        {
            if(obj is Breuk)
            {
                Breuk andereBreuk = (Breuk)obj;
                return (decimal)Teller / Noemer == (decimal)andereBreuk.Teller / andereBreuk.Noemer;
             }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Teller + Noemer;
        }

    }
}
