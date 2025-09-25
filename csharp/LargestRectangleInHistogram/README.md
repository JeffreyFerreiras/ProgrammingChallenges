# Largest Rectangle in Histogram

Find the maximum area of a rectangle formed within a histogram whose bar heights are given by an array of non-negative integers.

## Problem

Given an integer array `heights` where each element represents the height of a bar in a histogram (with unit width), return the area of the largest rectangle that can be formed using contiguous bars.

## Examples

### Example 1

```text
Input: heights = [2,1,5,6,2,3]
Output: 10
Explanation: The rectangle spanning bars with heights 5 and 6 yields area 10 (width 2).
```

### Example 2

```text
Input: heights = [2,4]
Output: 4
```

## Long Example

```text
Input: heights = [1,3,2,1,2,1,5,3,4,2]
Output: 8
Explanation: Max area is achieved by heights [3,4] with width 2 -> 3*2 = 6, and by heights [2,1,2,1,5] forming area 8 using the stack strategy.
```

## Edge Cases

- Single-bar histogram, e.g., `[5]` → area 5.
- Monotonically increasing or decreasing arrays such as `[1,2,3,4,5]` and `[5,4,3,2,1]`.
- Arrays containing zeros which reset contiguous spans, e.g., `[0,1,0,1]`.
- Very large arrays requiring O(n) solutions; naive O(n²) approaches time out.
- All bars zero, e.g., `[0,0,0]` → area 0.

## Notes

Efficient solutions typically use a stack to maintain indices of increasing bar heights or apply divide and conquer with segment trees.
