using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
            (Name: "Another Example", S: "abcdebdde", T: "bde", Expected: "deb"),
            (Name: "Test Case", S: "acbbaca", T: "aba", Expected: "baca"),
            (Name: "Edge: babb", S: "babb", T: "baba", Expected: string.Empty),
            (Name: "Edge: All Same Character", S: "aaaa", T: "aa", Expected: "aa"),
            (Name: "Edge: Window at End", S: "xyzzabc", T: "abc", Expected: "abc"),
            (Name: "Edge: Window at Start", S: "abcxyz", T: "abc", Expected: "abc"),
            (Name: "Edge: Multiple Valid Windows", S: "abcdefabc", T: "abc", Expected: "abc"),
            (Name: "Edge: Single Char Repeated", S: "aaaaaaa", T: "a", Expected: "a"),
            (Name: "Edge: Interleaved", S: "cabwefgewcwaefgcf", T: "cae", Expected: "cwae"),
            (Name: "Edge: T Longer Than Match", S: "ab", T: "a", Expected: "a"),
            (Name: "Edge: Entire String", S: "abc", T: "abc", Expected: "abc")
        };

        // Use reflection to find all public methods that match the signature
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(m => m.ReturnType == typeof(string) && 
                   m.GetParameters().Length == 2 &&
                   m.GetParameters()[0].ParameterType == typeof(string) &&
                   m.GetParameters()[1].ParameterType == typeof(string))
            .ToList();

        if (methods.Count == 0)
        {
            Console.WriteLine("No matching methods found in Solution class.");
            return;
        }

        foreach (var method in methods)
        {
            Console.WriteLine($"\n{'═',80}\n");
            Console.WriteLine($"Testing Method: {method.Name}");
            Console.WriteLine($"{'═',80}\n");

            int passedCount = 0;
            int totalCount = scenarios.Length;

            foreach (var scenario in scenarios)
            {
                bool passed = RunScenario(solution, method, scenario.Name, scenario.S, scenario.T, scenario.Expected);
                if (passed) passedCount++;
            }

            Console.WriteLine($"\n{'─',80}");
            Console.WriteLine($"Summary: {passedCount}/{totalCount} test cases passed");
            Console.WriteLine($"{'─',80}");
        }
    }

    private static bool RunScenario(Solution solution, MethodInfo method, string name, string s, string t, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = (string?)method.Invoke(solution, new object[] { s, t }) ?? string.Empty;
        stopwatch.Stop();

        bool passed = result == expected;
        string statusIcon = passed ? "✓" : "✗";

        string FormatDisplay(string value) => string.IsNullOrEmpty(value) && value != expected ? "null" : $"\"{value}\"";

        Console.WriteLine($"{statusIcon} Scenario: {name}");
        Console.WriteLine($"  Method: {method.Name}");
        Console.WriteLine($"  Input: s = \"{s}\", t = \"{t}\"");
        Console.WriteLine($"  Result: {FormatDisplay(result)}, Expected: {FormatDisplay(expected)}");
        Console.WriteLine($"  Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));

        return passed;
    }
}
