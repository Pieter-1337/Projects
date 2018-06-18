using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DbManagers
{
    public class Film
    {
        private int BandNrValue;
        private string TitelValue;
        private int GenreValue;
        private int InVoorraadValue;
        private int UitVoorraadValue;
        private Decimal PrijsValue;
        private int TotaalVerhuurdValue;

        public Film( int bandnr, string titel, int genre, int invoorraad, int uitvoorraad, Decimal prijs, int totaalverhuurd)
        {
            this.BandNrValue = bandnr;
            this.TitelValue = titel;
            this.GenreValue = genre;
            this.InVoorraadValue = invoorraad;
            this.UitVoorraadValue = uitvoorraad;
            this.PrijsValue = prijs;
            this.TotaalVerhuurdValue = totaalverhuurd;
            this.changed = false;
            
        }

        public Film()
        {

        }

        public bool changed { get; set; }

        public int BandNr
        {
            get { return BandNrValue; }
        }

        public string Titel
        {
            get { return TitelValue; }
            set { TitelValue = value; }
           
        }

        public int Genre
        {
            get { return GenreValue; }
            set { GenreValue = value; }
          
        }

        public int InVoorraad
        {
            get { return InVoorraadValue; }
            set {
                InVoorraadValue = value;
                changed = true;
                }
           
        }

        public int uitVoorraad
        {
            get { return UitVoorraadValue; }
            set {
                UitVoorraadValue = value;
                changed = true;
            }
        }

        public Decimal Prijs
        {
            get { return PrijsValue; }
            set { PrijsValue = value; }
        }

        public int TotaalVerhuurd
        {
            get { return TotaalVerhuurdValue; }
            set {
                TotaalVerhuurdValue = value;
                changed = true;
            }
        }
    }
}
