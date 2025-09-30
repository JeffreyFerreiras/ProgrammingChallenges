using System;
using System.Diagnostics;

namespace LongestSubstringWithoutRepeatingCharacters;

// LeetCode 3: Longest Substring Without Repeating Characters
// Given a string s, find the length of the longest substring without repeating characters.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Longest Substring Without Repeating Characters");
        Console.WriteLine("================================================\n");

        var solution = new Solution();
        const string longUnique = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var scenarios = new[]
        {
            (Name: "Example 1", Input: "abcabcbb", Expected: 3),
            (Name: "Example 2", Input: "bbbbb", Expected: 1),
            (Name: "Example 3", Input: "pwwkew", Expected: 3),
            (Name: "Edge: Empty", Input: string.Empty, Expected: 0),
            (Name: "Edge: Single Space", Input: " ", Expected: 1),
            (Name: "Long Unique", Input: longUnique, Expected: 52),
            (Name: "Mixed Repetition", Input: "dvdf", Expected: 3)
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.Input, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, string input, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.LengthOfLongestSubstring(input);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.LengthOfLongestSubstring)}");
        Console.WriteLine($"Input: \"{input}\"");
        Console.WriteLine($"Result: {result}, Expected: {expected}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
