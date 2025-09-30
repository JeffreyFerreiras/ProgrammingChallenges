# 146. LRU Cache (NeetCode, Rust)

Design a data structure that supports get and put in O(1) time while discarding the least recently used key when capacity is exceeded. Typically this combines a doubly linked list for recency ordering with a hash map for key lookup.

## Examples
`	ext
Input: [\"LRUCache\", \"put\", \"put\", \"get\", \"put\", \"get\", \"put\", \"get\", \"get\", \"get\"]
       [[2], [1,1], [2,2], [1], [3,3], [2], [4,4], [1], [3], [4]]
Output: [null, null, null, 1, null, -1, null, -1, 3, 4]
`

## Long Example
`	ext
Capacity: 3
Operations: put(1,100), put(2,200), put(3,300), get(1), put(4,400), get(2), put(5,500), get(3), put(1,150), get(1), get(4), get(5)
Expected get sequence: [100, -1, -1, 150, -1, 500]
`

## Edge Cases
- Capacity of one must still evict correctly on each new insert.
- get on missing keys must not alter cache state aside from returning -1.
- Re-inserting an existing key updates its value and recency.
- Large workloads require stable iteration over the doubly linked list without orphan nodes.

*Implementation is intentionally left as a 	odo!() in src/solution.rs.*
