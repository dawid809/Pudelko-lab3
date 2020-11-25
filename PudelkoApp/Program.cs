using PudelkoLibrary;
using System;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(2.5,9.321,0.1, UnitOfMeasure.meter);
            //Pudelko p2 = new Pudelko(1, 1, 1, UnitOfMeasure.milimeter);
            //Console.WriteLine(p2.Objetosc);
            

            Console.WriteLine(pudelko.ToString("m"));
            Console.WriteLine(pudelko.ToString("cm"));
            Console.WriteLine(pudelko.ToString("mm"));
            



        }
    }
}
