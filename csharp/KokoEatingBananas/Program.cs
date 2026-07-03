// LeetCode 875 - Koko Eating Bananas
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace KokoEatingBananas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { 3, 6, 7, 11 }, 8, 4),
                new Scenario("Example 2", new[] { 30, 11, 23, 4, 20 }, 5, 30),
                new Scenario("Example 3", new[] { 30, 11, 23, 4, 20 }, 6, 23),
                new Scenario("Single Gigantic Pile", new[] { 1_000_000_000 }, 1, 1_000_000_000),
                new Scenario("Many Small Piles", Enumerable.Repeat(5, 30).ToArray(), 60, 3),
            };

            foreach (var scenario in scenarios)
                RunScenario(scenario);
            Console.WriteLine();
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            var solution = new Solution();
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 2)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
                .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.Piles, scenario.Hours }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Piles, int Hours, int Expected);
    }
}

    private static int[] CreateRepeatedPiles(int pileCount, int pileSize)
    {
        int[] piles = new int[pileCount];
        for (int i = 0; i < pileCount; i++)
        {
            piles[i] = pileSize;
        }
        return piles;
    }

    private static int[] CreateRampPiles(int pileCount, int start, int step)
    {
        int[] piles = new int[pileCount];
        int current = start;
        for (int i = 0; i < pileCount; i++)
        {
            piles[i] = current;
            current += step;
        }
        return piles;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Hours: {scenario.Hours}");
        Console.WriteLine($"Expected Speed: {scenario.ExpectedSpeed}");
        Console.WriteLine($"Pile Count: {scenario.Piles.Length}");
        Console.WriteLine($"Piles Preview: {FormatArrayPreview(scenario.Piles)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;
        bool testPassed = false;
        bool hasError = false;

        try
        {
            int result = solution.MinEatingSpeed(scenario.Piles, scenario.Hours);
            resultDisplay = result.ToString();
            testPassed = result == scenario.ExpectedSpeed;
        }
        catch (NotImplementedException ex)
        {
            resultDisplay = $"Not Implemented ({ex.Message})";
            hasError = true;
        }
        catch (Exception ex)
        {
            resultDisplay = $"Error ({ex.GetType().Name}: {ex.Message})";
            hasError = true;
        }
        finally
        {
            stopwatch.Stop();
        }

        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Result: {resultDisplay}");

        string statusIcon = hasError ? "✗" : (testPassed ? "✓" : "✗");
        string statusText = hasError ? "ERROR" : (testPassed ? "PASS" : "FAIL");
        Console.WriteLine($"Status: {statusIcon} {statusText}");
        Console.WriteLine();
    }

    private static string FormatArrayPreview(int[] numbers)
    {
        const int previewCount = 10;
        if (numbers.Length <= previewCount)
        {
            return $"[{string.Join(",", numbers)}]";
        }

        string[] preview = new string[previewCount + 1];
        for (int i = 0; i < previewCount; i++)
        {
            preview[i] = numbers[i].ToString();
        }
        preview[previewCount] = $"..., {numbers[^1]}";
        return $"[{string.Join(",", preview)}]";
    }
}
