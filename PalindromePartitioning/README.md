# Palindrome Partitioning

## Problem Description
Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

From LeetCode Problem #131.

## Examples
```
Example 1:
Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]

Example 2:
Input: s = "a" 
Output: [["a"]]
```

## Solution Approach
The implementation provides two different approaches to solve this problem:

### 1. Basic Backtracking Solution
- Use recursion to try all possible partitions
- For each prefix of the remaining string, check if it's a palindrome
- If it is, add it to the current partition and recursively process the remaining string
- Backtrack by removing the last added partition when returning from recursion

### 2. Optimized Solution with Dynamic Programming
- Precompute all palindrome substrings using a 2D DP table
- Use backtracking with this precomputed information to build partitions:
  - For each position, we already know which substrings starting at that position are palindromes
  - Only recurse for valid palindromic prefixes
  
## Performance Comparison
The implementation includes performance measurement for both approaches, showing significant improvements with the DP-based solution, especially for longer strings.

## Key Optimizations
1. **Palindrome Precomputation**:
   - Single characters are always palindromes
   - Check 2-character palindromes directly
   - For longer palindromes, use the relation: `isPalindrome[i][j] = (s[i] == s[j]) && isPalindrome[i+1][j-1]`

2. **Early Pruning**: Only explore branches where the current prefix is a palindrome

## Complexity Analysis
- **Time Complexity**: 
  - Original: O(n·2ⁿ) in worst case
  - Optimized: O(n²) for palindrome precomputation + O(n·2ⁿ) for backtracking
- **Space Complexity**: 
  - Original: O(n) for recursion stack
  - Optimized: O(n²) for the palindrome DP table + O(n) for recursion

This problem demonstrates the value of combining dynamic programming with backtracking for significant performance improvements without changing the core algorithm.