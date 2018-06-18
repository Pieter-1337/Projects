using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagers
{
    public class Genre
    {
        private int GenreNrValue;
        private string GenreNaamValue;

        public Genre(int genrenr, string genrenaam)
        {
            this.GenreNrValue = genrenr;
            this.GenreNaamValue = genrenaam;
        }

        public int GenreNr
        {
            get { return GenreNrValue; }
        }

        public string GenreNaam
        {
            get { return GenreNaamValue; }
        }
    }
}
