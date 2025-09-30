# Lowest Common Ancestor of a Binary Search Tree

## Problem Statement
Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes p and q. The LCA is defined as the lowest node in the tree that has both p and q as descendants (a node can be a descendant of itself).

## Examples

**Example 1**
`
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6
`

**Example 2**
`
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2
`

## Constraints
- The number of nodes in the tree is in the range [2, 10^5].
- -10^9 <= Node.val <= 10^9
- All Node.val are unique.
- p and q will exist in the tree.

## Additional Scenarios
- **Edge Case:** p equals q → LCA is that node itself.
- **Root as Ancestor:** When one node is the root, LCA is the root.
- **Left-heavy BST:** oot = [5,3,null,2,null,1] with p = 1, q = 3 → LCA is 3.
- **Right-heavy BST:** oot = [5,null,8,null,10,null,12] with p = 8, q = 12 → LCA is 8.
- **Deep Nodes:** Large BST where p and q share an ancestor several levels above still resolves correctly.
