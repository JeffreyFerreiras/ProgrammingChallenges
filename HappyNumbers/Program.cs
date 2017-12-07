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

        Example: 5 is the square of 25 so ... 5+5=10. 10 is the sum of the square.

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
happy number: 7->49 ->97->130->10->1.

Here's why 22 is NOT a happy number: 
22->8->64->52->29->85->89->145->42->20->4->16->37->58->89...
        
         */
    class Program
    {
        static HashSet<int> cache = new HashSet<int>();

        public static void Main(string[] args)
        {
            Console.WriteLine(IsHappyNumber(Convert.ToInt32("145")));
            Console.ReadLine();
        }
        static int IsHappyNumber(int num)
        { //SOLUTION
             
            int sumOfSquares = 0;

            while(num != 0)
            {
                int digit = num % 10;
                num = num / 10;

                sumOfSquares += (int)Math.Pow(digit, 2);                                   
            }

            if(!cache.Add(sumOfSquares)) return 0;   
            if(sumOfSquares == 1) return 1;

            return IsHappyNumber(sumOfSquares);
        }
    }
}
