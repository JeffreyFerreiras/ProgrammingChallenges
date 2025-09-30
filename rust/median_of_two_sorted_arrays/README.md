# 4. Median of Two Sorted Arrays (Rust)

## Problem
Given two sorted arrays `nums1` and `nums2`, return the median of the combined multiset. The overall time complexity must be `O(log(m + n))`, so the typical approach partitions the smaller array and checks whether the left partition holds valid boundary values.

## Examples
- **Example 1**: `nums1 = [1,3]`, `nums2 = [2]` ? `2.0`
- **Example 2**: `nums1 = [1,2]`, `nums2 = [3,4]` ? `2.5`
- **Example 3**: `nums1 = [0,0]`, `nums2 = [0,0]` ? `0.0`
- **Example 4**: `nums1 = []`, `nums2 = [2]` ? `2.0`

## Edge Cases and Long Examples
- Arrays with very different lengths (`[1,3,8,9,15]` and `[7,11,18,19,21,25]` ? `11.0`).
- Inputs containing many duplicates or zeros.
- Large arrays used in the harness: `nums1` contains values `0..99,999` and `nums2` contains `100,000..199,999`, which yields the median `99,999.5`.

## Constraints
- `0 <= nums1.len(), nums2.len() <= 10^3`
- `1 <= nums1.len() + nums2.len() <= 2 * 10^3`
- `-10^6 <= nums[i] <= 10^6`

## Implementation Notes
- Implement `Solution::find_median_sorted_arrays` using binary search on the partition of the smaller array.
- `src/main.rs` supplies multiple scenarios, prints timing information in milliseconds to four decimal places, and reports either the computed median or a panic message alongside the expected value. The solution is currently a `todo!()` placeholder.
