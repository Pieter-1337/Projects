using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class KasBon : ISpaarMiddel
    {
        private DateTime AankoopDatumValue;
        private double BedragValue;
        private int LoopTijdValue;
        private double IntrestValue;
        private Klant EigenaarValue;


        public KasBon(DateTime aankoopDatum, double bedrag, int looptijd, double intrest, Klant eigenaar)
        {
            this.AankoopDatum = aankoopDatum;
            this.Bedrag = bedrag;
            this.LoopTijd = looptijd;
            this.Intrest = intrest;
            this.Eigenaar = eigenaar;
        }

        public DateTime AankoopDatum
        {
            get
            {
                return AankoopDatumValue;
            }
            set
            {
                DateTime startDate = new DateTime(1900, 1, 1);
                if(value >= startDate)
                {
                    AankoopDatumValue = value;
                }
                else
                {
                    throw new Exception( string.Format("De aankoopDatum mag niet voor {0} beginnen", startDate.ToLongDateString()));
                }
            }
        }

        public double Bedrag
        {
            get
            {
                return BedragValue;
            }
            set
            {
                if(value > 0)
                {
                    BedragValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een positieve waarde in te geven bij bedrag");
                }
            }
        }

        public int LoopTijd
        {
            get
            {
                return LoopTijdValue;
            }
            set
            {
                if(value > 0)
                {
                    LoopTijdValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een positieve waarde in te geven bij looptijd");
                }
            }
        }

        public double Intrest
        {
            get
            {
                return IntrestValue;
            }
            set
            {
                if(value > 0)
                {
                    IntrestValue = value;
                }
                else
                {
                    throw new Exception("Gelieve een positieve waarde in te geven bij Intrest");
                }
            }
        }

        public Klant Eigenaar
        {
            get
            {
                return EigenaarValue;
            }
            set
            {
                EigenaarValue = value;
            }
        }

        public void Afbeelden()
        {
            Console.WriteLine("KASBON");
            Console.WriteLine("AankoopDatum: {0}", AankoopDatum);
            Console.WriteLine("Bedrag: {0} Euro", Bedrag);
            Console.WriteLine("Looptijd: {0} Jaar", LoopTijd);
            Console.WriteLine("Intrest: {0}%", Intrest);
            Console.WriteLine("Eigenaar: {0} {1}", Eigenaar.Voornaam, Eigenaar.Achternaam);
        }


    }
}
