using System;
using System.Linq;

namespace AmazonEmployeeShift
{
    public class Task(int minSkill, int hours)
    {
        public int Skill { get; set; } = minSkill;
        public int Hours { get; set; } = hours;
    }

    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public int Skill { get; set; }
    }

    public class Solution
    {
        public Employee[] Employees { get; set; } = [];

        public int MinimumEmployeesRequired(Task[] tasks)
        {
            return MinimumEmployeesRequired_BruteForce(tasks);
        }

        public int MinimumEmployeesRequired_BruteForce(Task[] tasks)
        {
            if (tasks == null || tasks.Length == 0)
            {
                return 0;
            }

            if (Employees == null || Employees.Length == 0)
            {
                return -1;
            }

            var availableEmployees = Employees
                .Where(e => e != null)
                .OrderBy(e => e.Skill)
                .ToArray();

            if (availableEmployees.Length == 0)
            {
                return -1;
            }

            var sortedTasks = tasks
                .Where(t => t != null)
                .OrderByDescending(t => t.Hours)
                .ThenByDescending(t => t.Skill)
                .ToArray();

            if (sortedTasks.Any(t => t.Hours > 8 || t.Hours <= 0))
            {
                return -1;
            }

            var currentHours = new int[availableEmployees.Length];
            var currentEmployeeUsed = new bool[availableEmployees.Length];
            var best = int.MaxValue;

            void Search(int taskIndex, int usedEmployees)
            {
                if (usedEmployees >= best)
                {
                    return;
                }

                if (taskIndex == sortedTasks.Length)
                {
                    best = Math.Min(best, usedEmployees);
                    return;
                }

                var task = sortedTasks[taskIndex];

                for (var employeeIndex = 0; employeeIndex < availableEmployees.Length; employeeIndex++)
                {
                    if (!currentEmployeeUsed[employeeIndex])
                    {
                        continue;
                    }

                    var employee = availableEmployees[employeeIndex];
                    if (employee.Skill < task.Skill || currentHours[employeeIndex] + task.Hours > 8)
                    {
                        continue;
                    }

                    currentHours[employeeIndex] += task.Hours;
                    Search(taskIndex + 1, usedEmployees);
                    currentHours[employeeIndex] -= task.Hours;
                }

                for (var employeeIndex = 0; employeeIndex < availableEmployees.Length; employeeIndex++)
                {
                    if (currentEmployeeUsed[employeeIndex])
                    {
                        continue;
                    }

                    var employee = availableEmployees[employeeIndex];
                    if (employee.Skill < task.Skill)
                    {
                        continue;
                    }

                    currentEmployeeUsed[employeeIndex] = true;
                    currentHours[employeeIndex] = task.Hours;
                    Search(taskIndex + 1, usedEmployees + 1);
                    currentHours[employeeIndex] = 0;
                    currentEmployeeUsed[employeeIndex] = false;
                }
            }

            Search(0, 0);
            return best == int.MaxValue ? -1 : best;
        }
    }
}
