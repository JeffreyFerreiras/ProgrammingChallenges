# 33. Search in Rotated Sorted Array (Rust)

## Problem
A strictly increasing array is rotated around an unknown pivot and a target value is provided. Return the index of the target if it exists or `-1` otherwise. The solution must run in `O(log n)` time.

## Examples
- **Example 1**: `nums = [4,5,6,7,0,1,2]`, `target = 0` ? `4`
- **Example 2**: `nums = [4,5,6,7,0,1,2]`, `target = 3` ? `-1`
- **Example 3**: `nums = [1]`, `target = 0` ? `-1`

## Edge Cases and Long Examples
- Single-element arrays with and without a match.
- Rotations that move negative numbers to the middle or end (`[9,12,17,-4,-1,0,3]`).
- Arrays that appear already sorted after rotation (`[30,34,40,2,5,8,11]`).
- Large rotations produced by the harness (120,000 entries) looking for a target deep in the sequence.

## Constraints
- `1 <= nums.len() <= 10^4`
- `-10^4 <= nums[i], target <= 10^4`
- All numbers are distinct.

## Implementation Notes
- Implement `Solution::search` using a binary search that determines which side of the array is sorted on each iteration.
- `src/main.rs` prints scenario details, times the call with `Instant`, and reports either the returned index or a panic message alongside the expected result. The solution is currently a `todo!()` placeholder.
