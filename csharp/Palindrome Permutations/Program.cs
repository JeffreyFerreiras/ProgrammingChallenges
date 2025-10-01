using System;
namespace Palindrome_Permutations
{
    class Program
    {
        /*
        Given a string, write a function to check if it's a permutation of a palindrome.
        A palindrome is a word or phrase that is the same forwards and backwards.
        A permutation is a rearrangement of letters. The palindrome does not need to be limited to dictionary words.

            Example.
            Input: Tact Coa
            Output: True (taco cat, atco cta)
        */

        static void Main(string[] args)
        {
            bool x = PermutationOfPalindrome("Taco cat");
        }

        static bool PermutationOfPalindrome(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
                throw new NullReferenceException("phrase is empty");

            int[] table = BuildCharTable(phrase.Replace(" ", ""));
            return CheckMaxOneOdd(table);
        }

        static bool CheckMaxOneOdd(int[] table)
        {
            bool hasOdd = false;

            foreach (var i in table)
            {
                if (i % 2 == 1)
                {
                    if (hasOdd)
                        return false;

                    hasOdd = true;
                }
            }

            return true;
        }

        static int[] BuildCharTable(string phrase)
        {
            int[] table = new int[25];
            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                table[x]++;
            }
            return table;
        }

        static int GetCharNumber(char c) //NOTE: in C#.NET characters have default integer values corresponding to ASCII numbers. 
        {
            //return char.ToLower(c) - 'a';

            if ('a' <= c && c <= 'z')
                return c - 'a';
            else if ('A' <= c && c <= 'Z')
                return c - 'A';
            return -1;
        }
    }
}