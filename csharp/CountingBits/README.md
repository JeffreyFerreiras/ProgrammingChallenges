# 338. Counting Bits

## Problem Description
Given an integer `n`, return an array `ans` of length `n + 1` such that for each `i` (0 <= i <= n), `ans[i]` is the number of 1's in the binary representation of `i`.

## Examples:
```
Example 1:
Input: n = 2
Output: [0,1,1]
Explanation:
0 --> 0
1 --> 1
2 --> 10

Example 2:
Input: n = 5
Output: [0,1,1,2,1,2]
Explanation:
0 --> 0
1 --> 1
2 --> 10
3 --> 11
4 --> 100
5 --> 101
```

## Constraints:
- 0 <= n <= 10^5

## Solution Approach
The solution uses a bit manipulation approach to count the number of 1's in each number:

1. Create a result array of size n+1
2. For each number from 0 to n, count the number of 1 bits in its binary representation
3. Use bitwise operations to efficiently count the 1 bits:
   - Use the `&` (AND) operator with 1 to check if the least significant bit is set
   - Use the `>>` (right shift) operator to shift the bits and examine each position

This approach has:
- Time Complexity: O(n log n) since for each of the n+1 numbers, we perform O(log n) operations to count bits
- Space Complexity: O(n) for the result array

The problem also suggests optimizations to achieve O(n) time complexity using dynamic programming techniques, which could be implemented by using previously computed results.