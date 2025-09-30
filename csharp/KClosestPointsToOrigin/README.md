# 973. K Closest Points to Origin (C#)

## Problem
Given an array of Cartesian coordinates points, return the k points closest to the origin (0,0) using Euclidean distance. The answer can be returned in any order. A max-heap (priority queue) of size k yields O(n log k) performance by discarding points that are farther than the current kth closest.

## Examples
- **Example 1**
  - Input: points = [[1,3],[-2,2]], k = 1
  - Output: [[-2,2]]
- **Example 2**
  - Input: points = [[3,3],[5,-1],[-2,4]], k = 2
  - Output: [[3,3],[-2,4]]

## Edge Cases and Long Examples
- When k equals the number of points, simply return all points.
- Multiple points can share the same distance; any order is acceptable.
- The harness builds thousands of evenly distributed points on a circle and requests a tiny subset, stressing the heap maintenance logic.

## Constraints
- 1 <= k <= points.length <= 10^4
- -10^4 <= points[i][0], points[i][1] <= 10^4
- Answers may be returned in any order.

## Implementation Notes
- Implement Solution.KClosest(int[][] points, int k) by tracking squared distances (to avoid floating-point operations) and storing the farthest among the current k candidates at the root of the max-heap.
- Program.cs enumerates representative scenarios, clones input arrays to protect them, measures runtime with a stopwatch, and prints the returned point list alongside the expected set. The solution method currently throws NotImplementedException so you can implement the heap logic yourself.
