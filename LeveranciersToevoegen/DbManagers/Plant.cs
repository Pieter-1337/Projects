using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagers
{
    public class Plant
    {
        private int PlantNummerValue;
        private string PlantNaamValue;
        private string PlantSoortValue;
        private string LeverancierValue;
        private string KleurValue;
        private Decimal KostprijsValue;

        public Plant(string plantnaam, string plantsoort, string leverancier, string kleur, Decimal kostprijs, int plantnummer)
        {
            
            this.PlantNaam = plantnaam;
            this.PlantSoort = plantsoort;
            this.Leverancier = leverancier;
            this.Kleur = kleur;
            this.Kostprijs = kostprijs;
            PlantNummerValue = plantnummer;
        }
        public Plant(string plantnaam, string plantsoort, string leverancier, string kleur, Decimal kostprijs)
        {

            this.PlantNaam = plantnaam;
            this.PlantSoort = plantsoort;
            this.Leverancier = leverancier;
            this.Kleur = kleur;
            this.Kostprijs = kostprijs;
           
        }

        public Plant() { }

        public int PlantNummer
        {
            get { return PlantNummerValue; }
        }

      
        public string PlantNaam
        {
            get { return PlantNaamValue; }
            set { PlantNaamValue = value; }
        }

        public string PlantSoort
        {
            get { return PlantSoortValue; }
            set { PlantSoortValue = value; }
        }

        public string Leverancier
        {
            get { return LeverancierValue; }
            set { LeverancierValue = value; }
        }

        public string Kleur
        {
            get { return KleurValue; }
            set { KleurValue = value; }
        }

        public Decimal Kostprijs
        {
            get { return KostprijsValue; }
            set { KostprijsValue = value; }
        }

    }
}
