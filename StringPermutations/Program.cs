using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutations
{
    class Program
    {
        /*
            Given a string, print all permutations.
            NOTE: Never ever do something this inneficient in real life.
                Printing permuations is an O(n!) operation.
        */

        private static int _count = 0;
        static void Main(string[] args)
        {
            //Permutation("caturday");
            Permute("caturday");
            //Permutation("The quick brown fox jumps over the lazy dog");
            Console.Read();
        }
        static void Permutation(string str)
        {   // SOLUTION
            Permutation(str, "");
        }

        static void Permutation(string str, string currentString)
        {
            if(str.Length == 0)
            {
                Console.WriteLine($"{_count++}: {currentString}");
            }
            else
            {
                for(int i = 0; i < str.Length; i++)
                {
                    string remainingChars = str.Substring(0 , i) + str.Substring(i + 1);
                    Permutation(remainingChars, currentString + str[i]);
                }
            }
        }

        
        static void Permute(string input, string permutation = "")
        {
            if(input.Length == 0)
            {
                System.Console.WriteLine(permutation);
            }
            else
            {
                for(int i = 0; i < input.Length; i++ )
                {
                    Permute(input[0..i] + input[(i + 1)..], permutation + input[i]);
                }
            }
        }
    }
}
