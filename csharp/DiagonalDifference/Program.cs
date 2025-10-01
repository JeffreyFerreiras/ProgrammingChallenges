using System;

namespace DiagonalDifference
{
    class Program
    {
        /*
Given a square matrix of size N, calculate the absolute difference between the sums of its diagonals.

The first line contains a single integer, . The next  lines denote the matrix's rows, with each line containing space-separated integers describing the columns.

Output

Print the absolute difference between the two sums of the matrix's diagonals as a single integer.

Sample Input

3
11 2 4
4 5 6
10 8 -12

Sample Output

15

Explanation

The primary diagonal is: 
11
      5
            -12

Sum across the primary diagonal: 11 + 5 - 12 = 4

The secondary diagonal is:
            4
      5
10
Sum across the secondary diagonal: 4 + 5 + 10 = 19 
Difference: |4 - 19| = 15
*/
        static void Main(String[] args)
        {
            //Generated code
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] numArray = new int[n][];

            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                numArray[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }
            //End Generated code

            PrintArrayDiagnalSum(numArray);
            Console.ReadLine();
        }

        private static void PrintArrayDiagnalSum(int[][] numArray)
        {//SOLUTION
            if (numArray == null)
                throw new NullReferenceException("Array cannot be null");

            int firstDiagSum = 0, secondDiagSum = 0;

            for (int i = 0; i < numArray.Length; i++)
            {
                firstDiagSum += numArray[i][i];
                secondDiagSum += numArray[(numArray.Length - 1) - i][i];
            }

            Console.WriteLine(Math.Abs(firstDiagSum - secondDiagSum));
        }
    }
}
