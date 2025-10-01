using System;
using System.Collections.Generic;

namespace FirstUniqueCharacter
{
    /*
     Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.

Examples:

s = "leetcode"
return 0.

s = "loveleetcode"
return 2.
 

Note: You may assume the string contains only lowercase English letters.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstUniqChar("leetcode"));
            Console.WriteLine(FirstUniqChar("cc"));
            Console.WriteLine(FirstUniqChar("acaadcad"));
            Console.WriteLine(FirstUniqChar("dddccdbba"));


            //not optimal
            int FirstUniqChar(string s)
            {
                if (string.IsNullOrEmpty(s)) return -1;
                if (s.Length == 1) return 0;

                var seen = new HashSet<char>();

                for (int i = 0; i < s.Length - 1; i++)
                {
                    int j = i + 1;

                    if (seen.Contains(s[i])) continue;

                    while (j < s.Length && s[i] != s[j]) j++;

                    if (j == s.Length && s[i] != s[s.Length - 1])
                    {
                        return i;
                    }

                    if (j < s.Length)
                    {
                        seen.Add(s[j]);
                    }
                }

                if (!seen.Contains(s[s.Length - 1])) return s.Length - 1;

                return -1;
            }
        }

        //optimal
        public int FirstUniqChar(string s)
        {

            int[] letters = new int[26];

            foreach (char c in s)
            {
                letters[c - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (letters[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
