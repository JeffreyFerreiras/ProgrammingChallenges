# 210. Course Schedule II

## Problem Description
There are a total of `numCourses` courses you have to take, labeled from 0 to numCourses - 1. You are given an array `prerequisites` where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

## Examples:
```
Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3] or [0,1,2,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

Example 3:
Input: numCourses = 1, prerequisites = []
Output: [0]

Example 4:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: []
Explanation: It is impossible to finish all courses.
```

## Constraints:
- 1 <= numCourses <= 2000
- 0 <= prerequisites.length <= numCourses * (numCourses - 1)
- prerequisites[i].length == 2
- 0 <= ai, bi < numCourses
- ai != bi
- All the pairs [ai, bi] are distinct

## Solution Approaches
The solution implements three different algorithms for topological sorting:

1. **Depth-First Search (DFS)** (`FindOrderTopologicalDFS`):
   - Build an adjacency list of course prerequisites
   - Perform DFS traversal with cycle detection
   - Add courses to the result in post-order fashion
   - Reverse the result to get the correct order

2. **Breadth-First Search / Kahn's Algorithm** (`FindOrderTopologicalBFS`):
   - Calculate in-degree for each course (number of prerequisites)
   - Start with courses that have no prerequisites (in-degree = 0)
   - As each course is taken, decrement the in-degree of dependent courses
   - Add courses to the result as their in-degree becomes 0

3. **Adjacency List with DFS** (`FindOrderAdjDfs`):
   - Another variation of the DFS approach using adjacency lists
   - Optimized implementation for large course numbers

All three approaches have:
- Time Complexity: O(V + E) where V is the number of courses and E is the number of prerequisites
- Space Complexity: O(V + E) for the adjacency lists and visited arrays

The implementation includes comprehensive benchmarking to compare the performance of all three algorithms.