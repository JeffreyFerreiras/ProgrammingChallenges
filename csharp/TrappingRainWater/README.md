# Trapping Rain Water

Compute the amount of rainwater that can be trapped between bars in an elevation map represented by a list of non-negative integers.

## Problem

Given `height`, an array of non-negative integers where each represents the height of a bar, compute how much water can be trapped after raining.

## Examples

### Example 1

```text
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
```

### Example 2

```text
Input: height = [4,2,0,3,2,5]
Output: 9
```

## Long Example

```text
Input: height = [4,2,0,3,2,5,0,1,2,3,1,2,1,4,2,2,5]
Output: 26
Explanation: Multiple basins accumulate water between taller boundaries leading to a total of 26 units trapped.
```

## Edge Cases

- Arrays with length less than 3 cannot trap water.
- Strictly increasing or strictly decreasing arrays result in zero trapped water.
- Large flat plateaus with dips only at the ends.
- Arrays containing zeros interspersed with tall bars.
- Very large inputs where O(n) solutions are required to avoid timeouts.

## Notes

Common approaches include two-pointer sweeps, prefix/suffix maxima arrays, and monotonic stacks.
