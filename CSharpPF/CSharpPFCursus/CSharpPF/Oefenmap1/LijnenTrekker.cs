using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class LijnenTrekker
    {
        //Eerste versie van method TrekLijn
        public void TrekLijn(int lengte, char teken)
        {
            for(int i = 0; i < lengte; i++)
            {
                
                Console.Write(teken);
               
            }
            Console.Write(' ');
        }

        //Tweede versie van method TrekLijn dit is een geoverloade versie van versie1
        public void TrekLijn(int lengte)
        {
            TrekLijn(lengte, '-');
        }

        //Derde versie van emthod trekLijn dit een geoverloade versie van versie1
        public void TrekLijn()
        {
            TrekLijn(97);
        }
    }
}
