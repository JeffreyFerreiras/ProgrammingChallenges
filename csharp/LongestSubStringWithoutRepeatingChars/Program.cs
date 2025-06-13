using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubStringWithoutRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //optimal
        public static int Solution2(string s)
        {
            var seen = new Dictionary<char, int>();
            int max = 0, i = 0;

            while(i < s.Length)
            {
                if (seen.ContainsKey(s[i]))
                {
                    max = Math.Max(max, seen.Count());
                    i = seen[s[i]] + 1;
                    seen.Clear();
                }
                else
                {
                    seen[s[i]] = i;
                    i++;
                }
            }

            return Math.Max(max, seen.Count());
        }


        public static int Solution(string s)
        {
            var seen = new HashSet<char>(s);
            if (s.Count() == seen.Count()) return s.Count();

            string sub = string.Empty;
            seen.Clear();

            for (int i = 0; i < s.Count(); i++)
            {
                if (seen.Contains(s[i]))
                {
                    if (seen.Count() > sub.Count())
                    {
                        sub = new string(seen.ToArray());
                    }

                    seen.Clear();

                    int curr = i;

                    while (s[curr] != s[--i]) ;

                    i++;

                    seen.Add(s[i]);
                }
                else
                {
                    seen.Add(s[i]);
                }
            }

            if (seen.Count() > sub.Count())
            {
                sub = new string(seen.ToArray());
            }

            return sub.Count();
        }
    }
}
