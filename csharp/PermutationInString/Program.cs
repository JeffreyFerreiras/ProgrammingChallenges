using System;
using System.Diagnostics;

namespace PermutationInString;

// LeetCode 567: Permutation in String
// Return true if s2 contains any permutation of s1 as a substring.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Permutation in String");
        Console.WriteLine("======================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", S1: "ab", S2: "eidbaooo", Expected: true),
            (Name: "Example 2", S1: "ab", S2: "eidboaoo", Expected: false),
            (Name: "Edge: Identical Single Char", S1: "a", S2: "a", Expected: true),
            (Name: "Edge: s1 Longer", S1: "abcd", S2: "abc", Expected: false),
            (Name: "Repeated Characters", S1: "aabc", S2: "bbacaabca", Expected: true),
            (Name: "Long Example", S1: "xyz", S2: "abcdefghijklmnopqrxyz", Expected: true),
            (Name: "No Match", S1: "abc", S2: "defghi", Expected: false)
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.S1, scenario.S2, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, string s1, string s2, bool expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.CheckInclusion(s1, s2);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.CheckInclusion)}");
        Console.WriteLine($"Input: s1 = \"{s1}\", s2 = \"{s2}\"");
        Console.WriteLine($"Result: {result}, Expected: {expected}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
