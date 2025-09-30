# 153. Find Minimum in Rotated Sorted Array (C#)

## Problem
You are given a strictly increasing array of unique integers that has been rotated around an unknown pivot. Formally, the original array was sorted in ascending order and then shifted: `[a0, a1, ..., an-1]` became `[ak, ..., an-1, a0, ..., a(k-1)]`. The goal is to return the smallest element in the rotated array using only `O(log n)` comparisons.

## Examples
- **Example 1**
  - Input: `nums = [3,4,5,1,2]`
  - Output: `1`
  - Explanation: The array was rotated three times; the minimum is the wrapped-around value `1`.
- **Example 2**
  - Input: `nums = [4,5,6,7,0,1,2]`
  - Output: `0`
  - Explanation: Rotated four times, so the smallest element moved near the end.
- **Example 3**
  - Input: `nums = [11,13,15,17]`
  - Output: `11`
  - Explanation: No rotation occurred; the first element is the minimum.

## Edge Cases and Long Examples
- Single-element rotations, e.g. `nums = [1]` ? `1`.
- Two-element arrays rotated once, e.g. `nums = [2,1]` ? `1`.
- Arrays that remain fully sorted because the rotation count equals the array length, e.g. `nums = [-9,-3,0,4,7,12]` ? `-9`.
- Large arrays with tens of thousands of elements rotated at an arbitrary pivot. The harness creates one with `100,000` entries spanning `[-50,000, 49,999]` to stress-test a logarithmic search.

## Constraints
- `1 <= nums.length <= 5 * 10^4`
- `-10^4 <= nums[i] <= 10^4`
- All `nums[i]` are unique.
- `nums` was originally sorted in ascending order and then rotated any number of times.

## Implementation Notes
- Implement `Solution.FindMin(int[] nums)` with a modified binary search that narrows the search space based on which half is ordered.
- `Program.cs` enumerates a variety of scenarios, captures the execution time in milliseconds (four decimal places), and prints both the returned value and the expected minimum. The method currently throws `NotImplementedException` so you can fill in the logic.
