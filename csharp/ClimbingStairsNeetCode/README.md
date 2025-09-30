# Climbing Stairs

## Problem Statement
You are climbing a staircase. It takes 
 steps to reach the top. Each time you can climb either 1 or 2 steps. Return the number of distinct ways you can climb to the top.

## Examples

**Example 1**
`
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
`

**Example 2**
`
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
`

## Constraints
- 1 <= n <= 45

## Additional Scenarios
- **Edge Case:** 
 = 1 → Only one way to climb.
- **Larger Input:** 
 = 10 → The answer should be 89 (Fibonacci sequence behavior).
- **Even n:** 
 = 8 → Ways = 34, ensuring pattern recognition for higher inputs.
- **Performance Check:** 
 = 45 → Largest allowable value; confirm solution handles upper bound.
