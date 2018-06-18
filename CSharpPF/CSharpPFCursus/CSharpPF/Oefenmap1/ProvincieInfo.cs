using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    class ProvincieInfo
    {
        public int provincieGrootte(string provincieNaam)
        {
            StreamReader lezer = new StreamReader(@"C:\Users\User\Documents\Visual Studio 2017\provincies.txt");
            try
            {
                string regel;
                while ((regel = lezer.ReadLine()) != null)
                {
                    int dubbelPuntPos = regel.IndexOf(':');
                    string provincie = regel.Substring(0, dubbelPuntPos);
                    if (provincie == provincieNaam)
                    {
                        return int.Parse(regel.Substring(dubbelPuntPos + 1));
                    }
                }
            }
            finally
            {
                lezer.Close();
            }
            throw new Exception("Onbestaande provincie: " + provincieNaam);
            
        }
    }
}
