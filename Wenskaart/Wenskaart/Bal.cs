using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wenskaart
{
    public class Bal 
    {

        public Bal(string kleur, int x, int y, string tag)
        {
            this.Kleur = kleur;
            this.xPos = x;
            this.yPos = y;
            this.Tag = tag;
        }
        public string Kleur
        {
            get;
            set;
        }

        public int xPos
        {
            get;
            set;
        }

        public int yPos
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

    }
}
