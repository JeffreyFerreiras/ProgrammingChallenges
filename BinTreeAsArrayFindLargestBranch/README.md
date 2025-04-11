# Binary Tree as Array - Find Largest Branch

## Problem Description
Given a binary tree represented as an array, determine which branch (left or right) has the largest sum of values.

In this representation, a binary tree is stored as an array where:
- Index 0 contains the root node
- For a node at index i, its left child is at index 2i+1 and its right child is at index 2i+2

The problem is to find which branch (starting from the root's left child or right child) has the larger sum of all node values.

## Examples:
```
Input: [3, 6, 2, 9, -1, 10]
Output: "Left"
Explanation: Left branch (6, 9) sum is 15, right branch (2, -1, 10) sum is 11.
```

## Constraints:
- The input array represents a binary tree
- The array may contain negative integers
- If both branches have equal sums, return an empty string

## Solution Approach
The solution takes a simple approach to calculate the sums of the left and right branches:

1. Identify all elements in the left branch (indexes 1, 3, 5, ...)
2. Identify all elements in the right branch (indexes 2, 4, 6, ...)
3. Calculate the sum of each branch
4. Return "Left" if the left branch has a larger sum
5. Return "Right" if the right branch has a larger sum
6. Return an empty string if both branches have equal sums

Time Complexity: O(n) where n is the size of the array
Space Complexity: O(1) as we only use a constant amount of extra space