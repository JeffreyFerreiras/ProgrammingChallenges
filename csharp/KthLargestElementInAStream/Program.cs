using System.Diagnostics;
using System.Linq;

namespace KthLargestElementInAStream;

internal record Operation(int Value, int Expected);
internal record TestScenario(string Name, int K, int[] InitialValues, Operation[] Operations);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.CreateKthLargest);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                3,
                [4, 5, 8, 2],
                [
                    new Operation(3, 4),
                    new Operation(5, 5),
                    new Operation(10, 5),
                    new Operation(9, 8),
                    new Operation(4, 8),
                ]
            ),
            new(
                "Single Element Stream",
                1,
                [5],
                [
                    new Operation(2, 5),
                    new Operation(6, 6),
                    new Operation(4, 6),
                ]
            ),
            new(
                "Growing Stream",
                2,
                [7],
                [
                    new Operation(0, 7),
                    new Operation(3, 7),
                    new Operation(4, 7),
                    new Operation(10, 7),
                    new Operation(12, 10),
                ]
            ),
            new(
                "Large Input",
                3,
                GenerateDescendingArray(50_000),
                [
                    new Operation(1_000_000, 999_998),
                    new Operation(1_000_001, 1_000_000),
                ]
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static int[] GenerateDescendingArray(int length)
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
        Console.WriteLine($"Initial Length: {scenario.InitialValues.Length}");
        Console.WriteLine($"Initial Preview: {FormatArrayPreview(scenario.InitialValues)}");
        Console.WriteLine($"Operations: {FormatOperations(scenario.Operations)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            Solution.KthLargest kthLargest = solution.CreateKthLargest(scenario.K, scenario.InitialValues);
            int[] results = new int[scenario.Operations.Length];
            for (int i = 0; i < scenario.Operations.Length; i++)
            {
                results[i] = kthLargest.Add(scenario.Operations[i].Value);
            }
            stopwatch.Stop();
            resultDisplay = $"[{string.Join(",", results)}]";
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
        Console.WriteLine($"Expected: [{string.Join(",", scenario.Operations.Select(op => op.Expected))}]");
        Console.WriteLine();
    }

    private static string FormatArrayPreview(int[] numbers)
    {
        const int previewCount = 10;
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

    private static string FormatOperations(Operation[] operations)
    {
        return $"[{string.Join(",", operations.Select(op => $"({op.Value}->{op.Expected})"))}]";
    }
}
