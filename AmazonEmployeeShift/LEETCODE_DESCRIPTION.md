# Amazon Employee Shift Assignment

You are given a list of tasks and an array of employees. Each task is defined by:
- A minimum required skill level.
- A required number of hours to complete.

Each employee has:
- A name.
- A skill level.
- A maximum available shift of 8 hours.

A task must be completed by a single employee whose skill level is greater than or equal to the task's minimum required skill level. An employee may perform several tasks in one shift provided that the total hours do not exceed 8.

Your goal is to determine the minimum number of employees that must be assigned to a shift to cover all tasks. If the provided employees are insufficient, assume you have the freedom to "hire" additional employees with the required skills if necessary.

**Example 1:**

Input: tasks = [ (minSkill=3, hours=4), (minSkill=5, hours=4) ], employees = [ {Name:"Alice", Skill:5} ]  
Output: 1  
Explanation: Both tasks can be completed in one shift (total 8 hours) by Alice.

**Example 2:**

Input: tasks = [ (minSkill=2, hours=5), (minSkill=3, hours=5) ], employees = [ {Name:"Bob", Skill:3}, {Name:"Charlie", Skill:3} ]  
Output: 2  
Explanation: The tasks require 10 hours in total. With an 8‑hour shift limit per employee, you need at least two employees.

*Note:* This problem is similar to bin packing with the additional twist of a skill requirement.
