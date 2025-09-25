# 155. Min Stack

## Problem Description

Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the `MinStack` class:
- `MinStack()` initializes the stack object.
- `void push(int val)` pushes the element `val` onto the stack.
- `void pop()` removes the element on the top of the stack.
- `int top()` gets the top element of the stack.
- `int getMin()` retrieves the minimum element in the stack.

You must implement a solution with `O(1)` time complexity for each function.

## Examples

**Example 1:**
```text
Input
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output
[null,null,null,null,-3,null,0,-2]

Explanation
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin(); // return -3
minStack.pop();
minStack.top();    // return 0
minStack.getMin(); // return -2
```

## Constraints

- `-2^31 <= val <= 2^31 - 1`
- Methods `pop`, `top` and `getMin` operations will always be called on non-empty stacks.
- At most `3 * 10^4` calls will be made to `push`, `pop`, `top`, and `getMin`.

## Solution Approach

This problem can be solved using two approaches:

**Approach 1: Two Stacks**
1. Use one stack for normal operations
2. Use another stack to track minimum values
3. When pushing, also push to min stack if value is <= current minimum
4. When popping, also pop from min stack if the value equals current minimum

**Approach 2: Single Stack with Pairs**
1. Store pairs of (value, current_minimum) in the stack
2. Each element knows the minimum at the time it was pushed
3. All operations become O(1)

## Time Complexity

- O(1) for all operations (push, pop, top, getMin)

## Space Complexity

- O(n) - We store all elements and their minimums
