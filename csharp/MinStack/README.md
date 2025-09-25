# Min Stack

Design a stack with constant time retrieval of the minimum element.

## Problem

Implement a stack data structure that supports the following operations:

- `void Push(int val)` – add an element to the top of the stack.
- `void Pop()` – remove the element on the top of the stack.
- `int Top()` – return the top element of the stack.
- `int GetMin()` – return the smallest element currently in the stack.

All operations must run in constant time, and the stack may contain duplicate values.

## Examples

### Example 1

```text
Input:
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output:
[null,null,null,null,-3,null,0,-2]
```

### Example 2

```text
Operations: push(2), push(0), push(3), push(0)
getMin() -> 0
pop()
getMin() -> 0
pop()
getMin() -> 0
pop()
getMin() -> 2
```

## Long Example

```text
Input:
["MinStack","push","push","push","push","push","push","getMin","pop","pop","getMin","top","push","push","getMin"]
[[],[-2],[0],[-3],[4],[-1],[4],[],[],[],[],[],[1],[-2],[]]

Output:
[null,null,null,null,null,null,null,-3,null,null,-2,4,null,null,-3]
```

## Edge Cases

- Pushing multiple values with the same minimum; ensure the minimum is maintained after pops.
- Calling `Pop()` on a single-element stack and then pushing new minima.
- Handling negative numbers, zeros, and positive numbers.
- Long alternating sequences of `Push` and `Pop` operations.

## Notes

A common approach is to maintain an auxiliary stack that tracks the current minimum alongside the main stack.
