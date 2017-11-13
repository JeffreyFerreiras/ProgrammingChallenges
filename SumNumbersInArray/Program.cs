using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbersInArray
{
    class Program
    {
        /*
         * Given an array of numbers, identify if two numbers in the array sum up to a given number
         */
        static void Main(string[] args)
        {
            int[] arr = new[] { 1, 2, 3, 9 };
            int[] arr2 = new[] { 1, 2, 4, 4 };


            bool isSumUp = HasSumWithSorted(arr, 8);
            bool isSumUp2 = HasSumWithSorted(arr2, 8);

            isSumUp = HasSumNotSorted(arr, 8);
            isSumUp2 = HasSumNotSorted(arr2, 8);
        }
        /*
         * Negatives are allowed.
         * Array of type int.
         * cannot sum number in same index to get result.
         * numbers can repeat.
         * array is in order
         * 
         * Loop through each element
         * Eliminate looping through numbers that cannot be summed up by 8;
         * find first element that returns true;
         * 
         */

        private static bool HasSumWithSorted(int[] arr, int x)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (arr[high] > x) high--;

            while (low <= high)
            {
                int sum = (arr[low] + arr[high]);

                if (sum == x)
                    return true;
                else if(sum > x)
                    high--;
                else
                    low++;
            }

            return false;
        }

        private static bool HasSumNotSorted(int[] arr, int x)
        {
            HashSet<int> compliment = new HashSet<int>();

            foreach (var value in arr)
            {
                if(value <= x)
                {
                    if (compliment.Contains(value))
                    {
                        return true;
                    }

                    compliment.Add(x - value);
                }
            }

            return false;
        }
    }
}
