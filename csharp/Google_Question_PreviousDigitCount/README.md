# Google Question - Look-and-Say Sequence

## Problem Description
Write a program that outputs the next number in the "Look-and-Say" sequence given a previous number. The sequence starts with "1" and each subsequent term is determined by "looking at" and "saying" the previous term.

To generate the next number in the sequence, you read off the digits of the current number, counting the number of consecutive digits, and then representing that as digits. For example, 1 is read as "one 1" which is written as "11". 11 is read as "two 1s" which is written as "21".

## Examples:
```
Starting with 1:
1 → "one 1" → 11
11 → "two 1s" → 21
21 → "one 2, one 1" → 1211
1211 → "one 1, one 2, two 1s" → 111221
111221 → "three 1s, two 2s, one 1" → 312211
```

## Constraints:
- Input is a positive integer
- The sequence follows the "count and say" pattern

## Solution Approaches
The solution implements two equivalent approaches to generate the next number in the sequence:

1. **First Approach** (`GetSequence`):
   - Convert the input integer to a string
   - Iterate through the string, counting consecutive identical digits
   - When a different digit is encountered, append the count and the previous digit to the result
   - Special case: If the input has only one digit, return "1" followed by the digit

2. **Second Approach** (`GetSequence_4_2020`):
   - Similar implementation with slightly different structure
   - Both approaches correctly handle the sequence generation

The algorithm has:
- Time Complexity: O(n) where n is the number of digits in the input
- Space Complexity: O(n) for storing the result string

This problem is a popular interview question that tests string manipulation, pattern recognition, and ability to implement a straightforward algorithm.