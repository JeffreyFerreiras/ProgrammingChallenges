# 417. Pacific Atlantic Water Flow

## Problem Description
There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

The island is partitioned into a grid of square cells. You are given an m x n integer matrix `heights` where `heights[r][c]` represents the height above sea level of the cell at coordinate (r, c).

The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.

Return a 2D list of grid coordinates `result` where `result[i] = [ri, ci]` denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.

## Examples:
```
Example 1:
Input: heights = [
  [1,2,2,3,5],
  [3,2,3,4,4],
  [2,4,5,3,1],
  [6,7,1,4,5],
  [5,1,1,2,4]
]
Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]

Example 2:
Input: heights = [
  [2,1],
  [1,2]
]
Output: [[0,0],[0,1],[1,0],[1,1]]
```

## Solution Approach
The solution uses a Breadth-First Search (BFS) approach to determine if water can flow from each cell to both oceans:

1. For each cell in the grid:
   - Run a BFS starting from that cell
   - Track visited cells to avoid cycles
   - Check if water can flow to both the Pacific (top/left edges) and Atlantic (bottom/right edges)

2. BFS Implementation Details:
   - Use a queue to track cells to visit
   - For each cell, check all four adjacent cells (up, down, left, right)
   - Water can only flow from higher to equal or lower heights
   - Track if the search has reached each ocean
   - A cell is added to the result if water can reach both oceans

3. Optimization Considerations:
   - Use a HashSet to track visited cells and avoid revisiting
   - Check boundaries to determine if an ocean has been reached
   - Short-circuit the BFS if both oceans have been reached

## Test Cases
The implementation includes comprehensive test cases:
1. 5x5 matrix with varied heights
2. 2x2 matrix (small test case)
3. 1x1 matrix (single cell island)
4. Uniform height matrix (all cells have same height)

## Complexity Analysis:
- Time Complexity: O(m²n²) in the worst case, where m and n are the dimensions of the grid
- Space Complexity: O(mn) for the queue and visited set

## Performance
The implementation includes performance benchmarking using Stopwatch to measure execution time for each test case.

This problem demonstrates the application of graph traversal algorithms to solve problems involving connectivity and path finding.