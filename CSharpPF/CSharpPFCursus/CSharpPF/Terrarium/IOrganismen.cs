using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrarium
{
    public interface IOrganismen
    {
        
        OrganismeSoort Soort
        {
            get;
        }

        int LevensKracht
        {
            get;
            set;
        }

    }
}
