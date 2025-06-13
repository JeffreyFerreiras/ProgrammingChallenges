# 322. Coin Change

## Problem Description
You are given an integer array `coins` representing coins of different denominations and an integer `amount` representing a total amount of money.

Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

## Examples:
```
Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0
```

## Constraints:
- 1 <= coins.length <= 12
- 1 <= coins[i] <= 2^31 - 1
- 0 <= amount <= 10^4

## Solution Approaches
The solution provides two different approaches to the Coin Change problem:

1. **Dynamic Programming Approach** (`CoinChange`):
   - Uses a bottom-up DP approach
   - Creates an array where `dp[i]` represents the minimum coins needed to make amount `i`
   - Initializes the array with a value larger than the maximum possible answer
   - For each amount, tries each coin and updates the minimum
   - Time Complexity: O(amount * coins.length)
   - Space Complexity: O(amount)

2. **Greedy Approach** (`CoinChangeX`):
   - Sorts the coins in ascending order
   - Starts with the largest coin and tries to use it as many times as possible
   - Moves to the next largest coin when needed
   - This approach doesn't work for all coin systems (produces incorrect results for some inputs)
   - Only works when the coin system has the "canonical property"

The solution includes comprehensive test cases, including edge cases and larger amounts with various coin denominations.