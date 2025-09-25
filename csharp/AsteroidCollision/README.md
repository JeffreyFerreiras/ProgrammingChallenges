# Asteroid Collision

Simulate collisions between moving asteroids represented as an integer array. Positive values move to the right, negative values move to the left. When two asteroids meet, the smaller (by absolute value) explodes; if they are the same size, both are destroyed.

## Problem

Given an array `asteroids` of integers representing asteroids in a row, return the state of the asteroids after all collisions. The absolute value of each asteroid represents its size, and the sign represents its direction.

## Examples

### Example 1

```text
Input: asteroids = [5,10,-5]
Output: [5,10]
Explanation: The 10 survives because it is larger than 5 in absolute value; -5 collides with 10 and explodes.
```

### Example 2

```text
Input: asteroids = [8,-8]
Output: []
Explanation: The asteroids are the same size and both explode.
```

## Long Example

```text
Input: asteroids = [10,2,-5,-20,15,-3,12,-25,20]
Output: [-20,15,-3,12,-25,20]
Explanation: Collisions resolve sequentially using stack rules, leaving the listed survivors.
```

## Edge Cases

- Asteroids moving entirely in one direction; no collisions occur.
- Chain reactions where a single collision causes multiple subsequent collisions.
- Equal magnitude collisions that remove both asteroids.
- Large inputs requiring O(n) stack-based processing to avoid timeouts.
- Initial zero-value asteroids (if permitted) should be treated carefully (usually not included).

## Notes

A typical solution uses a stack to simulate the interactions and resolve collisions in linear time.
