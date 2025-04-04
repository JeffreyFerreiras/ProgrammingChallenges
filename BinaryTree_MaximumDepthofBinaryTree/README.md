# 104. Maximum Depth of Binary Tree

## Problem Description
Given the `root` of a binary tree, return *its maximum depth*.  
The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

## Example 1:
```
Input: root = [3,9,20,null,null,15,7]
Output: 3
```

## Example 2:
```
Input: root = [1,null,2]
Output: 2
```

## Example 3:
```
Input: root = []
Output: 0
```

## Constraints:
- The number of nodes in the tree is in the range [0, 10⁴].
- -100 <= Node.val <= 100

## Explanation
This problem requires you to traverse the binary tree and find the longest path from the root to any leaf node. Common approaches include depth-first search (DFS) or breadth-first search (BFS).
