using System.Collections.Generic;

namespace PrimeFactors
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            var factors = new List<int>();

            int divider = 2;
            while (number > 1)
            {
                while (number % divider == 0)
                {
                    factors.Add(divider);
                    number /= divider;
                }
                divider = divider + 1;
            }
            return factors;
        }
    }
}
