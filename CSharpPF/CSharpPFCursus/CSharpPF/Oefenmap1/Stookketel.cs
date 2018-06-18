using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class Stookketel : IVervuiler 
    {
        private double VervuilingValue;
        private double CONormValue;

        public Stookketel(double coNorm)
        {
            this.CONormValue = coNorm;
        }

        public double Vervuiling
        {
            get
            {
                return GeefVervuiling();
            }
            
        }

        public double CONorm
        {
            get
            {
                return CONormValue;
            }
            set
            {
                CONormValue = value;
            }
        }

        public void Afbeelden()
        {
            Console.WriteLine("De vervuiling van het toestel bedraagd: {0}", Vervuiling);
        }

        public double GeefVervuiling()
        {
            VervuilingValue = CONorm * 100;
            return VervuilingValue;
        }
    }
}
