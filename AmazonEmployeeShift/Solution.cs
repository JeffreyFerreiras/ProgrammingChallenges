using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int Skill { get; set; }
    }

    public class Solution
    {
        public Employee[] Employees { get; set; }

        public IEnumerable<Employee> GreedyAssignment(Task[] tasks)
        {
            const int maxHours = 8;

            var result = new List<Employee>();
            
            //take only 8 hours worth of tasks
            if(tasks.Sum(t => t.Hours) > maxHours)
            {
                throw new InvalidOperationException($"Tasks exceed {maxHours} hours");
            }

            //sort employees by skill
            Employees = [.. Employees.OrderBy(e => e.Skill)];

            foreach (var task in tasks)
            {
                var employee = Employees.FirstOrDefault(e => e.Skill >= task.Skill)
                    ?? throw new InvalidOperationException("No employee available for the task");

                result.Add(employee);
            }

            return result;
        }

        // New method: OptimalAssignment assigns each task to a unique employee
        public IEnumerable<Employee> OptimalAssignment(Task[] tasks)
        {
            const int maxHours = 8;
            if (tasks.Sum(t => t.Hours) > maxHours)
            {
                throw new InvalidOperationException($"Tasks exceed {maxHours} hours");
            }
            
            // Sort employees to try lower-skilled ones first
            var sortedEmployees = Employees.OrderBy(e => e.Skill).ToArray();
            int n = tasks.Length;
            List<Employee> bestAssignment = null;
            int bestCost = int.MaxValue;
            
            // Recursive DFS to try unique assignments
            void DFS(int idx, List<Employee> currentAssignment, bool[] used, int currentCost)
            {
                if (idx == n)
                {
                    if (currentCost < bestCost)
                    {
                        bestCost = currentCost;
                        bestAssignment = [.. currentAssignment];
                    }
                    return;
                }
                foreach (var (employee, i) in sortedEmployees.Select((emp, i) => (emp, i)))
                {
                    if (!used[i] && employee.Skill >= tasks[idx].Skill)
                    {
                        used[i] = true;
                        currentAssignment.Add(employee);
                        DFS(idx + 1, currentAssignment, used, currentCost + (employee.Skill - tasks[idx].Skill));
                        currentAssignment.RemoveAt(currentAssignment.Count - 1);
                        used[i] = false;
                    }
                }
            }
            
            DFS(0, [], new bool[sortedEmployees.Length], 0);
            if (bestAssignment == null)
            {
                throw new InvalidOperationException("No valid optimal assignment found");
            }
            return bestAssignment;
        }
    }
}
