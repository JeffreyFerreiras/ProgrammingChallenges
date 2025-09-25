# 150. Evaluate Reverse Polish Notation

## Problem Description

You are given an array of strings `tokens` that represents an arithmetic expression in a Reverse Polish Notation.

Evaluate the expression. Return an integer that represents the value of the expression.

**Note that:**
- The valid operators are `'+'`, `'-'`, `'*'`, and `'/'`.
- Each operand may be an integer or another expression.
- The division between two integers always truncates toward zero.
- There will not be any division by zero.
- The input represents a valid arithmetic expression in a reverse polish notation.
- The answer and all intermediate calculations can be represented in a 32-bit integer.

## Examples

**Example 1:**
```text
Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9
```

**Example 2:**
```text
Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6
```

**Example 3:**
```text
Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5 = 22
```

## Constraints

- `1 <= tokens.length <= 10^4`
- `tokens[i]` is either an operator: `"+"`, `"-"`, `"*"`, `"/"`, or an integer in the range `[-200, 200]`.

## Solution Approach

This problem can be solved using a stack:

1. Use a stack to store operands
2. Iterate through each token:
   - If it's a number, push it onto the stack
   - If it's an operator, pop two operands, perform the operation, and push the result back
3. The final result will be the only element left in the stack

**Key points:**
- Division truncates toward zero (use integer division)
- Order of operands matters for subtraction and division
- Handle negative numbers correctly

## Time Complexity

- O(n) - We visit each token once

## Space Complexity

- O(n) - In the worst case, we store all operands on the stack
