using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap2
{
    public class Baasje
    {
        public string Naam { get; set; }
        public List<Bird> Birds { get; set; }

        //Methode om vogels te voeren
        public void Voer(string vogel)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine( $"{this.Naam} voert {vogel}");  
        }

        //Methode om vogels boos te maken
        public void MaakBoos(string vogel)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine($"{this.Naam} Maakt {vogel} boos!");
        }

    }

   
}
