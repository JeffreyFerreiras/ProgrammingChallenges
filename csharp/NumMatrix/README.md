# 304. Range Sum Query 2D - Immutable

## Problem Description
Given a 2D matrix, handle multiple queries to find the sum of elements inside a rectangle defined by its top-left corner (row1, col1) and bottom-right corner (row2, col2).

Implement the NumMatrix class:
- `NumMatrix(int[][] matrix)` initializes the object with the integer matrix.
- `int sumRegion(int row1, int col1, int row2, int col2)` returns the sum of elements in the rectangle with top-left corner (row1, col1) and bottom-right corner (row2, col2).

## Examples:
```
Input:
["NumMatrix", "sumRegion", "sumRegion", "sumRegion"]
[[[[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]], [2, 1, 4, 3], [1, 1, 2, 2], [1, 2, 2, 4]]
Output:
[null, 8, 11, 12]

Explanation:
NumMatrix numMatrix = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
numMatrix.sumRegion(2, 1, 4, 3); // return 8 (i.e. sum of the elements in the rectangle [2,1,4,3])
numMatrix.sumRegion(1, 1, 2, 2); // return 11 (i.e. sum of the elements in the rectangle [1,1,2,2])
numMatrix.sumRegion(1, 2, 2, 4); // return 12 (i.e. sum of the elements in the rectangle [1,2,2,4])
```

## Constraints:
- m == matrix.length
- n == matrix[i].length
- 1 <= m, n <= 200
- -10^5 <= matrix[i][j] <= 10^5
- 0 <= row1 <= row2 < m
- 0 <= col1 <= col2 < n
- At most 10^4 calls will be made to sumRegion.

## Solution Approach
The solution uses a 2D prefix sum approach to optimize region sum queries:

### Preprocessing:
1. Create a 2D array `matrixSum` that is one row and column larger than the input matrix
2. Each cell `matrixSum[i,j]` stores the sum of all elements in the submatrix from (0,0) to (i-1,j-1)
3. The prefix sum is calculated using the formula:
   - `matrixSum[i+1,j+1] = matrixSum[i+1,j] + matrixSum[i,j+1] - matrixSum[i,j] + matrix[i][j]`

### Query:
- To find the sum of elements in a rectangle from (row1,col1) to (row2,col2), use:
  - `matrixSum[row2+1,col2+1] - matrixSum[row1,col2+1] - matrixSum[row2+1,col1] + matrixSum[row1,col1]`

### Time Complexity:
- Constructor: O(m×n) where m and n are the dimensions of the matrix
- sumRegion: O(1) per query

### Space Complexity:
- O(m×n) for the prefix sum matrix

The implementation is highly efficient for multiple queries as each query can be answered in constant time after the preprocessing step.