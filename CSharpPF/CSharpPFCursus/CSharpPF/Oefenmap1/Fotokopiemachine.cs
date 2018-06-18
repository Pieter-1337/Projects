using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Materiaal
{
    public delegate void OnderhoudsBeurt(Fotokopiemachine machine);
    public class Fotokopiemachine : IKost
    {

        //Event afkomstig van delegate onderhoudsbeurt als volgt geschreven: public event, Datatype, eventnaam
        public event OnderhoudsBeurt OnderhoudNodig;
        
    
        //Const met waarde blz tussen onderhoudsbeurt
        private const int AantalBlzTussenOnderhoudsBeurt = 10;

        //Method waarin event OnderhoudNodig zal geraised worden
        public void Fotokopieer(int aantalBlz)
        {
            for (int blz = 1; blz <= aantalBlz; blz++)
            {
                Console.WriteLine($"FotokopieMachine {SerieNr} kopieert blz. {blz} van {aantalBlz}");
                if (++AantalGekopieerdeBlz % AantalBlzTussenOnderhoudsBeurt == 0)
                {
                    //Het event OnderhoudNodig kan de waarde null bevatten als geen enkele method met het event zou verbonden zijn. Dan mag het event niet veroorzaakt worden.
                    if (OnderhoudNodig != null)
                    {
                        OnderhoudNodig(this);    
                    }
                }
            }
        }
        

        private string SerieNrValue;
        private int AantalGekopieerdeBlzValue;
        private double KostPerblzValue;

        public Fotokopiemachine(string serieNr, int aantalGekopieerdeBlz, double kostPerBlz)
        {
            this.SerieNr = serieNr;
            this.AantalGekopieerdeBlz = aantalGekopieerdeBlz;
            this.KostPerBlz = kostPerBlz;
        }

        //Afkomstig van Interface
        public double Bedrag
        {
            get
            {
                return AantalGekopieerdeBlz * KostPerBlz;
            }
        }

        //Afkomstig van Interface
        public bool Menselijk
        {
            get
            {
                return false;
            }
        }

        public string SerieNr
        {
            get
            {
                return SerieNrValue;
            }
            set
            {
                SerieNrValue = value;
            }
        }

        public int AantalGekopieerdeBlz
        {
            get
            {
                return AantalGekopieerdeBlzValue;
            }
            set
            {
                if(value < 0)
                {
                    throw new AantalBlzException("Aantal blz kan niet kleiner zijn dan 0, ingegeven waarde was", value);
                }
                else
                {
                    AantalGekopieerdeBlzValue = value;
                }
            }
        }

        public double KostPerBlz
        {
            get
            {
                return KostPerblzValue;
            }
            set
            {
                if(value <= 0)
                {
                    throw new KostPerBlzException("Kost per blz kan niet kleiner zijn dan 0, ingegeven waarde was", value);
                }
                else
                {
                    KostPerblzValue = value;
                }
            }
        }

        //Nested Exception classes
        public class KostPerBlzException : Exception
        {
            private double verkeerdeKostvalue;



            public KostPerBlzException(string message, double verkeerdeKost) : base (message)
            {
                
                this.VerkeerdeKost = verkeerdeKost;
            }

            public double VerkeerdeKost
            {
                get
                {
                    return verkeerdeKostvalue;
                }
                set
                {
                    verkeerdeKostvalue = value;
                }
            }
        }

        public class AantalBlzException : Exception
        {
            private int verkeerdeAantalBlzValue;

            public AantalBlzException(string message, int verkeerdeAantBlz) : base(message)
            {
                this.VerkeerdeAantalBlz = VerkeerdeAantalBlz;
            }

            public int VerkeerdeAantalBlz
            {
                get
                {
                    return verkeerdeAantalBlzValue;
                }
                set
                {
                    verkeerdeAantalBlzValue = value;
                }
            }
        }
             
    }
}
