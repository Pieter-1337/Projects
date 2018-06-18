using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 1.0 Delegates 
    //Delegate met return type

    //Declare Delegate type and design signature (All methods invoked with this delegate type need to have the same signature (Parameters and return type))
    //public delegate int Transformer(int x);
    //class Program
    //{
    //    //define a method which can be invoked by a delegate (has the same signature)
    //    public static int Square(int x)
    //    {
    //        return (x * x);
    //    }

    //    //Main program method
    //    public static void Main(string[] args)
    //    {
    //        Transformer t = Square;//Create delegate instance
    //        int result = t(3);//Invoke delegate
    //        Console.WriteLine(result); //Output result variable (which is the result of the invoked delegate method/function)
    //    }
    //}

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 1.1 Delegates
    //Delegate zonder return type (Void)


    //Declare Delegate type and design signature(All methods invoked with this delegate type need to have the same signature (Parameters and return type or void)
    //public delegate void Gesprek(string input);

    //class Program
    //{
    //    //define a method which can be invoked by a delegate (has the same signature)
    //    public static void Persoon1(string input)
    //    {
    //        Console.WriteLine($"Persoon1: {input}");
    //    }

    //    //define another method which can be invoked by a delegate (has the same signature)
    //    public static void Persoon2(string input)
    //    {
    //        Console.WriteLine($"Persoon2: {input}");
    //    }

    //    public static void Main(string[] args)
    //    {
    //        Gesprek gesprek = Persoon1;

    //        gesprek("Hallo hoe gaat het?");

    //        gesprek = Persoon2;
    //        gesprek("Goed en met U?");

    //        gesprek = Persoon1;
    //        gesprek("Ook goed bedankt");

    //    }
    //}

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Voorbeeld 1.0 Delegates 
    //Multicast delegates

    // Declare Delegate type and design signature(All methods invoked with this delegate type need to have the same signature (Parameters and return type))
    public delegate void Transformer(int x);
    class Program
    {
        public static int resultaat = 0;
        
        //define methods which can be invoked by a delegate (has the same signature)
        public static void Square(int x)
        {
            int result = (x * x);

            resultaat += result;
        }

        public static void Double(int x)
        {
            int result = (2 * x);

            resultaat += result;
        }

        //Main program method
        public static void Main(string[] args)
        {
            Transformer t = Square;//Create delegate instance
            t += Double;

            if ( t!= null )
            {
                t(3);//Invoke multicst delegate
                Console.WriteLine(resultaat); //Output resultaat variable (which is the result of the invoked delegate method/function)
            }
            else
            {
                throw new Exception("Delegate is null");
            }
 

            resultaat = 0;
            t -= Square;
            if (t != null)
            {
                t(3);//Invoke multicst delegate
                Console.WriteLine(resultaat); //Output resultaat variable (which is the result of the invoked delegate method/function)
            }
            else
            {
                throw new Exception("Delegate is null");
            }
            
            

            resultaat = 0;
            t -= Double;
            if(t != null)
            {
                t(3);//Invoke multicst delegate
                Console.WriteLine(resultaat); //Output resultaat variable (which is the result of the invoked delegate method/function)
            }
            else
            {
                throw new Exception("Delegate is null");
            }
        }
    }
}
