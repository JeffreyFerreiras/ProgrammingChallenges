using System;
using System.Numerics;

namespace ExtraLongFactorial
{
    class Program
    {
        /*
         * You are given an integer N. Print the factorial of this number.
         */

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
            Console.WriteLine(Factorial(19));
            Console.WriteLine(Factorial(25));

            Console.ReadLine();
        }

        static System.Numerics.BigInteger Factorial(BigInteger n)
        {
            if (n == 1) return n;

            return n * Factorial(n - 1);
        }
    }
}
