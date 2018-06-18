using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class ZichtRekening : Rekening
    {
        private double MaxKredietValue;

        public ZichtRekening(double maxKrediet) : base(rekeningNummer, saldo, creatieDatum)
        {
            this.MaxKrediet = maxKrediet;
        }

        private double MaxKrediet
        {
            get
            {
                return MaxKredietValue;
            }
            set
            {
                if(value >= 0)
                {
                    MaxKredietValue = value;
                }
            }
        }
    }
}
