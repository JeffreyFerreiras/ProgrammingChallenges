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

        static void Permutation(string a, string b)
        {
            if(a.Length == 0)
                Console.WriteLine(b);
            else
                for(int i = 0; i < a.Length; i++)
                {
                    string rem = a.Substring(0 , i) + a.Substring(i + 1);
                    Permutation(rem, b + a[i]);
                }
        }
    }
}
