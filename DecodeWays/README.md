# 91. Decode Ways

## Problem Description
A message containing letters from A-Z can be encoded into numbers using the following mapping:
- 'A' -> "1"
- 'B' -> "2"
- ...
- 'Z' -> "26"

To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse of the mapping above. Note that the grouping of digits is not unique.

Given a string `s` containing only digits, return the number of ways to decode it.

## Examples:
```
Example 1:
Input: s = "12"
Output: 2
Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).

Example 2:
Input: s = "226"
Output: 3
Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

Example 3:
Input: s = "06"
Output: 0
Explanation: "06" cannot be mapped to "F" because the leading zero makes it ambiguous. A valid encoding starts with a non-zero digit.
```

## Constraints:
- 1 <= s.length <= 100
- s contains only digits and may contain leading zeros

## Solution Approaches
The solution implements two different approaches:

1. **Memoization Approach** (`Solution_Memoization`):
   - Uses recursion with memoization to avoid redundant calculations
   - Breaks the problem into subproblems and caches results
   - Handles edge cases like strings starting with '0'
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(n) for the memoization cache

2. **Iterative Approach** (`Solution_Iterative`):
   - Uses dynamic programming with a bottom-up approach
   - Maintains a DP array where dp[i] = number of ways to decode the substring s[0...i]
   - Handles edge cases efficiently
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(n) for the DP array

The implementation includes benchmarking to compare the performance of both approaches across different test cases.