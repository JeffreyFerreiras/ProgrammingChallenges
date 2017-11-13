using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumRepeatedNumbers
{
    class Program
    {
        /*
         * Suppose array has series of numbers, if user wants to find maximum repeated number in an array.
         */
        static void Main(string[] args)
        {
            int[] a = new int[] { 10, 20, 100, 100, 100, 10, 30, 20, 40, 50, 12, 14 };
            
            int repeated = FindMaxRepeat(a);
            Console.WriteLine(repeated);
            Console.Read();
        }

        private static int FindMaxRepeat(int[] arr)
        {
            int max = -1;

            HashSet<int> seen = new HashSet<int>();

            foreach(var num in arr)
            {
                if (seen.Contains(num))
                {
                    if(max < num)
                    {
                        max = num;
                    }
                }

                seen.Add(num);
            }

            return max;
        }
    }
}
