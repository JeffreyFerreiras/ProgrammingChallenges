using System;

namespace FindDigits
{
    class Program
    {
        /*
         * Given an integer N, traverse its digits one by one. determine how many digits evenly divide N.
         * (i.e count the number of times N divided by each digit has a remainder of 0) print the number (sum) of
         * evenly divisible digits.
         * 
         */

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                //...Your code here.

                Console.WriteLine(DivisibleDigits(n));
            }
        }

        static int DivisibleDigits(int n)
        {
            int digit = 0, divisibleDigits = 0, ncopy = n;

            while(n > 0)
            {
                digit = n % 10;     // Get the digit all the way to the right.
                n = n / 10;         // Reasign N, getting rid of the last digit so we can pick up the next digit in the iteration that follows.

                if(digit > 0 && ncopy % digit == 0) 
                {
                    divisibleDigits += 1; 
                }
            }

            return divisibleDigits;
        }
    }
}
