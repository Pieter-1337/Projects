using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//BELANGRIJKE STANDAARD FUNCTIES
//////////////////////////////////////////////////////////////////////////////////
//int x = (int)'A'; ---------> Geeft nummer van de ASCII code van letter A weer 
//////////////////////////////////////////////////////////////////////////////////

namespace Oefenmap
{
    //1. VARIABELEN CONSTANTEN EN BEWERKINGEN OEFENINGEN
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Oefening conversie van Celsius naar fahrenheit

    //class ConversieCelcius_Fahrenheit
    //{
    //    const float GemLichTempCelsius = 37.0F;
    //    static void Main(string[] args)
    //    {
    //        float GemLichTempFahrenheit = GemLichTempCelsius * 9.0F / 5.0F + 32.0F;
    //        Console.WriteLine("De gemiddelde lichaamstemperatuur in Celsius is: {0}", GemLichTempCelsius);
    //        Console.WriteLine("De gemiddelde lichtaamstemperatuur in Fahrenheit is: {0}", GemLichTempFahrenheit);     
    //    }
    //}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Oefening omrekening van seconden naar uren minuten seconden

    //class OmrekeningSeconden
    //{
    //    const int aantalSecondenInEenUur = 3600;
    //    const int aantalSecondenInEenMinuut = 60;
    //    static void Main(string[] args)
    //    {
    //        //Manier zelf berekend
    //        int aantalSeconden = 3736;
    //        int uren, minuten, seconden, restseconden;
    //        uren = aantalSeconden / aantalSecondenInEenUur;
    //        restseconden = aantalSeconden % aantalSecondenInEenUur;
    //        minuten = restseconden / aantalSecondenInEenMinuut;
    //        seconden = restseconden % aantalSecondenInEenMinuut;
    //        Console.WriteLine("U: {0}, M: {1}, S: {2}", uren, minuten, seconden);

    //        ////Manier via .Net library
    //        //int aantalSeconden = 3736;
    //        TimeSpan rekenOm = TimeSpan.FromSeconds(aantalSeconden);
    //        Console.WriteLine(rekenOm.ToString());
    //    }
    //}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //SnoepAutomaat

    //    class SnoepAutomaat{

    //        const double invoerMunt = 2.0;
    //        static void Main(string[] args)
    //        {
    //            double bedrag = 1.04;
    //            int aantal1Euro, aantal50Cent, aantal20Cent, aantal10Cent, aantal5Cent, aantal2Cent, aantal1Cent;

    //            double wisselGeld = invoerMunt - bedrag;
    //            int wisselGeldCenten = (int)(wisselGeld * 100);

    //            //bepaal hoeveel er van een bepaald stuk genomen dient te worden
    //            aantal1Euro = wisselGeldCenten / 100;
    //            //Herbereken het overgebleven bedrag dat dient terug betaald te worden
    //            wisselGeldCenten %= 100;

    //            aantal50Cent = wisselGeldCenten / 50;
    //            wisselGeldCenten %= 50;

    //            aantal20Cent = wisselGeldCenten / 20;
    //            wisselGeldCenten %= 20;

    //            aantal10Cent = wisselGeldCenten / 10;
    //            wisselGeldCenten %= 10;

    //            aantal5Cent = wisselGeldCenten / 5;
    //            wisselGeldCenten %= 5;

    //            aantal2Cent = wisselGeldCenten / 2;

    //            aantal1Cent = wisselGeldCenten % 2;

    //            Console.WriteLine("Te betalen: {0}", bedrag);
    //            Console.WriteLine("");
    //            Console.WriteLine("Wisselgeld: {0}", wisselGeld);
    //            Console.WriteLine("Munten van 1  euro: {0}", aantal1Euro);
    //            Console.WriteLine("Munten van 50 cent: {0}", aantal50Cent);
    //            Console.WriteLine("Munten van 20 cent: {0}", aantal20Cent);
    //            Console.WriteLine("Munten van 10 cent: {0}", aantal10Cent);
    //            Console.WriteLine("Munten van 5  cent: {0}", aantal5Cent);
    //            Console.WriteLine("Munten van 2  cent: {0}", aantal2Cent);
    //            Console.WriteLine("Munten van 1  cent: {0}", aantal1Cent);

    //        }
    //    }


    //2. OEFENINGEN OP SELECTIES
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Kortingsbon

    //class kortingsbon
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.Write("Voer het aankoopbedrag in:");
    //        decimal aankoopBedrag = Convert.ToDecimal(Console.ReadLine());
    //        decimal kortingsBon = 0;

