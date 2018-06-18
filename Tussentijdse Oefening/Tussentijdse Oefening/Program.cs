using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voorwerpen.Boekenrek;
using Voorwerpen.Boeken;
using Voorwerpen.Boeken.LeesBoek;
using Voorwerpen.Boeken.WoordenBoek;




namespace Voorwerpen
{
    class Program
    {
        static void Main(string[] args)
        {
            double Winsttotaal = 0;
            Doelgroep Jeugd = new Doelgroep(17);
            Doelgroep Volwassen = new Doelgroep(18);

            Genre Fantasy = new Genre("Science Fiction", Jeugd);
            Genre Educatief = new Genre("Educatief", Volwassen);

            IVoorwerpen[] ElementenArr = new IVoorwerpen[3];

            ElementenArr[0] = new Leesboek("The Lord of the rings", "Tolkien", Eigenaar.vdab, 25, "Fantasy", Fantasy);
            ElementenArr[1] = new WoordenBoek("Dikke van Dale", "Van Dale", Eigenaar.vdab, 30, "Nederlands-Frans", Educatief);
            ElementenArr[2] = new BoekenRek(200, 150, 80);
            
            foreach(IVoorwerpen element in ElementenArr)
            {
                Console.WriteLine("");
                element.GegevensTonen();
                Winsttotaal += element.Winst;
            }
            Console.WriteLine("");
            Console.WriteLine("Totale winst: {0} ", Winsttotaal);
        }
    }
}
