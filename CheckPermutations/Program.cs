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
            bool isPermute  = IsPermutationOrderBy("taco cat","acto tac");
            bool isPermute2 = IsPermutationOrderBy("taco cat","taco ca");
            bool isPermute6 = IsPermutationOrderBy("taco cat",string.Empty);
            sw.Stop();

            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            bool isPermute3 = IsPermutationQuickSort("taco cat","acto tac");
            bool isPermute4 = IsPermutationQuickSort("taco cat","taco ca");
            bool isPermute5 = IsPermutationQuickSort("taco cat","");
            sw2.Stop();
            //END TEST

            //TEST
            //System.Diagnostics.Stopwatch sw3 = new System.Diagnostics.Stopwatch();
            //sw3.Start();
            //bool isPermute9 = IsPermutationWithHash("taco cat","acto tac");
            //bool isPermute7 = IsPermutationWithHash("taco cat","taco ca");
            //bool isPermute8 = IsPermutationWithHash("taco cat","");
            //sw3.Stop();
            //END TEST


            //TEST
            System.Diagnostics.Stopwatch sw4 = new System.Diagnostics.Stopwatch();
            sw4.Start();
            bool isPermute10 = IsAnagram("taco cat","acto tac");
            bool isPermute11 = IsAnagram("taco cat","taco ca");
            bool isPermute12 = IsAnagram("taco cat","");
            sw4.Stop();
            //END TEST
        }

        static bool IsPermutationWithHash(string original, string permutation)
        {   //Even faster/ not accurate solution.
            if(original == permutation)
                return true;

            if(original == null || permutation == null || original.Length != permutation.Length)
                return false;

            var originalSet = new List<char>(original);
            originalSet.Sort();

            foreach(var c in permutation)
            {
                if(originalSet.BinarySearch(c) == -1)
                    return false;
            }

            return true;
        }

        static bool IsPermutationQuickSort(string original, string permutation)
        {
            //SOLUTION: With custom QuickSort algorithm implementation.
            //This implementation is nearly 4X faster than using OrderBy
            
            if(original == permutation)
                return true;

            bool notEmpty = (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(permutation));

            if ( notEmpty && original.Length != permutation.Length)
                return false;

            original    = original.QuickSorter();
            permutation = permutation.QuickSorter();

            return original == permutation;
        }

        static bool IsPermutationOrderBy(string s1, string s2)
        {
            //SOLUTION: in one line.
            return s1.Length == s2.Length ? s1.OrderBy(x => x).ToString() == s2.OrderBy(x => x).ToString() : false;
        }

        //Best solution
        static bool IsAnagram(string original, string permutation)
        {
            var charTableOriginal = BuildCharTable(original);
            var charTablePermutation = BuildCharTable(permutation);
          
            for(int i = 0; i < charTableOriginal.Length; i++)
            {
                if(charTableOriginal[i] != charTablePermutation[i]) return false;
            }

            return true;
        }

        static int[] BuildCharTable(string phrase)
        {
            int [] table = new int[25];

            foreach(char c in phrase.Replace(" ",""))
            {
                int x = GetCharNumber(c);
                table[x]++;
            }

            return table;
        }

        static int GetCharNumber(char c) //NOTE: in C#.NET characters have default integer values corresponding to ASCII numbers. 
        {
            if('a' <= c && c <= 'z')
                return c - 'a';
            else if('A' <= c && c <= 'Z')
                return c - 'A';
            return -1;
        }
    }
}
