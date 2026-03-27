using System.Diagnostics;

namespace DesignAddAndSearchWordsDataStructure;

internal record Operation(string Command, string? Word, bool? ExpectedResponse);

internal record TestScenario(
    string Name,
    Operation[] Operations,
    string InputDisplay,
    string ExpectedOutputDisplay
);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.CreateWordDictionary);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                [
                    new("addWord", "bad", null),
                    new("addWord", "dad", null),
                    new("addWord", "mad", null),
                    new("search", "pad", false),
                    new("search", "bad", true),
                    new("search", ".ad", true),
                    new("search", "b..", true),
                ],
                "[[], [\"bad\"], [\"dad\"], [\"mad\"], [\"pad\"], [\"bad\"], [\".ad\"], [\"b..\"]]",
                "[null, null, null, null, false, true, true, true]"
            ),
            new(
                "Duplicate Single-Letter Word",
                [
                    new("addWord", "a", null),
                    new("addWord", "a", null),
                    new("search", ".", true),
                    new("search", "a", true),
                    new("search", "aa", false),
                    new("search", "a", true),
                    new("search", ".a", false),
                    new("search", "a.", false),
                ],
                "[[], [\"a\"], [\"a\"], [\".\"], [\"a\"], [\"aa\"], [\"a\"], [\".a\"], [\"a.\"]]",
                "[null, null, null, true, true, false, true, false, false]"
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine("211. Design Add and Search Words Data Structure");
        Console.WriteLine(new string('=', 46));
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine("Input:");
        Console.WriteLine(BuildCommandDisplay(scenario.Operations));
        Console.WriteLine(scenario.InputDisplay);
        Console.WriteLine($"Expected: {scenario.ExpectedOutputDisplay}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;
        bool pass = false;

        try
        {
            Solution.WordDictionary wordDictionary = solution.CreateWordDictionary();
            string[] results = ExecuteOperations(wordDictionary, scenario.Operations);
            resultDisplay = $"[{string.Join(", ", results)}]";
            pass = resultDisplay == scenario.ExpectedOutputDisplay;
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
        Console.WriteLine($"Result: {resultDisplay}{(pass ? " ✓" : string.Empty)}");
        Console.WriteLine();
    }

    private static string BuildCommandDisplay(Operation[] operations)
    {
        string[] commands = new string[operations.Length + 1];
        commands[0] = "\"WordDictionary\"";

        for (int i = 0; i < operations.Length; i++)
        {
            commands[i + 1] = $"\"{operations[i].Command}\"";
        }

        return $"[{string.Join(",", commands)}]";
    }

    private static string[] ExecuteOperations(
        Solution.WordDictionary wordDictionary,
        Operation[] operations
    )
    {
        string[] results = new string[operations.Length + 1];
        results[0] = "null";

        for (int i = 0; i < operations.Length; i++)
        {
            Operation operation = operations[i];

            switch (operation.Command)
            {
                case "addWord":
                    if (operation.Word is null)
                    {
                        throw new InvalidOperationException("addWord requires a non-null word.");
                    }

                    wordDictionary.AddWord(operation.Word);
                    results[i + 1] = "null";
                    break;
                case "search":
                    if (operation.Word is null)
                    {
                        throw new InvalidOperationException("search requires a non-null word.");
                    }

                    results[i + 1] = wordDictionary
                        .Search(operation.Word)
                        .ToString()
                        .ToLowerInvariant();
                    break;
                default:
                    throw new InvalidOperationException(
                        $"Unsupported command: {operation.Command}"
                    );
            }
        }

        return results;
    }
}
