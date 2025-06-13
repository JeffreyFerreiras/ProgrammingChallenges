# FizzBuzz

## Problem Description
Write a program that prints the numbers from 1 to N. But for multiples of three, print "Fizz" instead of the number, and for the multiples of five, print "Buzz" instead of the number. For numbers which are multiples of both three and five, print "FizzBuzz".

## Example:
```
Input: N = 15
Output:
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
```

## Constraints:
- 1 <= N <= 10^5

## Solution Approach
The solution uses a straightforward approach to solve the FizzBuzz problem:

1. Iterate through numbers from 1 to N
2. For each number, check if it's divisible by both 3 and 5
   - If yes, print "FizzBuzz"
3. If not, check if it's divisible by 3
   - If yes, print "Fizz"
4. If not, check if it's divisible by 5
   - If yes, print "Buzz"
5. If none of the above conditions are met, print the number itself

The implementation optimizes the check for divisibility by both 3 and 5 by directly checking if the number is divisible by 15 (3*5).

This approach achieves:
- Time Complexity: O(N) where N is the input number
- Space Complexity: O(1) as it uses constant extra space

Despite its simplicity, FizzBuzz is a popular interview question that tests basic programming skills, understanding of conditional logic, and ability to implement a clear solution.