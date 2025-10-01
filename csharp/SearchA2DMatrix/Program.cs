using System.Diagnostics;
using System.Linq;

namespace SearchA2DMatrix;

internal record TestScenario(string Name, int[][] Matrix, int Target, bool Expected);

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("74. Search a 2D Matrix");
        Console.WriteLine("======================");
        Console.WriteLine();

        var methodName = nameof(Solution.SearchMatrix);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                [
                    new[] { 1, 3, 5, 7 },
                    [10, 11, 16, 20],
                    [23, 30, 34, 60],
                ],
                3,
                true
            ),
            new(
                "Example 2",
                [
                    new[] { 1, 3, 5, 7 },
                    [10, 11, 16, 20],
                    [23, 30, 34, 60],
                ],
                13,
                false
            ),
            new(
                "Single Element Present",
                [new[] { 5 }],
                5,
                true
            ),
            new(
                "Single Element Missing",
                [new[] { 5 }],
                1,
                false
            ),
            new(
                "Empty Row",
                [Array.Empty<int>()],
                1,
                false
            ),
            new(
                "Tall Matrix",
                [
                    new[] { 1, 4, 7 },
                    [10, 13, 16],
                    [19, 22, 25],
                    [28, 31, 34],
                    [37, 40, 43],
                    [46, 49, 52],
                    [55, 58, 61],
                ],
                40,
                true
            ),
            new(
                "Wide Matrix",
                [
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                ],
                11,
                false
            ),
            new(
                "Large Example",
                GenerateLargeMatrix(50, 50, 2),
                4897,
                true
            ),
            new(
                "Large Example Not Found",
                GenerateLargeMatrix(50, 50, 2),
                50001,
                false
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(methodName, scenario);
        }
    }

    private static int[][] GenerateLargeMatrix(int rows, int columns, int step)
    {
        int[][] matrix = new int[rows][];
        int value = 1;
        for (int r = 0; r < rows; r++)
        {
            matrix[r] = new int[columns];
            for (int c = 0; c < columns; c++)
            {
                matrix[r][c] = value;
                value += step;
            }
        }
        return matrix;
    }

    private static void RunScenario(string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"  Target: {scenario.Target}");
        Console.WriteLine($"  Expected: {scenario.Expected}");

        string matrixPreview = string.Join(", ", scenario.Matrix.Select(row => $"[{string.Join(",", row)}]"));
        Console.WriteLine($"  Matrix: {matrixPreview}");

        Stopwatch stopwatch = Stopwatch.StartNew();

        try
        {
            bool result = Solution.SearchMatrix(scenario.Matrix, scenario.Target);
            stopwatch.Stop();
            Console.WriteLine($"  Method: {methodName}");
            Console.WriteLine($"  Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {result}");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
            Console.WriteLine($"  Method: {methodName}");
            Console.WriteLine($"  Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine("  Result: not implemented");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"  Method: {methodName}");
            Console.WriteLine($"  Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: error ({ex.Message})");
        }

        Console.WriteLine();
    }
}
