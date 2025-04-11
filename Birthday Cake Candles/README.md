# Birthday Cake Candles

## Problem Description
Colleen is turning n years old! She has n candles of various heights on her cake, and each candle has a specific height.

Because the taller candles tower over the shorter ones, Colleen can only blow out the tallest candles.

Given the height for each individual candle, find and print the number of candles she can successfully blow out (i.e., the number of candles that are of maximum height).

## Example:
```
Input: n = 4, ar = [3, 2, 1, 3]
Output: 2
Explanation: Colleen can blow out only the tallest candles, and there are 2 candles with height 3 (the maximum height).
```

## Constraints:
- 1 ≤ n ≤ 10^5
- 1 ≤ ar[i] ≤ 10^7

## Solution Approach
The solution uses a single pass through the array to find both the maximum height and count how many candles have that height:

1. Initialize variables to track the tallest candle's height and count
2. Iterate through the array once:
   - If the current candle is taller than the tallest found so far, update the tallest height and reset the count to 1
   - If the current candle is the same height as the tallest, increment the count
3. Return the final count of the tallest candles

Time Complexity: O(n) where n is the number of candles
Space Complexity: O(1) as we only use a constant amount of extra space