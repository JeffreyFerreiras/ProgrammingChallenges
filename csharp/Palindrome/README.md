# Palindrome

## Problem Description
Determine if a given string is a palindrome. A palindrome is a string that reads the same backward as forward, ignoring case.

## Examples:
```
Example 1:
Input: "Malayalam"
Output: true
Explanation: "Malayalam" is the same when read backward, ignoring case.

Example 2:
Input: "Racecar"
Output: true
Explanation: "Racecar" is the same when read backward, ignoring case.

Example 3:
Input: "Not a palindrome"
Output: false
Explanation: "Not a palindrome" does not read the same backward.

Example 4:
Input: "" (empty string)
Output: false
Explanation: Empty strings are considered invalid input.

Example 5:
Input: null
Output: false
Explanation: Null strings are considered invalid input.
```

## Solution Approach
The solution uses a two-pointer approach to check if a string is a palindrome:

1. Handle edge cases: null or empty strings return false
2. Compare characters from both ends of the string, moving inward
3. Only need to check half the string (up to the middle character)
4. Use bitwise OR operation with space character (' ') to make comparison case-insensitive

### Implementation Details:
- Bitwise operation `char | ' '` converts uppercase letters to lowercase for comparison
- This works because the ASCII value of space (32) has a bit pattern that sets the 6th bit to 1, which is the bit that differs between uppercase and lowercase letters
- Using bitwise operations avoids the overhead of creating new strings or using string methods like ToLower()

## Complexity Analysis:
- Time Complexity: O(n) where n is the length of the string
- Space Complexity: O(1) as we only use a constant amount of extra space regardless of input size

This elegant solution demonstrates efficient character comparison and bitwise manipulation techniques to solve a common string problem with minimal overhead.