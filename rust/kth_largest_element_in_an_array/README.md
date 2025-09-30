# 215. Kth Largest Element in an Array (Rust)

## Problem
Given an unsorted integer array 
ums and an integer k, return the kth largest element. This is the element that would appear at index 
ums.len() - k after sorting. Efficient solutions use a min-heap of size k (O(n log k)) or quickselect partitioning (O(n) average time).

## Examples
- **Example 1**: 
ums = [3,2,1,5,6,4], k = 2 ? 5
- **Example 2**: 
ums = [3,2,3,1,2,4,5,5,6], k = 4 ? 4

## Edge Cases and Long Examples
- Duplicate values are allowed and count separately toward ranking.
- When k = 1, return the maximum; when k = nums.len(), return the minimum.
- The harness includes large ascending and descending arrays with 200,000 elements to stress-test the approach.

## Constraints
- 1 <= k <= nums.len() <= 10^5
- -10^4 <= nums[i] <= 10^4

## Implementation Notes
- Implement Solution::find_kth_largest using either quickselect or a heap, paying attention to integer ranges.
- src/main.rs defines several workloads, measures elapsed milliseconds (four decimal places), and prints the returned value while catching 	odo!() panics.
