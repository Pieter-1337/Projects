using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap2
{
    public class Bird : IHuisdieren
    {
        private string NaamValue;
        private int HungerValue;
        private int WeightValue;
        public int Anger { get; set; }
        public Baasje baasje { get; set; }
        
        
        public Bird(string naam, int weight, int hunger)
        {
            this.Naam = naam;
            this.Weight = weight;
            this.Hunger = hunger;
            this.Anger = 0;
        }

        public string Naam
        {
            get
            {
                return NaamValue;
            }
            set
            {

                NaamValue = value;
            }
        }

        public int Hunger
        {
            get
            {
                return HungerValue;
            }
            set
            {
                if(value > 0)
                {
                    HungerValue = value;
                }
                else
                {
                    HungerValue = 0;
                }
            }
        }

        public int Weight
        {
            get
            {
                return WeightValue;
            }
            set
            {
                if(value > 0)
                {
                    WeightValue = value;
                }
                else
                {
                    WeightValue = 0;
                }
            }
        }

        //Methode om vogel te laten eten
        public void Eat(int amountOfFood)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine($"{this.Naam} eet {amountOfFood} vogelzaadjes");
            this.Hunger -= 20;
            this.Weight += 20;
            Console.WriteLine($"{this.Naam} weegt: {this.Weight} en heeft een honger level van {this.Hunger}");
            Console.WriteLine("==============================================================");
        }

        //Methode als vogel boos gemaakt wordt
        public void Provoke()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine($"Je daagde {this.Naam} uit");
            this.Hunger += 40;
            this.Anger += 20;
            Console.WriteLine($"{this.Naam} heeft een boosheids level van {this.Anger} en een honger level van {this.Hunger}");
            Console.WriteLine("==============================================================");
        }
    }

   
}
