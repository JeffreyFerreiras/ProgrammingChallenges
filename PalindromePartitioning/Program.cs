using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
 * LeetCode Problem 131 - Palindrome Partitioning
 * 
 * Given a string s, partition s such that every substring of the partition is a palindrome.
 * Return all possible palindrome partitioning of s.
 * 
 * Example 1:
 * Input: s = "aab"
 * Output: [["a","a","b"],["aa","b"]]
 * 
 * Example 2:
 * Input: s = "a"
 * Output: [["a"]]
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Palindrome Partitioning");
        Console.WriteLine("======================");
        
        var solution = new Solution();
        var testCases = new Dictionary<string, IList<IList<string>>>
        {
            { "aab", new List<IList<string>> { new List<string> { "a", "a", "b" }, new List<string> { "aa", "b" } } },
            { "a", new List<IList<string>> { new List<string> { "a" } } },
            { "bb", new List<IList<string>> { new List<string> { "b", "b" }, new List<string> { "bb" } } }
        };
        
        foreach (var testCase in testCases)
        {
            var input = testCase.Key;
            var expected = testCase.Value;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var result = solution.Partition(input);
            
            stopwatch.Stop();
            
            Console.WriteLine($"Method: Partition");
            Console.WriteLine($"Input: \"{input}\"");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Result: {FormatResult(result)}");
            Console.WriteLine($"Expected: {FormatResult(expected)}");
            Console.WriteLine();
        }
    }
    
    private static string FormatResult(IList<IList<string>> result)
    {
        if (result == null) return "null";
        
        var outerList = new List<string>();
        foreach (var innerList in result)
        {
            outerList.Add("[" + string.Join(",", innerList.Select(s => $"\"{s}\"")) + "]");
        }
        
        return "[" + string.Join(",", outerList) + "]";
    }
}
