using System;
using System.Collections.Generic;

namespace AlmostPalindrome
{
    class Program
    {

        /*
1. Problem: string with lowercase, almost palindrom.
Given a string S consisting of lowercase English characters determine if you can make it a palindrome by removing at most 1 character.
*/

// aba - True, abacc - False, abba - True

/* 1. (palindrom, candidate)

// aba , acba;
// */


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tests = new Dictionary<string, bool>
            {
                { "abca", true },
                { "aabbcs", false }
            };

            foreach (var item in tests)
            {
                PrintExpected(IsAlmostPalindrom(item.Key), item.Value);
            }

            static void PrintExpected(bool actual, bool expected)
            {
                Console.WriteLine($"actual: {actual}\tresult: {expected}");
            }

            Console.ReadLine();

        }

        private static bool IsAlmostPalindrom(string candidate)
        {

            for (int i = 0, j = candidate.Length - 1; i < j; i++, j--)
            {

                bool isMatch = candidate[i] == candidate[j];

                if (!isMatch)
                {
                    if (candidate[i] == candidate[j - 1])
                    {
                        j--;
                    }
                    else if (candidate[i + 1] == candidate[j])
                    {
                        i++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
