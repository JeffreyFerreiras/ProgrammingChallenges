# 74. Search a 2D Matrix (Rust)

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
- `m == matrix.len()`
- `n == matrix[i].len()`
- `1 <= m, n <= 100`
- `-10^4 <= matrix[i][j], target <= 10^4`
- The matrix satisfies the ordering rules listed above.

## Console Harness
`main.rs` wires several scenarios that exercise both standard and edge cases, and wraps calls to `Solution::search_matrix` in a panic catcher so the binary keeps running while the method remains unimplemented. Each scenario reports:
- Scenario metadata (name, target, expectation, and the matrix itself).
- Method name invoked.
- Execution time in milliseconds with four decimal places.
- The returned value, or a panic message if the solution has not been written yet.

The scenario set mirrors the C# harness with additional tall, wide, and large matrices (including one where the target is intentionally absent).

`Solution::search_matrix` is left as `unimplemented!()` for you to fill in with your algorithm.
