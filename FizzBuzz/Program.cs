using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class Program
    {        /*
        "Write a program that prints the numbers from 1 to N.
        But for multiples of three print “Fizz” instead of the number 
            and for the multiples of five print “Buzz” instead of the number.
        
        For numbers which are multiples of both three and five print “FizzBuzz”."
        */

        static void Main(string[] args)
        {
            PrintFizzBuzz(100);
            Console.ReadLine();
        }

        static void PrintFizzBuzz(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                if(i % (3*5) == 0)
                    Console.WriteLine("FizzBuzz");
                else if(i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if(i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}