using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonEmployeeShift
{
    public class Task
    {
        public int Skill { get; set; }
        public int Hours { get; set; }
        public Task(int minSkill, int hours)
        {
            Skill = minSkill;
            Hours = hours;
        }
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
            Employees = Employees.OrderBy(e => e.Skill).ToArray();

            foreach (var task in tasks)
            {
                var employee = Employees.FirstOrDefault(e => e.Skill >= task.Skill)
                    ?? throw new InvalidOperationException("No employee available for the task");

                result.Add(employee);
            }

            return result;
        }
    }
}
