# 22. Generate Parentheses

## Problem Description

Given `n` pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

## Example

**Example 1:**

```text
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
```

**Example 2:**

```text
Input: n = 1
Output: ["()"]
```

## Constraints

- `1 <= n <= 8`

## Solution Approach

This problem can be solved using backtracking:

1. Use recursion to build valid parentheses combinations
2. Keep track of the number of open and close parentheses used
3. Add an open parenthesis when we haven't used all `n` open parentheses
4. Add a close parenthesis when the number of close parentheses is less than open parentheses
5. When we have used `n` open and `n` close parentheses, we have a valid combination

## Time Complexity

- O(4^n / √n) - This is the nth Catalan number, which represents the number of valid parentheses combinations

## Space Complexity

- O(4^n / √n) - Space for storing all valid combinations