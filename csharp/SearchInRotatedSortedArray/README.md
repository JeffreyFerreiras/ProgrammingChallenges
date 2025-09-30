# 33. Search in Rotated Sorted Array (C#)

## Problem
Take an array of distinct integers sorted in ascending order, rotate it at an unknown pivot, and provide a target value. The challenge is to return the index of the target if it exists or `-1` otherwise. The runtime must be `O(log n)`.

The rotation slices the sorted array into two sorted subarrays, so an efficient search needs to decide which half remains ordered at each step and then discard the other half.

## Examples
- **Example 1**
  - Input: `nums = [4,5,6,7,0,1,2]`, `target = 0`
  - Output: `4`
- **Example 2**
  - Input: `nums = [4,5,6,7,0,1,2]`, `target = 3`
  - Output: `-1`
- **Example 3**
  - Input: `nums = [1]`, `target = 0`
  - Output: `-1`

## Edge Cases and Long Examples
- Single-element arrays with and without a match (`[1]` ? `1`, `[1]` ? `-1`).
- Rotations that wrap negative values to the end, e.g. `nums = [9,12,17,-4,-1,0,3]`, `target = -1` ? `4`.
- Datasets that appear already sorted (`nums = [2,5,8,12,16,19]`, `target = 16` ? `4`).
- Large inputs with over one hundred thousand entries and a rotation deep inside: the harness builds an array of length `120,000`, rotates it at index `75,000`, and searches for `12,345`.

## Constraints
- `1 <= nums.length <= 10^4`
- `-10^4 <= nums[i] <= 10^4`
- All elements are distinct.
- `nums` was obtained from a sorted array through a rotation.
- `-10^4 <= target <= 10^4`

## Implementation Notes
- Fill in `Solution.Search(int[] nums, int target)` with a rotation-aware binary search. Detect which side of the array is sorted at each iteration and tighten the bounds accordingly.
- `Program.cs` exercises a variety of scenarios, measures execution time (milliseconds with four decimal places), and prints the computed index next to the expected result. Currently the solution method throws so you can implement it yourself.
