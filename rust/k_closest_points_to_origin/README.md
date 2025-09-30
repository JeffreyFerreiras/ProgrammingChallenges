# 973. K Closest Points to Origin (Rust)

## Problem
Given a list of points in the plane, return the k points closest to the origin (0,0) according to Euclidean distance. The answer can be in any order. Using a max-heap of size k keeps only the k closest points seen so far in O(n log k) time.

## Examples
- **Example 1**: points = [[1,3],[-2,2]], k = 1 ? [[-2,2]]
- **Example 2**: points = [[3,3],[5,-1],[-2,4]], k = 2 ? [[3,3],[-2,4]]

## Edge Cases and Long Examples
- When k equals points.len(), return all points unchanged.
- Duplicated distances are allowed; any valid ordering is accepted.
- The harness includes 10,000 points distributed in a circle and asks for the five closest, stressing heap maintenance.

## Constraints
- 1 <= k <= points.len() <= 10^4
- -10^4 <= points[i][0], points[i][1] <= 10^4

## Implementation Notes
- Implement Solution::k_closest using squared distances to avoid floating-point operations. Maintain a max-heap keyed by distance and pop when more than k points are stored.
- src/main.rs covers several scenarios, times execution with a stopwatch, and prints the returned list alongside the expected result, while catching 	odo!() panics.
