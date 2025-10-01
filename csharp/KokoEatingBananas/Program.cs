using System.Diagnostics;

namespace KokoEatingBananas;

internal record TestScenario(string Name, int[] Piles, int Hours, int ExpectedSpeed);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.MinEatingSpeed);

        TestScenario[] scenarios =
        [
            new("Example 1", [3, 6, 7, 11], 8, 4),
            new("Example 2", [30, 11, 23, 4, 20], 5, 30),
            new("Example 3", [30, 11, 23, 4, 20], 6, 23),
            new("Single Gigantic Pile", [1_000_000_000], 1, 1_000_000_000),
            new("Many Small Piles", CreateRepeatedPiles(30, 5), 60, 3),
            new("Large Stress Test", CreateRampPiles(5_000, 1, 5), 5_000, 24_996),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
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
