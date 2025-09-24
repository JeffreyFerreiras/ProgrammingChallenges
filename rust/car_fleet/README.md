# 853. Car Fleet

## Problem Description

There are `n` cars going to the same destination along a one-lane road. The destination is `target` miles away.

You are given two integer arrays `position` and `speed`, both of length `n`, where `position[i]` is the position of the `ith` car and `speed[i]` is the speed of the `ith` car (in miles per hour).

A car can never pass another car ahead of it, but it can catch up to it and drive bumper to bumper at the same speed. The faster car will slow down to match the slower car's speed. The distance between these two cars is ignored (i.e., they are assumed to have the same position).

A car fleet is some non-empty set of cars driving at the same position and same speed. Note that a single car is also a car fleet.

If a car catches up to a car fleet right at the destination point, it will still be considered as one car fleet.

Return the number of car fleets that will arrive at the destination.

## Examples

### Example 1

```text
Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
Output: 3
Explanation:
The cars starting at 10 (speed 2) and 8 (speed 4) become a fleet, meeting each other at 12.
The car starting at 0 does not catch up to any other car, so it is a fleet by itself.
The cars starting at 5 (speed 1) and 3 (speed 3) become a fleet, meeting each other at 6.
The car starting at 3 (speed 3) catches up to the car starting at 5 (speed 1) at 6.
Note that no other cars meet these fleets before the destination, so the answer is 3.
```

### Example 2

```text
Input: target = 10, position = [3], speed = [3]
Output: 1
```

### Example 3

```text
Input: target = 100, position = [0,2,4], speed = [4,2,1]
Output: 1
Explanation:
The cars starting at 0 (speed 4) and 2 (speed 2) become a fleet, meeting each other at 4.
The car starting at 4 (speed 1) already is a fleet by itself.
The car starting at 2 (speed 2) catches up to the car starting at 4 (speed 1) at 4.
The car starting at 0 (speed 4) catches up to the car starting at 2 (speed 2) at 4.
The car starting at 0 (speed 4) catches up to the car starting at 4 (speed 1) at 4.
All cars meet at 4, so the answer is 1.
```

## Constraints

- `n == position.length == speed.length`
- `1 <= n <= 10^5`
- `0 < target <= 10^6`
- `0 <= position[i] < target`
- All the values of `position` are unique.
- `0 < speed[i] <= 10^6`

## Approach

The key insight is to think about when cars will meet. For two cars to meet, the car behind must be faster and must be able to catch up to the car in front before the destination.

1. **Calculate arrival times**: For each car, calculate the time it takes to reach the destination.
2. **Sort by position**: Sort cars by their starting position (closest to destination first).
3. **Process from front to back**: For each car, check if it can catch up to the car fleet in front of it.
4. **Count fleets**: Each time a car cannot catch up to the fleet in front, it starts a new fleet.

## Time Complexity

- **Time**: O(n log n) - due to sorting
- **Space**: O(n) - for storing the sorted cars and their arrival times

## Solution Structure

The solution is implemented in the `Solution` struct with a `car_fleet` method that takes:

- `target`: The destination distance
- `position`: Vector of car positions
- `speed`: Vector of car speeds

Returns the number of car fleets that will arrive at the destination.

## Running the Solution

To run the solution with test cases:

```bash
cargo run
```

This will execute all test cases with timing information and verify the results against expected outputs.
