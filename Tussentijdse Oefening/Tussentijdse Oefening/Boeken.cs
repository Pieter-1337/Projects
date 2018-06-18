using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorwerpen.Boeken
{
    abstract class Boeken : IVoorwerpen
    {
        //Enum to expand owners if needed
        

        //class variables for boeken
        private string TitelValue;
        private string AuteurValue;
        private Eigenaar EigenaarValue;
        private double AankooPrijsValue;
        private Genre GenreValue;
        
        public Boeken(string titel, string auteur, Eigenaar eigenaar, double aankoopPrijs, Genre genre)
        {
            this.Titel = titel;
            this.Auteur = auteur;
            this.Eigenaar = eigenaar;
            this.AankoopPrijs = aankoopPrijs;
            this.Genre = genre;
        }

        public string Titel
        {
            get
            {
                return TitelValue;
            }
            set
            {
                TitelValue = value;
            }
        }

        public string Auteur
        {
            get
            {
                return AuteurValue;
            }
            set
            {
                AuteurValue = value;
            }
        }

        public Eigenaar Eigenaar
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

        public double AankoopPrijs
        {
            get
            {
                return AankooPrijsValue;
            }
            set
            {
                if (value >= 0)
                {
                    AankooPrijsValue = value;
                }
            }
        }

        public Genre Genre
        {
            get
            {
                return GenreValue;
            }
            set
            {
                GenreValue = value;
            }
        }


        public virtual double Winst
        {
            get;
            
        }
      
    
        public virtual void GegevensTonen()
        {
            Console.WriteLine($"Titel: {Titel}");
            Console.WriteLine($"Auteur: {Auteur}");
            Console.WriteLine($"Eigenaar: {Eigenaar}");
            Console.WriteLine($"AankoopPrijs: {AankoopPrijs} Euro");
            Console.WriteLine($"Genre: {Genre.Naam}");
            Console.WriteLine($"Doelgroep: {Genre.DoelGroep.Categorie}");
        }
    }
}
