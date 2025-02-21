using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fibonacci_Print
{
    internal class Program
    {
        /*
         * Write a function to calculate the nth number in the Fibonacci sequence.
         *
         *
         * NOTES: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
         * POS  : 1, 2, 3, 4, 5, 6 , 7, 8
         *
         * CASE: Input 8, resut 21
         */

        private static void Main(string[] args)
        {
            //Console.WriteLine(BasicFib(8));

            /*
             * Performance Runs
             */



            int num = 8;
            Console.WriteLine($"----  Test with {num} input  ----\n");

            FibMethodRunStats(PracticeFib, num);
            FibMethodRunStats(BasicFib, num);
            FibMethodRunStats(MemoizedFib, num);
            FibMethodRunStats(BottomUpFib, num);

            num = 30;
            cache = null;
            cache = [];
            Console.WriteLine($"\n----  Test with {num} input  ----\n");
            FibMethodRunStats(BasicFib, num);
            FibMethodRunStats(MemoizedFib, num);
            FibMethodRunStats(BottomUpFib, num);
            FibMethodRunStats(BottomUpFib2, num);

            Console.Read();
        }

        private static void FibMethodRunStats(Func<int, int> fib, int current)
        {
            var sw = Stopwatch.StartNew();
            int result = fib(current);
            sw.Stop();

            Console.WriteLine($"{fib.Method.Name}: \t\t\t\t{sw.ElapsedTicks} \t\t\t\t" +
                $"Result {result}");

            sw.Reset();
        }

        private static int BasicFib(int current)
        {
            if(current < 2)
                return current;

            return BasicFib(current - 1) + BasicFib(current - 2);
        }

        private static Dictionary<int, int> cache = [];

        private static int MemoizedFib(int current)
        {
            if(cache.ContainsKey(current))
                return cache[current];

            if(current < 2)
                return current;

            int firstResult = MemoizedFib(current - 1);
            int secondResult = MemoizedFib(current - 2);

            cache[current] = firstResult + secondResult;

            return cache[current];
        }

        /*
         * A Fibbonacci sequence is one that sums the result of a number when added 
         to the previous result starting with 1.
         *
         * so.. 1 + 1 = 2
         *      2 + 3 = 5
         *      3 + 5 = 8
         *      5 + 8 = 13
         *      8 + 13 = 21
         *
         * Following the sequence above we can create a bottom up approach.
         */

        private static int BottomUpFib(int n)
        {
            if(n < 1) throw new ArgumentException("Nth Fibbonacci number cannot be less than 1");
            if(n == 2) return n;

            int fib = 1;
            int last = 1;

            for(int i = 2; i < n; i++)
            {
                int temp = fib;
                fib += last;
                last = temp;
            }

            return fib;
        }

        private static int BottomUpFib2(int n)
        {
            if(n <= 2) return n; 

            int current = 5;
            int prev = 2;
            int fibCount = 3;

            while(fibCount++ < n){
                int temp = current;
                current += prev;
                prev = temp;
            }

            return current;
        }

        
        private static int PracticeFib(int n)
        {
            if(n < 2)
            {
                return n;
            }

            return PracticeFib(n - 1) + PracticeFib(n - 2);
        }
    }
}