    //        if(aankoopBedrag < 26)
    //        {
    //            kortingsBon = (aankoopBedrag / 100) * 1;
    //        }
    //        else if(aankoopBedrag > 25 && aankoopBedrag < 51)
    //        {
    //            kortingsBon = (aankoopBedrag / 100) * 2;
    //        }
    //        else if(aankoopBedrag > 50 && aankoopBedrag < 101)
    //        {
    //            kortingsBon = (aankoopBedrag / 100) * 3;
    //        }
    //        else
    //        {
    //            kortingsBon = (aankoopBedrag / 100) * 5;  
    //        }
    //        Console.WriteLine($"U kortingbedrag bedraagt {kortingsBon} Euro");


    //    }
    //}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Schrikkeljaar

    //class schrikkeljaar
    //{
    //    static void Main(string[] args)
    //    {
    //        decimal restWaarde = 0;
    //        Console.Write("Geef een jaartal in: ");
    //        decimal jaartal = Convert.ToDecimal(Console.ReadLine());
    //        string schrikkel = "";
    //            if (jaartal % 4 == restWaarde)
    //                {
    //                    if (jaartal % 100 == restWaarde & jaartal % 100 != 400 )
    //                    {
    //                        schrikkel = "geen";
    //                    }

    //                        schrikkel = "een";
    //                }
    //            else
    //            {
    //                schrikkel = "geen";
    //            }

    //    Console.WriteLine($"Dit jaar is {schrikkel} schrikkeljaar");
    //    }
    //}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Lichtkrant

    //class lichtkrant
    //{
    //    const string boodschappenWeekDag = "We wensen u een prettige werkdag";
    //    const string boodschappenWeekend = "We wensen u een fijn weekend";
    //    const string openingsUrenWeekDag = "Wij zijn open van 09:00 tot 12:00 en van 13:00 tot 18:00";
    //    const string openingsZaterdag =  "Wij zijn open van 10:00 tot 12:00";
    //    const string boodschapZondag = "Wij zijn vandaag gesloten";
    //    static void Main(string[] args)
    //    {
    //        Console.Write("Geef de datum wanneer u onze winkel wenst te bezoeken");
    //        DateTime datum = DateTime.Parse(Console.ReadLine());
    //        int weekDag = (int)datum.DayOfWeek;
    //        string LichtKrantMsg = "";

    //        if(weekDag > 0 && weekDag < 7)
    //        {
    //           LichtKrantMsg = boodschappenWeekDag + " " + openingsUrenWeekDag;

    //        }
    //        else if(weekDag  == 7)
    //        {
    //            LichtKrantMsg = boodschappenWeekend + " " + openingsZaterdag;
    //        }
    //        else if(weekDag == 0)
    //        {
    //            LichtKrantMsg = boodschapZondag + " " + boodschappenWeekend;
    //        }

    //        Console.WriteLine(LichtKrantMsg);




    //    }
    //}

    //3. OEFENINGEN OP ITERATIES
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Kleinste grootste en gemiddelde berekenen

    //class kleinsteGrootsteGemiddelde
    //{
    //    static void Main(string[] args)
    //    {
    //        int userInput = 0;
    //        int teller = 0;
    //        int kleinste = 0;
    //        int grootste = 0;
    //        int totaal = 0;

    //        Console.WriteLine("Geef een willekeurig positief getal in of geef -1 in om te stoppen");
    //        userInput = Convert.ToInt16(Console.ReadLine());

    //        if(userInput != -1)
    //        {
    //            kleinste = userInput;
    //            grootste = userInput;
    //        }

    //        while(userInput != -1)
    //        {
    //            if(teller != 0)
    //            {
    //                Console.WriteLine("Geef een willekeurig positief getal in of geef -1 in om te stoppen");
    //                userInput = Convert.ToInt16(Console.ReadLine());
    //            }

    //            if(userInput != -1)
    //            {
    //                if(userInput > grootste)
    //                {
    //                    grootste = userInput;
    //                }

    //                if(userInput < kleinste)
    //                {
    //                    kleinste = userInput;
    //                }

    //                totaal = totaal + userInput;
    //                teller = teller + 1;
    //            }
    //        }

    //        Console.WriteLine($"Het grootste getal is {grootste}");
    //        Console.WriteLine($"Het kleinste getal is {kleinste}");
    //        Console.WriteLine($"Het totaal van alle getallen is {totaal}");
    //        decimal gemiddelde = totaal / teller;
    //        Console.WriteLine($"Het gemiddelde van alle getallen is {gemiddelde}");
    //    }
    //}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //priemGetal

