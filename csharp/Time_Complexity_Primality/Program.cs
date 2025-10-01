using System;
using System.Collections.Generic;

namespace Time_Complexity_Primality
{
    internal class Program
    {
        /*
         * A prime is a natural number greater than 1 that has no positive divisors other than 1 and itself.
         * Given  integers, determine the primality of each integer and print whether it is Prime or Not prime on a new line.
         */

        /*  1. Analyze
         *  2. Clarify
         *  3. Brute Force
         *  4. Optimize
         *  5. Walkthrough
         *  6. Code
         *  7. Test
         */

        private static void Main(string[] args)
        {
            int[] data = [
                30 ,
                1  ,
                4  ,
                9  ,
                16 ,
                25 ,
                36 ,
                49 ,
                64 ,
                81 ,
                100,
                121,
                144,
                169,
                196,
                225,
                256,
                289,
                324,
                361,
                400,
                441,
                484,
                529,
                576,
                625,
                676,
                729,
                784,
                841,
                907,
            ];

            foreach (int n in data)
            {
                if (IsPrime(n))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not prime");
                }
            }
        }

        private static readonly HashSet<int> knownPrimes = []; //stores all the known prime numbers to avoid recalculating them.

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false; //1 is not a prime number and anything less than 1 is not a natural number.
            if (number == 2) return true; //2 is the only even prime number.
            if (number % 2 == 0 || number % 3 == 0) return false; //eliminates all even numbers, because even numbers cannot be a prime number.
            if (knownPrimes.Contains(number)) return true; //checks if the number is already in the list of known prime numbers.

            /// Calculates the square root of the given number and rounds it up to the nearest integer.
            int sqrt = (int)Math.Ceiling(Math.Sqrt(number));

            for (int i = 5; i <= sqrt; i += 2) // iterates through all odd numbers starting from 5 to the square root of the given number.
            {
                if (number % i == 0) //checks if the number is divisible by the current number.
                {
                    return false;
                }
            }

            knownPrimes.Add(number);

            return true;
        }
    }
}