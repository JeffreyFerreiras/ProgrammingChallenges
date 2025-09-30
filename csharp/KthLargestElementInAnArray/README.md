# 215. Kth Largest Element in an Array (C#)

## Problem
Given an unsorted integer array 
ums and an integer k, return the kth largest element. The kth largest is the element that would appear in sorted order at index 
ums.Length - k. Efficient solutions use a min-heap of size k or quickselect partitioning to achieve average O(n) time.

## Examples
- **Example 1**
  - Input: 
ums = [3,2,1,5,6,4], k = 2
  - Output: 5
- **Example 2**
  - Input: 
ums = [3,2,3,1,2,4,5,5,6], k = 4
  - Output: 4

## Edge Cases and Long Examples
- Arrays with repeated values still count each occurrence separately; the kth largest might not be unique.
- When k = 1, return the maximum; when k = nums.Length, return the minimum.
- Large monotonic arrays (ascending or descending) ensure the algorithm handles best and worst-case partitions. The harness generates 200,000-element sequences to stress-test the solution.

## Constraints
- 1 <= k <= nums.length <= 10^5
- -10^4 <= nums[i] <= 10^4

## Implementation Notes
- Implement Solution.FindKthLargest(int[] nums, int k) using either quickselect (in-place partitioning) or a min-heap maintained at size k.
- Program.cs clones each input array, times execution with a stopwatch, and prints both the returned value and the expected answer. The method currently throws NotImplementedException so you can provide the algorithm yourself.
