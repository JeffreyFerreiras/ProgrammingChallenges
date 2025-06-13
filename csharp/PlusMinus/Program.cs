using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusMinus
{
    class Program
    {/*
        
Given an array of integers, calculate which fraction of its elements are positive,
which fraction of its elements are negative,
and which fraction of its elements are zeroes, respectively.
Print the decimal value of each fraction on a new line.

Note: This challenge introduces precision problems.
The test cases are scaled to six decimal places,
 though answers with absolute error of up to  are acceptable.

Input Format

The first line contains an integer, , denoting the size of the array. 
The second line contains  space-separated integers describing an array of numbers .

Output Format

You must print the following  lines:

A decimal representing of the fraction of positive numbers in the array.
A decimal representing of the fraction of negative numbers in the array.
A decimal representing of the fraction of zeroes in the array.
Sample Input

6
-4 3 -9 0 4 1         
Sample Output

0.500000
0.333333
0.166667
*/
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);

            //Solution
            float pos=0, neg =0, zero = 0;
            int arrLen = arr.Length;
            for(int i = 0; i < arrLen; i++)
            {
                if(arr[i] == 0) zero += 1;
                if(arr[i] < 0) neg += 1;
                if(arr[i] > 0) pos += 1;
            }
            Console.WriteLine(pos / arrLen);
            Console.WriteLine(neg / arrLen);
            Console.WriteLine(zero / arrLen);
        }
    }
}