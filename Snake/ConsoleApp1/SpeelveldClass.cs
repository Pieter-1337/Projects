using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SpeelveldClass
    {
        public static int hoogteSpeelveld = 24;
        public static int breedteSpeelveld = 80;
        public static List<List<string>> speelveld = new List<List<string>>(hoogteSpeelveld);
        
        public SpeelveldClass()
        {
           initialiseerSpeelveld();
            
        }

        public static void initialiseerSpeelveld()
        {
            for (var i = 0; i < hoogteSpeelveld; i++)
            {
                speelveld.Add(new List<string>(breedteSpeelveld));
                for (var i2 = 0; i2 < breedteSpeelveld; i2++)
                {

                    speelveld[i].Add("");
                }

            }
        }
        

        public void OmkaderSpeelveld()
        {
            for (var i = 0; i < hoogteSpeelveld; i++)
            {  
                for (var i2 = 0; i2 < breedteSpeelveld; i2++)
                {
                    if (i == 0 || i == hoogteSpeelveld - 1)
                    {
                        speelveld[i][i2] = "+";
                    }   
                    else 
                    {
                        if(i2 == 0)
                        {
                            speelveld[i][i2] = "+";
                        }
                        else if(i2 == breedteSpeelveld - 1)
                        {
                            speelveld[i][i2] = "+";
                        }
                        else
                        {
                            speelveld[i][i2] = " ";
                        }
                    }                    
                }     
            }
        }

        public void TekenSpeelveld()
        {
            foreach(var list in speelveld)
            {
                foreach(var item in list)
                {
                    Console.Write(item);
                }

                Console.WriteLine("");
            }
        }

        public void SlangPlaatsen(Slang slang)
        {
            
            speelveld[slang.Coordinaten.xPos][slang.Coordinaten.yPos] = slang.BodySlang;
        }

        public void ApplePlaatsen(Apple apple)
        {
            speelveld[apple.Coordinaten.xPos][apple.Coordinaten.yPos] = apple.AppleBody;
        }

        public void BeweegSlang(Slang slang, Apple appel)
        {
            int repeat = 0;
            do
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        for (var i = 0; i < breedteSpeelveld; i++)
                        {
                            if (slang.Coordinaten.yPos == breedteSpeelveld - 1)
                            {
                                throw new Exception("Out of bounds!");
                            }
                        
                        }
                        if(speelveld[slang.Coordinaten.xPos][slang.Coordinaten.yPos] == "O")
                        {
                            slang.Score += appel.Point;
                            ApplePlaatsen(Apple.RandomApple());
                        }
                        Console.Clear();
                        speelveld[slang.Coordinaten.xPos][slang.Coordinaten.yPos - 1] = " ";
                        //speelveld[slang.Coordinaten.xPos + 1][slang.Coordinaten.yPos - 1] = " ";
                        //speelveld[slang.Coordinaten.xPos - 1][slang.Coordinaten.yPos - 1] = " ";
                        slang.Coordinaten.yPos++;
                        break;


                    case ConsoleKey.LeftArrow:
                        for (var i = 0; i < breedteSpeelveld; i++)
                        {
                            if (slang.Coordinaten.xPos == 0)
                            {
                                throw new Exception("Out of bounds!");
                            }

                        }
                        Console.Clear();
                        speelveld[slang.Coordinaten.xPos][slang.Coordinaten.yPos + 1] = " ";
                        //speelveld[slang.Coordinaten.xPos - 1][slang.Coordinaten.yPos + 1] = " ";
                        //speelveld[slang.Coordinaten.xPos + 1][slang.Coordinaten.yPos + 1] = " ";
                        slang.Coordinaten.yPos--;
                        break;

                    case ConsoleKey.UpArrow:

                        for (var i = 0; i < hoogteSpeelveld ; i++)
                        {
                            if (slang.Coordinaten.yPos == hoogteSpeelveld - 1)
                            {
                                throw new Exception("Out of bounds!");
                            }

                        }
                        Console.Clear();
                        speelveld[slang.Coordinaten.xPos + 1][slang.Coordinaten.yPos] = " ";
                        //speelveld[slang.Coordinaten.xPos + 1][slang.Coordinaten.yPos - 1] = " ";
                        //speelveld[slang.Coordinaten.xPos + 1][slang.Coordinaten.yPos + 1] = " ";
                        slang.Coordinaten.xPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        for (var i = 0; i < hoogteSpeelveld; i++)
                        {
                            if (slang.Coordinaten.yPos == 0)
                            {
                                throw new Exception("Out of bounds!");
                            }

                        }
                        Console.Clear();
                        speelveld[slang.Coordinaten.xPos - 1][slang.Coordinaten.yPos] = " ";
                        //speelveld[slang.Coordinaten.xPos - 1][slang.Coordinaten.yPos - 1] = " ";
                        //speelveld[slang.Coordinaten.xPos - 1][slang.Coordinaten.yPos + 1] = " ";
                        slang.Coordinaten.xPos++;
                        break;
                }
                repeat = 1;


            } while (repeat == 0);
        }
    }
}
