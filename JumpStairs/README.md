# Jump Stairs

## Problem Description
You are climbing a staircase. It takes n steps to reach the top. Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

## Examples:
```
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
```

## Constraints:
- 1 <= n <= 45

## Solution Approach
The solution recognizes that this problem is essentially a Fibonacci sequence in disguise:

1. For n = 1, there is only 1 way to climb (take 1 step)
2. For n = 2, there are 2 ways to climb (take 1+1 steps or take 2 steps)
3. For n = 3, there are 3 ways to climb (1+1+1, 1+2, or 2+1)
4. For n = 4, there are 5 ways to climb
5. And so on...

The number of ways to climb n stairs is the (n+1)th Fibonacci number.

The implementation uses recursive calls to calculate the Fibonacci numbers:
```csharp
public static long Solution(long n)
{
    if (n <= 1)
        return n;

    return fib(n + 1);
}

static long fib(long n)
{
    if (n <= 1)
        return n;

    return fib(n - 1) + fib(n - 2);
}
```

While this recursive approach correctly solves the problem, it has:
- Time Complexity: O(2^n) due to overlapping subproblems in the recursive calls
- Space Complexity: O(n) for the recursion stack

Note: This implementation could be optimized using memoization (top-down) or a bottom-up approach to achieve O(n) time complexity.