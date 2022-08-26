using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumbers
{
    /*
Programming Challenge Description:
A happy number is defined by the following process.
Starting with any positive integer,
replace the number - by the sum, of the squares of its digits,
and repeat the process until the number equals 1 (where it will stay),
or it loops endlessly in a cycle which does not include 1.

Those numbers for which this process ends in 1 are happy numbers,
while those that do not end in 1 are unhappy numbers.

Input:
Your program should read lines of text from standard input.
Each line contains a single positive integer, N.

Output:
If the number is a happy number, print 1 to standard output. Otherwise, print 0.

For the curious,
here's why 7 is a 
happy number: 7->49->97->130->10->1.
Here's why 22 is NOT a happy number: 
22->8->64->52->29->85->89->145->42->20->4->16->37->58->89 ...
        
         */
    class Program
    {
        static List<int> s_cache = new List<int>();

        public static void Main(string[] args)
        {
            Console.WriteLine(IsHappyNumber(49));
        
            // is happy number test 8/25/2022
            int num = 7;
            Console.WriteLine($"is happy {num}: result: {IsHappy(num)} expected: true");
            num = 22;
            Console.WriteLine($"is happy {num}: result: {IsHappy(num)} expected: false");

            Console.ReadLine();
        }

        /**
         * Returns 1 if the number is a happy number, 0 otherwise. 2022
         */
        public static int IsHappy(int n){
            /**
             *   1. If the number is 1, return 1.
             *   2. while the number is not 1, the number squared
             *   3. if the number is bigger than 9 then sum the number of each digit.
             *   4. if the number is in the cache, return 0 because the numbers are repeating.
             */
            
            if (n == 1) return 1;
            var cache = new HashSet<int>();

            while(n > 1){
                n = SumOfSquares(n);
                if (cache.Contains(n)) 
                    return 0;
                cache.Add(n);
            }

            return n; // should be 1

            int SumOfSquares(int num){
                int sum = 0;
                while(n > 0){
                    int digit = n % 10;
                    sum += digit * digit;
                    n /= 10;
                }
                return sum;
            }
        }

        /**
         * Returns 1 if the number is a happy number, 0 otherwise. 2016
         */
        static int IsHappyNumber(int num)
        { //SOLUTION
             
            int sumOfRightDigit = 0;

            while(num != 0)
            {
                int digit = num % 10;
                num = num / 10;
                sumOfRightDigit += (int) Math.Pow(digit, 2);                                   
            }

            if(s_cache.Contains(sumOfRightDigit))
                return 0;

            s_cache.Add(sumOfRightDigit);

            if(sumOfRightDigit == 1)
                return 1;

            return IsHappyNumber(sumOfRightDigit);
        }
    }
}
