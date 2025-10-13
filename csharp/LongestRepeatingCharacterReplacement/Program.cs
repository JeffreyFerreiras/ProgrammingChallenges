using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
            (Name: "ABBB Test", Input: "ABBB", K: 1, Expected: 4),
            (Name: "Edge: Single Char", Input: "A", K: 0, Expected: 1),
            (Name: "Edge: No Replacements", Input: "ABC", K: 0, Expected: 1),
            (Name: "Uniform String", Input: new string('B', 10), K: 2, Expected: 10),
            (Name: "Long Convertible", Input: "ABCDEFGHIJKLMNOPQRSTUVWXYZ", K: 26, Expected: 26),
            (Name: "Mixed High Frequency", Input: "BAAABA", K: 2, Expected: 5)
        };

        foreach (var scenario in scenarios)
        {
            // Use reflection to get all public methods that return int and take string and int parameters
            var solutionType = typeof(Solution);
            var methods = solutionType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType == typeof(int) && 
                           m.GetParameters().Length == 2 && 
                           m.GetParameters()[0].ParameterType == typeof(string) &&
                           m.GetParameters()[1].ParameterType == typeof(int))
                .ToArray();

            Console.WriteLine($"=== {scenario.Name} ===");
            Console.WriteLine($"Input: s = \"{scenario.Input}\", k = {scenario.K}");
            Console.WriteLine($"Expected: {scenario.Expected}");
            Console.WriteLine();

            foreach (var method in methods)
            {
                RunScenarioWithReflection(solution, method, scenario.Name, scenario.Input, scenario.K, scenario.Expected);
            }
            
            Console.WriteLine(); // Add spacing between scenario groups
        }

        // Summary of all public methods tested
        var allMethods = typeof(Solution).GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.ReturnType == typeof(int) && 
                       m.GetParameters().Length == 2 && 
                       m.GetParameters()[0].ParameterType == typeof(string) &&
                       m.GetParameters()[1].ParameterType == typeof(int))
            .ToArray();

        Console.WriteLine("\nSUMMARY");
        Console.WriteLine("=======");
        Console.WriteLine("Public methods discovered and tested:");
        foreach (var method in allMethods)
        {
            Console.WriteLine($"• {method.Name}");
        }
        Console.WriteLine($"\nTotal methods found: {allMethods.Length}");
        Console.WriteLine($"Total test scenarios per method: {scenarios.Length}");
    }

    private static void RunScenarioWithReflection(Solution solution, MethodInfo method, string name, string input, int k, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = (int)method.Invoke(solution, new object[] { input, k })!;
        stopwatch.Stop();

        var isCorrect = result == expected;
        var checkmark = isCorrect ? "✓" : "✗";
        var statusColor = isCorrect ? "\x1b[32m" : "\x1b[31m"; // Green for pass, Red for fail
        var resetColor = "\x1b[0m";

        Console.WriteLine($"  {method.Name}:");
        Console.WriteLine($"    Result: {result} {statusColor}{checkmark}{resetColor}");
        Console.WriteLine($"    Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
    }
}
