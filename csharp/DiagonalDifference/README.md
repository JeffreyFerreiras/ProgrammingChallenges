# Diagonal Difference

## Problem Description
Given a square matrix of size N, calculate the absolute difference between the sums of its diagonals.

The first line contains a single integer N, representing the size of the square matrix. The next N lines denote the matrix's rows, with each line containing space-separated integers describing the columns.

## Example:
```
Input:
3
11 2 4
4 5 6
10 8 -12

Output:
15

Explanation:
The primary diagonal is: 11, 5, -12
Sum across the primary diagonal: 11 + 5 - 12 = 4

The secondary diagonal is: 4, 5, 10
Sum across the secondary diagonal: 4 + 5 + 10 = 19

Absolute difference: |4 - 19| = 15
```

## Constraints:
- Matrix is square (N x N)
- Matrix size: 1 <= N <= 100
- Matrix elements: -100 <= A[i][j] <= 100

## Solution Approach
The solution implements a straightforward approach to calculate the diagonal difference:

1. Iterate through the matrix once, from 0 to N-1
2. For each index i:
   - Add the value at position [i][i] to the primary diagonal sum
   - Add the value at position [(N-1)-i][i] to the secondary diagonal sum
3. Calculate the absolute difference between the two sums

This single-pass approach achieves:
- Time Complexity: O(N) where N is the size of the matrix
- Space Complexity: O(1) as we only store the sum values

The solution handles potential edge cases like null arrays with appropriate error checking.