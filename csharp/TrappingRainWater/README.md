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

**Visual representation:**

```text
            █
            █ ░ █ █
            █ ░ █ █
            █ ░ █ █
      █ ░ ░ █ █ █ █
  █ ░ █ █ ░ █ █ █ █ █ █
0 1 0 2 1 0 1 3 2 1 2 1
```

Legend: `█` = bars, `░` = trapped water

Water trapped: 1 + 1 + 2 + 1 + 1 = 6 units

### Example 2

```text
Input: height = [4,2,0,3,2,5]
Output: 9
```

**Visual representation:**

```text
          █
█ ░ ░ ░ ░ █
█ ░ ░ ░ ░ █
█ █ ░ ░ ░ █
█ █ ░ █ █ █
4 2 0 3 2 5
```

Legend: `█` = bars, `░` = trapped water

Water trapped: 2 + 2 + 3 + 2 = 9 units

## Long Example

```text
Input: height = [4,2,0,3,2,5,0,1,2,3,1,2,1,4,2,2,5]
Output: 26
Explanation: Multiple basins accumulate water between taller boundaries leading to a total of 26 units trapped.
```

**Visual representation:**

```text
                                              █
█ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ █ ░ ░ ░ ░ ░ ░ ░ ░ ░ █
█ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ █ ░ ░ ░ ░ ░ ░ ░ ░ ░ █
█ ░ ░ ░ █ ░ ░ ░ ░ ░ ░ ░ ░ █ ░ ░ ░ ░ ░ ░ ░ ░ ░ █
█ ░ ░ █ █ ░ ░ ░ ░ ░ ░ ░ ░ █ ░ ░ ░ ░ ░ ░ ░ ░ ░ █
█ █ ░ █ █ █ ░ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █ █
4 2 0 3 2 5 0 1 2 3 1 2 1 4 2 2 5 1 1 1 1 1 1 6
```

Legend: `█` = bars, `░` = trapped water

This creates multiple water basins with different levels, accumulating 26 total units.

## How It Works

The key insight is that water at any position is trapped by the **minimum of the maximum heights to its left and right**, minus the height of the current bar.

**Visual example of water level calculation:**

```text
For position i=4 in [4,2,0,3,2,5]:
          █
█ ░ ░ ░ ░ █    ← Water level = min(4,5) = 4
█ ░ ░ ░ ░ █      Current height = 2
█ █ ░ ░ ░ █      Trapped water = 4 - 2 = 2
█ █ ░ █ █ █
4 2 0 3 2 5
        ↑
      pos 4
```

**Left max:** 4 (tallest bar to the left)  
**Right max:** 5 (tallest bar to the right)  
**Water level:** min(4,5) = 4  
**Current height:** 2  
**Trapped water:** 4 - 2 = 2 units

## Edge Cases

- Arrays with length less than 3 cannot trap water.
- Strictly increasing or strictly decreasing arrays result in zero trapped water.
- Large flat plateaus with dips only at the ends.
- Arrays containing zeros interspersed with tall bars.
- Very large inputs where O(n) solutions are required to avoid timeouts.

**Edge case examples:**

*Strictly increasing (no water trapped):*

```text
    █
  █ █
█ █ █
1 2 3  → 0 units trapped
```

*Strictly decreasing (no water trapped):*

```text
█ █ █
  █ █
    █
3 2 1  → 0 units trapped
```

*Flat plateau with end dips:*

```text
  █ █ █ █  
░ █ █ █ █ ░
█ █ █ █ █ █
0 1 1 1 1 0  → 4 units trapped
```

## Notes

Common approaches include two-pointer sweeps, prefix/suffix maxima arrays, and monotonic stacks.
