# 32. Longest Valid Parentheses

## Problem Description
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

A valid parentheses string is one where every opening parenthesis '(' has a matching closing parenthesis ')' and they are properly nested.

## Examples:
```
Example 1:
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".

Example 2:
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".
```

## Constraints:
- 0 <= s.length <= 3 * 10^4
- s[i] is '(', or ')'

## Solution Approach
This is a challenging problem that can be solved using several approaches:

1. **Stack-based Approach**:
   - Use a stack to track opening parentheses positions
   - Push -1 onto the stack as a base marker
   - For each '(' encountered, push its index onto the stack
   - For each ')' encountered, pop from the stack
   - If the stack becomes empty, push the current index
   - Otherwise, calculate the length of the valid substring (current index - top of stack)
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(n) for the stack

2. **Dynamic Programming Approach**:
   - Use a 1D array to keep track of the length of valid substring ending at each position
   - For each ')', check if there's a matching '(' and update the length accordingly
   - Time Complexity: O(n)
   - Space Complexity: O(n) for the DP array

3. **Two-Pass Approach**:
   - Scan from left to right, tracking open and close parentheses counts
   - When they become equal, update the max length
   - When close count exceeds open count, reset both counts
   - Repeat the scan from right to left (for cases where open exceeds close)
   - Time Complexity: O(n)
   - Space Complexity: O(1)

The implementation includes timing metrics to evaluate performance across different test cases, demonstrating the solution's efficiency.