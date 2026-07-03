// LeetCode 153 - Find Minimum in Rotated Sorted Array
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace FindMinimumInRotatedSortedArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { 3, 4, 5, 1, 2 }, 1),
                new Scenario("Example 2", new[] { 4, 5, 6, 7, 0, 1, 2 }, 0),
                new Scenario("Example 3", new[] { 11, 13, 15, 17 }, 11),
                new Scenario("Single Element", new[] { 1 }, 1),
                new Scenario("Two Elements Rotated", new[] { 2, 1 }, 1),
                new Scenario("Already Sorted", new[] { -9, -3, 0, 4, 7, 12 }, -9),
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
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.Numbers }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Numbers, int Expected);
    }
}

    private static int[] GenerateRotatedArray(int length, int pivot)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i - (length / 2);
        }

        pivot %= length;
        if (pivot < 0)
        {
            pivot += length;
        }

        int[] rotated = new int[length];
        int index = 0;
        for (int i = pivot; i < length; i++, index++)
        {
            rotated[index] = numbers[i];
        }
        for (int i = 0; i < pivot; i++, index++)
        {
            rotated[index] = numbers[i];
        }

        return rotated;
    }

    private static int GetMinimumValue(int[] numbers)
    {
        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Expected: {scenario.ExpectedMinimum}");
        Console.WriteLine($"Array Length: {scenario.Numbers.Length}");
        Console.WriteLine($"Array Preview: {FormatArrayPreview(scenario.Numbers)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int result = solution.FindMin(scenario.Numbers);
            resultDisplay = result.ToString();
        }
        catch (NotImplementedException ex)
        {
            resultDisplay = $"Not Implemented ({ex.Message})";
        }
        catch (Exception ex)
        {
            resultDisplay = $"Error ({ex.GetType().Name}: {ex.Message})";
        }
        finally
        {
            stopwatch.Stop();
        }

        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Result: {resultDisplay}");
        Console.WriteLine();
    }

    private static string FormatArrayPreview(int[] numbers)
    {
        const int previewCount = 12;
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
