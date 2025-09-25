# Valid Parentheses

Determine if a string containing only bracket characters is valid. A string is valid if every opening bracket has a corresponding closing bracket of the same type and the brackets are properly nested.

## Problem

Given a string `s` consisting of characters `'('`, `')'`, `'{'`, `'}'`, `'['`, and `']'`, return `true` if the string is valid and `false` otherwise.

Validity conditions:

- Open brackets must be closed by the same type of brackets.
- Open brackets must be closed in the correct order.
- Every closing bracket must match a previous opening bracket.

## Examples

### Example 1

```text
Input: s = "()"
Output: true
```

### Example 2

```text
Input: s = "()[]{}"
Output: true
```

### Example 3

```text
Input: s = "(]"
Output: false
```

## Long Example

```text
Input: s = "{[()]}[{}](([])){()}"
Output: true
Explanation: Each opening symbol is correctly matched and the overall structure is properly nested.
```

## Edge Cases

- Empty string should return `true` (no unmatched brackets).
- Single closing bracket without a prior opening bracket should return `false`.
- Strings like `"([)]"` where closing order mismatches should return `false`.
- Long sequences with repeated patterns, e.g., thousands of `'('` followed by thousands of `')'`.
- Mixed nesting depths, e.g., `"[{({[]})}]"`.

## Notes

A standard solution uses a stack to track opening brackets and matches them as closing brackets appear.
