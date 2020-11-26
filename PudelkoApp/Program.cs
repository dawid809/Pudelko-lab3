using PudelkoLibrary;
using System;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(2.5,9.321,0.1, UnitOfMeasure.meter);
            Pudelko p2 = new Pudelko(0.001, 0.002, 0.003, UnitOfMeasure.meter);
            Console.WriteLine(p2.Objetosc);


            Console.WriteLine(pudelko.ToString("m"));
            Console.WriteLine(pudelko.ToString("cm"));
            Console.WriteLine(pudelko.ToString("mm"));
            Console.WriteLine(p2[1]);



        }
    }
}
