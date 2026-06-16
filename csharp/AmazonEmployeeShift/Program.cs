using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AmazonEmployeeShift
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var scenarios = new[]
                {
                    new Scenario(
                        "Scenario 1",
                        new[] { new Task(3, 4), new Task(5, 4) },
                        new[] { new Employee { Name = "Alice", Skill = 5 } },
                        1),
                    new Scenario(
                        "Scenario 2",
                        new[] { new Task(2, 5), new Task(3, 5) },
                        new[] { new Employee { Name = "Bob", Skill = 3 }, new Employee { Name = "Charlie", Skill = 3 } },
                        2),
                    new Scenario(
                        "Scenario 3",
                        new[] { new Task(1, 2), new Task(2, 3), new Task(3, 2), new Task(2, 3) },
                        new[] { new Employee { Name = "Dave", Skill = 3 }, new Employee { Name = "Eve", Skill = 2 } },
                        2),
                    new Scenario(
                        "Edge Case - No Tasks",
                        Array.Empty<Task>(),
                        new[] { new Employee { Name = "Grace", Skill = 5 } },
                        0),
                    new Scenario(
                        "Edge Case - Impossible Assignment",
                        new[] { new Task(10, 4) },
                        new[] { new Employee { Name = "Heidi", Skill = 3 } },
                        -1)
                };

                foreach (var scenario in scenarios)
                {
                    RunScenario(scenario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            Console.WriteLine($"Tasks: {string.Join(", ", scenario.Tasks.Select(t => $"({t.Skill},{t.Hours})"))}");
            Console.WriteLine($"Employees: {string.Join(", ", scenario.Employees.Select(e => $"{e.Name}:{e.Skill}"))}");

            var solution = new Solution
            {
                Employees = scenario.Employees
            };

            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName)
                .Where(method => method.GetParameters().Length == 1)
                .Where(method => method.GetParameters()[0].ParameterType == typeof(Task[]))
                .Where(method => method.ReturnType == typeof(int))
                .OrderBy(method => method.Name)
                .ToArray();

            if (methods.Length == 0)
            {
                Console.WriteLine("No runnable solution methods were discovered.");
                return;
            }

            foreach (var method in methods)
            {
                var stopwatch = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try
                {
                    result = method.Invoke(solution, new object?[] { scenario.Tasks });
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                finally
                {
                    stopwatch.Stop();
                }

                var elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"{method.Name} | {elapsedMilliseconds:0.0000} ms | ");

                if (exception != null)
                {
                    Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                    continue;
                }

                var numericResult = Convert.ToInt32(result);
                var passed = numericResult == scenario.ExpectedResult;
                Console.WriteLine($"{numericResult} | Expected {scenario.ExpectedResult} | {(passed ? "✅ PASS" : "❌ FAIL")}");
            }
        }

        private sealed record Scenario(string Name, Task[] Tasks, Employee[] Employees, int ExpectedResult);
    }
}
