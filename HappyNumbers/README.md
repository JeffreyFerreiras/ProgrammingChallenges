# 202. Happy Numbers

## Problem Description
A happy number is defined by the following process:
1. Starting with any positive integer, replace the number by the sum of the squares of its digits.
2. Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
3. Those numbers for which this process ends in 1 are happy numbers, while those that do not end in 1 are unhappy numbers.

## Examples:
```
Example 1:
Input: 7
Output: 1 (true)
Explanation: 7 → 49 → 97 → 130 → 10 → 1

Example 2:
Input: 22
Output: 0 (false)
Explanation: 22 → 8 → 64 → 52 → 29 → 85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89 → ...
(Enters a cycle that doesn't include 1)
```

## Constraints:
- Input will be a positive integer

## Solution Approaches
The solution implements two different approaches to determine if a number is happy:

1. **Recursive Approach with Static Cache** (`IsHappyNumber`, from 2016):
   - Recursively calculate the sum of squares of digits
   - Use a static list as a cache to detect cycles
   - Return 1 if the process reaches 1, 0 otherwise
   - Time Complexity: O(log n)
   - Space Complexity: O(log n) for the recursion stack and cycle detection

2. **Iterative Approach with HashSet** (`IsHappy`, from 2022):
   - Iteratively calculate the sum of squares of digits
   - Use a HashSet to detect cycles
   - Return 1 if the process reaches 1, 0 otherwise
   - Time Complexity: O(log n)
   - Space Complexity: O(log n) for cycle detection

Both approaches effectively detect cycles to avoid infinite loops, but the iterative approach with a local HashSet is generally more maintainable than using a static cache.