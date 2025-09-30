using System.Diagnostics;

namespace BinarySearch;

internal record TestScenario(string Name, int[] Numbers, int Target, int ExpectedIndex);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.Search);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[] { -1, 0, 3, 5, 9, 12 },
                9,
                4
            ),
            new(
                "Target Missing",
                new[] { -1, 0, 3, 5, 9, 12 },
                2,
                -1
            ),
            new(
                "Single Element Hit",
                new[] { 5 },
                5,
                0
            ),
            new(
                "Single Element Miss",
                new[] { 5 },
                -5,
                -1
            ),
            new(
                "Negative Numbers",
                new[] { -15, -9, -4, 0, 12, 18, 27 },
                -4,
                2
            ),
            new(
                "Large Ascending Array",
                GenerateSequentialArray(200_001, -100_000),
                54_321,
                154_321
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static int[] GenerateSequentialArray(int length, int start)
    {
        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = start + i;
        }
        return result;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Target: {scenario.Target}");
        Console.WriteLine($"Expected: {scenario.ExpectedIndex}");
        Console.WriteLine($"Array Length: {scenario.Numbers.Length}");
        Console.WriteLine($"Array Preview: {FormatArrayPreview(scenario.Numbers)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int result = solution.Search(scenario.Numbers, scenario.Target);
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
