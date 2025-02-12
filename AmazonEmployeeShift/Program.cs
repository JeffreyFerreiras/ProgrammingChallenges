using System;
using System.Diagnostics;

namespace AmazonEmployeeShift
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Updated scenarios with employee objects
                RunScenario("Scenario 1",
                    [
                        new Task(3,4),
                        new Task(5,4)
                    ],
                    [
                        new Employee { Name = "Alice", Skill = 5 }
                    ],
                    expectedResult: 1);

                RunScenario("Scenario 2",
                    [
                        new Task(2,5),
                        new Task(3,5)
                    ],
                    [
                        new Employee { Name = "Bob", Skill = 3 },
                        new Employee { Name = "Charlie", Skill = 3 }
                    ],
                    expectedResult: 2);

                RunScenario("Scenario 3",
                    [
                        new Task(1,2),
                        new Task(2,3),
                        new Task(3,2),
                        new Task(2,3)
                    ],
                    [
                        new Employee { Name = "Dave", Skill = 3 },
                        new Employee { Name = "Eve", Skill = 2 }
                    ],
                    expectedResult: 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Updated method to accept employees and assign them to the Solution.
        static void RunScenario(string scenarioName, Task[] tasks, Employee[] employees, int expectedResult)
        {
            var solution = new Solution
            {
                Employees = employees
            };
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var result = solution.GreedyAssignment(tasks);
            stopwatch.Stop();
            Console.WriteLine($"{scenarioName} - GreedyAssignment took {stopwatch.ElapsedTicks} ticks. Result = {result}, Expected = {expectedResult}");
        }
    }
}
