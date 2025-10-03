using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace MedianOfTwoSortedArrays;

internal record TestScenario(
    string Name,
    int[] FirstArray,
    int[] SecondArray,
    double ExpectedMedian
);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int[] largeA = GenerateSequentialArray(0, 100_000);
        int[] largeB = GenerateSequentialArray(100_000, 100_000);

        TestScenario[] scenarios =
        [
            new("Example 1", [1, 3], [2], 2.0),
            new("Example 2", [1, 2], [3, 4], 2.5),
            new("Zero Arrays", [0, 0], [0, 0], 0.0),
            new("Single Non-Empty", Array.Empty<int>(), [2], 2.0),
            new("Different Lengths", [1, 3, 8, 9, 15], [7, 11, 18, 19, 21, 25], 11.0),
            new("Unbalanced Lengths", [1, 2, 3, 4, 5], [6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17], 9.0),
            new("Large Balanced Arrays", largeA, largeB, 99_999.5),
        ];

        // Get all public methods that return double and take two int[] parameters
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.ReturnType == typeof(double) &&
                       m.GetParameters().Length == 2 &&
                       m.GetParameters().All(p => p.ParameterType == typeof(int[])))
            .ToArray();

        foreach (var method in methods)
        {
            Console.WriteLine($"========== Testing Method: {method.Name} ==========");
            Console.WriteLine();

            foreach (TestScenario scenario in scenarios)
            {
                RunScenario(solution, method, scenario);
            }

            Console.WriteLine();
        }
    }

    private static int[] GenerateSequentialArray(int start, int count)
    {
        int[] result = new int[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = start + i;
        }
        return result;
    }

    private static void RunScenario(Solution solution, MethodInfo method, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {method.Name}");
        Console.WriteLine(
            $"Expected Median: {scenario.ExpectedMedian.ToString("F4", CultureInfo.InvariantCulture)}"
        );
        Console.WriteLine($"First Array Length: {scenario.FirstArray.Length}");
        Console.WriteLine($"Second Array Length: {scenario.SecondArray.Length}");
        Console.WriteLine($"First Array Preview: {FormatArrayPreview(scenario.FirstArray)}");
        Console.WriteLine($"Second Array Preview: {FormatArrayPreview(scenario.SecondArray)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            double result = (double)method.Invoke(solution, [scenario.FirstArray, scenario.SecondArray])!;
            resultDisplay = result.ToString("F4", CultureInfo.InvariantCulture);
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
        const int previewCount = 8;
        if (numbers.Length == 0)
        {
            return "[]";
        }

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
