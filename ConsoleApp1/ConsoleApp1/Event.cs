using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectX
{
    public class Event : Events
    {
        private DateTime DatumTijdValue;
        private string LocatieValue;
        private List<Contact> UitgenodigdValue;

        public Event(DateTime datumTijd, string locatie, List<Contact> uitgenodigd) : base (datumTijd, locatie, uitgenodigd)
        {
            this.DatumTijd = datumTijd;
            this.Locatie = locatie;
            this.Uitgenodigd = uitgenodigd;
        }

        public DateTime DatumTijd
        {
            get
            {
                return DatumTijdValue;
            }
            set
            {
                //Check of de tijd in de toekomst ligt
                DatumTijdValue = value;
            }
        }

        public string Locatie
        {
            get
            {
                return LocatieValue;
            }
            set
            {
                //Eventueel Locatie link via google maps
                LocatieValue = value;
            }
        }

        public List<Contact> Uitgenodigd
        {
            get
            {
                return UitgenodigdValue;
            }
            set
            {
                UitgenodigdValue = value;
            }
        }
    }
}
