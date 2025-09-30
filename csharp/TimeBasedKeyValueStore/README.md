# 981. Time Based Key-Value Store (C#)

## Problem
Design a data structure that supports storing string values by key and timestamp and retrieving the most recent value at or before a query time. Two operations are required:

- `set(key, value, timestamp)`: Stores the pair `(value, timestamp)` for the given key. Timestamps are strictly increasing for each key.
- `get(key, timestamp)`: Returns the value associated with `key` whose timestamp is less than or equal to `timestamp`. If none exists, return the empty string.

Both operations should run in `O(log n)` time with respect to the number of stored timestamps for a key.

## Examples
- **Example 1**
  - Input: `["TimeMap","set","get","get","set","get","get"]`
  - Arguments: `[[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]`
  - Output: `[null,null,"bar","bar",null,"bar2","bar2"]`
- **Example 2**
  - Input performs a `get` before any `set` call for the key and should return an empty string.

## Edge Cases and Long Examples
- Interleaving `set` and `get` calls on multiple keys where timestamps interleave.
- Queries that ask for timestamps before the earliest entry for a key (should return empty string).
- A dense timeline where hundreds of successive timestamps are stored for a single key to validate logarithmic lookups. The harness builds twenty timestamps for one key and queries at each moment and the subsequent moment.

## Constraints
- `1 <= key.length, value.length <= 100`
- `1 <= timestamp <= 10^7`
- The timestamps for each key strictly increase.
- At most `2 * 10^5` calls will be made to `set` and `get` in total.

## Implementation Notes
- Implement `Solution.CreateTimeMap()` so it returns a `TimeMap` instance, and implement `TimeMap.Set`/`TimeMap.Get` with a binary-search-friendly structure such as a sorted list or dictionary of vectors.
- `Program.cs` defines several operation sequences, times the execution (milliseconds with four decimal places), and prints both the collected outputs and the expected responses. The methods currently throw `NotImplementedException` to leave the core logic unfinished.
