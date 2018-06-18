using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public class LeegOrganisme : IOrganismen
    {
        private OrganismeSoort SoortValue;
        private int LevensKrachtValue;
            public LeegOrganisme()
            {
            this.Soort = OrganismeSoort.Leeg;
            this.LevensKracht = 0;
            }
            
            public OrganismeSoort Soort
            {
                get; set;
            }

            public int LevensKracht
            {
            get;
            set;
            }

            public override string ToString()
            {
                return $".      ";
            }

            public string Gegevens()
            {
                return $"Soort: {this.Soort}, Levenskracht: {this.LevensKracht}";
            }
        
    }
}
