# Palindrome Permutations

## Problem Description
Given a string, determine if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. The palindrome does not need to be limited to dictionary words.

## Examples:
```
Example:
Input: "Tact Coa"
Output: true
Explanation: Permutations include "taco cat" and "atco cta", which are palindromes.
```

## Solution Approach
The key insight is that a string can be rearranged to form a palindrome if and only if it has at most one character that appears an odd number of times. This is because:
- Characters in a palindrome mirror across the center
- Each character must have a matching character on the opposite side
- At most one character (in the middle) can appear an odd number of times

The solution implements this logic in three steps:
1. Build a frequency table for each character in the string (ignoring spaces)
2. Check that at most one character has an odd frequency count
3. If this condition is met, the string can be rearranged into a palindrome

### Implementation Details:
- The `BuildCharTable` method counts the frequency of each letter
- The `CheckMaxOneOdd` method verifies that at most one character has an odd count
- Spaces are ignored when building the frequency table
- The implementation handles both uppercase and lowercase letters

## Complexity Analysis:
- Time Complexity: O(n) where n is the length of the string
- Space Complexity: O(1) as the character table has a fixed size (26 for lowercase English letters)

This solution elegantly demonstrates how understanding the properties of palindromes can lead to an efficient algorithm without needing to generate all possible permutations.