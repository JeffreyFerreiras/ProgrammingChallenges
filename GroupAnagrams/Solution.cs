using System;
using System.Collections.Generic;

namespace GroupAnagrams
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = [];
            Dictionary<string, List<string>> groups = [];

            foreach (var s in strs)
            {
                var sorted = ToSorted(s);
                if (!groups.TryAdd(sorted, new List<string>(26) { s }))
                {
                    groups[sorted].Add(s);
                }
            }

            foreach (var g in groups)
            {
                result.AddRange(g.Value);
            }

            return result;

            static string ToSorted(string val)
            {
                var chars = val.ToCharArray();
                Array.Sort(chars);
                return new string(chars);
            }
        }
    }
}
