# 125. Valid Palindrome

## Problem Description
Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring case.

Note: For the purpose of this problem, we define an empty string as a valid palindrome.

## Examples:
```
Example 1:
Input: "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome when considering only alphanumeric characters and ignoring case.

Example 2:
Input: "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
```

## Constraints:
- s consists only of printable ASCII characters

## Solution Approaches
The solution implements two different approaches to check if a string is a palindrome:

1. **Preprocessing and Two-Pointer Approach** (`IsPalindrome`):
   - First preprocess the string:
     - Remove all non-alphanumeric characters
     - Convert all characters to lowercase
   - Then use a two-pointer technique to check if the string is a palindrome:
     - Start with pointers at the beginning and end
     - Compare characters and move pointers inward
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(n) for storing the processed string

2. **In-place Two-Pointer Approach** (`IsPalindrome2`):
   - Convert the string to lowercase
   - Use two pointers (left and right) starting from the ends of the string
   - Skip non-alphanumeric characters
   - Compare alphanumeric characters as the pointers move toward each other
   - Return false if any mismatch is found
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(1) as it processes the string in-place without creating a new string

The second approach is more efficient in terms of space complexity as it doesn't require creating a new string for the comparison.