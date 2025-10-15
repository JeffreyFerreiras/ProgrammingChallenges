using System;
using System.Diagnostics;
using System.Reflection;

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

        // Get all public methods that match the signature: bool MethodName(string, string)
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.ReturnType == typeof(bool) &&
                       m.GetParameters().Length == 2 &&
                       m.GetParameters().All(p => p.ParameterType == typeof(string)))
            .ToList();

        Console.WriteLine($"Testing {methods.Count} method(s):\n");

        var scenarios = new[]
        {
            (Name: "Example 1", S1: "ab", S2: "eidbaooo", Expected: true),
            (Name: "Example 2", S1: "ab", S2: "eidboaoo", Expected: false),
            (Name: "Edge: Identical Single Char", S1: "a", S2: "a", Expected: true),
            (Name: "Edge: s1 Longer", S1: "abcd", S2: "abc", Expected: false),
            (Name: "Edge: Empty s2", S1: "a", S2: "", Expected: false),
            (Name: "Edge: s1 equals s2", S1: "abc", S2: "abc", Expected: true),
            (Name: "Edge: Permutation at Start", S1: "abc", S2: "bacdefg", Expected: true),
            (Name: "Edge: Permutation at End", S1: "abc", S2: "defgcba", Expected: true),
            (Name: "Edge: Permutation in Middle", S1: "abc", S2: "defcbaghij", Expected: true),
            (Name: "Repeated Characters", S1: "aabc", S2: "bbacaabca", Expected: true),
            (Name: "All Same Characters", S1: "aaa", S2: "bbbaaaccc", Expected: true),
            (Name: "All Same Chars - No Match", S1: "aaa", S2: "bbbaacc", Expected: false),
            (Name: "Long Example", S1: "xyz", S2: "abcdefghijklmnopqrxyz", Expected: true),
            (Name: "Long s1 - No Match", S1: "abcdefgh", S2: "zyxwvutsrqponmlkji", Expected: false),
            (Name: "No Match", S1: "abc", S2: "defghi", Expected: false),
            (Name: "Almost Permutation", S1: "abc", S2: "aabbc", Expected: false),
            (Name: "Multiple Permutations", S1: "ab", S2: "ababab", Expected: true),
            (Name: "Case Sensitive", S1: "Ab", S2: "ba", Expected: false),
            (Name: "Duplicate Heavy", S1: "aab", S2: "cbabadcbbabbcbabaabccbabc", Expected: true),
            (Name: "Single Char - No Match", S1: "z", S2: "abcdefghijklmnopqrstuvwxy", Expected: false)
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, methods, scenario.Name, scenario.S1, scenario.S2, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, List<MethodInfo> methods, string name, string s1, string s2, bool expected)
    {
        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Input: s1 = \"{s1}\", s2 = \"{s2}\"");
        Console.WriteLine($"Expected: {expected}");
        Console.WriteLine();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = (bool)method.Invoke(solution, new object[] { s1, s2 })!;
            stopwatch.Stop();

            bool passed = result == expected;
            string status = passed ? "✓" : "✗";

            Console.WriteLine($"  {status} {method.Name,-30} Result: {result,-5} Time: {stopwatch.Elapsed.TotalMilliseconds,8:F4} ms");
        }

        Console.WriteLine(new string('-', 80));
        Console.WriteLine();
    }
}
