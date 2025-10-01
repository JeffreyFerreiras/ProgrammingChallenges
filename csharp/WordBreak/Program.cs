using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WordBreak;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Word Break");
        Console.WriteLine(new string('=', 10) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", S: "leetcode", Dict: new[] { "leet", "code" }, Expected: true),
            (Name: "Example 2", S: "applepenapple", Dict: ["apple", "pen"], Expected: true),
            (Name: "Example 3", S: "catsandog", Dict: ["cats", "dog", "sand", "and", "cat"], Expected: false),
            (Name: "Edge: Single", S: "a", Dict: ["a"], Expected: true),
            (Name: "Failure", S: "aaaaab", Dict: ["a", "aa", "aaa"], Expected: false),
            (Name: "Long String", S: string.Concat(Enumerable.Repeat("leet", 5)), Dict: ["leet", "code"], Expected: true)
        };

        foreach (var scenario in scenarios)
        {
            var wordDict = (IList<string>)scenario.Dict;
            var stopwatch = Stopwatch.StartNew();
            var result = solution.WordBreak(scenario.S, wordDict);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.WordBreak)}");
            Console.WriteLine($"Input: s = \"{scenario.S}\", wordDict = {FormatList(wordDict)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatList(IEnumerable<string> values) => "[" + string.Join(",", values.Select(v => $"\"{v}\"")) + "]";
}
