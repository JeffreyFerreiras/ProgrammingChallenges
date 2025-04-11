# Pairs

## Problem Description
Given an array of N integers, count the number of pairs of integers whose difference is exactly K.

## Examples:
```
Example 1:
Input: 
Array: [1, 5, 3, 4, 2]
K: 2
Output: 3
Explanation: The pairs with difference 2 are (1,3), (3,5), and (2,4)

Example 2:
Input:
Array: [1, 5, 3, 4, 2]
K: 3
Output: 2
Explanation: The pairs with difference 3 are (1,4) and (2,5)
```

## Solution Approach
The solution uses a HashSet for O(1) lookups to efficiently find pairs with the required difference:

1. Create a HashSet containing all elements from the input array
2. For each element in the array, check if there exists another element that differs by exactly K
3. If such an element exists, increment the count

This approach is much more efficient than the brute force method, which would require checking all possible pairs with O(n²) time complexity.

### Implementation Details:
- For each element `x` in the array, we check if `x - k` exists in the HashSet
- This approach handles finding both pairs where the current element is larger and where it's smaller

### Key Insight:
We only need to check in one direction (looking for `arr[i] - k` rather than both `arr[i] - k` and `arr[i] + k`) because if a pair (a,b) satisfies the condition, we'll find it when we process b by looking for b-k.

## Complexity Analysis:
- Time Complexity: O(n) where n is the number of elements in the array
- Space Complexity: O(n) for the HashSet storage

This problem demonstrates how to use a HashSet to transform a potentially O(n²) problem into an O(n) solution by trading space complexity for time efficiency.