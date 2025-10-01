using System.Diagnostics;
using System.Reflection;
using MinStack;

class Program
{
    static void Main()
    {
        Console.WriteLine("155. Min Stack");
        Console.WriteLine("===============\n");

        var testCases = new (
            string name,
            List<(string action, int? value, int? expected)> operations
        )[]
        {
            (
                "Example 1",
                new List<(string, int?, int?)>
                {
                    ("push", -2, null),
                    ("push", 0, null),
                    ("push", -3, null),
                    ("getMin", null, -3),
                    ("pop", null, null),
                    ("top", null, 0),
                    ("getMin", null, -2),
                }
            ),
            (
                "Example 2",
                new List<(string, int?, int?)>
                {
                    ("push", 2, null),
                    ("push", 0, null),
                    ("push", 3, null),
                    ("push", 0, null),
                    ("getMin", null, 0),
                    ("pop", null, null),
                    ("getMin", null, 0),
                    ("pop", null, null),
                    ("getMin", null, 0),
                    ("pop", null, null),
                    ("getMin", null, 2),
                }
            ),
        };

        foreach (var testCase in testCases)
        {
            Console.WriteLine($"Test: {testCase.name}");
            Console.WriteLine(
                $"  Operations: {string.Join(", ", testCase.operations.Select(op =>
                op.value.HasValue ? $"{op.action}({op.value})" : op.action))}"
            );

            var sw = Stopwatch.StartNew();
            try
            {
                var stack = new MinStack.MinStack();
                bool allPassed = true;

                foreach (var (action, value, expected) in testCase.operations)
                {
                    switch (action)
                    {
                        case "push":
                            stack.Push(value!.Value);
                            break;
                        case "pop":
                            stack.Pop();
                            break;
                        case "top":
                            var topResult = stack.Top();
                            if (topResult != expected)
                            {
                                allPassed = false;
                                Console.WriteLine(
                                    $"    Top failed: got {topResult}, expected {expected}"
                                );
                            }
                            break;
                        case "getMin":
                            var minResult = stack.GetMin();
                            if (minResult != expected)
                            {
                                allPassed = false;
                                Console.WriteLine(
                                    $"    GetMin failed: got {minResult}, expected {expected}"
                                );
                            }
                            break;
                    }
                }

                sw.Stop();
                string status = allPassed ? "✓ PASSED" : "✗ FAILED";
                Console.WriteLine($"  Result: {status} [{sw.Elapsed.TotalMilliseconds:F4} ms]");
            }
            catch (NotImplementedException)
            {
                sw.Stop();
                Console.WriteLine(
                    $"  Result: ⚠ NOT IMPLEMENTED [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                );
            }
            catch (Exception ex)
            {
                sw.Stop();
                Console.WriteLine($"  Result: ✗ ERROR [{sw.Elapsed.TotalMilliseconds:F4} ms]");
                Console.WriteLine($"    Error: {ex.Message}");
            }
            Console.WriteLine();
        }
    }
}
