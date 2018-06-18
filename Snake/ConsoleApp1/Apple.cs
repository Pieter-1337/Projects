using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Apple
    {
        
        public Random randomPoint = new Random();
        public Coordinaat Coordinaten = new Coordinaat(0, 0);
        private int PointValue;
        
        public Apple(Coordinaat coordinaten)
        {
            this.Coordinaten = coordinaten;
            this.PointValue = Point;
        }

       public string AppleBody
        {
            get
            {
                return "O";
            }
        }

       public int Point
        {
            get
            {
                int points = randomPoint.Next(150, 251);
                return points;
            }
            
        }
            
        public static Apple RandomApple()
        {
            Random random = new Random();
            int RandomApplexPos = random.Next(1, 78);
            int RandomAppleyPos = random.Next(1, 22);
            Apple Appel = new Apple(new Coordinaat (RandomApplexPos, RandomAppleyPos));
            return Appel;
        }
    }   
}
