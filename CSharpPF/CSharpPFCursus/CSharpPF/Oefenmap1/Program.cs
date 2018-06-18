using System;
using System.IO;
using Oefenmap;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Personeel;
using Firma.Materiaal;
using MateriaalStatus = Firma.Materiaal;
using PersoneelsStatus = Firma.Personeel;
using System.Threading;

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

    //class Program
    //{

    //    public static void Main(string[] args)
    //    {

    //        Afdeling afdeling1 = new Afdeling("C#", 3);
    //        Afdeling afdeling2 = new Afdeling("Java", 2);

    //        Werknemer[] wij = new Werknemer[3];
    //        wij[0] = new Arbeider("Asterix", new DateTime(2018, 02, 26), Geslacht.man, 12.9, 1);
    //        wij[0].Afdeling = afdeling1;
    //        wij[0].Regime = new Werknemer.WerkRegime(Werknemer.WerkRegime.RegimeType.Voltijds);

    //        wij[1] = new Bediende("Obelix", new DateTime(2018, 02, 26), Geslacht.man, 2500);
    //        wij[1].Afdeling = afdeling2;
    //        wij[1].Regime = new Werknemer.WerkRegime(Werknemer.WerkRegime.RegimeType.Halftijds);

    //        wij[2] = new Manager("Idefix", new DateTime(2018, 02, 26), Geslacht.man, 2900, 750);
    //        wij[2].Afdeling = afdeling1;
    //        wij[2].Regime = new Werknemer.WerkRegime(Werknemer.WerkRegime.RegimeType.Viervijfde);

    //        LijnenTrekker trekker = new LijnenTrekker();

    //        foreach (Werknemer eenWerknemer in wij)
    //        {

    //            eenWerknemer.Afbeelden();
    //            trekker.TrekLijn(30, '=');
    //        }

    //        Arbeider Pieter = new Arbeider("Pieter", new DateTime(2017, 02, 22), Geslacht.man, 14.5, 1);
    //        Arbeider Maarten = new Arbeider("Maarten", new DateTime(2014, 02, 22), Geslacht.man, 15.1, 2);
    //        Arbeider Marc = new Arbeider("Marc", new DateTime(1996, 02, 22), Geslacht.man, 15.7, 3);
    //        Bediende Ilse = new Bediende("Ilse", new DateTime(2000, 02, 22), Geslacht.vrouw, 2500);
    //        Manager Eline = new Manager("Eline", new DateTime(2018, 02, 22), Geslacht.vrouw, 2900, 500);


    //        trekker.TrekLijn(30, '=');
    //        Console.WriteLine(Pieter.ToString());
    //        Pieter.Afbeelden();

    //        trekker.TrekLijn(30, '=');
    //        Console.WriteLine(Maarten.ToString());
    //        Maarten.Afbeelden();

    //        trekker.TrekLijn(30, '=');
    //        Console.WriteLine(Marc.ToString());
    //        Marc.Afbeelden();

    //        trekker.TrekLijn(30, '=');
    //        Console.WriteLine(Ilse.ToString());
    //        Ilse.Afbeelden();

    //        trekker.TrekLijn(30, '=');
    //        Console.WriteLine(Eline.ToString());
    //        Eline.Afbeelden();

    //        trekker.TrekLijn(30, '=');
    //    }

    //    Console.WriteLine(Rekenaar.Kwadraat(12));

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



    // }
    //}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //5.1 Oefening Bank
    //5.1.1 & 5.1.2 De class rekening -> zie class Rekening.cs
    //    class Program
    //{
    //    public static void Main()
    //    {
    //            SpaarRekening.Intrest = 3;

    //            Klant Pieter = new Klant("Pieter", "Bracke");
    //            ZichtRekening mijnZichtRekening = new ZichtRekening("BE40747524091936", Pieter, 2000, DateTime.Today, -2000);
    //            SpaarRekening mijnSpaarRekening = new SpaarRekening("BE40645100000163", Pieter, 1000, DateTime.Today);

    //            mijnSpaarRekening.Afbeelden();
    //            Console.WriteLine("");
    //            mijnZichtRekening.Afbeelden();



    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //    5.2 Oefening voertuigen
    //    5.2.1 De class voertuigen -> zie class Voertuigen.cs
    //class Program
    //{
    //    public static void Main()
    //    {
    //        LijnenTrekker trekker = new LijnenTrekker();
    //        Voertuigen[] VoertuigenArr = new Voertuigen[2];

    //        VoertuigenArr[0] = new PersonenWagen("Pieter Bracke", 12500, 110, 6.3, "1-BQJ-140", 3, 5);
    //        VoertuigenArr[1] = new Vrachtwagen("Maarten Bracke", 60000, 580, 15.6, "Q-ZFX-980", 10000);

    //        foreach(Voertuigen eenVoertuig in VoertuigenArr)
    //        {
    //            eenVoertuig.Afbeelden();
    //            trekker.TrekLijn(30, '=');
    //            Console.WriteLine("");
    //            Console.Write("");
    //        }

    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //6.0 INTERFACES
    //Voorbeeld

    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        IKost[] kosten = new IKost[4];

    //        kosten[0] = new Arbeider("Asterix", new DateTime(2016, 1, 1), Geslacht.man, 14.5, 3);
    //        kosten[1] = new Bediende("Oberlix", new DateTime(2016, 1, 1), Geslacht.vrouw, 2500);
    //        kosten[2] = new Manager("Idefix", new DateTime(2016, 1, 1),Geslacht.man, 2900, 750);
    //        kosten[3] = new Fotokopiemachine("2014785", 2500, 0.75);

    //        double TotaleKost = 0;

    //        foreach(IKost eenKost in kosten)
    //        {
    //            Console.WriteLine("Menselijke kost: {0}", eenKost.Menselijk);
    //            Console.WriteLine("Kostprijs: {0} Euro", eenKost.Bedrag);
    //            TotaleKost += eenKost.Bedrag;
    //            Console.WriteLine("");
    //        }

    //        Console.WriteLine("Totale Kost: {0} Euro" ,TotaleKost);
    //    }


    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //6.1 Oefeningen op Interfaces
    //6.1.1 Rekening + Kasbon + Interface ISpaarMiddel
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Klant Pieter = new Klant("Pieter", "Bracke");
    //        ISpaarMiddel[] SpaarMiddelArr = new ISpaarMiddel[3];
    //        SpaarMiddelArr[0] = new ZichtRekening("BE09652819143157", Pieter, 2000, new DateTime(2018, 1, 1), -2000);
    //        SpaarMiddelArr[1] = new SpaarRekening("BE09652819143157", Pieter, 5800, new DateTime(2018, 1, 1));
    //        SpaarMiddelArr[2] = new KasBon(new DateTime(2018, 1, 1), 5000, 3, 5.25, Pieter);

    //        foreach(ISpaarMiddel eenAccount in SpaarMiddelArr)
    //        {
    //            eenAccount.Afbeelden();
    //            Console.WriteLine("");
    //        }


    //    }

    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //6.1.2 Voertuigen + Interface IVervuiler
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        IVervuiler[] Vervuilers = new IVervuiler[2];
    //        Vervuilers[0] = new Vrachtwagen("Pieter Bracke", 58000, 580, 12.7, "Q-XAZ-980", 10000);
    //        Vervuilers[1] = new PersonenWagen("Maarten Bracke", 18000, 260, 9.7, "1-BQJ-140", 5, 5);

    //        foreach(IVervuiler voertuig in Vervuilers)
    //        {
    //            voertuig.Afbeelden();
    //            Console.WriteLine("");
    //        }
    //    }

    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //6.1.3 Stookketel + Intercafe IVervuiler
    //class Program
    //    {
    //        public static void Main(string[] args)
    //        {
    //            IVervuiler[] Stookketels = new IVervuiler[2];
    //            Stookketels[0] = new Stookketel(25);
    //            Stookketels[1] = new Stookketel(30);

    //            foreach(IVervuiler stookketel in Stookketels)
    //            {
    //                stookketel.Afbeelden();
    //                Console.WriteLine("");
    //            }

    //        }
    //    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //6.1.4 
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        IPrivaat[] voertuigenPrivaat = new IPrivaat[3];
    //        voertuigenPrivaat[0] = new Vrachtwagen("Pieter Bracke", 80000, 580, 12.5, "Q-BQJ-140", 10000);
    //        voertuigenPrivaat[1] = new PersonenWagen("Maarten Bracke", 18000, 260, 8.9, "1-AXZ-980", 5, 3);
    //        voertuigenPrivaat[2] = new PersonenWagen("Marc Bracke", 25000, 180, 7.5, "1-GTE-250", 4, 3);

    //        IMilieu[] voertuigenMilieu = new IMilieu[3];
    //        voertuigenMilieu[0] = new Vrachtwagen("Pieter Bracke", 80000, 580, 12.5, "Q-BQJ-140", 10000);
    //        voertuigenMilieu[1] = new PersonenWagen("Maarten Bracke", 18000, 260, 8.9, "1-AXZ-980", 5, 3);
    //        voertuigenMilieu[2] = new PersonenWagen("Marc Bracke", 25000, 180, 7.5, "1-GTE-250", 4, 3);

    //        for(var i = 0; i < voertuigenPrivaat.Length; i++)
    //        {

    //           Console.WriteLine("Private gegevens:");
    //           Console.WriteLine(voertuigenPrivaat[i].GeefPrivateData());

    //            Console.WriteLine("");

    //            Console.WriteLine("Milieu gegevens:");
    //            Console.WriteLine(voertuigenMilieu[i].GeefMilieuData());

    //            Console.WriteLine("");
    //        }
    //    }
    //}

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //7.0 NAMESPACES
    //7.1.1 Voorbeeld
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Firma.Materiaal.Status statusBoorMachine = Firma.Materiaal.Status.Werkend;
    //        Firma.Personeel.Status Directeur = Firma.Personeel.Status.HogerKader;

    //        Console.WriteLine(statusBoorMachine);
    //        Console.WriteLine(Directeur);
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ZIE APART PROJECT DELEGATES VOOR EEN SIMPELERE UITLEG OVER DELEGATES!
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //8.0 Delegate Functions and Methods & Events   
    //8.1.1 Voorbeeld
    //class Program
    //{
    //    //Delegate stelt dat methods met dezelfde handtekening (naam en parameters) uitgevoerd kunnen worden binnin Main method
    //    delegate void WerknemersLijst(Werknemer[] werknemers);
    //    public static void Main(string[] args)
    //    {
    //        Werknemer[] wij = new Werknemer[3];
    //        wij[0] = new Arbeider("Asterix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 24.79, 3);
    //        wij[1] = new Bediende("Obelix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Halftijds, 2400.79);
    //        wij[2] = new Manager("Idefix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Viervijfde, 2800, 750);


    //        WerknemersLijst lijst;

    //        lijst = Werknemer.UitgebreideWerknemersLijst;
    //        lijst(wij); //Verwijst naar de method -> UitgebreideWerknermsLijst(WerknemersLijst[] werknemers); in werknemers.cs
    //        Console.WriteLine();

    //        lijst = Werknemer.KorteWerkenemersLijst;
    //        lijst(wij); //Verwijst naar de method -> KorteWerknemersLijst(WerknemersLijst[] werknemers); in werknemers.cs

    //        WerknemersLijst rapport;

    //        rapport = delegate (Werknemer[] werknemers)
    //        {
    //            double totaal = 0;
    //            foreach (Werknemer werknemer in werknemers)
    //            {
    //                totaal += werknemer.Bedrag;   
    //            }
    //            Console.WriteLine($"Totale werknemerskost is {totaal} Euro");
    //        };
    //        Console.WriteLine("");
    //        rapport(wij);
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //8.1.2 Voorbeeld 2
    //    class Program
    //    {
    //        public static void Main(string[] args)
    //        {
    //            Fotokopiemachine machine1 = new Fotokopiemachine("5800", 0, 0.5);
    //            Fotokopiemachine machine2 = new Fotokopiemachine("5900", 0, 0.5);
    //            Bediende Eline = new Bediende("Eline Bracke", new DateTime(2016, 1, 1), Geslacht.vrouw, RegimeType.Voltijds, 2900);
    //            Manager Pieter = new Manager("Pieter Bracke", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 3500, 1000);

    //            //Koppel een anonymous function aan event onderhoudNodig dat geraised zal worden wanneer Fotokopieer wordt uitgevoergd, gebruik dit enkel als je weet dat je de code slechts een maal zal gebruiken
    //            machine1.OnderhoudNodig += delegate (Fotokopiemachine machine)
    //            { 
    //                Console.WriteLine("Onderhoud is aangevraagd voor machine {0}", machine.SerieNr);  
    //            };

    //            //OnderhoudNodig is event dat geraisd wordt in method Fotokopieer en in dit event adden we andere methods zijnde DoeOnderhoud en OnderhoudNoteren
    //            machine1.OnderhoudNodig += Eline.DoeOnderhoud;
    //            machine1.OnderhoudNodig += Pieter.OnderhoudNoteren;

    //            //Call functie Fotokopieer dewelke defined wordt in class FotokopieMachine
    //            machine1.Fotokopieer(45);

    //            Console.WriteLine("");
    //            Console.WriteLine("Volgende machine");

    //            //Koppel een anonymous function aan event onderhoudNodig dat geraised zal worden wanneer Fotokopieer wordt uitgevoergd, gebruik dit enkel als je weet dat je de code slechts een maal zal gebruiken
    //            machine2.OnderhoudNodig += delegate (Fotokopiemachine machine)
    //            {
    //                Console.WriteLine("Onderhoud is aangevraagd voor machine {0}", machine.SerieNr);   
    //            };

    //            machine2.OnderhoudNodig += Eline.DoeOnderhoud;
    //            machine2.OnderhoudNodig += Pieter.OnderhoudNoteren;

    //            machine2.Fotokopieer(45);   

    //        }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //8.2.0 Oefening Bank Delegates en events 
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        BankBediende Pieter = new BankBediende("Pieter", "Bracke");
    //        Klant Jan = new Klant("Jan", "Deman");

    //        ZichtRekening ZichtRekeningJan = new ZichtRekening("BE09652819143157", Jan, 2500, DateTime.Today, 5000d);
    //        Console.WriteLine("Zichtrekening: ");
    //        ZichtRekeningJan.Afbeelden();
    //        Console.WriteLine("");

    //        ZichtRekeningJan.RekeningUitreksel += Pieter.ToonRekeningUitreksel;
    //        ZichtRekeningJan.SaldoInHetRood += Pieter.ToonBoodschapBijSaldoInRood;

    //        ZichtRekeningJan.Storten(100);
    //        Console.WriteLine("");

    //        ZichtRekeningJan.Afhalen(2400);
    //        Console.WriteLine("");

    //        ZichtRekeningJan.Afhalen(2400);
    //        Console.WriteLine("");
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //9.0 Exceptions opvangen (Foutmeldingen)
    //9.1.1 Voorbeeld
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        decimal getal1, getal2;

    //        //Try clause als er een fout optreed tussen deze accolades gaat hij alle catches af en voert de daarin gespecifieerde opdracht uit
    //        try
    //        {
    //            Console.WriteLine("Geef eerste getal: ");
    //            getal1 = decimal.Parse(Console.ReadLine());
    //            try
    //            {
    //                Console.WriteLine("Geef tweede getal: ");
    //                getal2 = decimal.Parse(Console.ReadLine());
    //                if (getal2 != 0)
    //                {
    //                    Console.WriteLine("Deling van getal1 en getal2: " + getal1 / getal2);
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Delen door 0 is niet toegelaten");
    //                }
    //            }
    //            catch (FormatException)
    //            {
    //                Console.WriteLine("Gelieve een getal in de geven als getal2");
    //            }
    //        }
    //        //Catch clause indien er ergens een fout optreed die niet wordt opgevangen met een if statement zal de catch clause uitgevoerd worden
    //        catch(FormatException)
    //        {
    //            Console.WriteLine("Gelieve een getal in te geven als getal1");
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //9.1.2 Voorbeeld2
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        try
    //        {
    //            Fotokopiemachine machine1 = new Fotokopiemachine("5800", 6, -0.5);
    //            Console.WriteLine("Machine correct gedeclareerd");
    //        }
    //        catch(Fotokopiemachine.KostPerBlzException ex)
    //        {
    //            Console.WriteLine("Constructor Fout: " + ex.Message + ":" + ex.VerkeerdeKost);
    //        }
    //        catch(Fotokopiemachine.AantalBlzException ex)
    //        {
    //            Console.WriteLine("Constuctor Fout: " + ex.Message + ":" + ex.VerkeerdeAantalBlz);
    //        }
    //        Console.WriteLine("Einde programma");
    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //9.1.3 Voorbeeld 3
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Console.WriteLine("Geef provincie ");
    //        string input = Console.ReadLine();

    //        try
    //        {
    //            ProvincieInfo info = new ProvincieInfo();
    //            Console.WriteLine(info.provincieGrootte(input));
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }

    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //9.2.0 Oefening op exceptions
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        try
    //        {
    //            Klant Pieter = new Klant("Pieter", "Bracke");

    //            ISpaarMiddel[] spaarmiddelen = new ISpaarMiddel[3];

    //            spaarmiddelen[0] = new ZichtRekening("BE09652819143157", Pieter, 5000, new DateTime(1900,1,1), -5000);
    //            spaarmiddelen[1] = new SpaarRekening("BE09652819143157", Pieter, 5000, new DateTime(1900, 1, 1));
    //            spaarmiddelen[2] = new KasBon(new DateTime(1900, 1, 1), 5000, 5, 3.0, Pieter);

    //            foreach(ISpaarMiddel element in spaarmiddelen)
    //            {
    //                element.Afbeelden();
    //                Console.WriteLine();
    //            }

    //        }
    //        catch(Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }

    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //10.0 Operator overloading NAKIJKEN NIET BEGREPEN!
    //10.1.1 Voorbeeld 
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Breuk breuk1 = new Breuk(1, 2);
    //        Breuk breuk2 = new Breuk(1, 3);
    //        Breuk breuk3 = new Breuk(2, 6);

    //        Console.WriteLine(breuk1.ToString());
    //        Console.WriteLine(breuk2.Equals(breuk3));
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //11.0 Indexers
    //Voorbeeld
    //class Program
    //{
    //    //See class Indexers for implementation of the indexer!

    //    public static void Main(string[] args)
    //    {
    //        //Declare variable as new Indexer, The Indexers "Method is declared in the class Indexers.cs"
    //        var Indexer = new Indexers();

    //        //Add value to the different indexes in the newly created Indexer
    //        Indexer[0] = "Indexer op positie 0 in array";
    //        Indexer[5] = "Indexer op positie 5 in array";

    //        //Loop through the indexer
    //        for(int i = 0; i < Indexer.Length; i++)
    //        {
    //            Console.WriteLine($"Index {i}: " + Indexer[i]);
    //        }



    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //11.1.0 Indexers
    //Voorbeeld
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {

    //        // Indexer uit class Overuren
    //        Overuren mijnOveruren = new Overuren(); //Creeer new indexer mijnOveren gebaseerd op de class Overuren

    //        //Assign values aan de indexes van de Indexer mijnOveruren
    //        mijnOveruren[0] = 4;
    //        mijnOveruren[1] = 9;
    //        mijnOveruren[2] = 12;
    //        mijnOveruren[6] = 1;
    //        mijnOveruren[10] = 22;

    //        //Geef overuren terug op de verschillende manieren die de Overuren class aanbied
    //        Console.WriteLine(mijnOveruren["jan"]);
    //        Console.WriteLine(mijnOveruren[6]);
    //        Console.WriteLine(mijnOveruren.Totaal);


    //        // Indexer uit class PuntenLeerlingen
    //        PuntenLeerlingen puntenWiskunde = new PuntenLeerlingen();//Creeer new Indexer puntenWiskunde gebaseerd op de class PuntenLeerlingen

    //        //Assign values aan de indexes van de indexer puntenWiskunde
    //        puntenWiskunde[0] = 7;
    //        puntenWiskunde[1] = 9;
    //        puntenWiskunde[2] = 8;
    //        puntenWiskunde[3] = 10;
    //        puntenWiskunde[4] = 7;

    //        //Geef punten terug op basis van de leerlingnaam via de class PuntenLeerlingen
    //        Console.WriteLine("Pieter haalde: " + puntenWiskunde["Pieter"] + "/20");
    //        Console.WriteLine("Ilse haalde: " + puntenWiskunde["Ilse"] + "/20");
    //        Console.WriteLine("Marc haalde: " + puntenWiskunde["Marc"] + "/20");
    //        Console.WriteLine("Eline haalde: " + puntenWiskunde["Eline"] + "/20");
    //        Console.WriteLine("Maarten haalde: " + puntenWiskunde["Maarten"] + "/20");

    //        //Bereken het gemiddelde op basis van property gemiddelde in de PuntenLeerlingen class
    //        Console.WriteLine("Het gemiddelde van de klas is: " + puntenWiskunde.Gemiddelde + "/20");
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //12.0.1 COLLECTIONS
    //COLLECTIONS -> ArrayList Voorbeeld
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Arbeider Asterix = new Arbeider("Asterix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 16.8, 1);
    //        Bediende Obelix = new Bediende("Obelix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 2500);
    //        Manager Idefix = new Manager("Idefix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 3500, 1500);

    //        //Create new ArrayList and store the different objects in the ArrayList
    //        ArrayList Personeel = new ArrayList();
    //        Personeel.Add(Asterix);
    //        Personeel.Add(Obelix);
    //        Personeel.Add(Idefix);

    //        foreach(Werknemer personeelslid in Personeel)
    //        {

    //            personeelslid.Afbeelden();
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //COLLECTIONS
    //12.0.2 -> List Voorbeeld
    //List is de nieuwere versie van ArrayList en het is dus beter om List te gebruiken ipv ArrayList
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Arbeider Asterix = new Arbeider("Asterix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 16.8, 1);
    //        Bediende Obelix = new Bediende("Obelix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 2500);
    //        Manager Idefix = new Manager("Idefix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 3500, 1500);

    //        //Create new ArrayList and store the different objects in the ArrayList
    //        List<Werknemer> Personeel = new List<Werknemer>();
    //        Personeel.Add(Asterix);
    //        Personeel.Add(Obelix);
    //        Personeel.Add(Idefix);

    //        foreach (Werknemer personeelslid in Personeel)
    //        {
    //           personeelslid.Afbeelden();
    //        }
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //COLLECTIONS
    //12.0.3 -> Dictionary Voorbeeld
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Dictionary<int, string> opleiding = new Dictionary<int, string>()
    //        {
    //            {1, "Word"}, //ook mogelijk [1] = "Word",
    //            {2, "Excel"},// [2] = "Excel",
    //            {3, "Acces"} // [3] = "Acces"
    //        };

    //        Dictionary<string, string> extensies = new Dictionary<string, string>()
    //        {
    //            {"txt", "Notepad"},
    //            {"docx", "Word"},
    //            {"xlsx", "Excel"}
    //        };

    //        //Een element toevoegen
    //        opleiding.Add(4, "Photoshop");
    //        extensies.Add("Ps", "Photoshop");

    //        //Een element opvragen
    //        Console.WriteLine(extensies["docx"]);
    //        Console.WriteLine(opleiding[1]);

    //        //Foreach loop met elementen uit dictionary opleiding
    //        foreach(KeyValuePair<int, string> element in opleiding)
    //        {
    //            Console.WriteLine($"key = {element.Key}, value = {element.Value}");
    //        }

    //        //Foreach loop met elementen uit dictionary extensies
    //        foreach(KeyValuePair<string, string> element in extensies)
    //        {
    //            Console.WriteLine($"key = {element.Key}, value = {element.Value}");
    //        }

    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //COLLECTIONS
    //12.0.4 List voorbeeld met null conditional operator
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Create new List with werknemer objects
    //        List<Werknemer> werknemers = new List<Werknemer>
    //        {
    //            new Arbeider("Asterix", new DateTime(2016,1,1), Geslacht.man,RegimeType.Voltijds,16,1),
    //            new Bediende("Obelix", new DateTime(2016, 1, 1), Geslacht.man, RegimeType.Voltijds, 2900),
    //            new Manager("Idefix", new DateTime(2016,1,1), Geslacht.man, RegimeType.Voltijds, 3500, 1500)
    //        };
    //        Console.WriteLine($"Aantal werknemers: {werknemers.Count}");

    //        //Set List werknemers to null
    //        werknemers = null;

    //        Console.WriteLine($"Aantal werknemers: {werknemers?.Count ?? 0}"); //Test if werknemers == null if true set default waarde to 0 en vermijd een nullReferenceException
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //NULLABLE TYPES
    //13.0.1 voorbeeld nullable type
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        byte? aantalKinderen = null; //Nullable type aantalKinderen
    //        byte aantalKamers;
    //        aantalKamers = aantalKinderen ?? 0; //aantalKamers krijgt value van aantalKinderen als deze value echter null is dan wordt de value van aantalKamers op 0 gezet en geeft deze geen fout
    //        Console.WriteLine($"Er zijn {aantalKamers} kinderkamers nodig");

    //        //Controleren of een variable van een nullable type een waarde bevat
    //        if(aantalKinderen.HasValue) //of if (aantalKinderen != null)
    //        {
    //            Console.WriteLine($"Het aantalkinderen is: {aantalKinderen}");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Het aantal kinderen is onbekend");
    //        }
    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Lambda expressions
    //14.0.0 Oefeningen Lambda Expressions
    //class Program
    //{

    //    delegate bool EvenOneven(int getal);  //Declare een delegate functie
    //    delegate bool PositiefNegatief(int getal); //Declare een delegate functie

    //    public static void Main(string[] args)
    //    {
    //        //Declare een list 
    //        List<int> Getallen = new List<int> { -1, 2, -3, 4, 5, 6, 7, -8, 9, 10 };

    //        EvenOneven FilterEvenGetallen = getal => getal % 2 == 0; //Initialize een delegate functie -> Variable name voor de functie -> Parameter van de delegate functie -> Lambda expressie
    //        //EvenOneven FilterOnevenGetallen = getal => getal % 2 == 1;

    //        PositiefNegatief FilterPostitiefGetal = getal => (getal >= 0); //Initialize een delegate functie -> Variable name voor de functie -> Parameter van de delegate functie -> Lambda expressie
    //        //PositiefNegatief FilterNegatiefGetal = getal => (getal < 0);

    //        Console.WriteLine("Filter Even en oneven getallen");
    //        Console.WriteLine("Even getallen zijn groen, oneven getallen zijn rood");
    //        Console.WriteLine("");

    //        foreach(int getal in Getallen)
    //        {
    //            if (FilterEvenGetallen(getal))
    //            {
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                Console.WriteLine(getal);
    //            }
    //            else
    //            {
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine(getal);
    //            }
    //        }

    //        Console.ForegroundColor = ConsoleColor.White;
    //        Console.WriteLine("");
    //        Console.WriteLine("Filter postieve en negatieve getallen");
    //        Console.WriteLine("Positieve getallen zijn wit, negatieve getallen zijn geel");
    //        Console.WriteLine("");

    //        foreach(int getal in Getallen)
    //        {
    //            if (FilterPostitiefGetal(getal))
    //            {
    //                Console.ForegroundColor = ConsoleColor.White;
    //                Console.WriteLine(getal);
    //            }
    //            else
    //            {
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine(getal);
    //            }
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ZIE CURSUS TAKEN PAGINA 69 voor meer mogelijkheden tot oplossing bovenstaande met lambdas -> statement Lambdas, Oplossing met Func<>, Oplossing met Action<>

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //15.0.0 LinQ instructies LinQ = Language integrated query
    //Voorbeeld 1 Where, OrderBy & Count

    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var getallen = new[] { 0, 2, 1, 4, 3, 5, 7, 6, 8, 9 };

    //        Console.WriteLine("Getallen groter dan 3: ");

    //        //Hier maken we gebruik van de LinQ statement WHERE op een array en steken een Lambda expressie in de Where clause van de array dit maakt uiteindelijk een array GetallenGroterDan3 met alle getallen groter dan 3 uit de array getallen
    //        var GetallenGroterDan3 = getallen.Where(getal => getal > 3); 

    //        foreach(var getal in GetallenGroterDan3)
    //        {
    //            Console.WriteLine(getal);
    //        }

    //        Console.WriteLine("Gesorteerde getallen: ");

    //        //Hier maken gebruik van de LinQ statement ORDERBY  op een array en steken een Lambda expressie in de Orderby clause van de array dit maakt uiteindelijk een array GesorteerdeGetallen met alle getallen uit de array getallen gesorteerd van klein naar groot
    //        var GestorteerdeGetallen = getallen.OrderBy(getal => getal);
    //        foreach(var getal in GestorteerdeGetallen)
    //        {
    //            Console.WriteLine(getal);
    //        }

    //        Console.WriteLine("Aantal getallen groter dan 3: ");

    //        //Hier maken we gebruik de LinQ statement COUNT op een array en steken een Lambda expressie in de Count clause van de array dit geef uiteindelijk een int terug met het aantal getallen groter dan 3 uit de array getallen
    //        //Bij gebruik van Count kan je geen foreacht statement gebruik aangezien een Count steeds een int zal weer geven en geen soort collection
    //        Console.WriteLine(getallen.Count(getal => getal > 3));

    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //LinQ instructies
    //Voorbeeld 2 Where, StartsWith
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var namen = new List<string> { "Asterix", "Obelix", "Idexfix", "Ambiorix" };

    //        Console.WriteLine("Geef de beginletter(s) in van de namen die je zoekt: ");
    //        var BeginVanNaam = Console.ReadLine();

    //        //Hier maken we gebruik van de LinQ statement Where en steken een Lambda expressie in de Where clause van de array deze geeft een array terug met alle namen beginnende met de opgegeven input van de user aangezien we ook gebruik van de LinQ statement StartsWith 
    //        var GevondenNaam = namen.Where(naam => naam.StartsWith(BeginVanNaam));

    //        foreach(var naam in GevondenNaam)
    //        {
    //            Console.WriteLine(naam);
    //        }
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //LinQ instructies
    //Voorbeeld 3 OrderBy, Sum
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Create new anonieme array en steek er objecten in
    //        var landen = new[]
    //        {
    //            new {Naam = "Frankrijk", Oppervlakte = 643427 },
    //            new {Naam = "Nederland", Oppervlakte = 41528 }
    //        };

    //        //Sorteer de array op oppervlakte van klein naar groot maak hiervoor gebruik van de LinQ statement OrderBy en steek hier een lamda expressie in dewelke zegt op wat te sorteren deze geeft een array waarover geïtereerd kan worden
    //        var gesorteerdeLanden = landen.OrderBy(land => land.Oppervlakte);

    //        //Foreach loop geef van elk van de landen de naam en de oppervlakte
    //        foreach(var eenLand in gesorteerdeLanden)
    //        {
    //            Console.WriteLine("Naam: " + eenLand.Naam + ", Oppervlakte: " + eenLand.Oppervlakte + " Km");
    //        }

    //        //Maakt gebruikt van de LinQ statement Sum steek hierin de Lambda expressie om elke oppervlakte op te tellen 
    //        Console.WriteLine("De totale oppervalkte van alle landen is: {0} Km", landen.Sum(land => land.Oppervlakte));

    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //LinQ instructies
    //Voorbeeld 4 Chaining -> een aantal LinQ instructies (extension methods) na mekaar uitvoeren

    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var namen = new List<string> {"Asterix", "Obelix", "Idefix", "Ambiorix" };

    //        var geselecteerdeNamenInHoofdLetters = namen.Where(naam => naam.Length > 6).OrderBy(naam => naam).Select(naam => naam.ToUpper());

    //        foreach(var naam in geselecteerdeNamenInHoofdLetters)
    //        {
    //            Console.WriteLine($"Naam: {naam}");
    //        }
    //      
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////Het is ook mogelijk om bovenstaande code via SQL query's te schrijven in C#
    ////Voorbeeld 5 SQL query's in C# (Query comprehension syntax)

    //        geselecteerdeNamenInHoofdLetters =
    //            from naam in namen
    //            where naam.Length > 6
    //            orderby naam
    //            select naam.ToUpper();

    //        foreach (var naam in geselecteerdeNamenInHoofdLetters)
    //        {
    //            Console.WriteLine($"Naam: {naam}");
    //        }

    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 6.0 Bieren en Brouwers 
    //LinQ toegepast op een verzameling van zelf gedefinieerde objecten
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Maak een verzameling van brouwers via het Brouwers object de methode GetBrouwers() van dit object geeft een verzameling Brouwer objecten als resultaat terug
    //        var brouwers = new Brouwers().GetBrouwers();


    //        //LinQ query selecteer alle brouwers van de gemaakte verzameling brouwers 
    //        var alleBrouwers = from brouwer in brouwers select brouwer;

    //        //Dubbele foreach loop
    //        //Iteratie door de verzameling alleBrouwers we maken hier gebruik van de ToString Method (gedefinieerd in de class Brouwer.cs) om de informatie door te geven
    //        foreach (var brouwer in alleBrouwers)
    //        {
    //            Console.WriteLine(brouwer.ToString());

    //            //Iteratie door alle bieren per brouwer iot de verzameling alleBrouwerswe maken hier gebruik van de ToString Methode (gedefinieerd in de class Bier.cs) om de informatie door te geven
    //            foreach (var bier in brouwer.Bieren)
    //            {
    //                Console.WriteLine(bier.ToString());
    //            }

    //            Console.WriteLine("");
    //        }

    //        //Andere mogelijkheid

    //        //Maak een verzameling van brouwers via het Brouwers object de methode GetBrouwers() van dit object geeft een verzameling Brouwer objecten als resultaat terug
    //        /* var */brouwers = new Brouwers().GetBrouwers();

    //        //LinQ query selecteer alle brouwers van de verzameling brouwers en selecteer nadien alle bieren van brouwer.bieren
    //        var bieren = from brouwer in brouwers from bier in brouwer.Bieren select bier;

    //        //Iteratie over de verameling bieren
    //        foreach (var bier in bieren)
    //        {
    //            Console.WriteLine(bier.ToString());
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 6.1 Bieren en Brouwers
    //LinQ toegepast op een verameling van zelf gedefinieerde objecten
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Maak nieuwe verzameling van objecten brouwers uit de class Brouwers met de functie GetBrouwers
    //        var brouwers = new Brouwers().GetBrouwers();
    //        //Sorteer de brouwers uit de verzameling brouwers op Naam Ascending
    //        var brouwersGesorteerdAsc = from brouwer in brouwers orderby brouwer.BrouwerNaam select brouwer;

    //        Console.WriteLine("Ascending: ");

    //        //Iteratie door alle brouwers uit de verzameling brouwersGesorteerdAsc
    //        foreach(var brouwer in brouwersGesorteerdAsc)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //        Console.WriteLine("");

    //        //Sorteer de brouwers uit de verzameling brouwers op Naam Descending
    //        var brouwersGesorteerdDesc = from brouwer in brouwers orderby brouwer.BrouwerNaam descending select brouwer;

    //        Console.WriteLine("Descending: ");

    //        //Iteratie door alle brouwers uit de verzameling brouwersGesorteerdDesc
    //        foreach (var brouwer in brouwersGesorteerdDesc)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 6.2 Bieren en Brouwers
    //LinQ toegepast op een verzameling van zelf gedefinieerde objecten
    //Query met een anoniem type
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Maak een nieuwe verzameling van alle brouwer objecten uit de class Brouwers.cs
    //        var brouwers = new Brouwers().GetBrouwers();

    //        //Gebruik een LinQ statement om nieuwe objecten aan te maken in de verzameling brouwerGegevens en geef deze elementen de brouwerNaam en het aantal bieren per brouwer mee
    //        var brouwerGegevens = from brouwer in brouwers select new { BrouwerNaam = brouwer.BrouwerNaam, AantalBieren = brouwer.Bieren.Count };

    //        //Iteratie door alle anoniem aangemaakte objecten uit de verzameling brouwerGegevens 
    //        foreach(var brouwer in brouwerGegevens)
    //        {
    //            Console.WriteLine($"Brouwernaam: {brouwer.BrouwerNaam}, Aantal bieren: {brouwer.AantalBieren}");
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 6.3 Bieren en Brouwers
    //LinQ toegepast op een verzameling van zelf gedefinieerde objecten
    //Querys met WHERE clause
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var brouwers = new Brouwers().GetBrouwers();

    //        Console.WriteLine("Belgische Brouwerijen:");

    //        var BelgischeBrouwerijen = from brouwer in brouwers where brouwer.Belgisch select brouwer;
    //        foreach (var brouwer in BelgischeBrouwerijen)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Niet Belgische Brouwerijen:");

    //        var NietBelgischeBrouwerijen = from brouwer in brouwers where !brouwer.Belgisch select brouwer;
    //        foreach(var brouwer in NietBelgischeBrouwerijen)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Brouwers met 2 bieren: ");

    //        var BrouwersMet2Bieren = from brouwer in brouwers where brouwer.Bieren.Count == 2 select brouwer;
    //        foreach(var brouwer in BrouwersMet2Bieren)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Brouwers met een ingegeven aantal bieren: ");
    //        Console.WriteLine("Geef een aantal: ");
    //        var Aantal = int.Parse(Console.ReadLine());

    //        var BrouwersMetingegevenAantal = from brouwer in brouwers where brouwer.Bieren.Count == Aantal select brouwer;
    //        foreach(var brouwer in BrouwersMetingegevenAantal)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Belgische brouwers met 3 bieren: ");
    //        var BelgischeBrouwersMet3Bieren = from brouwer in brouwers where brouwer.Bieren.Count == 3 && brouwer.Belgisch select brouwer;

    //        foreach(var brouwer in BelgischeBrouwersMet3Bieren)
    //        {
    //            Console.WriteLine(brouwer.ToString());
    //        }

    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 6.4 Bieren en Brouwers
    //LinQ toegepast op een verameling van zelf gedefinieerde objecten
    //Query's
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var brouwers = new Brouwers().GetBrouwers();
    //        var alcoholarmeBieren = from brouwer in brouwers from bier in brouwer.Bieren where bier.Alcohol < 0.2F select bier;

    //        foreach(var bier in alcoholarmeBieren)
    //        {
    //            Console.WriteLine(bier.ToString());
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //15.1.0 Oefening LinQ
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var planten = new Planten().getPlanten();

    //        //Alle planten uit de lijst met alle gegevens per plant
    //        /* foreach(var plant in planten)
    //         {
    //             Console.WriteLine(plant.ToString());
    //         }*/

    //        Console.WriteLine("Toon plantennaam, kleur en prijs van de witte planten, gesorteerd op prijs.");
    //        var plantenQuery1 = from plant in planten where plant.Kleur == "Wit" orderby plant.Prijs select plant;

    //        foreach(var plant in plantenQuery1)
    //        {
    //            Console.WriteLine($"Plantennaam: {plant.PlantenNaam}, Kleur: {plant.Kleur}, Prijs: {plant.Prijs} Euro");
    //        }

    //        Console.WriteLine("");


    //        Console.WriteLine("Toon het aantal witte planten.");
    //        var plantenQuery2 = from plant in planten where plant.Kleur == "Wit" select plant;

    //        Console.WriteLine("Aantal witte planten: {0}", plantenQuery2.Count());
    //        Console.WriteLine("");

    //        Console.WriteLine("Bereken de gemiddelde prijs van de heesters en toon deze op het scherm.");
    //        var plantenQuery3 = from plant in planten where plant.Soort == "Heester" select plant.Prijs;

    //        decimal totaal = 0;
    //        foreach(var prijs in plantenQuery3)
    //        {
    //            totaal = totaal + prijs;
    //        }

    //        Console.WriteLine("Het gemiddelde van alle Heesters is: {0} Euro", totaal / plantenQuery3.Count());
    //        Console.WriteLine("");

    //        Console.WriteLine("Toon de gemiddelde prijs en de maximumprijs van de kruiden.");
    //        var plantenQuery4 = from plant in planten where plant.Soort == "Kruid" select plant.Prijs;

    //        totaal = 0;
    //        foreach(var prijs in plantenQuery4)
    //        {
    //            totaal = totaal + prijs;
    //        }

    //        Console.WriteLine("Het gemiddelde van alle Kruiden is: {0} Euro", totaal / plantenQuery4.Count());
    //        Console.WriteLine("De hoogste prijs uit alle kruiden is: {0} Euro", plantenQuery4.Max());
    //        Console.WriteLine("");

    //        Console.WriteLine("Toon de plantennamen die met de letter “B” beginnen.");
    //        var plantenQuery5 = from plant in planten.Where (plant => plant.PlantenNaam.StartsWith("B")) select plant.PlantenNaam;

    //        foreach(var plant in plantenQuery5)
    //        {
    //            Console.WriteLine($"Naam: {plant}");
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Toon een lijst van de verschillende plantenkleuren op het scherm");
    //        var plantenQuery6 = from plant in planten select plant.Kleur;

    //        ArrayList kleuren = new ArrayList();

    //        foreach(var kleur in plantenQuery6)
    //        {
    //            if (!kleuren.Contains(kleur))
    //            {
    //                kleuren.Add(kleur);
    //            }
    //        }


    //        foreach (var kleur in kleuren)
    //        {
    //            Console.WriteLine("Kleur: {0}", kleur);
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Toon de plantennamen per kleur op het scherm");
    //        var plantenQuery7 = from plant in planten orderby plant.Kleur select plant;

    //        foreach(var plant in plantenQuery7)
    //        {
    //            Console.WriteLine($"Plantnaam: {plant.PlantenNaam}, Kleur: {plant.Kleur}");
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Toon per soort de maximum plantenprijs van die soort");
    //        var plantenQuery8 = from plant in planten group plant by plant.Soort into soortgroep select new { Soort = soortgroep.Key, maxPrijs = soortgroep.Max(plant => plant.Prijs)};


    //        foreach(var groep in plantenQuery8)
    //        {
    //            Console.WriteLine($"{groep.Soort}: , Max prijs: {groep.maxPrijs} Euro");
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Toon de soorten alfabetisch met per soort, het aantal planten van deze soort, de namen van de planten van deze soort");
    //        var plantenQuery9 = from plant in planten orderby plant.Soort group plant by plant.Soort into soortgroep select new { Soort = soortgroep.Key, Aantal = soortgroep.Count(), Planten = soortgroep};

    //        foreach(var groep in plantenQuery9)
    //        {
    //            Console.WriteLine($"Soort: {groep.Soort}" );
    //            Console.WriteLine($"Aantal planten: {groep.Aantal}");
    //            Console.WriteLine("Planten: ");
    //            foreach(var plant in groep.Planten)
    //            {
    //                Console.WriteLine(plant.PlantenNaam);
    //            }
    //            Console.WriteLine("");
    //        }

    //        Console.WriteLine("");
    //        Console.WriteLine("Toon de namen van de planten gegroepeerd per soort en binnen de soort per kleur");
    //        var plantenQuery10 = from plant in planten group plant by plant.Soort into soortgroep select new { Soort = soortgroep.Key,
    //            GroepKleur = from plant in soortgroep group plant by plant.Kleur into kleurgroep select new { Kleur = kleurgroep.Key, Planten = kleurgroep} };

    //        foreach(var groep in plantenQuery10)
    //        {
    //            Console.WriteLine($"Soort:{groep.Soort}");
    //            foreach(var kleur in groep.GroepKleur)
    //            {
    //                Console.WriteLine($"Kleur:{kleur.Kleur}");
    //                foreach(var plant in kleur.Planten)
    //                {
    //                    Console.WriteLine($"             {plant.PlantenNaam}");
    //                }
    //            }
    //            Console.WriteLine("");
    //            Console.WriteLine("==========================");
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.0 Files & Streams I.O
    //STEEDS SYSTEM.IO importeren bij gebruik van streams!
    //Voorbeeld 1 Verwijderen en aanmaken van directory's
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        string directoryNaam = @"C:\Data";

    //        //Kijk of de directory naam bestaat
    //        if (Directory.Exists(directoryNaam))
    //        {
    //            Console.WriteLine($"De directory {directoryNaam} bestaat");

    //            //Kijk of de directory inhoud of submappen bevat
    //            if(Directory.GetDirectories(directoryNaam).Count() != 0 || Directory.GetFiles(directoryNaam).Count() != 0)
    //            {
    //                Console.WriteLine("De directory met inhoud wordt verwijderd");
    //                //Deletes een directory met al zijn submappen of inhoud
    //                Directory.Delete(directoryNaam, true);
    //            }
    //            else
    //            {
    //                Console.WriteLine("De directory wordt verwijderd");
    //                //Deletes een directory met geen inhoud (lees geen inhoud of submappen)
    //                Directory.Delete(directoryNaam);
    //            }     
    //        }
    //        else
    //        {
    //            Console.WriteLine($"De directory {directoryNaam} bestaat niet");
    //            Console.WriteLine($"De directory wordt aangemaakt");
    //            //Maak een directory aan
    //            Directory.CreateDirectory(directoryNaam);
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.1 Files & Streams I.O
    //Voorbeeld 2 De classes File en FileInfo
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        string directoryNaam = @"C:\Data";
    //        string bestandsNaam = "Pizzas.txt";
    //        string bestand = directoryNaam + @"\" + bestandsNaam;

    //        Directory.CreateDirectory(directoryNaam);

    //        if (!File.Exists(bestand))
    //        {
    //            Console.WriteLine("Het bestand {0} bestaat niet", bestand);
    //            Console.WriteLine("Het bestand {0} wordt nu aangemaakt", bestand);
    //            string tekst;
    //            tekst = "Pizza Margherita (tomatensaus - mozzarella): 8 Euro";
    //            File.WriteAllText(bestand, tekst);

    //            tekst = Environment.NewLine + "Pizza Vegatariana (tomatensaus - mozarella-groenten): 9.5 Eur";
    //            File.AppendAllText(bestand, tekst);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Het bestand {0} bestaat", bestand);
    //            string bestandsinformatie = "Datum creatie: " + File.GetCreationTime(bestand) + System.Environment.NewLine + "Datum laatst gebruikt: " + File.GetLastAccessTime(bestand);
    //            Console.WriteLine(bestandsinformatie);
    //            Console.WriteLine("De inhoude van het bestand: ");
    //            string tekst = File.ReadAllText(bestand);
    //            Console.WriteLine(tekst);
    //            File.Delete(bestand);
    //            Console.WriteLine("Het bestand wordt weer gedeletet");
    //        }
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.2 Files & Streams I.O$
    //Voorbeeld 3 Lezers en schrijvers (readers & writers)
    //Creëren en lezen van een bestand
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //bepaal de locatie waar het bestand dient opgeslagen te worden
    //        string locatie = @"C:\Data\";

    //        //We gebruiken een try catch structuur om fouten op te vangen
    //        try
    //        {
    //            //Maak gebruikt van de StreamWriter class om hier een nieuw object van te creëren, we geven de locatie + bestandsnaam mee in de constructor
    //            using (StreamWriter schrijver = new StreamWriter(locatie + "Pizzas.txt")) 
    //            {
    //                //Geef een titel aan je bestand (1ste regel)
    //                string titel = "Prijslijst pizza's";
    //                schrijver.WriteLine(titel);

    //                //Add tekst aan je bestand toe (For loop is niet verplicht dit is enkel in het voorbeeld!)
    //                for(var teller = 1; teller <= titel.Length; teller++)
    //                {
    //                    schrijver.Write('*');
    //                    schrijver.WriteLine();
    //                    schrijver.WriteLine("Pizza Margherita (tomatensaus - mozzarella): 8 Euro");
    //                    schrijver.WriteLine("Pizza Napoli (tomatensaus - mozarella - ansjovis - kappertjes - olijven: 9.5 Euro");
    //                    schrijver.WriteLine("Pizza Vegetariana (tomatensaus - mozarella - assortiment van groenten): 9.5 Euro");
    //                }
    //                Console.WriteLine("Het bestand werd succesvol gemaakt");
    //            }

    //            //Nog extra gegevens toevoegen (2de parameter op true = bestaand bestand openen en nieuwe data toevegen - 2de parameter op false = nieuw bestand creëren en hier data aan toevoegen)
    //            using (StreamWriter schrijver = new StreamWriter(locatie + "Pizzas.txt", true))
    //            {
    //                schrijver.WriteLine("Pizza Lardiera (tomatensaus - mozarella - spek): 9.5 Euro");
    //            }

    //        }
    //        //2 verschillende catches om fouten op te vangen
    //        catch(IOException)
    //        {
    //            Console.WriteLine("Fout bij het schrijven naar het bestand!");
    //        }
    //        catch(Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.3 Files & Stream I.O
    //Voorbeeld 4 Tekst inlezen vanuit een bestand
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        try
    //        {
    //            string regel;
    //            using (StreamReader Lezer = new StreamReader(@"C:\Data\pizzas.txt"))
    //            {
    //                while ((regel = Lezer.ReadLine()) != null)
    //                {
    //                    Console.WriteLine(regel);
    //                }
    //            }
    //        }
    //        catch(IOException)
    //        {
    //            Console.WriteLine("Fout bij het lezen van het bestand!");
    //        }
    //        catch(Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }

    //    }
    //}
    //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.4 Streams & Files IO
    //Voorbeeld 5 Gegevens schrijven naar bestand
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        List<Pizza> pizzas = new List<Pizza>
    //        {
    //        new Pizza {Naam = "Pizza Margherita", Onderdelen = new List<string> {"Tomatensaus", "Mozarrela"}, Prijs = 8m },
    //        new Pizza {Naam = "Pizza Vegetariana", Onderdelen = new List<string> { "Tomatensaus", "Mozarrela", "Groenten" }, Prijs = 9.5m },
    //        new Pizza {Naam = "Pizza Napoli", Onderdelen = new List<string> {"Tomatensaus", "Mozarella", "Ansjovis", "Kappers", "Olijven" }, Prijs = 10m }
    //        };

    //        string locatie = @"C:\Data\";
    //        StringBuilder pizzaRegel;

    //        try
    //        {
    //            using(StreamWriter schrijver = new StreamWriter(locatie + "pizzas.txt"))
    //            {
    //                foreach(var pizza in pizzas)
    //                {
    //                    pizzaRegel = new StringBuilder();
    //                    pizzaRegel.Append(pizza.Naam + ": ");

    //                    pizzaRegel.Append("Ingredienten: " + pizza.Onderdelen.Count.ToString() + " ");


    //                    foreach(string onderdeel in pizza.Onderdelen)
    //                    {
    //                        pizzaRegel.Append(onderdeel + ": ");
    //                    }
    //                    pizzaRegel.Append("Prijs: " + pizza.Prijs + " Euro");
    //                    schrijver.WriteLine(pizzaRegel);


    //                }

    //                Console.WriteLine("Schrijven naar bestand is geslaagd");
    //            }
    //        }
    //        catch (IOException)
    //        {
    //            Console.WriteLine("Fout het schrijven naar bestand!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }

    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.0.5 Streams & Files
    //Gegevens binair wegschrijven
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        string tekst = "Lottogetallen";
    //        int aantalGetallen = 45;
    //        byte[] lottogetallen = { 1,27,32,33,44,12,5};
    //        float winst = 18f;
    //        string datum = DateTime.Now.ToShortDateString();

    //        using (BinaryWriter schrijver = new BinaryWriter(File.Open(@"C:\Data\Lottogetallen.bin", FileMode.Create)))
    //        {
    //            schrijver.Write(aantalGetallen);
    //            schrijver.Write(tekst);
    //            schrijver.Write(lottogetallen);
    //            schrijver.Write(winst);
    //            schrijver.Write(datum);
    //        }

    //        tekst = "";
    //        winst = 0;
    //        datum = "";

    //        using(BinaryReader lezer = new BinaryReader(File.Open(@"C:\Data\Lottogetallen.bin", FileMode.Open)))
    //        {
    //            aantalGetallen = lezer.ReadInt32();
    //            tekst = lezer.ReadString();
    //            lottogetallen = lezer.ReadBytes(7);
    //            winst = lezer.ReadSingle();
    //            datum = lezer.ReadString();
    //        }

    //        Console.WriteLine("Aantal mogelijk getallen: {0}", aantalGetallen);
    //        Console.WriteLine();
    //        Console.WriteLine("Getrokken {0}" ,tekst);
    //        int i = 1;
    //        foreach (byte lottogetal in lottogetallen)
    //        {
    //            Console.WriteLine("Getal{0}: {1}",i, lottogetal);
    //            i++;
    //        }
    //        Console.WriteLine();
    //        Console.WriteLine("Winst: {0} Euro", winst);
    //        Console.WriteLine("Datum {0}", datum);
    //    }
    //}
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //16.1.0 Oefening Streams & Files
    //Oefening tweets

    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Twitter twitter = new Twitter();
    //        bool choosing = true;
    //        string naam;
    //        string bericht;
    //        string input;
    //        while(choosing == true)
    //        {
    //            Console.WriteLine("Kies 1 om een bericht te plaatsen");
    //            Console.WriteLine("Kies 2 om de meest recente berichten te lezen");
    //            Console.WriteLine("Kies 3 om recente berichten van een bepaalde gebruiker te lezen");
    //            input = Console.ReadLine();

    //            if(input == "1")
    //            {
    //                choosing = false;

    //                Console.WriteLine("Geef u gebruikersnaam in");
    //                naam = Console.ReadLine();

    //                Console.WriteLine("Geef u bericht van max 140 karakters in");
    //                bericht = Console.ReadLine();
                    
    //                Tweet tweet = new Tweet()
    //                {
    //                    Naam = naam,
    //                    Bericht = bericht
    //                };

    //                twitter.schrijfTweet(tweet);
    //            }

    //            else if(input == "2")
    //            {
    //                choosing = false;

    //                var tweets = twitter.AlleTweets();
    //                foreach(var tweet in tweets)
    //                {
    //                    Console.WriteLine($"Datum: {tweet.Tijdstip}");
    //                    Console.WriteLine($"Schrijver: {tweet.Naam}");
    //                    Console.WriteLine($"Bericht: {tweet.Bericht}");
    //                    Console.WriteLine("");
    //                }
    //            }
    //            else if(input == "3")
    //            {
    //                choosing = false;
    //                Console.WriteLine("Wie wil je volgen? ");
    //                naam = Console.ReadLine();

    //                var tweetsVan = twitter.TweetsVan(naam);
    //                if(tweetsVan.Count() == 0)
    //                {
    //                    Console.WriteLine($"{naam} heeft nog geen tweets geplaatst");
    //                }
    //                else
    //                {
    //                    foreach(var tweet in tweetsVan)
    //                    {
    //                        Console.WriteLine($"Datum: {tweet.Tijdstip}");
    //                        Console.WriteLine($"Schrijver: {tweet.Naam}");
    //                        Console.WriteLine($"Bericht: {tweet.Bericht}");
    //                        Console.WriteLine("");
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("Geen geldige ingave");
    //            }

    //        }
    //    }       
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //17.0.0 Asynchrone Code 
    //Voorbeeld 1 Een synchrone method 
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Console.WriteLine("Method main is gestart");
    //        Start();
    //        Console.WriteLine("Terug in de Method Main");
    //        Console.WriteLine("Druk een willekeurige toets .....");
    //        Console.WriteLine("");
    //        Console.ReadLine();    
    //    }

    //    static void Start()
    //    {
    //        string tekst = DoeIets();
    //        Console.WriteLine(tekst);
    //    }

    //    static string DoeIets()
    //    {
    //        Console.WriteLine("Bezig met method ... DoeIets()");
    //        //Thread laat het programma 5 seconden slapen
    //        Thread.Sleep(5000);
    //        return "De taak is afgewerkt";
    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //17.0.1 Asynchrone Code
    //Voorbeeld 2 een Asynchrone method
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Method Main is gestart");
            Start();
            Console.WriteLine("terug in Method Main");
            Console.WriteLine("Druk een willekeurige toets als je het resultaat ziet");
            Console.WriteLine();
            Console.ReadLine();
        }

        static async void Start()
        {
            Console.WriteLine("Method is gestart");
            string tekst = await DoeIetsAsync();
            Console.WriteLine(tekst);
        }

        static async Task<string> DoeIetsAsync()
        {
            Console.WriteLine("Bezig met taak ... DoetIetsAsync");
            await Task.Delay(5000);
            return "De taak is afgewerkt";
        }
    }

}//Einde namespace

