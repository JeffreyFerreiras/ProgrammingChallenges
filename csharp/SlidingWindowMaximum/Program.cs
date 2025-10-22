using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SlidingWindowMaximum;

// LeetCode 239: Sliding Window Maximum
// Return an array of maximum values for each contiguous subarray of length k.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Sliding Window Maximum");
        Console.WriteLine("=======================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (
                Name: "Example 1",
                Nums: new[] { 1, 3, -1, -3, 5, 3, 6, 7 },
                K: 3,
                Expected: new[] { 3, 3, 5, 5, 6, 7 }
            ),
            (Name: "Example 2", Nums: [1], K: 1, Expected: [1]),
            (Name: "Edge: Full Window", Nums: [9, 8, 7, 6, 5], K: 5, Expected: [9]),
            (Name: "Edge: Duplicates", Nums: [4, 4, 4, 4], K: 2, Expected: [4, 4, 4]),
            (Name: "Increasing Sequence", Nums: [1, 2, 3, 4, 5], K: 2, Expected: [2, 3, 4, 5]),
            (
                Name: "Long Example",
                Nums: [10, 6, 9, 8, 7, 5, 4, 3, 2, 1, 0, 12, 11, 13, 15],
                K: 4,
                Expected: [10, 9, 9, 8, 7, 5, 4, 3, 12, 12, 13, 15]
            ),
        };

        // Get all methods that return int[] and take int[] and int parameters
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m =>
                m.ReturnType == typeof(int[])
                && m.GetParameters().Length == 2
                && m.GetParameters()[0].ParameterType == typeof(int[])
                && m.GetParameters()[1].ParameterType == typeof(int)
            )
            .ToArray();

        // Track statistics for each method
        var methodStats = methods.ToDictionary(
            m => m.Name,
            m => new { PassedTests = 0, TotalElapsed = 0.0 }
        );

        // Run each scenario against all methods before moving to next scenario
        foreach (var scenario in scenarios)
        {
            Console.WriteLine($"Running Scenario: {scenario.Name}");
            Console.WriteLine(new string('=', 60));

            foreach (var method in methods)
            {
                var (passed, elapsed) = RunScenario(
                    solution,
                    method,
                    scenario.Name,
                    scenario.Nums,
                    scenario.K,
                    scenario.Expected
                );

                // Update method statistics
                var currentStats = methodStats[method.Name];
                methodStats[method.Name] = new
                {
                    PassedTests = currentStats.PassedTests + (passed ? 1 : 0),
                    TotalElapsed = currentStats.TotalElapsed + elapsed,
                };
            }
            Console.WriteLine();
        }

        // Print final statistics for each method
        Console.WriteLine("FINAL METHOD STATISTICS");
        Console.WriteLine(new string('=', 70));

        foreach (var method in methods)
        {
            var stats = methodStats[method.Name];
            int totalTests = scenarios.Length;

            Console.WriteLine($"Method: {method.Name}");
            Console.WriteLine(
                $"  Tests Passed: {stats.PassedTests}/{totalTests} ({(double)stats.PassedTests / totalTests * 100:F1}%)"
            );
            Console.WriteLine($"  Total Time: {stats.TotalElapsed:F4} ms");
            Console.WriteLine($"  Average Time: {stats.TotalElapsed / totalTests:F4} ms");
            Console.WriteLine(new string('-', 50));
        }
    }

    private static (bool passed, double elapsed) RunScenario(
        Solution solution,
        MethodInfo method,
        string name,
        int[] nums,
        int k,
        int[] expected
    )
    {
        var stopwatch = Stopwatch.StartNew();

        // Changed: use proper parameters array and safe cast to nullable int[]
        object? invokeResult = method.Invoke(solution, [nums, k]);
        int[]? result = invokeResult as int[];

        stopwatch.Stop();

        bool passed = result != null && expected != null && result.SequenceEqual(expected);
        string status = passed ? "✓" : "✗";

        Console.WriteLine($"Scenario: {name} {status}");
        Console.WriteLine($"Method: {method.Name}");
        Console.WriteLine($"Input: nums = {FormatArray(nums)}, k = {k}");
        Console.WriteLine($"Result: {FormatArray(result)}, Expected: {FormatArray(expected)}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));

        return (passed, stopwatch.Elapsed.TotalMilliseconds);
    }

    // Changed signature to accept nullable array because result may be null
    private static string FormatArray(int[]? values)
    {
        if (values is null)
        {
            return "null";
        }

        return "[" + string.Join(", ", values) + "]";
    }
}
