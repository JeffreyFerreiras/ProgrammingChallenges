using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Palindrome_Permutations
{
    class Program
    {
        /**
        Given a string, write a function to check if it's a permutation of a palindrome.
        A palindrome is a word or phrase that is the same forwards and backwards.
        A permutation is a rearrangement of letters. The palindrome does not need to be limited to dictionary words.

            Example.
            Input: Tact Coa
            Output: True (taco cat, atco cta)
        */

        /*
        Notes:
              This solution may not seem like the most elegant, but it's the best speed and space wise. 
        */
        static void Main(string[] args)
        {
            bool x = isPermutationOfPalindrome("Taco cat");
        }
        static bool isPermutationOfPalindrome(string phrase) //SOLUTION - Much more efficient than getting every permutation of the string. That would be O(n!) runtime.
        {
            if(string.IsNullOrEmpty(phrase))
                throw new NullReferenceException("Input string is empty");

            int [] table = BuildCharTable(phrase.Replace(" ",""));
            return CheckMaxOneOdd(table);
        }
        static bool CheckMaxOneOdd(int[] table)
        {
            bool hasOdd = false;
            foreach(var i in table)
            {
                if(i % 2 == 1)
                {
                    if(hasOdd)
                        return false;
                    hasOdd = true;
                }
            }
            return true;
        }
        static int[] BuildCharTable(string phrase)
        {
            int [] table = new int[25];
            foreach(char c in phrase)
            {
                int x = GetCharNumber(c);
                table[x]++;
            }
            return table;          
        }
        static int GetCharNumber(char character) //NOTE: in C#.NET characters have default integer values corresponding to ASCII numbers. 
        {
            if('a' <= character && character <= 'z')
                return character - 'a';
            else if('A' <= character && character <= 'Z')
                return character - 'A';
            return -1;
        }
    }
}