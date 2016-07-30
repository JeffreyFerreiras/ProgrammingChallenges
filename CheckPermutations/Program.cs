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
            bool isPermute  = IsPermutationOrderBy("taco cat","taco cat");
            bool isPermute2 = IsPermutationOrderBy("taco cat","taco ca");
            bool isPermute6 = IsPermutationOrderBy("taco cat",string.Empty);
            sw.Stop();

            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            bool isPermute3 = IsPermutationQuickSort("taco cat","taco cat");
            bool isPermute4 = IsPermutationQuickSort("taco cat","taco ca");
            bool isPermute5 = IsPermutationQuickSort("taco cat","");
            sw2.Stop();
            //END TEST
        }
        
        
        static bool IsPermutationQuickSort(string original, string permutation)
        {
            //SOLUTION: With custom QuickSort algorithm implementation.
            //This implementation is nearly 4X faster than using OrderBy
            //Changed the QuickSorter to an extension method.

            bool notEmpty = !(string.IsNullOrEmpty(original) || !string.IsNullOrEmpty(permutation));
            if( notEmpty && original.Length != permutation.Length)
                return false;

            original    = original.QuickSorter();
            permutation = permutation.QuickSorter();

            if(original == permutation)
                return true;
            else
                return false;
        }
        static bool IsPermutationOrderBy(string s1, string s2)
        {
            //SOLUTION: in one line.
            return s1.Length == s2.Length ? s1.OrderBy(x => x).ToString() == s2.OrderBy(x => x).ToString() : false;
        }
    }
}
