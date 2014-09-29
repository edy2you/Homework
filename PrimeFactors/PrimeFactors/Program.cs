using System;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a whole number:");
            int number = Int32.Parse(Console.ReadLine());
            PrimeFactors.Generate(number).ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
}
