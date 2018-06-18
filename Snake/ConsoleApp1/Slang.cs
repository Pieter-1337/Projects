using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Slang
    {
        private int lengteSlangValue;
        private int levensValue;
        private int scoreValue;
        private string bodySlangValue;
        public Coordinaat Coordinaten = new Coordinaat(0, 0);
        
        

        public Slang(int lengte, int levens, int score, Coordinaat coordinaten )
        {
            this.LengteSlang = lengte;
            this.Levens = levens;
            this.Score = score;
            this.BodySlang = bodySlangValue;
            this.Coordinaten = coordinaten;       
        }

        public int LengteSlang
        {
            get
            {
                return lengteSlangValue;
            }
            set
            {
                lengteSlangValue = value;
            }
        }

        public int Levens
        {
            get
            {
                return levensValue;
            }
            set
            {
                levensValue = value;
            }
        }

        public int Score
        {
            get
            {
                return scoreValue;
            }

            set
            {
                scoreValue = 0;
            }
        }

        public string BodySlang
        {
            get
            {
                return bodySlangValue;
            }
            set
            {
                bodySlangValue = "x";
            }
        }

       

        
    }
}
