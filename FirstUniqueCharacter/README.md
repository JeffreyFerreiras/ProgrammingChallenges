# 387. First Unique Character in a String

## Problem Description
Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.

## Examples:
```
Example 1:
Input: s = "leetcode"
Output: 0
Explanation: The first non-repeating character is 'l', which appears at index 0.

Example 2:
Input: s = "loveleetcode"
Output: 2
Explanation: The first non-repeating character is 'v', which appears at index 2.

Example 3:
Input: s = "cc"
Output: -1
Explanation: There are no non-repeating characters in the string.
```

## Constraints:
- 1 <= s.length <= 10^5
- s consists of only lowercase English letters

## Solution Approaches
The solution provides two different approaches:

1. **HashSet Approach** (Non-optimal):
   - Use a HashSet to track characters that have already been seen
   - For each character, check if it appears again in the rest of the string
   - If a character doesn't appear again, return its index
   - Time Complexity: O(n²) in the worst case
   - Space Complexity: O(k) where k is the number of unique characters

2. **Frequency Array Approach** (Optimal):
   - Create an array of size 26 to store the frequency of each lowercase letter
   - First pass: Count the occurrences of each character
   - Second pass: Find the first character with a frequency of 1
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(1) as the array size is constant (26)

The optimal solution makes use of the constraint that the string contains only lowercase English letters, which allows for a more efficient frequency-counting approach.