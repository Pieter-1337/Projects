using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public abstract class Planten : IOrganismen
    {
        
        //public List<Plant> GetPlant()
        //{
        //    return List <Plant>{ };
        //}

        public Planten()
        {
            this.Soort = OrganismeSoort.Plant;
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
