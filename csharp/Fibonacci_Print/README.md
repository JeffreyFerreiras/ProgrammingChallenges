# Fibonacci Sequence Calculator

## Problem Description
Write a function to calculate the nth number in the Fibonacci sequence.

The Fibonacci sequence is defined as a sequence where each number is the sum of the two preceding ones, starting from 0 and 1 (or sometimes 1 and 1).

In this implementation, the sequence starts with 1 and 1, so:
- F(1) = 1
- F(2) = 1 
- F(3) = 2
- F(4) = 3
- F(5) = 5
- ...and so on.

## Examples:
```
Input: n = 8
Output: 21

Input: n = 30
Output: 832040
```

## Constraints:
- 1 <= n <= 45 (for basic implementations)
- Higher values of n may cause integer overflow unless special types are used

## Solution Approaches
The solution implements multiple approaches to calculate Fibonacci numbers:

1. **Basic Recursive Approach** (`BasicFib`):
   - Uses the recursive definition: F(n) = F(n-1) + F(n-2)
   - Simple but highly inefficient for large n due to repeated calculations
   - Time Complexity: O(2^n)
   - Space Complexity: O(n) for the recursion stack

2. **Memoization Approach** (`MemoizedFib`):
   - Improves the recursive approach by caching previously computed values
   - Significantly reduces computation time by avoiding redundant calculations
   - Time Complexity: O(n)
   - Space Complexity: O(n)

3. **Bottom-Up Iterative Approaches** (`BottomUpFib` and `BottomUpFib2`):
   - Uses iteration to build up the solution from the base cases
   - Keeps track of only the two most recent Fibonacci numbers
   - Most efficient in terms of both time and space
   - Time Complexity: O(n)
   - Space Complexity: O(1)

The program includes benchmarking code to compare the performance of different approaches, demonstrating how dramatically performance differs for larger values of n.