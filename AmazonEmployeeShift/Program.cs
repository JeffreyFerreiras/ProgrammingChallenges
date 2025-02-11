using System;
using System.Diagnostics;
using AmazonEmployeeShift;

namespace AmazonEmployeeShift
{
    class Program
    {
        static void Main(string[] args)
        {
            // Updated scenarios with employee objects
            RunScenario("Scenario 1",
                new Task[]
                {
                    new Task(3,4),
                    new Task(5,4)
                },
                new Employee[]
                {
                    new Employee { Name = "Alice", Skill = 5 }
                },
                expected: 1);

            RunScenario("Scenario 2",
                new Task[]
                {
                    new Task(2,5),
                    new Task(3,5)
                },
                new Employee[]
                {
                    new Employee { Name = "Bob", Skill = 3 },
                    new Employee { Name = "Charlie", Skill = 3 }
                },
                expected: 2);

            RunScenario("Scenario 3",
                new Task[]
                {
                    new Task(1,2),
                    new Task(2,3),
                    new Task(3,2),
                    new Task(2,3)
                },
                new Employee[]
                {
                    new Employee { Name = "Dave", Skill = 3 },
                    new Employee { Name = "Eve", Skill = 2 }
                },
                expected: 2);

            Console.ReadLine();
        }

        // Updated method to accept employees and assign them to the Solution.
        static void RunScenario(string scenarioName, Task[] tasks, Employee[] employees, int expected)
        {
            Solution.Employees = employees;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = Solution.GreedyAssignment(tasks);
            stopwatch.Stop();
            Console.WriteLine($"{scenarioName} - GreedyAssignment took {stopwatch.ElapsedTicks} ticks. Result = {result}, Expected = {expected}");
        }
    }
}
