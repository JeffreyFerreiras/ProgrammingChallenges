# Find Smallest Range

## Problem Description
You have k lists of sorted integers. Find the smallest range that includes at least one number from each of the k lists.

The range [a, b] is smaller than range [c, d] if b-a < d-c or if b-a == d-c and a < c.

## Example:
```
Input:
List 1: [4, 10, 15, 24, 26]
List 2: [0, 9, 12, 20]
List 3: [5, 18, 22, 30]

Output: [20, 24]
Explanation: The range [20, 24] includes 24 from list 1, 20 from list 2, and 22 from list 3.
```

## Constraints:
- The input lists are sorted in ascending order
- 1 <= k <= 3500, where k is the number of lists
- 1 <= list[i].length <= 50, where list[i] is the ith list
- -10^5 <= list[i][j] <= 10^5, where list[i][j] is the jth element in the ith list
- It is guaranteed that there is a range that covers at least one number from each list

## Solution Approach
The solution implements a greedy approach with a sliding window:

1. Start with pointers at the end of each list (largest elements)
2. Calculate the current range [min, max] from the elements at each pointer
3. Track the smallest range found so far
4. Move the pointer of the list that contains the maximum value
5. Repeat until any pointer goes out of bounds

This approach works because:
- We always remove the largest element to try to reduce the range
- By starting with pointers at the end of the lists, we gradually explore all possible ranges

Time Complexity: O(n * log k) where n is the total number of elements across all lists and k is the number of lists
Space Complexity: O(k) for storing the current elements from each list