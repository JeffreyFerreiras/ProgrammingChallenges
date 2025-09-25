# 84. Largest Rectangle in Histogram

## Problem Description

Given an array of integers `heights` representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.

## Examples

**Example 1:**

```text
Input: heights = [2,1,5,6,2,3]
Output: 10
Explanation: The above is a histogram where width of each bar is 1.
The largest rectangle is shown in the red area, which has an area = 10 units.
```

**Example 2:**

```text
Input: heights = [2,4]
Output: 4
Explanation: The largest rectangle is shown in the red area, which has an area = 4 units.
```

## Constraints

- `1 <= heights.length <= 10^5`
- `0 <= heights[i] <= 10^4`

## Solution Approach

This problem can be solved using a stack:

1. Use a stack to keep track of indices of bars
2. For each bar, if it's taller than the bar at the top of the stack, push its index
3. If it's shorter, pop from the stack and calculate the area of the rectangle formed by the popped bar
4. The width of the rectangle is the difference between current index and the new top of stack
5. Continue until we find a bar shorter than current or stack is empty
6. Push current index to stack
7. After processing all bars, pop remaining bars and calculate their areas

**Key insight:** For each bar, we want to find the largest rectangle that includes that bar as the shortest bar.

## Time Complexity

- O(n) - Each bar is pushed and popped at most once

## Space Complexity

- O(n) - Stack can contain at most n elements
