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
            .OrderBy(m => m.Name)
            .ToList();

        if (methods.Count == 0)
        {
            Console.WriteLine("No matching methods found in Solution class.");
            return;
        }

        // Display header
        Console.WriteLine($"{"Scenario",-25} {"Method",-30} {"Result",-10} {"Expected",-10} {"Status",-8} {"Time (ms)",-12}");
        Console.WriteLine(new string('═', 100));

        // Track overall results
        var methodResults = methods.ToDictionary(m => m.Name, m => new { Passed = 0, Total = 0 });

        foreach (var scenario in scenarios)
        {
            Console.WriteLine($"\n{scenario.Name}:");
            Console.WriteLine(new string('-', 100));

            foreach (var method in methods)
            {
                var result = RunScenarioCompact(solution, method, scenario.S, scenario.T, scenario.Expected);
                
                // Update results
                var stats = methodResults[method.Name];
                methodResults[method.Name] = new { Passed = stats.Passed + (result.Passed ? 1 : 0), Total = stats.Total + 1 };

                Console.WriteLine($"{"",25} {method.Name,-30} {FormatResult(result.Result),-10} {FormatResult(scenario.Expected),-10} {(result.Passed ? "✓" : "✗"),-8} {result.ElapsedMs,-12:F4}");
            }
        }

        // Display summary
        Console.WriteLine($"\n{new string('═', 100)}");
        Console.WriteLine("SUMMARY:");
        Console.WriteLine($"{"Method",-30} {"Passed/Total",-15} {"Success Rate",-15}");
        Console.WriteLine(new string('-', 60));
        
        foreach (var method in methods)
        {
            var stats = methodResults[method.Name];
            double successRate = stats.Total > 0 ? (double)stats.Passed / stats.Total * 100 : 0;
            Console.WriteLine($"{method.Name,-30} {stats.Passed}/{stats.Total,-15} {successRate,-15:F1}%");
        }
    }

    private static (bool Passed, string Result, double ElapsedMs) RunScenarioCompact(Solution solution, MethodInfo method, string s, string t, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = (string?)method.Invoke(solution, new object[] { s, t }) ?? string.Empty;
        stopwatch.Stop();

        bool passed = result == expected;
        return (passed, result, stopwatch.Elapsed.TotalMilliseconds);
    }

    private static string FormatResult(string value)
    {
        return string.IsNullOrEmpty(value) ? "\"\"" : $"\"{value}\"";
    }
}
