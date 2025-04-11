# Sum Numbers 1 to N (Excluding Multiples of 5 and 7)

## Problem Description
Write a program that, given an integer n, sums all the numbers from 1 through n (both inclusive). Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.

## Examples
**Example:**
```
Input: 10
Output: 27
Explanation: Sum of numbers from 1 to 10, excluding 5, 7, and 10: 1 + 2 + 3 + 4 + 6 + 8 + 9 = 33
```

## Solution Approaches
This project demonstrates three different approaches to solving the problem:

1. **LINQ Approach**: Using C# LINQ's Enumerable.Range and Sum methods
   - One-liner solution that leverages functional programming techniques
   - Concise but may be less readable for those unfamiliar with LINQ

2. **Iterative Approach**: Using a standard for loop with a conditional check
   - Most efficient solution in terms of performance
   - Easy to read and understand
   - Considered the ideal solution by the author

3. **Recursive Approach**: Using recursion to build the sum
   - Demonstrates a functional programming approach
   - Potential for stack overflow with very large inputs
   - Elegant but less performant than the iterative solution

All three solutions have:
- Time Complexity: O(n) where n is the input integer
- Space Complexity: O(1) for iterative approach, O(n) for recursive approach due to call stack