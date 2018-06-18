using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public class Herbivoor : Herbivoren
    {
        public Herbivoor() : base()
        {

        }

        public override string ToString()
        {
            return $"H      ";
        }

        public string Gegevens()
        {
            return $"Soort: {this.Soort}, Levenskracht: {this.LevensKracht}";
        }

        //method als er rechts van een herbivoor een plant staat wordt deze opgegeten
        public static void HerbivoorEet(List<List<IOrganismen>> Speelveld)
        {
            foreach(var list in Speelveld)
            {
                for(var element = 0; element < Speelveld.Count(); element++)
                {
                    if (list[element] != list[5])
                    {
                        if (list[element].GetType() == typeof(Herbivoor) && list[element + 1].GetType() == typeof(Plant))
                        {
                            list[element + 1] = new LeegOrganisme();
                            ++list[element].LevensKracht;
                        }
                    }
                }
            }
        }

        //method als er rechts van een herbivoor nog een herbivoor staat en ze vrijën
        public static void HerbivoorVrijt(List<List<IOrganismen>> Speelveld)
        {
            bool plaatsenHerbivoor = true;

            foreach (var list in Speelveld)
            {
                for (var element = 0; element < Speelveld.Count(); element++)
                {
                    if (list[element] != list[5])
                    {
                        if (list[element].GetType() == typeof(Herbivoor) && list[element + 1].GetType() == typeof(Herbivoor))
                        {
                            
                            //Random plaatsen van 1 nieuwe herbivoor
                            
                                foreach (var list2 in Speelveld)
                                {
                                    for (var element2 = 0; element2 < Speelveld.Count(); element2++)
                                    {
                                        while (plaatsenHerbivoor == true)
                                        {
                                            if (list2[element2].GetType() == typeof(LeegOrganisme))
                                            {
                                                plaatsenHerbivoor = false;
                                                list2[element2] = new Herbivoor();
                                                list2[element2].LevensKracht = 0;

                                            }
                                        }
                                    }
                                }
                            
                        }
                    }
                }
            }
        }

        //Method als er rechts een lege plaats is van een herbivoor zet deze (indien mogelijk "Geen andere organismen of buiten het speelveld) willekurig een stap omhoog, omlaag, rechts of links
        public static void HerbivoorPosRechtsLeeg(List<List<IOrganismen>> Speelveld, Random r)
        {
            var previousList = Speelveld[0];
            var nextList = Speelveld[0];
        
            int intStap = 0;
            int x = 0;
            foreach (var list in Speelveld)
            {
                if(list != Speelveld[0])
                {
                    previousList = Speelveld[x - 1];
                }

                if(list != Speelveld[5])
                {
                    nextList = Speelveld[x + 1];
                }
                // x Wordt gebruikt om de index van het speelveld te bepalen
                x++;

                
                for (var element = 0; element < Speelveld.Count(); element++)
                {
                    
                    if (list[element] != list[5])
                    {
                        if (list[element].GetType() == typeof(Herbivoor) && list[element + 1].GetType() == typeof(LeegOrganisme))
                        {
                            string[] Richtingen = new string[4]; 
                            Richtingen[0] = "Rechts";
                            Richtingen[1] = "leeg";
                            Richtingen[2] = "leeg";
                            Richtingen[3] = "leeg";
                            
                            
                            //Teller die bijhoudt in hoeveel richtingen er kan bewogen worden
                            int possibleDirectionsNum = 1;
                           
                            //Console.WriteLine("Rechts leeg");
                            
                            //check range waarin de herbivoor zich kan voortbewegen

                                //Controleer of het te checken item niet het als eerste in de lijst staat
                                if(list[element] != list[0]){
                                    //Check of links leeg is
                                    if(list[element - 1].GetType() == typeof(LeegOrganisme))
                                    {
                                        //Console.WriteLine("Links leeg");
                                        Richtingen[1] = "Links";
                                    }
                                }
                                
                                //Check of boven leeg is
                                if(Speelveld[0] != list){
                                    if(previousList[element].GetType() == typeof(LeegOrganisme))
                                    {
                                        //Console.WriteLine("Boven leeg");
                                        Richtingen[2] = "Boven";
                                    }
                                }

                                //Check of onder leeg is
                                if(Speelveld[5] != list)
                                {
                                    if(nextList[element].GetType() == typeof(LeegOrganisme))
                                    {
                                        //Console.WriteLine("Onder leeg");
                                        Richtingen[3] = "Onder";
                                    }
                                }

                                string richting = "leeg";                                 
                                while(richting == "leeg")
                                    {
                                        richting = Richtingen[new Random().Next(0,Richtingen.Length - 1) ];
                                        //Console.WriteLine("de random richting is:{0}", richting);
                                    }
                                 
                                 
                                            if(richting == "Rechts")
                                            {
                                                list[element + 1] = list[element];
                                                list[element] = new LeegOrganisme();
                                            }
                                            if(richting == "Links")
                                            {
                                                list[element - 1] = list[element];
                                                list[element] = new LeegOrganisme();
                                            }
                                            if(richting == "Boven")
                                            {
                                                previousList[element] = list[element];
                                                list[element] = new LeegOrganisme();
                                            }
                                            if(richting == "Onder")
                                            {
                                                nextList[element] = list[element];
                                                list[element] = new LeegOrganisme();
                                            }
                                     
                        }
                    }
                }
            }
        }
    }
}
