# Amazon Employee Shift Assignment

You are given a list of tasks and a list of employees. Each task has a required skill level and a number of hours. Each employee has a skill level and can work on multiple tasks during one 8-hour shift as long as the total hours stay within the shift limit.

A task can be assigned only to an employee whose skill is at least the task's required skill.

Return the minimum number of employees required to cover all tasks. If the tasks cannot be completed with the provided employees, return -1.

## Example 1
- Input: tasks = [(3, 4), (5, 4)], employees = [Alice (5)]
- Output: 1
- Explanation: Alice can complete both tasks because the total hours are 8 and her skill satisfies both requirements.

## Example 2
- Input: tasks = [(2, 5), (3, 5)], employees = [Bob (3), Charlie (3)]
- Output: 2
- Explanation: The tasks require 10 total hours, so one employee cannot cover them within the 8-hour shift limit.

## Example 3
- Input: tasks = [(1, 2), (2, 3), (3, 2), (2, 3)], employees = [Dave (3), Eve (2)]
- Output: 2
- Explanation: The two employees split the tasks while staying within the 8-hour limit.

## Constraints
- Each task has a positive number of hours.
- The shift duration is 8 hours.
- Employees can take multiple tasks in one shift if the total hours are at most 8.
- Each task must be assigned to exactly one employee.

## Edge Cases
- No tasks: return 0.
- A task requires a skill level higher than every employee's skill: return -1.
- A single task requires more than 8 hours: return -1.
- Large mixed examples to practice optimization.
