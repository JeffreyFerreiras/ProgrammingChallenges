# Construct Binary Tree from Preorder and Inorder Traversal

## Problem Statement
Given two integer arrays preorder and inorder, where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

## Examples

**Example 1**
`
Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
Output: [3,9,20,null,null,15,7]
`

**Example 2**
`
Input: preorder = [-1], inorder = [-1]
Output: [-1]
`

## Constraints
- 1 <= preorder.length <= 3000
- inorder.length == preorder.length
- -3000 <= preorder[i], inorder[i] <= 3000
- preorder and inorder consist of unique values.
- Every value of inorder also appears in preorder.

## Additional Scenarios
- **Edge Case:** Single node tree where both traversals have one element.
- **Left Skewed Tree:** Preorder decreasing sequence with inorder reversed yields a chain leaning left.
- **Right Skewed Tree:** Preorder ascending sequence with inorder matching yields right-leaning tree.
- **Balanced Tree:** Preorder and inorder representing a perfect binary tree ensures reconstruction handles balanced splits.
- **Large Input:** Traversals of length 3000 stress the recursive stack and dictionary lookups.
