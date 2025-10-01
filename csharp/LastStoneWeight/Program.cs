using System.Diagnostics;

namespace LastStoneWeight;

internal record TestScenario(string Name, int[] Stones, int Expected);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.LastStoneWeight);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                [2, 7, 4, 1, 8, 1],
                1
            ),
            new(
                "Single Stone",
                [1],
                1
            ),
            new(
                "Even Smash",
                [9, 3, 2, 10],
                0
            ),
            new(
                "All Equal",
                Enumerable.Repeat(5, 6).ToArray(),
                0
            ),
            new(
                "Large Input",
                GenerateDescendingSequence(100_000),
                1
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static int[] GenerateDescendingSequence(int length)
    {
        int[] stones = new int[length];
        for (int i = 0; i < length; i++)
        {
            stones[i] = length - i;
        }
        return stones;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Stones: {FormatArrayPreview(scenario.Stones)}");
        Console.WriteLine($"Expected: {scenario.Expected}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int result = solution.LastStoneWeight((int[])scenario.Stones.Clone());
            stopwatch.Stop();
            resultDisplay = result.ToString();
        }
        catch (NotImplementedException ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Not Implemented ({ex.Message})";
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Error ({ex.GetType().Name}: {ex.Message})";
        }

        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Result: {resultDisplay}");
        Console.WriteLine();
    }

    private static string FormatArrayPreview(int[] numbers)
    {
        const int previewCount = 12;
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
