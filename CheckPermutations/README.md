# Check Permutations

## Problem Description
Given two strings, write a method to decide if one is a permutation of the other.

A permutation is a rearrangement of letters. For example, "acto tac" is a permutation of "taco cat".

## Examples:
```
Input: "taco cat", "acto tac"
Output: true

Input: "taco cat", "taco ca"
Output: false
Explanation: Different number of characters

Input: "taco cat", ""
Output: false
Explanation: Empty string is not a permutation
```

## Constraints:
- Strings may contain spaces and other non-letter characters
- Only letter characters (a-z, A-Z) are considered in determining permutation
- Case-insensitive (e.g., 'A' is considered the same as 'a')

## Solution Approach
The solution implements a character counting approach:

1. Create a character frequency table for each string, tracking only the letters
2. Compare the frequency tables - if they match, one string is a permutation of the other
3. Ignore non-letter characters
4. Handle case-insensitivity by converting all characters to the same case

The implementation uses:
- A helper function to build a frequency table (counting each letter's occurrences)
- A 26-element integer array to represent the frequency of each letter in the alphabet
- Bitwise OR with space character (`c | ' '`) to convert uppercase letters to lowercase

This approach has:
- Time Complexity: O(n) where n is the length of the string
- Space Complexity: O(1) as we use a fixed-size array (26 letters)