using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    public class Werknemer
    {
        //class variable
        private string naamValue;
        private DateTime InDienstValue;
        private Geslacht geslachtValue;

        //Static class variable
        private static DateTime personeelsFeestValue;


        
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
        public Werknemer(string naam, DateTime inDienst, Geslacht geslacht)
        {
            this.Naam = naam;
            this.InDienst = inDienst;
            this.Geslacht = geslacht;
            
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
            get {
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

        //Method die gebruikt wordt om alle data af te beelden
        public  virtual void Afbeelden()
        {
            Console.WriteLine(' ');
            Console.WriteLine("Naam: {0}", Naam);
            Console.WriteLine("Geslacht: {0}", Geslacht);
            Console.WriteLine("In dienst: {0}", InDienst);
            Console.WriteLine("Personeelsfeest: {0}", PersoneelsFeest);
            

        }

        public override string ToString()
        {
            return Naam + ' ' + Geslacht;
        }
        
        
        
    }
}
