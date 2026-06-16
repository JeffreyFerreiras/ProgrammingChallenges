# Amazon Employee Shift Assignment

This repository contains a practice scaffold for an Amazon-style interview problem about assigning shift work to employees.

## Problem Statement
You are given a list of tasks for one shift. Each task has:
- a minimum required skill level
- a required number of hours to complete

You are also given a list of employees. Each employee has:
- a name
- a skill level

Each employee can work on multiple tasks during a single shift as long as the total hours do not exceed 8 hours. An employee can only be assigned a task if their skill level is greater than or equal to the task's required skill level.

Return the minimum number of employees needed to cover all tasks. If it is impossible to cover all tasks with the provided employees, return -1.

## Example 1
Input:
- Tasks: [(skill = 3, hours = 4), (skill = 5, hours = 4)]
- Employees: [Alice (skill = 5)]

Output: 1

Explanation:
Alice can complete both tasks because the total hours are $4 + 4 = 8$, and Alice's skill meets both requirements.

## Example 2
Input:
- Tasks: [(skill = 2, hours = 5), (skill = 3, hours = 5)]
- Employees: [Bob (skill = 3), Charlie (skill = 3)]

Output: 2

Explanation:
The tasks require 10 total hours, so one employee cannot cover both tasks within the 8-hour shift. Two employees are needed.

## Example 3
Input:
- Tasks: [(skill = 1, hours = 2), (skill = 2, hours = 3), (skill = 3, hours = 2), (skill = 2, hours = 3)]
- Employees: [Dave (skill = 3), Eve (skill = 2)]

Output: 2

Explanation:
The two employees can split the work, with each shift staying within the 8-hour limit.

## Constraints
- Each task has a positive number of hours.
- Each shift is 8 hours long.
- An employee can work on multiple tasks in a single shift if the total hours stay within the limit.
- Each task must be assigned to exactly one employee.
- If no feasible assignment exists, return -1.

## Edge Cases
- No tasks are provided: return 0.
- A task requires a skill level higher than every employee's skill: return -1.
- A single task requires more than 8 hours: return -1.
- Employees with high skill can cover many tasks, while low-skill employees may be limited.

## Long Practice Example
Input:
- Tasks: [(skill = 2, hours = 3), (skill = 4, hours = 2), (skill = 3, hours = 4), (skill = 5, hours = 1), (skill = 1, hours = 5), (skill = 4, hours = 3)]
- Employees: [Mina (skill = 5), Jay (skill = 4), Priya (skill = 3)]

Expected output: 2

Explanation:
One employee can take a subset of compatible tasks whose hours sum to at most 8, while the remaining tasks go to another employee.

## Practice Notes
The solution scaffold intentionally leaves the main algorithm for you to design. The runner in this project reflects over public methods in the solution class and executes each one against every scenario so you can compare approaches side by side.