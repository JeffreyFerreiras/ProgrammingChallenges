# 74. Search a 2D Matrix (C#)

## Problem
You are given an `m x n` integer matrix `matrix` with the following properties:
- Each row is sorted in non-decreasing order.
- The first integer of each row is greater than the last integer of the previous row.

Given an integer `target`, return `true` if `target` is in `matrix` or `false` otherwise.

### Examples (from LeetCode)
**Example 1**
```
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true
```

**Example 2**
```
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false
```

### Constraints
- `m == matrix.length`
- `n == matrix[i].length`
- `1 <= m, n <= 100`
- `-10^4 <= matrix[i][j], target <= 10^4`
- The properties described above hold for `matrix`.

## Console Harness
`Program.cs` enumerates a set of representative scenarios, times each call to `Solution.SearchMatrix`, and prints:
- Scenario name and inputs.
- Method name invoked.
- Execution time in milliseconds with four decimal digits of precision.
- The returned result (if available) and the expected outcome.

The sample set covers:
- The official examples.
- Single-cell matrices with and without the target.
- An empty row edge case.
- Tall and wide matrices.
- Two large matrices to exercise long-running searches (one where the target exists and one where it does not).

`Solution.SearchMatrix` is intentionally left unimplemented so you can focus on writing the algorithm.
