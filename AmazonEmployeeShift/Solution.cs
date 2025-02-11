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

    public static class Solution
    {
        public Employee[] Employees { get; set; }

        public static IEnumerable<Employee> GreedyAssignment(Task[] tasks)
        {
            
        }
    }
}
