# One Edit Away

## Problem Description
There are three types of edits that can be performed on strings:
1. Insert a character
2. Remove a character
3. Replace a character

Given two strings, write a function to check if they are one (or zero) edits away from each other.

## Examples:
```
Example 1:
Input: source = "pale", target = "ple"
Output: true
Explanation: We can remove one character from "pale" to get "ple".

Example 2:
Input: source = "pale", target = "bale"
Output: true
Explanation: We can replace one character in "pale" to get "bale".

Example 3:
Input: source = null, target = ""
Output: false
Explanation: Null string is not valid.

Example 4:
Input: source = "", target = ""
Output: true
Explanation: Zero edits needed as they're already identical.
```

## Solution Approach
The solution divides the problem into different cases based on the length difference between the two strings:

1. **Zero length difference (same length)**:
   - Only a character replacement is possible
   - Iterate through both strings in parallel
   - Allow at most one character mismatch

2. **One length difference**:
   - This indicates a possible character insertion or removal
   - Identify the longer and shorter strings
   - Iterate through both strings, allowing the longer string to "skip" one position
   - If more than one skip is needed, return false

3. **More than one length difference**:
   - Immediately return false as this would require more than one edit

### Edge Cases:
- Handle null strings by returning false
- Identical strings require zero edits, so return true

## Complexity Analysis:
- Time Complexity: O(min(m, n)) where m and n are the lengths of the two strings
- Space Complexity: O(1) as only a constant amount of extra space is used

This problem demonstrates string manipulation techniques and careful handling of edge cases in character comparison operations.