    //class PriemGetal
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Geef een willekeurig positief getal in");
    //        decimal userInput = Convert.ToInt16(Console.ReadLine());
    //        decimal priemGetalCheck = 0;

    //        if( userInput > 0)
    //        {
    //            for(int i = 1; i < userInput + 1; i++)
    //            {

    //                decimal resultDeling = userInput / i;
    //                decimal resultModulo = resultDeling % i;
    //                //Console.WriteLine($"{resultModulo}");

    //                if(resultModulo == 0 || resultModulo == 1)
    //                {
    //                   priemGetalCheck++;
    //                }


    //                Console.WriteLine($"{userInput} / {i} = {resultDeling}");
    //            }

    //            if(priemGetalCheck == 2)
    //            {
    //                Console.WriteLine($"{userInput} is een priemgetal");
    //            }
    //            else
    //            {
    //                Console.WriteLine($"{userInput} is geen priemgetal");
    //            }

    //        }
    //        else
    //        {
    //            Console.WriteLine("Het ingegeven getal is kleiner dan of gelijk aan 0, gelieve een getal groter dan 0 in te geven");
    //        }

    //    }
    //}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Controle IBAN rekeningnummer
    //class IbanRekeningNummer
    //{
    //   static readonly string[] Alfabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };   
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Geef een IBAN rekeningnummer in");
    //        string IbanNr = Console.ReadLine();
    //        string IbanNrNoSpaces = "";
    //        string strings = "";

    //        for (int i = 0; i < IbanNr.Length; i++)
    //        {
    //            char chars = IbanNr[i];

    //            strings = Convert.ToString(chars);
    //            //Console.WriteLine(strings);

    //            if(strings == " ")
    //            {
    //                strings = "";
    //            }

    //            IbanNrNoSpaces += strings;       
    //        }

    //        Console.WriteLine(IbanNrNoSpaces);

    //        string EersteVierChars = IbanNrNoSpaces.Substring(0,4);
    //        Console.WriteLine(EersteVierChars);

    //        IbanNrNoSpaces = IbanNrNoSpaces.Substring(4, 12) + EersteVierChars;
    //        Console.WriteLine(IbanNrNoSpaces);


    //        int check = 0;
    //        string IbanNrOnly = "";

    //        for (int i = 0; i < IbanNrNoSpaces.Length; i++)
    //        {
    //            char chars = IbanNrNoSpaces[i];

    //            strings = Convert.ToString(chars);
    //            Console.WriteLine(strings);

    //            bool result = int.TryParse(strings, out check);
    //            Console.WriteLine(result);

    //            if(result == false)
    //            {
    //                for (int k = 0; k < Alfabet.Length; k++) {
    //                    if (strings == Alfabet[k])
    //                    {
    //                        int numericValue = k + 10;
    //                        string numericString = Convert.ToString(numericValue);
    //                        Console.WriteLine($"converted = {numericString}");
    //                        IbanNrOnly += numericString;
    //                    }

    //                    ////How to get ascii code from a letter to an int!
    //                    //byte[] asciiBytes = Encoding.ASCII.GetBytes(strings);
    //                    //Console.WriteLine($"{strings} Converted = " + asciiBytes[0]);
    //                    //IbanNrOnly += asciiBytes[0];
    //                }
    //            }
    //            else
    //            {
    //                IbanNrOnly += strings;
    //            }
    //        }

    //        Console.WriteLine(IbanNrOnly);
    //        Console.WriteLine(ulong.Parse(IbanNrOnly) % 97ul == 1 ? $"{IbanNr} is een geldig rekeningnummer" : $"{IbanNr} is geen geldig rekeningnummer");

    //    }
    //}

    //4. OEFENINGEN OP ARRAYS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Codeerprogramma 

    //class CodeerProgramma
    //{

    //    static void Main(string[] args)
    //    {
    //        char[] Code = { 'Q', 'S', 'P', 'A', 'T', 'V', 'X', 'B', 'C', 'R', 'J', 'Y', 'E', 'D', 'U', 'O', 'H', 'Z', 'G', 'I', 'F', 'L', 'N', 'W', 'K', 'M' };

    //        Console.WriteLine("Geef een zin in die je wenst te coderen !");
    //        string Txt = Console.ReadLine();
    //        Txt = Txt.ToUpper();
    //        string CodedTxt = string.Empty;

    //        for (int i = 0; i < Txt.Length; i++)
    //        {
    //            if (Txt[i] >= 'A' && Txt[i] <= 'Z')
    //            {

