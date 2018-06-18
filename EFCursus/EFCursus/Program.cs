using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace EFCursus
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Minimum Wedde: ");
            decimal minWedde = 0;
            List<Campus> campussen;

            if (decimal.TryParse("0", out minWedde))
            {

                using (var entities = new EFOpleidingenEntities())
                {
                    ///////////////////////////////////////////////////////////////////////////////
                    //1.0
                    ///////////////////////////////////////////////////////////////////////////////

                    //Simpele Query om voornaam familienaam en wedde van een docent weer te geven

                    //var query = from docent in entities.Docenten where docent.Wedde >= minWedde orderby docent.Voornaam, docent.Familienaam select docent;

                    ////Ook mogelijk als volgt
                    //var query = entities.Docenten
                    //    .Where(docent => docent.Wedde >= minWedde)
                    //    .OrderBy(docent => docent.Voornaam)
                    //    .ThenBy(docent => docent.Familienaam);

                    //foreach(var docent in query)
                    //{
                    //    Console.WriteLine($"{docent.Naam}, Wedde: {docent.Wedde} Euro");
                    //}

                    /////////////////////////////////////////////////////////////////////////////
                    //2.0
                    /////////////////////////////////////////////////////////////////////////////

                    //Geef de user verschillende opties en verbind een toepasselijke query aan deze opties

                    //       
                    //        //Geeft weer van welke type de query een object dient te returnen
                    //IQueryable<Docent> query;

                    //        Console.WriteLine("U kan sorteren op 1 (Wedde), 2 (Familienaam), 3 (Voornaam)");
                    //        var sorterenOp = Console.ReadLine();
                    //        
                    //        switch (sorterenOp)
                    //        {
                    //            case "1":

                    //                Console.WriteLine("Geef een minWedde op:");
                    //                minWedde = Convert.ToInt32(Console.ReadLine());
                    //                query = from docent in entities.Docenten where docent.Wedde >= minWedde orderby docent.Wedde select docent;
                    //                break;

                    //            case "2":
                    //                query = from docent in entities.Docenten orderby docent.Familienaam select docent;
                    //                break;

                    //            case "3":
                    //                query = from docent in entities.Docenten orderby docent.Voornaam select docent;
                    //                break;

                    //            default:
                    //                Console.WriteLine("Deze keuze is niet mogelijk");
                    //                query = null;
                    //                break;
                    //        }

                    //        if(query != null)
                    //        {
                    //            foreach(var docent in query)
                    //            {
                    //                Console.WriteLine(docent.Voornaam + " " + docent.Familienaam + " " + docent.Wedde);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("U tikte geen getal in");
                    //        }

                    ///////////////////////////////////////////////////////////////////////////////////
                    //3.0
                    ///////////////////////////////////////////////////////////////////////////////////

                    //Gebruik de find method om een entity te zoeken op zijn primary key

                    //Console.WriteLine("Geef een docentNr op:");
                    //if(int.TryParse(Console.ReadLine(), out int docentNr))
                    //{
                    //    var docent = entities.Docenten.Find(docentNr);
                    //    if(docent == null)
                    //    {
                    //        Console.WriteLine("Docent nr niet gevonden");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine(docent.Naam);
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Gelieve een getal in te tikken");
                    //}

                    ////////////////////////////////////////////////////////////////////////////////////
                    //4.0
                    ////////////////////////////////////////////////////////////////////////////////////

                    //Gebruik LinQ om gedeeltelijke objecten op te halen (enkel de geselecteerde properties van een object die geeft een betere performantie)

                    //var query = from campus in entities.Campussen orderby campus.Naam select new { campus.CampusNr, campus.Naam };

                    ////Ook mogelijk om als volgt te schrijven
                    ////var query = entities.Campussen
                    ////    .OrderBy(campus => campus.Naam)
                    ////    .Select(campus => new { campus.CampusNr, campus.Naam });


                    //foreach(var campus in query)
                    //{
                    //    Console.WriteLine(campus.CampusNr + " : " + campus.Naam);
                    //}

                    ///////////////////////////////////////////////////////////////////////////////////
                    //5.0
                    ///////////////////////////////////////////////////////////////////////////////////

                    //Groeperen van data in queries (voorbeeld alle voornamen worden in een groep gestoken op basis van hun voornaam : Groep Pieter -> alle pieters etc...)

                    //var query = from docent in entities.Docenten group docent by docent.Voornaam into VoornaamGroep select new { VoornaamGroep, Voornaam = VoornaamGroep.Key };

                    //foreach(var DocentenGroep in query)
                    //{
                    //    Console.WriteLine(DocentenGroep.Voornaam);
                    //    Console.WriteLine(new string('-', DocentenGroep.Voornaam.Length));

                    //    foreach(var docent in DocentenGroep.VoornaamGroep)
                    //    {
                    //        Console.WriteLine(docent.Naam);
                    //    }

                    //    Console.WriteLine("");
                    //}


                    //////////////////////////////////////////////////////////////////////////////////////
                    //6.0
                    //////////////////////////////////////////////////////////////////////////////////////

                    //Lazy loading -> Referenced properties aanspreken (vb campus naam voor alle Rogers in de database) -> Dit kan performantie problemen opeveren en is niet altijd aan te reden
                    //Info: campus.Naam is een referenced property afkomstig uit de tabel campussen

                    //Console.WriteLine("Voornaam: ");
                    //var voornaam = Console.ReadLine();

                    //var query = from docent in entities.Docenten where docent.Voornaam == voornaam select docent;

                    //foreach(var docent in query)
                    //{
                    //    Console.WriteLine($"{docent.Naam} : {docent.Campus.Naam}");
                    //}

                    //////////////////////////////////////////////////////////////////////////////////////
                    //7.0
                    //////////////////////////////////////////////////////////////////////////////////////

                    //Oplossing voor performantie probleem lazy loading -> Eager loading
                    //Console.WriteLine("Voornaam: ");
                    //var voornaam = Console.ReadLine();

                    ////Include een reference naar Campussen via het Include statement
                    //var query = from docent in entities.Docenten.Include("Campus") where docent.Voornaam == voornaam select docent;

                    //foreach(var docent in query)
                    //{
                    //    Console.WriteLine($"{docent.Naam} : {docent.Campus.Naam}");
                    //}

                    //////////////////////////////////////////////////////////////////////////////////////
                    //8.0
                    //////////////////////////////////////////////////////////////////////////////////////

                    //Zoeken op een deel van een naam (ingave van user)

                    //Console.WriteLine("Geef de naam (of een deel van de naam) van de campus die je zoekt op");
                    //var campusNaam = Console.ReadLine();

                    //var query = from campus in entities.Campussen.Include("Docenten") where campus.Naam.Contains(campusNaam) orderby campus.Naam select campus;

                    //foreach(var campus in query)
                    //{
                    //    Console.WriteLine(campus.Naam);
                    //    Console.WriteLine(new string('-', campus.Naam.Length));

                    //    foreach(var docent in campus.Docenten)
                    //    {
                    //        Console.WriteLine(docent.Naam);
                    //    }
                    //    Console.WriteLine("");
                    //}
                }//End of eerste using 

                ///////////////////////////////////////////////////////////////////////////////////////
                //9.0
                ///////////////////////////////////////////////////////////////////////////////////////

                //.ToList van een Query -> maakt gebruik van using System.Collections.Generic bij de namespaces
                //Declare een List<Campus> buiten de using van de entities
                //using (var entities = new EFOpleidingenEntities())
                //{
                //    var query = from campus in entities.Campussen orderby campus.Naam select campus;
                //    campussen = query.ToList();
                //}

                ////Itereer over de gemaakte list buiten de using
                //foreach(var campus in campussen)
                //{
                //    Console.WriteLine(campus.Naam);
                //}

                ////////////////////////////////////////////////////////////////////////////////////////
                //10.0
                ////////////////////////////////////////////////////////////////////////////////////////

                //Records(entities) toevoegen aan de database

                //Declare een nieuwe instantie van de campus class
                //var campus = new Campus
                //{
                //    Naam = "UGent",
                //    Straat = "Tolhuislaan",
                //    HuisNr = "96C",
                //    PostCode = "9000",
                //    Gemeente = "Gent"
                //};

                //var campus2 = new Campus
                //{
                //    Naam = "Artevelde hogeschool",
                //    Straat = "Cinema straat",
                //    HuisNr = "10",
                //    PostCode = "9000",
                //    Gemeente = "Gent",
                //};

                //var campus3 = new Campus
                //{
                //    Naam = "Andere hogeschool",
                //    Straat = "bakker straat",
                //    HuisNr = "27",
                //    PostCode = "9000",
                //    Gemeente = "Gent",
                //};

                ////Open de connectie naar EFOPleidingenDb
                //using (var entities = new EFOpleidingenEntities())
                //{
                //    entities.Campussen.Add(campus);//Add de nieuwe campus aan de bestaande db, je kan meerdere adds doen je hoeft maar een maal te saven
                //    entities.Campussen.Add(campus2); 
                //    entities.Campussen.Add(campus3);
                //    entities.SaveChanges(); //Sla de wijzigingen in de Db op
                //    Console.WriteLine(campus.CampusNr); //Schrijf eventueel wat data uit van het nieuw toegevoegde record
                //}

                //////////////////////////////////////////////////////////////////////////////////
                //11.0
                //////////////////////////////////////////////////////////////////////////////////

                //Een referenced record (entiteit) aan een nieuw record toevoegen (Je maakt eigenlijk 2 nieuwe records uit verschillende classes en links deze aan mekaar)

                //Maak 2 nieuwe records die aan elkaar gelinkt zullen worden

                //var campus4 = new Campus
                //{
                //    Naam = "Naam4",
                //    Straat = "Straat4",
                //    HuisNr = "4",
                //    PostCode = "4444",
                //    Gemeente = "Gemeente4"
                //};

                //var docent1 = new Docent
                //{
                //    Voornaam = "Voornaam1",
                //    Familienaam = "FamilieNaam1",
                //    Wedde = 1
                //};

                ////Reference de docent met de campus waar hij tewerkgesteld is
                //campus4.Docenten.Add(docent1);

                ////Open de connectie naar de database
                //using(var entiteiten = new EFOpleidingenEntities())
                //{
                //    entiteiten.Campussen.Add(campus4);
                //    entiteiten.SaveChanges();
                //}

                /////////////////////////////////////////////////////////////////////////////////////
                //12.0
                /////////////////////////////////////////////////////////////////////////////////////

                //Een nieuwe record toevoegen met een bestaande reference (Hier wordt een nieuwe docent toegevoegd en gelinkt met een reeds bestaande campus via het campusNR

                //var docent4 = new Docent
                //{
                //    Voornaam = "Voornaam4",
                //    Familienaam = "FamilieNaam4",
                //    Wedde = 4,
                //    CampusNr = 1
                //};

                //using(var entities = new EFOpleidingenEntities())
                //{
                //    entities.Docenten.Add(docent4);
                //    entities.SaveChanges();
                //}

                ///////////////////////////////////////////////////////////////////////////////////////
                //13.0
                ///////////////////////////////////////////////////////////////////////////////////////

                //Een entity (record) wijzigen

                //Console.WriteLine("Geef een docentNr in:");

                //if(int.TryParse(Console.ReadLine(),out int docentNr))
                //{
                //    using(var entities = new EFOpleidingenEntities())
                //    {
                //        var docent = entities.Docenten.Find(docentNr);
                        

                //        if(docent != null)
                //        {
                //            Console.WriteLine($"Wedde: {docent.Wedde}");
                //            Console.WriteLine("Geef het opslag bedrag in: ");

                //            if(decimal.TryParse(Console.ReadLine(), out decimal bedrag))
                //            {
                //                docent.Opslag(bedrag);
                //                entities.SaveChanges();
                //                Console.WriteLine($"Wedde na opslag: {docent.Wedde}");
                //            }
                //            else
                //            {
                //                Console.WriteLine("Gelieve een geldig bedrag in te geven");
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("Deze docent werd niet terug gevonden in onze database");
                //        }
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Gelieve een getal in te geven");
                //}

                /////////////////////////////////////////////////////////////////////////////////////////
                //14.0
                /////////////////////////////////////////////////////////////////////////////////////////

                //Entities (records) wijzigen die je hebt ingelezen via reference (associatie)

                //using(var entities = new EFOpleidingenEntities())
                //{
                //    //Zoek campus met campusnr 1
                //    var campus1 = entities.Campussen.Find(1);

                //    if(campus1 != null)
                //    {
                //        //Geef elke docent gereferenced aan campus1 opslag
                //        foreach(var docent in campus1.Docenten)
                //        {
                //            docent.Opslag(1000M);
                //        }
                //        entities.SaveChanges();
                //    }
                //}

                ////////////////////////////////////////////////////////////////////////////////////////
                //15.0
                ////////////////////////////////////////////////////////////////////////////////////////

                //Een reference (associatie)van een entity wijzigen (In het voorbeeld zullen zowel de nieuwe als de oude campus hetzelfde zijn om het verschil te zien moet je te wijzigen campus aanpassen naar een ander nr

                using(var entities = new EFOpleidingenEntities())
                {
                    //Find de te wijzigen docent
                    var docent1 = entities.Docenten.Find(1);
                    if(docent1 != null)
                    {
                        //Find de toe te wijzen campus
                        var campus2 = entities.Campussen.Find(2);
                        if(campus2 != null)
                        {
                            Console.WriteLine($"huidige campus docent: {docent1.CampusNr}");
                            //Wijs de campus toe aan de te wijzigen docent
                            docent1.Campus = campus2;

                            //Ook mogelijk is docent1.CampusNr = 2;  -> Hierbij dien je geen campus te zoeken bij entities.Campussen.Find 

                            //Save naar Database
                            entities.SaveChanges();
                            Console.WriteLine($"Nieuwe campus docent: {docent1.CampusNr}");
                        }
                        else
                        {
                            Console.WriteLine("Deze campus werd niet terug gevonden in onze database");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Deze docent werd niet terug gevonden in onze database");
                    }
                }
            }   
        }
    }
}
