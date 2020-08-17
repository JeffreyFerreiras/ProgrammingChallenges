using System;

namespace JumpStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // fibbonacci in disguase
        public static long Solution(long n)
        {
            if (n <= 1)
                return n;

            return fib(n + 1);
        }

        static long fib(long n)
        {
            if (n <= 1)
                return n;

            return fib(n - 1) + fib(n - 2);
        }
    }
}
