using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{

    public class Bediende : Werknemer
    {
        //Delegate response method
        public void DoeOnderhoud(Firma.Materiaal.Fotokopiemachine machine)
        {
            Console.WriteLine($"{Naam} onderhoudt machine {machine.SerieNr}");
        }

        private double WeddeValue;

        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, RegimeType regime, double wedde) : base(naam, inDienst, geslacht, regime)
        {
            this.Wedde = wedde;
        }

        public override double Bedrag
        {
            get
            {
                return Wedde * 12 + Premie;
            }
        }

        private double Wedde
        {
            get
            {
                return WeddeValue;
            }
            set
            {
                if (value >= 0)
                {
                    WeddeValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Wedde: {0} Euro / Maand", Wedde);
            Console.WriteLine("Premie: {0} Euro", Premie);
        }

        public override string ToString()
        {
            Console.WriteLine("");
            return base.ToString() + ' ' + Wedde + " Euro / maand";
        }

        public override double Premie
        {
            get
            {
                return Wedde * 2;
            }
        }
    }
}
