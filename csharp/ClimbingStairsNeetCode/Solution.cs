namespace ClimbingStairsNeetCode;

public class Solution
{
    /// <summary>
    /// Computes the number of distinct ways to reach the top of the staircase.
    /// </summary>
    public int ClimbStairs(int n)
    {
        if (n <= 2)
        {
            return n;
        }

        var previous = 1;
        var current = 2;

        for (var step = 3; step <= n; step++)
        {
            var next = previous + current;
            previous = current;
            current = next;
        }

        return current;
    }
}
