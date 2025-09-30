using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindAllAnagramsInAString;

// LeetCode 438: Find All Anagrams in a String
// Return all starting indices of p's anagrams inside s.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Find All Anagrams in a String");
        Console.WriteLine("==============================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", S: "cbaebabacd", P: "abc", Expected: (IList<int>)new List<int> { 0, 6 }),
            (Name: "Example 2", S: "abab", P: "ab", Expected: (IList<int>)new List<int> { 0, 1, 2 }),
            (Name: "Edge: No Match", S: "a", P: "b", Expected: (IList<int>)new List<int>()),
            (Name: "Edge: Identical", S: "a", P: "a", Expected: (IList<int>)new List<int> { 0 }),
            (Name: "Repeated Characters", S: "baa", P: "aa", Expected: (IList<int>)new List<int> { 1 }),
            (Name: "Long Example", S: "aaaaaaaaabaaaaaaaaa", P: "aaab", Expected: (IList<int>)new List<int> { 6, 7, 8, 9 }),
            (Name: "No Match Extended", S: "abcdefg", P: "hij", Expected: (IList<int>)new List<int>())
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.S, scenario.P, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, string s, string p, IList<int> expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.FindAnagrams(s, p);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.FindAnagrams)}");
        Console.WriteLine($"Input: s = \"{s}\", p = \"{p}\"");
        Console.WriteLine($"Result: {FormatList(result)}, Expected: {FormatList(expected)}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }

    private static string FormatList(IList<int> values)
    {
        if (values is null)
        {
            return "null";
        }

        return "[" + string.Join(", ", values) + "]";
    }
}
