# 4. Median of Two Sorted Arrays (C#)

## Problem
You are given two sorted arrays `nums1` and `nums2`. Their combined length is `m + n`, where each array can be empty. The task is to return the median of the union of both arrays. The desired time complexity is `O(log (m + n))`, which is achieved by partitioning the arrays with binary search instead of merging them outright.

## Examples
- **Example 1**
  - Input: `nums1 = [1,3]`, `nums2 = [2]`
  - Output: `2.0`
- **Example 2**
  - Input: `nums1 = [1,2]`, `nums2 = [3,4]`
  - Output: `2.5`
- **Example 3**
  - Input: `nums1 = [0,0]`, `nums2 = [0,0]`
  - Output: `0.0`
- **Example 4**
  - Input: `nums1 = []`, `nums2 = [2]`
  - Output: `2.0`

## Edge Cases and Long Examples
- Arrays with greatly different lengths: `nums1 = [1,3,8,9,15]`, `nums2 = [7,11,18,19,21,25]` ? `11.0`.
- Datasets dominated by zeros and duplicates, e.g. both arrays contain only zeros.
- Very large arrays tested by the harness: `nums1` contains the integers `0..99,999` and `nums2` contains `100,000..199,999`, producing the median `99,999.5`.

## Constraints
- `0 <= nums1.length, nums2.length <= 10^3`
- `1 <= nums1.length + nums2.length <= 2 * 10^3`
- `-10^6 <= nums[i] <= 10^6`

## Implementation Notes
- Implement `Solution.FindMedianSortedArrays(int[] nums1, int[] nums2)` using a binary search over the shorter array to partition both arrays into left and right halves with equal sizes.
- `Program.cs` assembles representative scenarios, measures execution time (milliseconds with four decimal places), and prints the calculated median alongside the expected value. The solution currently throws `NotImplementedException` so you can complete it yourself.
