using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap2
{
    public class Baasjes
    {
        //Lijst maken van alle baasjes en hun vogels (deze lijst wordt opgevraagd in de main method via "alleBaasjes = new Baasjes().GetBaasjes();
        public List<Baasje> GetBaasjes()
        {
            Baasje Pieter = new Baasje { Naam = "Pieter" };
            Pieter.Birds = new List<Bird>
            {
               new Bird("Arie", 100, 100),
               new Bird("Bassie", 100, 100)   
            };

            Baasje Maarten = new Baasje { Naam = "Maarten" };
            Maarten.Birds = new List<Bird>
            {
               new Bird("Moepie", 100, 100),
               new Bird("Floepie", 100, 100),
               new Bird("Arie", 100,100)
            };

            return new List<Baasje> { Pieter , Maarten};
        }
    }
}
