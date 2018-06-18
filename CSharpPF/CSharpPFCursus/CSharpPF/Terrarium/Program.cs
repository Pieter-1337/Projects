using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Program vars
            bool wrongInput = true;
            string input = "";
            bool playing = true;
            bool generateSpeelVeld = true;
            Random r = new Random();
            LeegOrganisme leegOrganisme1 = new LeegOrganisme(); //Laten staan wordt gebruikt bij het opvullen van het speelveld
            
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Voor 1'STE ACTIE VAN DE SPELER
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Initialiseren van het speelveld
            var Speelveld = new List<List<IOrganismen>>();
            for (int i = 0; i < 6; ++i)
            {
                var l = new List<IOrganismen>();
                Speelveld.Add(l);
            }

            //Willekeurig opvullen van het speelveld met alle organismen
            foreach (var list in Speelveld)
            {
                for (var i = 0; i < Speelveld.Count(); i++)
                {
                    int soortInt = r.Next(15);//Neemt een willekeurig getal 0 - 2 gebruikt in methode RandomSoort de .Random method mag steeds maar een maal geinitiliaseerd worden per variable in je programma dus nooit in een loop zetten

                    if (soortInt < 3)
                    {
                        list.Add(RandomSoort(soortInt));//Geef het willekeurig getal door aan methode RandomSoort en add een van de 3 soorten aan de lijst
                    }
                    else
                    {
                        list.Add(leegOrganisme1);//Add een leeg organisme (.) toe aan de lijst
                    }
                }
                Console.WriteLine();
            }

            while (playing == true)
            {
                while (generateSpeelVeld == true)
                {
                    Console.WriteLine("===========================================================");
                    Console.WriteLine("Het speelveld");
                    Console.WriteLine("===========================================================");

                    //Toon het speelveld
                    foreach (var list in Speelveld)
                    {
                        foreach (var element in list)
                        {
                            Console.Write(element.ToString());
                        }
                        Console.WriteLine();
                    }
                    //Zorgt ervoor dat het 1ste speelveld niet iedere maal getoond wordt bij een nieuwe dag
                    generateSpeelVeld = false;

                    //Validation op de input van de user
                    while (wrongInput == true)
                    {
                        Console.WriteLine("=========================================================== ");
                        Console.WriteLine("Druk op 1 om de volgende dag te zien");
                        Console.WriteLine("Druk op 2 om het spel te stoppen");
                        input = Console.ReadLine();
                        if (input != "1" && input != "2")
                        {
                            Console.WriteLine("=========================================================== ");
                            Console.WriteLine("Gelieve een correcte keuze te maken");
                        }
                        else
                        {
                            wrongInput = false;
                        }
                    }
                }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////NA 1'STE ACTIE VAN DE SPELER
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Alle code voor de veranderingen aan de matrix te genereren komen hierin
                    if (input == "1")
                    {
                    Console.WriteLine("===========================================================");
                    Console.WriteLine("Het speelveld vandaag voor de acties van de Organismen");
                    Console.WriteLine("===========================================================");
                    
                    //Add random plants voor een nieuwe dag
                    Plant.AddRandomPlants(Speelveld, r);
                    

                    

                    foreach (var list in Speelveld)
                    {
                        foreach (var element in list)
                        {
                            Console.Write(element.ToString());
                        }
                        Console.WriteLine();
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////
                    //Acties van de organismen
                    //////////////////////////////////////////////////////////////////////////////////////////
                    Herbivoor.HerbivoorPosRechtsLeeg(Speelveld, r);
                    Carnivoor.CarnivoorPosRechtsLeeg(Speelveld, r);
                    Herbivoor.HerbivoorEet(Speelveld);
                    Herbivoor.HerbivoorVrijt(Speelveld);
                    Carnivoor.CarnivoorEet(Speelveld);
                    Carnivoor.CarnivoorVecht(Speelveld);
                   

                    Console.WriteLine("===========================================================");
                    Console.WriteLine("Het speelveld van vandaag");
                    Console.WriteLine("===========================================================");

                    foreach (var list in Speelveld)
                    {
                        foreach (var element in list)
                        {
                            Console.Write(element.ToString());
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("=========================================================== ");
                        Console.WriteLine("Druk op 1 om de volgende dag te zien");
                        Console.WriteLine("Druk op 2 om het spel te stoppen");
                        input = Console.ReadLine();
                    }

                    //Het spel stopt de playing while loop
                    if (input == "2")
                    {
                        playing = false;
                        Console.WriteLine("=========================================================== ");
                        Console.WriteLine("Bedankt om te spelen");
                    }
                    //Het spelt geeft een foutmelding
                    if(input != "1" && input != "2")
                    {
                        Console.WriteLine("=========================================================== ");
                        Console.WriteLine("Gelieve een correcte keuze te maken");
                        input = "1";
                    }    
            }
        }//Einde Main Method


 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 //METHODS
 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Method om random soorten te spawnen bij eerste generatie van het speelveld
        public static IOrganismen RandomSoort(int soortInt)
        {
            IOrganismen result;
            result = new Plant();

            if(soortInt == 0)
            {
                result = new Plant();
            }
            if (soortInt == 1)
            {
                result = new Herbivoor();
            }
            if(soortInt == 2)
            {
                result = new Carnivoor();
            }
            if(soortInt != 0 && soortInt != 1 && soortInt != 2)
            {
                throw new Exception("Er is iets fout gegaan bij het random genereren van het speelveld");
            }
            return result;     
        }

       

        

        

        

        
    }//Einde program
}//Einde namespace
