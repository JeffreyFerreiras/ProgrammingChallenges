# 207. Course Schedule

## Problem Description
There are a total of `numCourses` courses you have to take, labeled from 0 to numCourses - 1. Some courses have prerequisites. For example, if prerequisites[i] = [a_i, b_i], you must take course b_i first before taking course a_i.

Given the total number of courses and a list of prerequisite pairs, determine if it is possible to finish all courses.

## Examples:
```
Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are 2 courses to take. To take course 1 you should have finished course 0. So it is possible.

Example 2:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are 2 courses to take. To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

Example 3:
Input: numCourses = 3, prerequisites = [[1,0],[2,1]]
Output: true
Explanation: There are 3 courses to take. To take course 1 you should have finished course 0, and to take course 2 you should have finished course 1. So it is possible.
```

## Constraints:
- 1 <= numCourses <= 10^5
- 0 <= prerequisites.length <= 5000
- prerequisites[i].length == 2
- 0 <= a_i, b_i < numCourses
- All the pairs prerequisites[i] are unique

## Solution Approach
The solution detects if there's a cycle in the directed graph of course prerequisites:

1. Build an adjacency list representation of the course dependencies
2. Use depth-first search (DFS) to detect cycles in the graph:
   - Track visited nodes and nodes currently in the recursion stack
   - If we encounter a node already in the recursion stack, we've found a cycle
3. If a cycle exists, it's impossible to complete all courses
4. If no cycles exist, it's possible to complete all courses

This approach is equivalent to determining if the directed graph of prerequisites is a directed acyclic graph (DAG).

Time Complexity: O(V + E) where V is the number of courses and E is the number of prerequisites
Space Complexity: O(V + E) for the adjacency list and visited arrays