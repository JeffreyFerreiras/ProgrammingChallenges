# 51. N-Queens

## Problem Description
The N-Queens puzzle is the problem of placing N chess queens on an N×N chessboard such that no two queens threaten each other. A solution requires that no two queens share the same row, column, or diagonal.

Given an integer n, return all distinct solutions to the N-Queens puzzle. Each solution contains a distinct board configuration of the N-Queens placement, where 'Q' indicates a queen and '.' indicates an empty space.

## Examples:
```
Example 1:
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There are two distinct solutions to the 4-queens puzzle as shown.

Example 2:
Input: n = 1
Output: [["Q"]]
Explanation: There is only one solution for n=1.
```

## Constraints:
- 1 <= n <= 9

## Solution Approach
The solution implements two different backtracking approaches to solve the N-Queens problem:

1. **Standard Backtracking** (`SolveNQueens`):
   - Use a recursive approach to place queens one row at a time
   - Check if a position is valid by ensuring no other queens threaten it
   - Build the board representation once a valid configuration is found
   - Time Complexity: O(N!), as we place queens row by row with decreasing options
   - Space Complexity: O(N²) for storing the board configurations

2. **Optimized Backtracking with StringBuilder** (`SolveNQueens2`):
   - Uses StringBuilder for more efficient string manipulation
   - Same backtracking logic but with optimized board representation
   - Time Complexity: O(N!)
   - Space Complexity: O(N²)

Both implementations are tested against known solution counts for different board sizes:
- n=1: 1 solution
- n=2: 0 solutions
- n=3: 0 solutions
- n=4: 2 solutions
- n=5: 10 solutions
- n=6: 4 solutions
- n=7: 40 solutions
- n=8: 92 solutions
- n=9: 352 solutions

The code includes a performance measurement component using Stopwatch to compare the efficiency of both approaches and displays the first solution for each test case as an example.

This is a classic example of using backtracking to solve constraint satisfaction problems.
