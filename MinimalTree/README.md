# Minimal Tree

## Problem Description
Given a sorted (increasing order) array of unique integer elements, write an algorithm to create a binary search tree with minimal height.

A binary search tree with minimal height is a balanced tree where the height of the two subtrees of any node differs by no more than 1 and both subtrees are also balanced binary search trees.

## Example:
```
Input: [1, 2, 3, 4, 5, 6, 7]
Output: A balanced binary search tree with the following structure:
       4
     /   \
    2     6
   / \   / \
  1   3 5   7
```

## Solution Approach
The solution utilizes a recursive approach to create a balanced binary search tree:

1. Find the middle element of the array to use as the root
2. Recursively build the left subtree using the left half of the array
3. Recursively build the right subtree using the right half of the array

This approach:
- Ensures the tree is balanced because we always pick the middle element as the root
- Results in a tree with minimal height (log n)
- Maintains the binary search tree property since the array is sorted

The implementation includes:
- A `BinTree` class that represents the binary search tree
- A `Node` class that represents individual nodes in the tree
- A static `Create` method that builds the entire tree from an array
- An `AddSorted` helper method that recursively constructs the tree
- An `InOrder` traversal method that visits elements in ascending order

Performance:
- Time Complexity: O(n) where n is the number of elements in the array
- Space Complexity: O(log n) for the recursive call stack in a balanced tree

The solution also includes random test data generation and performance measurement using a Stopwatch.

Note: There appears to be a deliberate division by zero in the test code which would cause a runtime error. This line (`f = f / 0;`) should be removed for proper execution.