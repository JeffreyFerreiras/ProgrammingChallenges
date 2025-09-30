using System.Diagnostics;

namespace KthLargestElementInAnArray;

internal record TestScenario(string Name, int[] Numbers, int K, int Expected);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.FindKthLargest);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[] { 3, 2, 1, 5, 6, 4 },
                2,
                5
            ),
            new(
                "Example 2",
                new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 },
                4,
                4
            ),
            new(
                "All Identical",
                Enumerable.Repeat(7, 8).ToArray(),
                3,
                7
            ),
            new(
                "Large Ascending",
                GenerateAscendingSequence(200_000),
                1,
                200_000
            ),
            new(
                "Large Descending",
                GenerateDescendingSequence(200_000),
                200_000,
                1
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static int[] GenerateAscendingSequence(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    private static int[] GenerateDescendingSequence(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = length - i;
        }
        return numbers;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"k: {scenario.K}");
        Console.WriteLine($"Array Length: {scenario.Numbers.Length}");
        Console.WriteLine($"Expected: {scenario.Expected}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int result = solution.FindKthLargest((int[])scenario.Numbers.Clone(), scenario.K);
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
}
