using System.Diagnostics;

namespace KClosestPointsToOrigin;

internal record TestScenario(string Name, int[][] Points, int K, int[][] Expected);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.KClosest);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[]
                {
                    new[] { 1, 3 },
                    new[] { -2, 2 },
                },
                1,
                new[]
                {
                    new[] { -2, 2 },
                }
            ),
            new(
                "Example 2",
                new[]
                {
                    new[] { 3, 3 },
                    new[] { 5, -1 },
                    new[] { -2, 4 },
                },
                2,
                new[]
                {
                    new[] { 3, 3 },
                    new[] { -2, 4 },
                }
            ),
            new(
                "K Equals Points",
                new[]
                {
                    new[] { 1, 0 },
                    new[] { 2, 0 },
                    new[] { 3, 0 },
                },
                3,
                new[]
                {
                    new[] { 1, 0 },
                    new[] { 2, 0 },
                    new[] { 3, 0 },
                }
            ),
            new(
                "Large Cloud",
                GenerateCircularPoints(10_000, radius: 100),
                5,
                GenerateCircularPoints(5, radius: 1)
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static int[][] GenerateCircularPoints(int count, int radius)
    {
        int[][] points = new int[count][];
        for (int i = 0; i < count; i++)
        {
            double angle = i * (Math.PI * 2 / Math.Max(1, count));
            int x = (int)Math.Round(radius * Math.Cos(angle));
            int y = (int)Math.Round(radius * Math.Sin(angle));
            points[i] = new[] { x, y };
        }
        return points;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"k: {scenario.K}");
        Console.WriteLine($"Points Count: {scenario.Points.Length}");
        Console.WriteLine($"Expected: {FormatPoints(scenario.Expected)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int[][] result = solution.KClosest(ClonePoints(scenario.Points), scenario.K);
            stopwatch.Stop();
            resultDisplay = FormatPoints(result);
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

    private static int[][] ClonePoints(int[][] points)
    {
        int[][] clone = new int[points.Length][];
        for (int i = 0; i < points.Length; i++)
        {
            clone[i] = (int[])points[i].Clone();
        }
        return clone;
    }

    private static string FormatPoints(int[][] points)
    {
        if (points.Length == 0)
        {
            return "[]";
        }

        string[] formatted = new string[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            formatted[i] = $"[{points[i][0]},{points[i][1]}]";
        }
        return $"[{string.Join(",", formatted)}]";
    }
}
