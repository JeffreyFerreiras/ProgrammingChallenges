# 191. Number of 1 Bits

## Problem Description
Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).

**Note:**
- In some languages, such as Java, there is no unsigned integer type. In this case, the input will be given as a signed integer type. It should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
- In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 3, the input represents the signed integer -3.

## Examples:
```
Example 1:
Input: n = 00000000000000000000000000001011
Output: 3
Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.

Example 2:
Input: n = 00000000000000000000000010000000
Output: 1
Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.

Example 3:
Input: n = 11111111111111111111111111111101
Output: 31
Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.
```

## Constraints:
- The input must be a binary string of length 32.

## Solution Approach
The solution uses a bit manipulation approach to count the number of 1 bits:

1. Initialize a counter to 0
2. Iterate while the input number is greater than 0:
   - Check if the least significant bit (LSB) is 1 by ANDing with 1
   - If the LSB is 1, increment the counter
   - Right shift the number by 1 bit to check the next bit
3. Return the final count

This approach:
- Time Complexity: O(log n) or O(1) since we're dealing with 32-bit integers
- Space Complexity: O(1)

The implementation also includes debug output showing the binary representation of the number after each right shift operation.

## Follow-up Question
If this function is called many times, how would you optimize it?

Possible optimizations:
1. Use a lookup table for small numbers or bit patterns
2. Use Brian Kernighan's algorithm: `n & (n-1)` to clear the least significant set bit
3. Use built-in functions like `__builtin_popcount()` in C++ or `Integer.bitCount()` in Java
4. Cache results for previously seen inputs