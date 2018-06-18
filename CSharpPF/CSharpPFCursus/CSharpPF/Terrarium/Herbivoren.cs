using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public abstract class Herbivoren : IOrganismen
    {
       
        //public List<Herbivoor> GetHerbivoren()
        //{
        //    return List<Herbivoor>{ };
        //}

        public Herbivoren()
        {
            this.Soort = OrganismeSoort.Herbivoor;
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
