# Extra Long Factorial

## Problem Description
You are given an integer N. Print the factorial of this number.

The factorial of a non-negative integer N, denoted by N!, is the product of all positive integers less than or equal to N. 

For example, 5! = 5 × 4 × 3 × 2 × 1 = 120.

The challenge here is to calculate factorial values for large integers that would normally cause integer overflow.

## Examples:
```
Input: 5
Output: 120

Input: 19
Output: 121645100408832000

Input: 25
Output: 15511210043330985984000000
```

## Constraints:
- 1 ≤ N ≤ 100

## Solution Approach
The solution uses C#'s BigInteger from the System.Numerics namespace to handle arbitrarily large integers:

1. Implement a recursive factorial function using BigInteger
2. For each input value N, calculate N!
3. Return the result as a BigInteger

The recursive implementation is elegantly simple:
- Base case: If N = 1, return 1
- Recursive step: Return N * factorial(N-1)

This approach handles large factorials that would cause overflow with standard integer types. The BigInteger type allows calculations with integers of any size, limited only by available memory.

Time Complexity: O(N) where N is the input number
Space Complexity: O(N) due to the recursive call stack