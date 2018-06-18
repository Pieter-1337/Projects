using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefenmap
{
    
  class Rekening
  {
        private readonly DateTime EersteCreatie = new DateTime(1900, 1, 1);
            private string rekeningNummerValue;
            private decimal saldoValue;
            private DateTime creatieDatumValue;

           

            public string RekeningNummer
            {
                get
                {
                return rekeningNummerValue;
                }
                set
                {
                    if (CheckRekening(value))
                    {
                        rekeningNummerValue = value;
                    }
                    else
                    {
                    rekeningNummerValue = "Foutief rekeningnummer";
                    }
                }
            }

            public decimal Saldo
            {
                get
                {
                    return saldoValue;
                }
                set
                {
                    saldoValue = value;
                }
            }

            public DateTime CreatieDatum
            {
                get
                {
                    return creatieDatumValue;
                }
                set
                {
                    if(value >= EersteCreatie)
                    {
                        creatieDatumValue = value;
                    }
                }
            }

        public Rekening(string rekeningNummer, decimal saldo, DateTime creatieDatum)
        {
            this.RekeningNummer = rekeningNummer;
            this.Saldo = saldo;
            this.CreatieDatum = creatieDatum;
        }

        public void Afbeelden()
        {
            Console.WriteLine("Rekeningnummer: {0}", RekeningNummer);
            Console.WriteLine("Saldo: {0}", Saldo);
            Console.WriteLine("Creatie datum: {0}", CreatieDatum);
        }

        public void Storten(decimal bedrag)
        {
            
            Saldo = Saldo + bedrag;
            
        }

        private bool CheckRekening(string RekeningNummer)
        {
            bool check = false;
            //string errorMessage = "";
            //Check if rekeningnummer de juiste lengte heeft
            if (RekeningNummer.Length != 16)
            {
                check = false;
                //errorMessage = "Gelieve een Belgisch Iban nummer van 16 tekens in te geven";
            }
            else {
                //Take eerste 2 teken en kijk of het deze BE bevatten in eerste if statement
                string eerste2Tekens = RekeningNummer.Substring(0, 2);

                //Take 3de en 4de teken en check of het nummers zijn
                string derdeEnVierdeTekens = RekeningNummer.Substring(2, 2);
                bool isNumeric = int.TryParse(derdeEnVierdeTekens, out int n);
                

                //Take volgende 10 cijfers en laatste 2 cijfer en bereken de rest als result
                decimal volgende10CijfersInt = Convert.ToInt64(RekeningNummer.Substring(4, 10));
                decimal laatste2CijfersInt = Convert.ToInt64(RekeningNummer.Substring(14, 2));
                decimal result = volgende10CijfersInt % 97;
                //Check if eerste 2 tekens BE zijn
                if (eerste2Tekens != "BE")
                {
                    //errorMessage = "Gelieve een Iban nummer beginnende met BE in te geven";
                    check = false;
                }
                else
                {
                    //Check if 3de en 4de teken cijfers zijn
                    if (!isNumeric)
                    {
                        //errorMessage = "Gelieve als derde en vierde character cijfers in te geven";
                        check = false;
                    }
                    else
                    {
                        //Check if rest van gelijk is aan laatste 2 cijfers van rekeningnummer
                        if (result == laatste2CijfersInt)
                        {
                            //errorMessage = "Dit is een correct rekeningnummer";
                            check = true;

                        }
                    }
                }
            }
           return check;
        }

  }
    
}
