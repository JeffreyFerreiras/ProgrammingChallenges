# 3. Longest Substring Without Repeating Characters

## Problem Description
Given a string `s`, find the length of the longest substring without repeating characters.

## Examples:
```
Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
```

## Constraints:
- 0 <= s.length <= 5 * 10^4
- s consists of English letters, digits, symbols and spaces.

## Solution Approach
The solution uses a sliding window approach with a hash set or dictionary:

1. Maintain a sliding window with two pointers (left and right)
2. Use a set or dictionary to track characters in the current window
3. Expand the window to the right (adding characters) as long as there are no duplicates
4. When a duplicate is found, contract the window from the left until the duplicate is removed
5. Track the maximum window size throughout the process

This approach achieves:
- Time Complexity: O(n) where n is the length of the string
- Space Complexity: O(min(m, n)) where m is the size of the character set

The sliding window technique efficiently handles this problem because:
- It allows us to consider all possible substrings
- The set/dictionary provides O(1) lookup to check for duplicates
- We never need to reconsider already processed characters