    //                CodedTxt += Code[(int)Txt[i] - (int)'A'];
    //            }
    //            else
    //            {
    //                CodedTxt += Txt[i];
    //            }

    //        }
    //        Console.WriteLine($"In code {CodedTxt}");
    //    }
    //}

    //4.1 ENUMS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld

    //public enum Seizoen
    //{
    //    Lente,Zomer,Herfst,Winter
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Seizoen plukseizoen = Seizoen.Herfst;
    //        Console.WriteLine(plukseizoen);
    //        Console.WriteLine((int)plukseizoen);
    //    }
    //}

    //5. OEFENINGEN OP CLASSES, OBJECTS, OBJECTVARIABLES EN CONSTRUCTORS
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld

    class Program
    {
        public static void Main(string[] args)
        {
            //Console.Write("PersoneelsFeest vindt plaats op: {0}", Werknemer.PersoneelsFeest);


            Arbeider Pieter = new Arbeider("Pieter", new DateTime(2017, 02, 22), Geslacht.man, 14.5, 1);
            Arbeider Maarten = new Arbeider("Maarten", new DateTime(2014, 02, 22), Geslacht.man, 15.1, 2);
            Arbeider Marc = new Arbeider("Marc", new DateTime(1996, 02, 22), Geslacht.man, 15.7, 3);
            Bediende Ilse = new Bediende("Ilse", new DateTime(2000, 02, 22), Geslacht.vrouw, 2500);
            Manager Eline = new Manager("Eline", new DateTime(2018, 02, 22), Geslacht.vrouw, 2900, 500);


            LijnenTrekker trekker = new LijnenTrekker();
            trekker.TrekLijn(30, '=');
            Console.WriteLine(Pieter.ToString());
            Pieter.Afbeelden();
            trekker.TrekLijn(30, '=');
            Console.WriteLine(Maarten.ToString());
            Maarten.Afbeelden();
            trekker.TrekLijn(30, '=');
            Console.WriteLine(Marc.ToString());
            Marc.Afbeelden();
            trekker.TrekLijn(30, '=');
            Console.WriteLine(Ilse.ToString());
            Ilse.Afbeelden();
            trekker.TrekLijn(30, '=');
            Console.WriteLine(Eline.ToString());
            Eline.Afbeelden();
            trekker.TrekLijn(30, '=');
            
            
            
           
           

            //Console.WriteLine(Rekenaar.Kwadraat(12));

            //int eerste = 10, tweede = 20;
            //Verwisselaar verwisselaar = new Verwisselaar();
            //verwisselaar.Verwissel(ref eerste, ref tweede);
            //Console.WriteLine(eerste);
            //Console.WriteLine(tweede);

            //LijnenTrekker trekLijn = new LijnenTrekker();
            //Omzetter omzetter = new Omzetter();
            //Console.WriteLine("25 cm is: " + omzetter.CmNaarInch(25) + "inch");

            //trekLijn.TrekLijn(25, '*');
            //Console.WriteLine(' ');
            //Console.WriteLine("25 inch is: " + omzetter.InchNaarCm(25) + "cm");

            //trekLijn.TrekLijn(25, '*');



        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //5.1 Oefening Bank
    //5.1.1 & 5.1.2 De class rekening -> zie class Rekening.cs
    //class Program
    //{
    //    public static void Main()
    //    {
    //       Rekening rekening1 = new Rekening("BE09652819143157", 0, DateTime.Today);
    //        rekening1.Afbeelden();
    //        rekening1.Storten(2000);
    //        rekening1.Afbeelden();
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //5.2 Oefening voertuigen
    //5.2.1 De class voertuigen -> zie class Voertuigen.cs
    //class Program
    //{
    //    public static void Main()
    //    {
    //        //Create new object auto van class Voertuigen met default constructor
    //        Console.WriteLine("");
    //        Voertuigen defaultAuto = new Voertuigen();
    //        defaultAuto.Afbeelden();
    //        Console.WriteLine("");

    //        //Create new object OpelPieter van class Voertuigen met geparametreerde constructor
    //        Voertuigen OpelPieter = new Voertuigen("Pieter Bracke", 12500, 110, 6.3, "1-BQJ-140");
    //        OpelPieter.Afbeelden();
    //        Console.WriteLine("");

    //        //Create new object VwMaarten van class Voertuigen met geparametreerde constructor
    //        Voertuigen VwMaarten = new Voertuigen("Maarten Bracke", 18000, 260, 8.5, "1-ZFX-980");
    //        VwMaarten.Afbeelden();
    //        Console.WriteLine("");
    //    }
    //}


}//Einde namespace

