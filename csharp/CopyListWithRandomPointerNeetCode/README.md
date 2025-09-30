# 138. Copy List With Random Pointer (NeetCode)

Clone a linked list where each node has an additional andom pointer that can reference any node (or null). Return the head of a deep copy so the original and cloned lists share no nodes while preserving both 
ext and andom relationships.

## Examples
`	ext
Input: nodes = [(7,null),(13,0),(11,4),(10,2),(1,0)]
Output: [(7,null),(13,0),(11,4),(10,2),(1,0)]

Input: nodes = [(1,1),(2,1)]
Output: [(1,1),(2,1)]
`

## Long Example
`	ext
Input: nodes = [(1,3),(2,0),(3,null),(4,2),(5,1),(6,4)]
Output: [(1,3),(2,0),(3,null),(4,2),(5,1),(6,4)]
`

## Edge Cases
- Random pointers may be null or self-referential.
- Multiple nodes can share the same random destination.
- Maintain the original random topology even when values repeat.
- The algorithm must run in linear time with constant extra space if using node weaving.

*Implementation is intentionally left as an exercise in Solution.cs.*
