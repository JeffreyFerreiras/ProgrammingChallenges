# 20. Valid Parentheses

## Problem Description

Given a string `s` containing just the characters `'('`, `')'`, `'{'`, `'}'`, `'['` and `']'`, determine if the input string is valid.

An input string is valid if:
1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.
3. Every close bracket has a corresponding open bracket of the same type.

## Examples

**Example 1:**
```text
Input: s = "()"
Output: true
```

**Example 2:**
```text
Input: s = "()[]{}"
Output: true
```

**Example 3:**
```text
Input: s = "(]"
Output: false
```

**Example 4:**
```text
Input: s = "([)]"
Output: false
```

**Example 5:**
```text
Input: s = "{[]}"
Output: true
```

## Constraints

- `1 <= s.length <= 10^4`
- `s` consists of parentheses only `'()[]{}'`.

## Solution Approach

This problem can be solved using a stack:

1. Use a stack to keep track of opening brackets
2. When we encounter an opening bracket, push it onto the stack
3. When we encounter a closing bracket, check if it matches the most recent opening bracket
4. If it matches, pop from the stack; if not, return false
5. At the end, the stack should be empty for a valid string

## Time Complexity

- O(n) - We visit each character once

## Space Complexity

- O(n) - In the worst case, we store all opening brackets on the stack
