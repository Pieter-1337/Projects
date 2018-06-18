using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public abstract class Werknemer : IKost
    {
        //class variable
        private string naamValue;
        private DateTime InDienstValue;
        private Geslacht geslachtValue;
        private Afdeling afdelingValue;
        private RegimeType regimeValue;
        private int vakantieValue;
        //Static class variable
        private static DateTime personeelsFeestValue;

        //Afkomstig van Interface
        public bool Menselijk
        {
            get
            {
                return true;
            }
        }

        //Afkomstig van Interface
        public abstract double Bedrag
        {
            get;
        }

        public Afdeling Afdeling
        {
            get
            {
                return afdelingValue;
            }
            set
            {
                afdelingValue = value;
            }
        }


        public Werknemer()
        {
            this.Naam = "Onbekend";
            this.InDienst = DateTime.Today;
            Console.WriteLine(this is Object);
        }


        //Static constructor voor static class variable PersoneelsFeest
        static Werknemer()
        {
            PersoneelsFeest = new DateTime(DateTime.Today.Year, 2, 1);
            while (PersoneelsFeest.DayOfWeek != DayOfWeek.Friday)
            {
                PersoneelsFeest = PersoneelsFeest.AddDays(1);
            }
        }

        //Geparametreerde constructor voor object werknemer
        public Werknemer(string naam, DateTime inDienst, Geslacht geslacht, RegimeType regime)
        {
            this.Naam = naam;
            this.InDienst = inDienst;
            this.Geslacht = geslacht;
            this.Regime = regime;

        }

        //Set Getters en Setters voor de verschillende class variables 
        public string Naam
        {
            get { return naamValue; }

            set
            {
                if (value != string.Empty)
                {
                    naamValue = value;
                }
            }
        }

        public DateTime InDienst
        {
            get
            {
                return InDienstValue;
            }
            set
            {
                InDienstValue = value;
            }
        }

        public Geslacht Geslacht
        {
            get
            {
                return geslachtValue;
            }
            set
            {
                geslachtValue = value;
            }
        }

        public RegimeType Regime
        {
            get
            {
                return regimeValue;
                
            }
            set
            {
                regimeValue = value;
            }
        }

        public int Vakantie
        {
            get
            {
                if (regimeValue == RegimeType.Voltijds)
                {
                    vakantieValue = 25;
                }
                if(regimeValue == RegimeType.Viervijfde)
                {
                    vakantieValue = 20;
                }
                if(regimeValue == RegimeType.Halftijds)
                {
                    vakantieValue = 16;
                }
                return vakantieValue;
            }
        }


        public bool VerjaarAncien
        {
            get
            {
                return InDienstValue.Month == DateTime.Today.Month && InDienstValue.Day == DateTime.Today.Day;
                //return DateTime.Today.Year - InDienstValue.Year;
            }

        }

        public static DateTime PersoneelsFeest
        {
            get
            {
                return personeelsFeestValue;
            }
            set
            {
                personeelsFeestValue = value;
            }
        }

        //Abstracte method Premie die de premies voor de verschillende types werknemers berekend
        public abstract double Premie
        {
            get;
        }



        //Method die gebruikt wordt om alle data af te beelden
        public virtual void Afbeelden()
        {
            Console.WriteLine(' ');
            Console.WriteLine("Naam: {0}", Naam);
            Console.WriteLine("Geslacht: {0}", Geslacht);
            Console.WriteLine("In dienst: {0}", InDienst);
            //Console.WriteLine("Personeelsfeest: {0}", PersoneelsFeest);
            if (Afdeling != null)
            {
                Console.WriteLine(Afdeling);
            }
            Console.WriteLine("Werkregime: {0}", Regime);
            Console.WriteLine("Vakantiedagen: {0}", Vakantie);
            Console.WriteLine("Kost per jaar {0} Euro", Bedrag);


        }

        public override string ToString()
        {
            return Naam + ' ' + Geslacht;
        }


        //Method die gecalled wordt door een delegate in program.cs
        public static void UitgebreideWerknemersLijst(Werknemer[] werknemers)
        {
            Console.WriteLine("Uitgebreide werknemerslijst:");
            foreach (Werknemer werknemer in werknemers)
            {
                werknemer.Afbeelden();
            }
        }

        //Method die gecalled wordt door een delegate in program.cs
        public static void KorteWerkenemersLijst(Werknemer[] werknemers)
        {
            Console.WriteLine("Verkorte werknemerslijst:");
            foreach (Werknemer werknemer in werknemers)
            {
                Console.WriteLine(werknemer.ToString());
            }
        }
    }
}//Einde Werknemer class

