using System;
using System.Collections.Generic;
using System.Linq;

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
            //Not prime
            //Not prime
            //Not prime
            //Not prime
            //Not prime
            //Not prime
            //Not prime
            //Prime
            //Not prime
            //Prime
            int[] data = {
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
            };
            //{ 12, 5, 7, 15 , 661, 450};

            foreach(int n in data)
            {
                if(IsPrime(n))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not prime");
                }
            }
        }

        private static HashSet<int> primes = new HashSet<int>();

        private static bool IsPrime(int value)
        {
            if(value <= 1) return false;
            if(value == 2) return true;
            if(value % 2 == 0 || value % 3 == 0) return false; //eliminates all even numbers.
            if(primes.Contains(value)) return true;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(value));

            for(int i = 5; i <= sqrt; i+=2)
            {
                if(value % i == 0)
                {
                    return false;
                }
            }
            
            primes.Add(value);

            return true;
        }
    }
}