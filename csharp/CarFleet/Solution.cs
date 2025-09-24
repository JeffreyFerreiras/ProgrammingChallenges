/*
853. Car Fleet
Medium

There are n cars going to the same destination along a one-lane road. The destination is target miles away.

You are given two integer arrays position and speed of length n, where position[i] is the position of the ith car 
and speed[i] is the speed of the ith car (in miles per hour).

A car can never pass another car ahead of it, but it can catch up to it and drive bumper to bumper at the same speed.

The faster car will slow down to match the slower car's speed. The distance between these two cars is ignored 
(i.e., they are assumed to be at the same position).

A car fleet is a car or cars driving next to each other. The number of car fleets is the number of groups of cars.

Return the number of car fleets that will arrive at the destination.

Example 1:
Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
Output: 3
Explanation:
The cars starting at 10 and 8 become a fleet, meeting each other at 12.
The car starting at 0 doesn't catch up to any other car, so it is a fleet by itself.
The cars starting at 5 and 3 become a fleet, meeting each other at 6.
Note that no other cars meet these fleets before the destination, so the answer is 3.

Example 2:
Input: target = 10, position = [3], speed = [3]
Output: 1
Explanation: There is only one car, hence there is only one fleet.

Example 3:
Input: target = 100, position = [0,2,4], speed = [4,2,1]
Output: 1
Explanation:
The cars starting at 0, 2, and 4 become one fleet, meeting each other at 100.

Constraints:
n == position.length == speed.length
1 <= n <= 10^5
0 < target <= 10^6
0 <= position[i] < target
All the values of position are unique.
0 < speed[i] <= 10^6
*/

namespace CarFleet;

public static class Solution
{
    /// <summary>
    /// Stack approach: Sort by position descending, use stack to track fleets
    /// Time: O(n log n), Space: O(n)
    /// </summary>
    public static int CarFleet_Stack(int target, int[] position, int[] speed)
    {
        int len = position.Length;
        Stack<int> stack = new();

        for (int i = 0; i < len; i++)
        {
            int timeToTarget = (target - position[i]) / speed[i];

            stack.Push(timeToTarget);
        }

        return stack.Count;
    }

    /// <summary>
    /// Linear scan approach: Sort by position, track slowest time seen
    /// Time: O(n log n), Space: O(n)
    /// </summary>
    public static int CarFleet_Linear(int target, int[] position, int[] speed)
    {
        // TODO: Implement linear scan solution
        throw new NotImplementedException();
    }

    /// <summary>
    /// Array-based approach: No extra stack, count directly
    /// Time: O(n log n), Space: O(n)
    /// </summary>
    public static int CarFleet_Array(int target, int[] position, int[] speed)
    {
        // TODO: Implement array-based solution
        throw new NotImplementedException();
    }
}