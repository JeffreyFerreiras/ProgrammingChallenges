# 200. Number of Islands

## Problem Description
Given an m x n 2D binary grid 'grid' which represents a map of '1's (land) and '0's (water), 
return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

## Examples:
```
Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
```

## Solution Approach
The solution implements both Depth-First Search (DFS) and Breadth-First Search (BFS) algorithms to find and count islands:

### Algorithm:
1. Iterate through each cell in the grid
2. When a land cell ('1') is found:
   - Increment the island counter
   - Use DFS/BFS to mark all connected land cells as visited (changed to '0')
3. Continue until all cells are processed

### DFS Implementation:
- Uses recursive approach to explore all adjacent land cells
- Changes visited cells to '0' to prevent revisiting
- Checks boundaries and water cells to stop recursion

### BFS Implementation:
- Uses a queue to track cells to visit
- Explores land cells in all four directions (up, down, left, right)
- Marks visited cells as '0' to avoid revisiting

## Complexity Analysis:
- Time Complexity: O(m×n) where m is the number of rows and n is the number of columns
- Space Complexity: O(m×n) in worst case for the recursive call stack (DFS) or queue (BFS)

## Performance Benchmarking
The implementation includes comprehensive test cases with performance measurement:
- Simple grid with a single island
- Grid with multiple distinct islands
- Large grid with a complex pattern of islands
- Performance metrics measured in ticks for each scenario

This problem demonstrates the classic application of graph traversal algorithms (DFS/BFS) to solve connected component problems.