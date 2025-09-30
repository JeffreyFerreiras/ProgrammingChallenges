using System;
using System.Diagnostics;

namespace LongestRepeatingCharacterReplacement;

// LeetCode 424: Longest Repeating Character Replacement
// Given a string s and an integer k, return the length of the longest substring containing the same letter after performing at most k replacements.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Longest Repeating Character Replacement");
        Console.WriteLine("========================================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Input: "ABAB", K: 2, Expected: 4),
            (Name: "Example 2", Input: "AABABBA", K: 1, Expected: 4),
            (Name: "Edge: Single Char", Input: "A", K: 0, Expected: 1),
            (Name: "Edge: No Replacements", Input: "ABC", K: 0, Expected: 1),
            (Name: "Uniform String", Input: new string('B', 10), K: 2, Expected: 10),
            (Name: "Long Convertible", Input: "ABCDEFGHIJKLMNOPQRSTUVWXYZ", K: 26, Expected: 26),
            (Name: "Mixed High Frequency", Input: "BAAABA", K: 2, Expected: 5)
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.Input, scenario.K, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, string input, int k, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.CharacterReplacement(input, k);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.CharacterReplacement)}");
        Console.WriteLine($"Input: s = \"{input}\", k = {k}");
        Console.WriteLine($"Result: {result}, Expected: {expected}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
