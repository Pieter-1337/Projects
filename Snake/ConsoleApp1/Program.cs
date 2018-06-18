using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            
            SpeelveldClass Speelveld = new SpeelveldClass();
            Slang Pieter = new Slang(1, 3, 0, new Coordinaat(40, 12));
            Apple Appel = Apple.RandomApple();
            Speelveld.OmkaderSpeelveld();
            Speelveld.SlangPlaatsen(Pieter);
            Speelveld.ApplePlaatsen(Appel);
            Speelveld.TekenSpeelveld();
            Console.WriteLine($"Score: {Pieter.Score}");
            Console.WriteLine($"Levens {Pieter.Levens}");

            while (playing == true)
            {
                Speelveld.BeweegSlang(Pieter, Appel);
                Speelveld.TekenSpeelveld();
                Speelveld.SlangPlaatsen(Pieter);
                Console.WriteLine($"Score: {Pieter.Score}");
                Console.WriteLine($"Levens {Pieter.Levens}");
            }

            Console.ReadKey();
        }
    }
}
