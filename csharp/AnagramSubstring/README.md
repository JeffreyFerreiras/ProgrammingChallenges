# Anagram Substring

## Problem Description
Given two strings `a` and `b`, find whether any anagram of string `a` is a sub-string of string `b`.

An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, using all the original letters exactly once.

## Example:
```
Input:
a = "xyz"
b = "afdgzyxksldfm"

Output: true
Explanation: "zyx" is an anagram of "xyz" and is a substring of "afdgzyxksldfm".
```

## Constraints:
- The strings consist of lowercase English letters
- The goal is to determine if any permutation of string a appears within string b

## Solution Approaches
The implementation offers two different approaches:

1. **Brute Force Approach** (O(A × B) time complexity):
   - Check if each character in string `a` is present in string `b`
   - Simple but inefficient for large strings

2. **Optimized Approach** (O(A + B) time complexity):
   - Create a frequency table for characters in string `b`
   - For each character in string `a`, check if it exists in the frequency table
   - If a character is found, decrement its count in the table
   - If any character from string `a` is not found in string `b` with available count, return false
   - Otherwise, return true

The optimized approach uses character frequency counting to efficiently determine if an anagram of string `a` could be a substring of string `b`.