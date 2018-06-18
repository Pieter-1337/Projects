using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap2
{
  
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 //Oefening Baasjes en hun vogels
    class Program
    {
        public static void Main(string[] args)
        {
            //Default vars
            bool CheckedName = false;
            bool CheckedBird = false;
            bool playing = true;
            string baasjeNaam = "";
            string input1 = "";
            string input2 = "";

            //Krijg alle baas objecten en hun gekoppelde classes (bird.cs)
            var alleBaasjes = new Baasjes().GetBaasjes();

            Console.WriteLine("==============================================================");
            Console.WriteLine("Welkom bij voer de vogel");
            Console.WriteLine("==============================================================");
            Console.WriteLine("Onderstaand kan u alle baasjes en hun vogels terug vinden!");
            Console.WriteLine("==============================================================");

            //Geef alle baasjes en hun vogels weer met een dubbele foreach loop
            foreach (var baasje in alleBaasjes)
            {
                Console.WriteLine($"Baasje: {baasje.Naam}");


                foreach (var vogel in baasje.Birds)
                {
                    Console.WriteLine($"              Vogelnaam: {vogel.Naam}");
                }
                Console.WriteLine("==============================================================");
            }

           
            while (playing == true)
            {
                //Keuze voor de speler
                Console.WriteLine("Druk op 1 om een vogel te voeren");
                Console.WriteLine("Druk op 2 om een vogel boos te maken");
                Console.WriteLine("Druk op 3 om het spel te stoppen");
                string input = Console.ReadLine();

                //check keuze
                if (input == "1")
                {
                    Console.WriteLine("Met welk baasje wenst u te voeren?");
                    input1 = Console.ReadLine();

                    Console.WriteLine("Welke Vogel wenst u te voeren? Geef zijn naam in");
                    input2 = Console.ReadLine();

                    //Query om alle data uit de lijst alleBaasjes te kunnen benaderen
                    var VogelQuery = from Baasje in alleBaasjes select Baasje;

                    //Foreach loop met check of de gekozen naam bestaat
                    foreach (var Baasje in VogelQuery)
                    {
                        if (Baasje.Naam == input1)
                        {
                            CheckedName = true;
                            foreach (var Bird in Baasje.Birds)
                            {
                                baasjeNaam = Baasje.Naam;
                                if (Bird.Naam == input2)
                                {
                                    //Uit te voeren functies bij gevonden naam
                                    Baasje.Voer(input2);
                                    Bird.Eat(20);
                                    CheckedBird = true;
                                }
                            }
                        }

                    }
                    //ifs als het opgegeven baasje of vogel niet terug gevonden werd in de foreach loop
                    if (CheckedName == false)
                    {
                        Console.WriteLine("==============================================================");
                        Console.WriteLine("Dit baasje is niet te vinden in onze database");
                        Console.WriteLine("==============================================================");
                    }
                    if (CheckedName == true && CheckedBird == false)
                    {
                        Console.WriteLine("==============================================================");
                        Console.WriteLine($"{input1} heeft geen vogel met deze naam");
                        Console.WriteLine("==============================================================");
                    }
                   
                }

                //Check keuze
                if (input == "2")
                {
                    Console.WriteLine("Van welk baasje wenst u een vogel boos te maken?");
                    input1 = Console.ReadLine();

                    Console.WriteLine("Welke Vogel wenst u boos te maken? Geef zijn naam in");
                    input2 = Console.ReadLine();

                    //Query om alle data uit de lijst alleBaasjes te kunnen benaderen
                    var VogelQuery = from Baasje in alleBaasjes select Baasje;

                    //Foreach loop met check of de gekozen naam bestaat
                    foreach (var Baasje in VogelQuery)
                    {
                        if (Baasje.Naam == input1)
                        {
                            CheckedName = true;
                            foreach (var Bird in Baasje.Birds)
                            {
                                baasjeNaam = Baasje.Naam;
                                if (Bird.Naam == input2)
                                {
                                    //Uit te voeren functies bij gevonden naam
                                    Baasje.MaakBoos(input2);
                                    Bird.Provoke();
                                    CheckedBird = true;
                                }
                            }
                        }

                    }
                    //ifs als het opgegeven baasje of vogel niet terug gevonden werd in de foreach loop
                    if (CheckedName == false)
                    {
                        Console.WriteLine("==============================================================");
                        Console.WriteLine("Dit baasje is niet te vinden in onze database");
                        Console.WriteLine("==============================================================");
                    }
                    if (CheckedName == true && CheckedBird == false)
                    {
                        Console.WriteLine("==============================================================");
                        Console.WriteLine($"{input1} heeft geen vogel met deze naam");
                        Console.WriteLine("==============================================================");
                    }
                
                }
                //Check keuze
                if (input == "3")
                {
                    //While loop stoppen als speler niet meer wil spelen
                    playing = false;
                    Console.WriteLine("Bedankt om te spelen!");
                    Console.WriteLine("==============================================================");
                }
                //Als ingegeven keuze niet tot de mogelijkheden behoort krijgt de speler een bericht en gaat de while loop opnieuw van start
                if(input != "1" && input != "2" && input != "3")
                {
                    Console.WriteLine("Gelieve een correcte keuze te maken!");
                    Console.WriteLine("==============================================================");
                   
                }
            }
        }
    }

}//Einde van namespace
