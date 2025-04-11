# Amazon Employee Shift Assignment

## Problem Description
This problem addresses the assignment of tasks to employees based on their skill levels. Each employee has a certain skill level, and each task requires a minimum skill level to be completed along with a defined duration.

The goal is to maximize the number of tasks that can be completed by the available employees.

## Examples:
```
Scenario 1:
Tasks: [(skill: 3, duration: 4), (skill: 5, duration: 4)]
Employees: [Alice (skill: 5)]
Expected Result: 1 task can be completed

Scenario 2:
Tasks: [(skill: 2, duration: 5), (skill: 3, duration: 5)]
Employees: [Bob (skill: 3), Charlie (skill: 3)]
Expected Result: 2 tasks can be completed

Scenario 3:
Tasks: [(skill: 1, duration: 2), (skill: 2, duration: 3), (skill: 3, duration: 2), (skill: 2, duration: 3)]
Employees: [Dave (skill: 3), Eve (skill: 2)]
Expected Result: 2 tasks can be completed
```

## Constraints:
- An employee can only work on a task if their skill level is greater than or equal to the task's required skill level
- Each employee can complete at most one task
- The goal is to maximize the number of completed tasks

## Solution Approach
The solution uses a greedy algorithm to assign tasks to employees:

1. Sort tasks and employees based on their skill requirements and skill levels
2. Assign tasks to the most suitable employees (those with just enough skill to complete the task)
3. Track assigned employees to ensure no employee is assigned more than one task
4. Count the maximum number of tasks that can be completed

This approach optimizes task assignment to maximize the total number of tasks completed given the skill constraints.