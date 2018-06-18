using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    class BankBediende
    {
        private string VoornaamValue;
        private string NaamValue;

        public BankBediende(string voornaam, string naam)
        {
            this.Voornaam = voornaam;
            this.Naam = naam;
        }

        public string Voornaam
        {
            get
            {
                return VoornaamValue;
            }
            set
            {
                VoornaamValue = value;
            }
        }

        public string Naam
        {
            get
            {
                return NaamValue;
            }
            set
            {
                NaamValue = value;
            }
        }

        public override string ToString()
        {
            return "Bankbediende " + Voornaam + ' ' + Naam;
        }

        public void ToonRekeningUitreksel(Oefenmap.Rekening rekening)
        {

            Console.WriteLine("Datum: {0:dd-MM-yyyy}", DateTime.Today);
            Console.WriteLine("Rekeninguitreksel van rekening {0}", rekening.RekeningNummer);
            Console.WriteLine("Vorig saldo: {0} euro", rekening.VorigSaldo);

            if (rekening.Saldo > rekening.VorigSaldo)
            {
                Console.WriteLine("storting van {0} euro", rekening.Saldo - rekening.VorigSaldo);
            }
            else
            {
                Console.WriteLine("Afhaling van {0} euro", rekening.VorigSaldo - rekening.Saldo);
            }
            Console.WriteLine("Nieuw saldo: {0} euro", rekening.Saldo);
        }

        public void ToonBoodschapBijSaldoInRood(Oefenmap.Rekening rekening)
        {
            Console.WriteLine("Afhaling niet mogelijk saldo ontoereikend");
            Console.WriteLine("Max af te halen saldo {0}", rekening.Saldo);
        }
    }
}
