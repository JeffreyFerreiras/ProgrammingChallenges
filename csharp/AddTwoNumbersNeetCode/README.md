# 2. Add Two Numbers (NeetCode)

Add two non-empty linked lists representing non-negative integers stored in reverse order (least significant digit first). Compute the digit-wise sum, carrying as needed, and return the sum as another linked list in the same format.

## Examples
`	ext
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]

Input: l1 = [0], l2 = [0]
Output: [0]
`

## Long Example
`	ext
Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
`

## Edge Cases
- Lists may have different lengths; treat missing digits as zero.
- The final carry can introduce an extra node at the end.
- Handle large chains of carries efficiently.
- Inputs may contain leading zeros yet still represent zero.

*Implementation is intentionally left as an exercise in Solution.cs.*
