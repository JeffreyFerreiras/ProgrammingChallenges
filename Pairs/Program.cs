using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    class Program
    {
        /*
         * Given N integers, count the number of pairs of integers whose difference is K.
         * 
         * Sample Input
         * 5 2  
         * 1 5 3 4 2 
         * 
         * Sample Output
         * 3
         */


        static void Main(string[] args)
        {
            int[] a = { 1, 5, 3, 4, 2 };
            Console.WriteLine(Pairs(a, 2));

            int[] b = { 1, 5, 3, 4, 2 };
            Console.WriteLine(Pairs(b, 3));
        }

        static int Pairs(int[] ar, int k)
        {
            var seen = new HashSet<int>(ar);
            int count = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (seen.Contains(ar[i] - k))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
