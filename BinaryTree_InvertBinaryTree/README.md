# 226. Invert Binary Tree

## Problem Description
Given the root of a binary tree, invert the tree, and return its root.

Inverting a binary tree means swapping every left node with its right node at every level of the tree.

## Examples:
```
Example 1:
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
Input: root = [2,1,3]
Output: [2,3,1]

Example 3:
Input: root = []
Output: []
```

## Constraints:
- The number of nodes in the tree is in the range [0, 100]
- -100 <= Node.val <= 100

## Solution Approach
The solution implements a recursive approach to invert the binary tree:

1. Base case: If the current node is null, return null
2. For each node:
   - Recursively invert the left subtree
   - Recursively invert the right subtree
   - Swap the left and right child pointers
3. Return the root node

This approach ensures that every node in the tree has its children swapped, resulting in a completely inverted binary tree.

Time Complexity: O(n) where n is the number of nodes in the tree
Space Complexity: O(h) where h is the height of the tree (due to recursion stack)