using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////
            //Oefening 02 Klanten met hun rekeningen weer geven
            ///////////////////////////////////////////////////////////////////

            //using(var entities = new EFBankEntities())
            //{
            //    var query = from klant in entities.Klanten.Include("Rekeningen") orderby klant.Voornaam select klant;
            //    decimal saldo;

            //    foreach(var klant in query)
            //    {
            //        saldo = 0;
            //        Console.WriteLine(klant.Voornaam);
            //        foreach(var rekening in klant.Rekeningen)
            //        {
            //            Console.WriteLine(rekening.RekeningNr + " : " + rekening.Saldo);
            //            saldo += Convert.ToDecimal(rekening.Saldo);
            //        }

            //        Console.WriteLine("Totaal: " + saldo);
            //        Console.WriteLine("");
            //    }

                
            //}

            /////////////////////////////////////////////////////////////////////
            //Oefening 03 Een zichtrekening toevoegen bij een bestaande klant
            /////////////////////////////////////////////////////////////////////

            //using(var entities = new EFBankEntities())
            //{
            //    var query = from klant in entities.Klanten orderby klant.KlantNr select klant;
            //    var klantnummer = 0;
            //    var rekeningnummer = "";

            //    foreach(var klant in query)
            //    {
            //        Console.WriteLine($"{klant.KlantNr} : {klant.Voornaam}");
            //    }

            //    try
            //    {

            //        Console.WriteLine("Kies een klantnummer voor welke u een rekening wenst toe te voegen");
            //        klantnummer = int.Parse(Console.ReadLine());
            //        var GeselecteerdeKlant = entities.Klanten.Find(klantnummer);
            //        if (GeselecteerdeKlant == null)
            //        {
            //            Console.WriteLine($"Klant met klantnummer {klantnummer} werd niet gevonden in onze database");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Geef een rekeningnummer in:");
            //            rekeningnummer = Console.ReadLine();

            //            var nieuweRekening = new Rekening
            //            {
            //                Soort = "Z",
            //                RekeningNr = rekeningnummer,
            //                Saldo = 0
            //            };

            //            GeselecteerdeKlant.Rekeningen.Add(nieuweRekening);
            //            entities.SaveChanges();
            //        }        
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Gelieve een getal in te tikken");
            //    }
                
            //}

            /////////////////////////////////////////////////////////////////////////////////////////////////////
            //Oefening 4 een bedrag storten op een rekening
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            
            using(var entities = new EFBankEntities())
            {
                Console.WriteLine("Geef een rekeningnummer in");
                var rekeningNr = Console.ReadLine();

                var rekening = entities.Rekeningen.Find(rekeningNr);
                if(rekening != null)
                {
                    Console.WriteLine("Geef een bedrag in om te storten");
                   
                    if(decimal.TryParse(Console.ReadLine(),out decimal bedrag))
                    {
                        Console.WriteLine($"Oud saldo {rekening.RekeningNr}: {rekening.Saldo}");
                        rekening.Storten(bedrag);
                        entities.SaveChanges();
                        Console.WriteLine($"Nieuw saldo {rekening.RekeningNr}: {rekening.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Gelieve een bedrag in te geven");
                    }
                }
                else
                {
                    Console.WriteLine("Dit rekening nummer werd niet terug gevonden in onze database");
                }
            }

        }
    }
}
