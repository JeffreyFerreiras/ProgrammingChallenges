using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GroupAnagrams
{
    /*
     * Group Anagrams Problem
     * ----------------------
     * Given an array of strings strs, group the anagrams together.
     * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
     * typically using all the original letters exactly once.
     * 
     * Example 1:
     * Input: strs = ["eat","tea","tan","ate","nat","bat"]
     * Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
     * 
     * Example 2:
     * Input: strs = [""]
     * Output: [[""]]
     * 
     * Example 3:
     * Input: strs = ["a"]
     * Output: [["a"]]
     * 
     * Constraints:
     * 1 <= strs.length <= 10^4
     * 0 <= strs[i].length <= 100
     * strs[i] consists of lowercase English letters
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Group Anagrams Problem");
            Console.WriteLine("----------------------");

            // Test cases
            RunTest(["eat", "tea", "tan", "ate", "nat", "bat"], 
                    "[[\"bat\"],[\"nat\",\"tan\"],[\"ate\",\"eat\",\"tea\"]]");
            RunTest([""], 
                    "[[\"\"]]");
            RunTest(["a"], 
                    "[[\"a\"]]");
        }

        static void RunTest(string[] input, string expectedOutput)
        {
            Solution solution = new Solution();
            Stopwatch stopwatch = new Stopwatch();
            
            Console.WriteLine($"Testing input: [{string.Join(", ", input.Select(s => $"\"{s}\""))}]");
            
            stopwatch.Start();
            IList<IList<string>> result = solution.GroupAnagrams(input);
            stopwatch.Stop();
            
            string resultStr = ConvertResultToString(result);
            
            Console.WriteLine($"Method: GroupAnagrams");
            Console.WriteLine($"Time taken: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Result: `{resultStr}`");
            Console.WriteLine($"Expected: `{expectedOutput}`");
            Console.WriteLine();
        }

        static string ConvertResultToString(IList<IList<string>> result)
        {
            return "[" + string.Join(",", result.Select(group => 
                "[" + string.Join(",", group.Select(s => $"\"{s}\"")) + "]")) + "]";
        }
    }
}
