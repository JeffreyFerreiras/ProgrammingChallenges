# 5. Longest Palindromic Substring

## Problem Description
Given a string `s`, return the longest palindromic substring in `s`.

A palindrome is a string that reads the same backward as forward, e.g., "madam" or "racecar".

## Examples:
```
Example 1:
Input: s = "babad"
Output: "bab" (Note: "aba" is also a valid answer)

Example 2:
Input: s = "cbbd"
Output: "bb"

Example 3:
Input: s = "a"
Output: "a"

Example 4:
Input: s = "ac"
Output: "a" (Note: "c" would also be a valid answer)
```

## Constraints:
- 1 <= s.length <= 1000
- s consists of only digits and English letters

## Solution Approach
The solution uses an "expand around center" technique:

1. Iterate through each position in the string
2. For each position, check two types of possible palindromes:
   - Odd-length palindromes centered at the current position
   - Even-length palindromes centered between the current position and the next
3. Expand outward from the center while characters match
4. Track the longest palindrome found

This approach is efficient because:
- It avoids the need for extra space required by dynamic programming
- It handles both odd and even length palindromes
- Time Complexity: O(n²) where n is the length of the string
- Space Complexity: O(1) as it only needs to store a few variables

The implementation includes timing metrics to evaluate performance across different test cases, demonstrating the solution's efficiency.