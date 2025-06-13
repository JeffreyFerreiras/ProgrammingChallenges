# 70. Climbing Stairs

## Problem Description
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

## Examples:
```
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
```

## Constraints:
- 1 <= n <= 45

## Solution Approaches
The solution implements three different approaches to solve the Climbing Stairs problem:

1. **Recursive Approach with Memoization** (`ClimbStairs`):
   - Uses recursion with a Dictionary for caching results
   - Builds the solution from top-down
   - Avoids recalculating the same values multiple times

2. **Dynamic Programming Approach** (`ClimbStairsCopilot`):
   - Uses an array to store intermediate results
   - Builds the solution from bottom-up
   - Eliminates recursion overhead

3. **Optimized Linear Approach** (`ClimbStairsLinear`):
   - Recognizes the problem as a Fibonacci sequence
   - Uses only two variables to track the last two results
   - Most space-efficient solution (O(1) space)

All approaches have O(n) time complexity, but the linear approach is the most efficient in terms of space usage. Performance testing shows the linear approach is fastest for large inputs (e.g., n = 45).