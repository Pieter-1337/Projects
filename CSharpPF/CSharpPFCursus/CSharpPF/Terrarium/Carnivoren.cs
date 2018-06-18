using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public abstract class Carnivoren : IOrganismen
    {
        
        public Carnivoren()
        {
            this.Soort = OrganismeSoort.Carnivoor;
            this.LevensKracht = 10;
        }

        public OrganismeSoort Soort
        {
            get;
            set;
        }

        public int LevensKracht
        {
            get;
            set;
        }
    }
}
