# 21. Merge Two Sorted Lists (NeetCode)

Given two sorted linked lists, stitch them into one sorted list by choosing the lowest head node at each step. The merged list must reuse the original nodes and remain sorted in non-decreasing order.

## Examples
`	ext
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Input: list1 = [], list2 = []
Output: []
`

## Long Example
`	ext
Input: list1 = [0,2,4,6,8,10], list2 = [1,3,5,7,9,11]
Output: [0,1,2,3,4,5,6,7,8,9,10,11]
`

## Edge Cases
- One input list may be empty; return the other list verbatim.
- All values in one list may be smaller than the other, so append the remainder efficiently.
- Duplicate values must be preserved in the merged order.
- Large lists require O(1) auxiliary space and linear time.

*Implementation is intentionally left as an exercise in Solution.cs.*
