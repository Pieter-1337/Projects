using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    [Serializable]
    public class Tweet
    {
        private string BerichtValue;

        public Tweet()
        {
            this.Tijdstip = DateTime.Now;
        }

        public string Naam
        {
            get; set;
        }
        
        public string Bericht
        {
            get
            {
                return BerichtValue;
            }
            set
            {
                if(value.Length <= 140)
                {
                    BerichtValue = value;
                }
                else
                {
                    throw new Exception("Een bericht mag maximum 140 tekens bevatten");
                }
            }
        }

        public DateTime Tijdstip { get; private set; }

        public override string ToString()
        {
            StringBuilder tweet = new StringBuilder($"{Naam}: {Bericht}: ");

            TimeSpan verschil = DateTime.Now - this.Tijdstip;

            if(verschil.Days > 0)
            {
                tweet.Append(this.Tijdstip.ToShortDateString());

            }
            else if(verschil.Hours > 0)
            {
                tweet.Append(verschil.Hours + " uur geleden");
            }
            else if(verschil.Minutes > 0)
            {
                tweet.Append(verschil.Minutes + (verschil.Minutes == 1 ? " minuut" : " minuten" + " geleden"));
            }
            else
            {
                tweet.Append(this.Tijdstip.ToShortDateString());
            }
            return tweet.ToString();
        }
    }
}
