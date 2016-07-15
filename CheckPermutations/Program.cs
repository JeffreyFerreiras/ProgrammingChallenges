using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPermutations
{
    class Program
    {
        /*
            Given two strings, write a method to decide if one is a permutation of the other.
        */
        static void Main(string[] args)
        {   //TEST
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool isPermute = IsPermutationOrderBy("taco cat","taco cat");
            bool isPermute2 = IsPermutationOrderBy("taco cat","taco ca");
            sw.Stop();

            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            bool isPermute3 = IsPermutationQuickSort("taco cat","taco cat");
            bool isPermute4 = IsPermutationQuickSort("taco cat","taco ca");
            sw2.Stop();
            //END TEST
        }
        
        
        static bool IsPermutationQuickSort(string original, string permutation)
        {
            //SOLUTION: With custom QuickSort algorithm implementation.
            //This implementation is nearly 4X faster than using OrderBy

            if(original.Length != permutation.Length)
                return false;

            original    = QuickSort.QuickSorter(original);
            permutation = QuickSort.QuickSorter(permutation);

            if(original.Equals(permutation))
                return true;
            else
                return false;
        }
        static bool IsPermutationOrderBy(string s1, string s2)
        {
            //SOLUTION: in one line.

            return s1.Length == s2.Length ? s1.OrderBy(x => x).Equals(s2.OrderBy(x => x)) : false;
                        
            //NOTE: OrderBy implements a QuickSort algorithm with a speed of O(n log n). It's an efficient way to sort.
        }

    }
}
