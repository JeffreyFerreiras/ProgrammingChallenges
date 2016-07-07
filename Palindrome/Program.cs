using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        /* Check if a string is a Palindrome */
        static void Main(string[] args)
        {
            //TEST CODE
            bool result1 = IsPalindrome("Malayalam");
            bool result2 = IsPalindrome("Racecar");
            bool result3 = IsPalindrome("Not a palindrome");
            //END TEST CODE
        }
        static bool IsPalindrome(string phrase)
        {
            //SOLUTION
            string lowerCasePhrase = phrase.ToLower();
            for(int i = 0, j = lowerCasePhrase.Length - 1; i != j; i++, j--)
            {
                if(lowerCasePhrase[i] != lowerCasePhrase[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
