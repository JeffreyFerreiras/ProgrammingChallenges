using System.Diagnostics;

namespace AnagramSubstring
{
    /*
     * Given two strings a and b, find whether any anagram of string a is a sub-string of string b. For eg: 
     * if a = xyz and b = afdgzyxksldfm then the program should return true.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            string a = "xyz";
            string b = "afdgzyxksldfm";

            bool isAnagramSubstring = IsAnagramSubstring_BruteForce(a, b);
            sw.Stop();

            long tics = sw.ElapsedTicks;

            sw.Restart();
            bool isAnagramSubstring2 = IsAnagramSubstring_Optimized(a, b);
            sw.Stop();
            long tics2 = sw.ElapsedTicks;
        }

        private static bool IsAnagramSubstring_Optimized(string a, string b)
        {
            var btable = GetCharTable(b);

            foreach (char c in a)
            {
                if (btable[c - 'a'] > 0)
                {
                    btable[c - 'a']--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        static int[] GetCharTable(string source)
        {
            var table = new int[26];

            foreach (char c in source)
            {
                int index = (c - 'a');
                table[index]++;
            }

            return table;
        }

        private static bool IsAnagramSubstring_BruteForce(string a, string b) //O(A x B) BruteForce
        {
            foreach (char c in a)
            {
                if (!b.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
