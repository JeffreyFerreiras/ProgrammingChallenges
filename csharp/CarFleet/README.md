# 853. Car Fleet

**Difficulty:** Medium  
**Topics:** Array, Stack, Sorting, Monotonic Stack  
**Companies:** Amazon, Google, Microsoft

## Problem Description

There are `n` cars going to the same destination along a one-lane road. The destination is `target` miles away.

You are given two integer arrays `position` and `speed` of length `n`, where:
- `position[i]` is the position of the ith car
- `speed[i]` is the speed of the ith car (in miles per hour)

**Key Rules:**
- A car can never pass another car ahead of it
- A car can catch up to another car and drive bumper to bumper at the same speed
- When a faster car catches up to a slower car, it slows down to match the slower car's speed
- The distance between cars driving together is ignored (assumed to be at the same position)

A **car fleet** is a car or cars driving next to each other. Return the number of car fleets that will arrive at the destination.

## Examples

### Example 1
```
Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
Output: 3
```

**Explanation:**
- Cars at positions 10 and 8 become a fleet, meeting at the destination (12 miles)
- Car at position 0 doesn't catch up to any other car (forms its own fleet)
- Cars at positions 5 and 3 become a fleet, meeting at position 6
- Total: 3 fleets

### Example 2
```
Input: target = 10, position = [3], speed = [3]
Output: 1
```

**Explanation:** Only one car, so only one fleet.

### Example 3
```
Input: target = 100, position = [0,2,4], speed = [4,2,1]
Output: 1
```

**Explanation:** All cars form one fleet, meeting at the destination.

## Constraints

- `n == position.length == speed.length`
- `1 <= n <= 10^5`
- `0 < target <= 10^6`
- `0 <= position[i] < target`
- All values of `position` are unique
- `0 < speed[i] <= 10^6`

## Approach

### Key Insight
The critical insight is to calculate the **time each car takes to reach the target** and process cars from closest to the target to farthest:

```
time_to_target = (target - position) / speed
```

### Algorithm Steps
1. **Calculate times:** For each car, compute how long it takes to reach the target
2. **Sort by position:** Process cars from closest to target to farthest (descending position)
3. **Track fleets:** Cars that take longer to reach the target form new fleets; faster cars join existing fleets

### Solution Approaches

#### 1. Stack Approach
- Use a stack to track the time of the slowest car in each fleet
- For each car (processed closest to target first):
  - If it takes longer than the current slowest car, it forms a new fleet
  - Otherwise, it joins the existing fleet (gets absorbed)

#### 2. Linear Scan Approach
- Track the slowest time seen so far
- Count how many times we see a car that's slower than all previous cars

#### 3. Array-Based Approach
- Similar to linear scan but uses index-based sorting instead of LINQ

## Complexity Analysis

- **Time Complexity:** O(n log n) - dominated by sorting
- **Space Complexity:** O(n) - for storing car data and sorting

## Usage

Run the solution:
```bash
dotnet run --project CarFleet.csproj
```

This will execute all test cases and show:
- ✓ PASSED for implemented and correct solutions
- ⚠ NOT IMPLEMENTED for methods that need implementation
- ✗ FAILED for incorrect implementations
- ✗ ERROR for runtime errors

## Implementation Status

- [ ] `CarFleet_Stack` - Stack-based approach (recommended)
- [ ] `CarFleet_Linear` - Linear scan approach (most efficient)
- [ ] `CarFleet_Array` - Array-based approach (alternative)

## Test Cases Covered

- **Example cases:** All LeetCode examples
- **Edge cases:** 
  - Single car
  - Two cars forming one fleet
  - Two cars forming separate fleets
  - All cars with same speed
  - Large position differences

## Related Problems

- [Daily Temperatures](../DailyTemperatures/) - Uses monotonic stack
- [Largest Rectangle in Histogram](https://leetcode.com/problems/largest-rectangle-in-histogram/) - Monotonic stack pattern
- [Next Greater Element](https://leetcode.com/problems/next-greater-element-i/) - Stack-based approach