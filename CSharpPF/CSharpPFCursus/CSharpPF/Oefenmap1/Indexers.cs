using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public class Indexers
    {
        //Creeer nieuwe array _strings om de elementen bij te houden
        private string[] _strings = new string[100];

        public string this[int i]// public indexer met string als return type, this slaat op het object overuren, [int maand] is opzoeken op nummer van de maand
        {
            get
            {
                return _strings[i];
            }
            set
            {
                _strings[i] = value;
            }
        }


        //Bij indexers steeds een Lenght property aanmaken omdat je in je hoofdprogramma de class "Indexer" geen standaard Length property heeft
        public int Length
        {
            get
            {
                return _strings.Length;
            }
        }
    }
}
