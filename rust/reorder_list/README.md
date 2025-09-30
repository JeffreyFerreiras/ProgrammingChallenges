# 143. Reorder List (NeetCode, Rust)

Given a singly linked list L0 ? L1 ? … ? Ln-1 ? Ln, reorder it to L0 ? Ln ? L1 ? Ln-1 ? L2 ? Ln-2 …. The reordering must happen in-place without altering node values, typically by splitting the list, reversing the second half, and weaving the two halves together.

## Examples
`	ext
Input: head = [1,2,3,4]
Output: [1,4,2,3]

Input: head = [1,2,3,4,5]
Output: [1,5,2,4,3]
`

## Long Example
`	ext
Input: head = [1,2,3,4,5,6,7,8]
Output: [1,8,2,7,3,6,4,5]
`

## Edge Cases
- Lists with zero or one node are already in the required order.
- Odd-length lists leave the middle element fixed in place.
- Ensure second-half reversal correctly handles two-node halves.
- Verify mutations do not create unintended cycles.

*Implementation is intentionally left as a 	odo!() in src/solution.rs.*
