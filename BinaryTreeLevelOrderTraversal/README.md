# 102. Binary Tree Level Order Traversal

## Problem Description
Given the root of a binary tree, return the level order traversal of its nodes' values (i.e., from left to right, level by level).

A level order traversal visits all nodes at the current depth before moving to nodes at the next depth level.

## Examples:
```
Example 1: Balanced Tree with 7 nodes
Input: root = [1,2,3,4,5,6,7]
Output: 
[
  [1],
  [2,3],
  [4,5,6,7]
]

Example 2: Unbalanced Tree with 5 nodes
Input: root = [1,2,null,4,null,5]
Output: 
[
  [1],
  [2],
  [4],
  [5]
]

Example 3: Empty Tree
Input: root = []
Output: []
```

## Constraints:
- The number of nodes in the tree is in the range [0, 1000]
- -1000 <= Node.val <= 1000

## Solution Approach
The solution implements a breadth-first search (BFS) traversal of the binary tree:

1. Use a queue to process nodes level by level
2. For each level:
   - Determine the number of nodes at the current level
   - Process all nodes at the current level and add their values to the current level's list
   - Enqueue their children (if any) for processing in the next level

Performance metrics:
- Time Complexity: O(n) where n is the number of nodes in the tree
- Space Complexity: O(n) for storing the queue and result

The solution efficiently handles different tree structures:
- Balanced trees
- Unbalanced trees
- Empty trees