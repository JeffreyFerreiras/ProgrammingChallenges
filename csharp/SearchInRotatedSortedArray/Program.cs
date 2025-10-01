using System.Diagnostics;

namespace SearchInRotatedSortedArray;

internal record TestScenario(string Name, int[] Numbers, int Target, int ExpectedIndex);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.Search);

        int[] largeRotation = GenerateRotatedArray(120_000, 75_000);
        int targetInLarge = 12_345;
        int expectedIndexLarge = FindIndex(largeRotation, targetInLarge);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                [4, 5, 6, 7, 0, 1, 2],
                0,
                4
            ),
            new(
                "Example 2",
                [4, 5, 6, 7, 0, 1, 2],
                3,
                -1
            ),
            new(
                "Single Element Present",
                [1],
                1,
                0
            ),
            new(
                "Single Element Missing",
                [1],
                0,
                -1
            ),
            new(
                "All Positive Rotation",
                [30, 34, 40, 2, 5, 8, 11],
                5,
                4
            ),
            new(
                "Negative and Positive",
                [9, 12, 17, -4, -1, 0, 3],
                -1,
                4
            ),
            new(
                "Large Rotation",
                largeRotation,
                targetInLarge,
                expectedIndexLarge
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

    private static int FindIndex(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                return i;
            }
        }
        return -1;
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
