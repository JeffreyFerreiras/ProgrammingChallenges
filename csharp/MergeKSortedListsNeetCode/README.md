# 23. Merge K Sorted Lists (NeetCode)

Combine k sorted linked lists into a single sorted list. The expected solution uses a min-heap or divide-and-conquer merge to achieve O(N log k) time while reusing nodes.

## Examples
`	ext
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]

Input: lists = []
Output: []
`

## Long Example
`	ext
Input: lists = [[0,5,10,15],[1,6,11,16],[2,7,12,17],[3,8,13,18],[4,9,14,19]]
Output: [0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19]
`

## Edge Cases
- Some lists may be empty; ignore them gracefully.
- Duplicate values across lists should all appear in the merged result.
- Extremely long lists benefit from a heap-based approach to avoid quadratic performance.
- Free any temporary dummy nodes created during the merge.

*Implementation is intentionally left as an exercise in Solution.cs.*
