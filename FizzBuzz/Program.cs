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
            foreach(var i in Enumerable.Range(1, 100))
            {
                Console.WriteLine(i % 3 == 0 && i % 5 == 0 ? "FizzBuzz" : i % 3 == 0 ? "Fizz" : i % 5 == 0 ? "Buzz" : i.ToString());
            }
            Console.ReadLine();

            FizzBuzz("3 5 15"); 
            Console.ReadLine();
        }
        static void FizzBuzz(string line)
        {
            //TEST CODE
            var numbers = line.Split(' ');
            var numArry = new int [3];
            for(int i = 0; i < numbers.Length; i++)
            {
                numArry[i] = int.Parse(numbers[i]);
            }
            //END TEST CODE
            PrintFizzBuzz(numArry);
        }
        static void PrintFizzBuzz(int[] numbers) //SOLUTION 2 (more readable, also takes array to customize how high the numbers go.)
        {
            if(numbers == null)
                throw new NullReferenceException("numbers cannot be empty");

            string fizz = "Fizz";
            string buzz = "Buzz";

            foreach(var i in Enumerable.Range(1, numbers[2]))
            {
                string fizzbuzz = string.Empty;

                if(i % numbers[0] == 0 && i % numbers[1] == 0)
                    fizzbuzz = fizz + buzz;
                else if(i % numbers[0] == 0)
                    fizzbuzz = fizz;
                else if(i % numbers[1] == 0)
                    fizzbuzz = buzz;
                else
                    fizzbuzz = i.ToString();

                Console.WriteLine(fizzbuzz);
            }       
        }
    }
}