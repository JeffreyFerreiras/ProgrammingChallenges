# Validate Binary Search Tree

## Problem Statement
Given the root of a binary tree, determine if it is a valid binary search tree (BST). A BST is valid if every node's left subtree contains values less than the node's value, every node's right subtree contains values greater than the node's value, and both subtrees are also BSTs.

## Examples

**Example 1**
`
Input: root = [2,1,3]
Output: true
`

**Example 2**
`
Input: root = [5,1,4,null,null,3,6]
Output: false
`

## Constraints
- The number of nodes in the tree is in the range [0, 10^4].
- -2^31 <= Node.val <= 2^31 - 1

## Additional Scenarios
- **Edge Case:** Empty tree → Valid BST by definition.
- **Single Node:** oot = [8] → Valid BST.
- **Equal Values:** oot = [2,2,2] → Not valid because duplicates violate BST property.
- **Violating Deep Node:** oot = [10,5,15,null,null,6,20] → Not valid as value 6 is in the right subtree of 10 but less than 10.
- **Large Valid Tree:** Increasing sequence inserted into BST should remain valid with in-order traversal strictly increasing.
