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
            NOTE: Never ever do something this inneficient in real life. Printing permuations is an O(n!) operation.
        */
        static void Main(string[] args)
        {
            Permutation("caturday");
            Console.Read();
        }
        static void Permutation(string str)
        {
            Permutation(str, "");
        }
        static void Permutation(string str, string currentString)
        {
            if(str.Length == 0)
                Console.WriteLine(currentString);
            else
                for(int i = 0; i < str.Length; i++)
                {
                    string remainingChars = str.Substring(0 , i) + str.Substring(i + 1);
                    Permutation(remainingChars, currentString + str[i]);
                }
        }
    }
}
