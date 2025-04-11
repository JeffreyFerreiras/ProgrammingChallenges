# 11. Container With Most Water

## Problem Description
You are given an integer array `height` of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

## Examples:
```
Example 1:
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water the container can contain is 49 (between the lines at positions 1 and 8).

Example 2:
Input: height = [1,1]
Output: 1
```

## Constraints:
- n == height.length
- 2 <= n <= 10^5
- 0 <= height[i] <= 10^4

## Solution Approach
The solution uses a two-pointer approach to efficiently find the maximum area:

1. Initialize two pointers, one at the beginning and one at the end of the array
2. Calculate the area between the lines at these two positions
3. Move the pointer pointing to the shorter line inward (since moving the pointer with the taller line would never result in a larger area)
4. Keep track of the maximum area seen so far
5. Continue until the pointers meet

This approach requires only a single pass through the array and has:
- Time Complexity: O(n) where n is the length of the array
- Space Complexity: O(1) as we only use a constant amount of extra space