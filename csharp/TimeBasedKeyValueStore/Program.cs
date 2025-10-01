using System.Diagnostics;

namespace TimeBasedKeyValueStore;

internal record Operation(string Command, string Key, string? Value, int Timestamp);
internal record TestScenario(string Name, Operation[] Operations, string?[] ExpectedResponses);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.CreateTimeMap);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                [
                    new("set", "foo", "bar", 1),
                    new("get", "foo", null, 1),
                    new("get", "foo", null, 3),
                    new("set", "foo", "bar2", 4),
                    new("get", "foo", null, 4),
                    new("get", "foo", null, 5),
                ],
                ["bar", "bar", "bar2", "bar2"]
            ),
            new(
                "Key Missing",
                [
                    new("set", "foo", "bar", 1),
                    new("get", "foo", null, 0),
                    new("get", "foo", null, 1),
                    new("get", "unknown", null, 5),
                ],
                [string.Empty, "bar", string.Empty]
            ),
            new(
                "Multiple Keys",
                [
                    new("set", "love", "high", 10),
                    new("set", "love", "low", 20),
                    new("set", "hate", "mild", 30),
                    new("get", "love", null, 5),
                    new("get", "love", null, 10),
                    new("get", "love", null, 15),
                    new("get", "love", null, 25),
                    new("get", "hate", null, 35),
                ],
                [string.Empty, "high", "high", "low", "mild"]
            ),
            new(
                "Dense Timeline",
                BuildDenseScenario(),
                BuildDenseExpected()
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static Operation[] BuildDenseScenario()
    {
        var operations = new Operation[60];
        int index = 0;
        for (int t = 1; t <= 20; t++)
        {
            operations[index++] = new Operation("set", "key", $"v{t}", t);
            operations[index++] = new Operation("get", "key", null, t);
            operations[index++] = new Operation("get", "key", null, t + 1);
        }
        return operations;
    }

    private static string?[] BuildDenseExpected()
    {
        var expected = new string?[40];
        int index = 0;
        for (int t = 1; t <= 20; t++)
        {
            expected[index++] = $"v{t}";
            expected[index++] = $"v{t}";
        }
        return expected;
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Operations: {scenario.Operations.Length}");
        Console.WriteLine($"Expected Responses: {FormatResponses(scenario.ExpectedResponses)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            Solution.TimeMap timeMap = solution.CreateTimeMap();
            string?[] results = ExecuteOperations(timeMap, scenario.Operations);
            resultDisplay = FormatResponses(results);
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

    private static string?[] ExecuteOperations(Solution.TimeMap timeMap, Operation[] operations)
    {
        int getCount = 0;
        for (int i = 0; i < operations.Length; i++)
        {
            if (operations[i].Command == "get")
            {
                getCount++;
            }
        }

        string?[] responses = getCount == 0 ? Array.Empty<string?>() : new string?[getCount];
        int index = 0;

        foreach (Operation operation in operations)
        {
            switch (operation.Command)
            {
                case "set":
                    if (operation.Value is null)
                    {
                        throw new InvalidOperationException("Set operation requires a value.");
                    }
                    timeMap.Set(operation.Key, operation.Value, operation.Timestamp);
                    break;
                case "get":
                    responses[index++] = timeMap.Get(operation.Key, operation.Timestamp);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported command: {operation.Command}");
            }
        }

        return responses;
    }

    private static string FormatResponses(string?[] responses)
    {
        if (responses.Length == 0)
        {
            return "[]";
        }

        string[] formatted = new string[responses.Length];
        for (int i = 0; i < responses.Length; i++)
        {
            formatted[i] = responses[i] is null ? "null" : $"\"{responses[i]}\"";
        }

        return $"[{string.Join(",", formatted)}]";
    }
}
