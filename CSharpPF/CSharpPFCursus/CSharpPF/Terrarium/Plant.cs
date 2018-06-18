using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public class Plant : Planten
    {
       
        public Plant() : base()
        {
            
        }

        public override string ToString()
        {
            return "P      ";
        }

        public string Gegevens()
        {
            return $"Soort: {this.Soort}, Levenskracht: {this.LevensKracht}";
        }

         //Method om elke dag random planten te spawnen
        public static void AddRandomPlants(List<List<IOrganismen>> Speelveld, Random r)
        {
            int intPlant;
            foreach(var list in Speelveld)
            {
                for(var element = 0; element < Speelveld.Count(); element++)
                {
                    intPlant = r.Next(15);

                    if (intPlant < 3)
                    {
                        //Bepaal het type van de soort in de lijst
                        var Typebepalen = list[element].GetType();
                        //Vergelijk het bepaalde type met de het type van het te vervangen organisme
                        if (Typebepalen == typeof(LeegOrganisme))
                        {
                            list[element] = new Plant();
                        }
                    }
                }
            }
        }
        
    }


}
