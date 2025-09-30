# Serialize and Deserialize Binary Tree

## Problem Statement
Design an algorithm to serialize a binary tree to a string and deserialize the string back to the original tree. Serialization converts the tree into a string representation, and deserialization converts the string back into the same tree structure.

## Examples

**Example 1**
`
Input: root = [1,2,3,null,null,4,5]
Output: "[1,2,3,null,null,4,5]"
`

**Example 2**
`
Input: root = []
Output: "[]"
`

## Constraints
- The number of nodes in the tree is in the range [0, 10^4].
- -1000 <= Node.val <= 1000

## Additional Scenarios
- **Edge Case:** Single node tree → Serialization [7], deserialization returns same structure.
- **Left-heavy Tree:** Ensures serialization preserves explicit 
ull markers for missing right children.
- **Right-heavy Tree:** Checks that deserialization recreates chains on the right.
- **Mixed Nulls:** Trees with alternating missing children verify that order of null tokens is significant.
- **Large Sparse Tree:** Validates approach handles long strings and numerous 
ull placeholders efficiently.
