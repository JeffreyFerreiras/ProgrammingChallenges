using System;
using System.Diagnostics;

namespace MinimumWindowSubstring;

// LeetCode 76: Minimum Window Substring
// Return the smallest substring of s that contains every character of t (including duplicates).
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Minimum Window Substring");
        Console.WriteLine("========================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", S: "ADOBECODEBANC", T: "ABC", Expected: "BANC"),
            (Name: "Example 2", S: "a", T: "a", Expected: "a"),
            (Name: "Example 3", S: "a", T: "aa", Expected: string.Empty),
            (Name: "Edge: Exact Match", S: "aa", T: "aa", Expected: "aa"),
            (Name: "Impossible", S: "a", T: "b", Expected: string.Empty),
            (Name: "Repeated Characters", S: "bbaa", T: "aba", Expected: "baa"),
            (Name: "Long Example", S: "NNNNNABCOOOABCNNNN", T: "ABC", Expected: "ABC"),
            (Name: "Another Example", S: "abcdebdde", T: "bde", Expected: "bdde")
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.S, scenario.T, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, string s, string t, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.MinWindow(s, t);
        stopwatch.Stop();

        string FormatDisplay(string value) => value is null ? "null" : $"\"{value}\"";

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.MinWindow)}");
        Console.WriteLine($"Input: s = \"{s}\", t = \"{t}\"");
        Console.WriteLine($"Result: {FormatDisplay(result)}, Expected: {FormatDisplay(expected)}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
