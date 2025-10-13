using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
            // Use reflection to get all public methods that return int and take a string parameter
            var solutionType = typeof(Solution);
            var methods = solutionType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType == typeof(int) && 
                           m.GetParameters().Length == 1 && 
                           m.GetParameters()[0].ParameterType == typeof(string))
                .ToArray();

            foreach (var method in methods)
            {
                RunScenarioWithReflection(solution, method, scenario.Name, scenario.Input, scenario.Expected);
            }
            
            if (methods.Length > 1)
                Console.WriteLine(); // Add spacing between scenario groups when multiple methods
        }

        // Summary of all public methods tested
        var allMethods = typeof(Solution).GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.ReturnType == typeof(int) && 
                       m.GetParameters().Length == 1 && 
                       m.GetParameters()[0].ParameterType == typeof(string))
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

    private static void RunScenarioWithReflection(Solution solution, MethodInfo method, string name, string input, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = (int)method.Invoke(solution, new object[] { input })!;
        stopwatch.Stop();

        var isCorrect = result == expected;
        var checkmark = isCorrect ? "✓" : "✗";
        var statusColor = isCorrect ? "\x1b[32m" : "\x1b[31m"; // Green for pass, Red for fail
        var resetColor = "\x1b[0m";

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {method.Name}");
        Console.WriteLine($"Input: \"{input}\"");
        Console.WriteLine($"Result: {result}, Expected: {expected} {statusColor}{checkmark}{resetColor}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
