# Island Treasure

## Problem Description
Given a grid with treasures (0), water (-1), and land (INF/2147483647), fill each land cell with the distance to its nearest treasure chest. If a land cell cannot reach a treasure chest, it remains INF.

The distance between two adjacent cells is 1, and you can only move horizontally or vertically (not diagonally).

## Examples:
```
Example 1:
Input Grid:
  [2147483647, -1,          0, 2147483647]
  [2147483647, 2147483647, 2147483647, -1]
  [2147483647, -1,          2147483647, -1]
  [         0, -1,          2147483647, 2147483647]

Output Grid:
  [3, -1, 0, 1]
  [2, 2, 1, -1]
  [1, -1, 2, -1]
  [0, -1, 3, 4]

Example 2:
Input Grid:
  [0, -1]
  [2147483647, 2147483647]

Output Grid:
  [0, -1]
  [1, 2]
```

## Constraints:
- Grid cells have three possible values:
  - 0: Treasure chest
  - -1: Water (cannot pass through)
  - 2147483647 (INF): Land (can walk on)
- You can only move horizontally or vertically (not diagonally)
- The grid size is between 1x1 and 100x100

## Solution Approach
The solution uses a breadth-first search (BFS) approach to find the shortest distance from each land cell to the nearest treasure:

1. Identify all treasure chest locations (cells with value 0)
2. Start a BFS from all treasure chests simultaneously
3. For each step, explore adjacent cells (up, down, left, right)
4. Update the distance of each land cell when first reached
5. Skip water cells (-1) and cells that have already been visited
6. Continue until all reachable land cells have been visited

This approach ensures that each land cell is assigned the minimum possible distance to a treasure chest, or remains INF if no treasure is reachable.

Time Complexity: O(m*n) where m and n are the dimensions of the grid
Space Complexity: O(m*n) for the queue and visited tracking