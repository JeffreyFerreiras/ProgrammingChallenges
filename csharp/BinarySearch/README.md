# 704. Binary Search

## Problem
You receive a sorted integer array `nums` and an integer `target`. The array is strictly increasing and may contain negative values. Your task is to return the index of `target` if it appears in the array; otherwise return `-1`. The search must execute in `O(log n)` time, which rules out linear scanning and directs you toward a divide-and-conquer approach.

## Examples
- **Example 1**
  - Input: `nums = [-1,0,3,5,9,12]`, `target = 9`
  - Output: `4`
  - Explanation: `9` is located at index `4` when zero-indexed.
- **Example 2**
  - Input: `nums = [-1,0,3,5,9,12]`, `target = 2`
  - Output: `-1`
  - Explanation: There is no element equal to `2`, so the method returns `-1`.

## Edge Cases and Long Examples
- Single element list where the target exists, e.g. `nums = [5]`, `target = 5` ? `0`.
- Single element list where the target does not exist, e.g. `nums = [5]`, `target = -5` ? `-1`.
- Arrays dominated by negative numbers, e.g. `nums = [-15,-9,-4,0,12,18,27]`, `target = -4` ? `2`.
- Large monotonic range to exercise logarithmic performance, e.g. `nums` contains `200,001` values from `-100,000` to `100,000`, `target = 54,321` ? `154,321`.

## Constraints
- `1 <= nums.length <= 10^4`
- `-10^4 <= nums[i] <= 10^4`
- `nums` is sorted in strictly ascending order.
- All values in `nums` are unique.
- `-10^4 <= target <= 10^4`

## Implementation Notes
- The `Solution.Search(int[] nums, int target)` method is intentionally left unimplemented. Add the binary search logic before running the scenarios in `Program.cs`.
- `Program.cs` defines several scenarios, invokes the solution method, and prints timing information in milliseconds with four decimal places for easy comparison.
