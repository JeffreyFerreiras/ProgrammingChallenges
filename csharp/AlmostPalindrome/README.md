# Almost Palindrome

## Problem Description
Given a string S consisting of lowercase English characters, determine if you can make it a palindrome by removing at most 1 character.

A palindrome is a string that reads the same forward and backward.

## Examples:
```
Input: "abca"
Output: true
Explanation: You can remove 'c' to make "aba" which is a palindrome.

Input: "aabbcs"
Output: false
Explanation: You cannot make it a palindrome by removing at most one character.
```

## Constraints:
- The string consists of lowercase English characters
- At most one character can be removed to form a palindrome

## Solution Approach
The solution uses a two-pointer approach to check if the string is an "almost palindrome":

1. Initialize two pointers, one at the beginning and one at the end of the string
2. Move the pointers toward each other, comparing characters at each step
3. If a mismatch is found, try skipping either the character at the left pointer or the right pointer
4. Continue checking if the rest of the string forms a palindrome
5. If any of these attempts results in a palindrome, return true
6. Otherwise, return false

This approach has:
- Time Complexity: O(n) where n is the length of the string
- Space Complexity: O(1) as we only use a constant amount of extra space