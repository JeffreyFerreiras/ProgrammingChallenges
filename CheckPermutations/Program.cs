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
        {
            bool isPermute = IsPermutation("taco cat","taco cat");
            bool isPermute2 = IsPermutation("taco cat","taco ca");
        }
        //ordering is slow.
        private static bool IsPermutation(string s1, string s2)
        {
            return s1.Length == s2.Length ? s1.OrderBy(x => x).Equals(s2.OrderBy(x => x)) : false;
            
            //NOTE: OrderBy implements a QuickSort algorithm with a speed of O(n log n). It's an efficient way to sort.
        }
    }
}
