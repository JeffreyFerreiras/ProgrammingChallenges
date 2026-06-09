using System;
using System.Collections.Generic;

namespace CheckIfStringContainsAllBinaryCodeOfSize
{
    //medium
    public class Solution
    {
        public bool HasAllCodes2(string s, int k)
        {
            var lookup = new HashSet<string>();

            if (k == 1)
            {
                return s.Contains("0") && s.Contains("1");
            }

            for (int i = 0; i < (s.Length - k + 1); i++)
            {
                lookup.Add(s.Substring(i, k));
            }

            return Math.Pow(k, 2) == lookup.Count;
        }

        public bool HasAllCodes(string s, int k)
        {
            var maxNum = Math.Pow(k, 2);

            for (int i = 0; i <= maxNum; i++)
            {
                var bString = Convert.ToString(i, 2);
                int startIndex = (bString.Length - k) > 0 ? (bString.Length - k) : 0;

                string permutation = bString.Substring(startIndex);

                if (s.IndexOf(permutation) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}