# Amazon Assessment - Maximum Quality

## Problem Description
Amazon's AWS provides fast and efficient server solutions. The developers want to stress-test the quality of the server's channels. They must ensure the following:

- Each of the packets must be sent via a single channel.
- Each of the channels must be used by exactly one packet.

The quality of the transfer for a channel is defined by the median of the sizes of all the data packets sent through that channel.

Note: The median of an array is the middle element if the array is sorted in non-decreasing order. If the number of elements in the array is even, the median is the average of the two middle elements.

Find the maximum possible sum of the qualities of all channels. If the answer is a floating-point number, round it to the nearest integer.

## Example:
```
Input:
packets = [1, 2, 3, 4, 5]
channels = 2

Output: (To be determined based on implementation)
```

## Constraints:
- All packets must be assigned to a channel
- Each channel must be used by exactly one packet
- The goal is to maximize the sum of qualities across all channels

## Solution Approach
The solution involves finding the optimal way to distribute packets across channels to maximize the sum of median values. This requires:

1. Sorting the packets
2. Finding all possible ways to divide packets among channels
3. For each distribution, calculate the median value of each channel
4. Summing the median values
5. Finding the maximum possible sum

The challenge involves optimizing the distribution of packets to maximize the overall quality of the system.