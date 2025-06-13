

/*
Amazon's AWS provides fast and efficient server solutions.
The Developers want to stress-test the quality of the server's
channels. They must ensure the following:

- Each of the packets must be sent via a single channel.
- Each of the channels must be used by exactly one packet.

The quality of the transfer for a channel is defined by the 
median of the sizes of all the data packets sent through that
channel.

Note: The median of an array is the middle element if the array 
if the array is sorted in non-decreasing order. If the number of elements 
in the array is even, the median is the average of the two middle elements.

Find the maximum possible sum of the qualities of all channels. If the answer is a floating-point
number, round it to the nearest integer.

Example
packets = [1, 2, 3, 4, 5]
channels = 2

*/

List<int> packets = new List<int> { 1, 2, 3, 4, 5 };
int channels = 2;

Console.WriteLine(Solution.maximumQuality(packets, channels));


