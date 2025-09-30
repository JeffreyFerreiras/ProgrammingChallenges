using System.Diagnostics;

namespace FindMinimumInRotatedSortedArray;

internal record TestScenario(string Name, int[] Numbers, int ExpectedMinimum);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.FindMin);

        int[] largeRotation = GenerateRotatedArray(100_000, 42_500);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[] { 3, 4, 5, 1, 2 },
                1
            ),
            new(
                "Example 2",
                new[] { 4, 5, 6, 7, 0, 1, 2 },
                0
            ),
            new(
                "Example 3",
                new[] { 11, 13, 15, 17 },
                11
            ),
            new(
                "Single Element",
                new[] { 1 },
                1
            ),
            new(
                "Two Elements Rotated",
                new[] { 2, 1 },
                1
            ),
            new(
                "Already Sorted",
                new[] { -9, -3, 0, 4, 7, 12 },
                -9
            ),
            new(
                "Large Rotation",
                largeRotation,
                GetMinimumValue(largeRotation)
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
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
