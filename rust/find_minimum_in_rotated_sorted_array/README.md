# 153. Find Minimum in Rotated Sorted Array (Rust)

## Problem
You receive a rotated version of a strictly increasing array with unique elements. The rotation shifts the array around a pivot, so the sequence `[0,1,2,4,5,6,7]` could become `[4,5,6,7,0,1,2]`. Return the minimum value in the array in `O(log n)` time.

## Examples
- **Example 1**: `nums = [3,4,5,1,2]` ? `1`
- **Example 2**: `nums = [4,5,6,7,0,1,2]` ? `0`
- **Example 3**: `nums = [11,13,15,17]` ? `11`

## Edge Cases and Long Examples
- Arrays with a single element (`[1]` ? `1`).
- Two-element rotations (`[2,1]` ? `1`).
- Arrays that remain sorted because the rotation wraps the entire length (`[-9,-3,0,4,7,12]` ? `-9`).
- Massive rotated arrays (100,000 elements spanning `[-50,000, 49,999]`) to validate the logarithmic performance requirement.

## Constraints
- `1 <= nums.len() <= 5 * 10^4`
- `-10^4 <= nums[i] <= 10^4`
- Every value is unique and the original array was strictly increasing.

## Implementation Notes
- Implement `Solution::find_min` with a binary search variant that compares `nums[mid]` to `nums[right]` to discard half of the array each iteration.
- `src/main.rs` drives several scenarios, measures execution time with `Instant`, and prints the result (or panic message) next to the expected value. The solution method currently calls `todo!()` so you can fill in the algorithm.
