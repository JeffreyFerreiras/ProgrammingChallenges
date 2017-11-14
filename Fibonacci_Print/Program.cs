using System;

namespace Fibonacci_Print
{
    class Program
    {
        /*
         * Write a function to calculate the nth number in the Fibonacci sequence.
         */
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(8));
            Console.Read();
        }

        static int Fib(int current)
        {
            if (current < 2)
                return current;

            return Fib(current - 1) + Fib(current - 2);
        }
    }
}
