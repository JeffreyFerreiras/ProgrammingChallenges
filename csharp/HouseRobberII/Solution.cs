namespace HouseRobberII;

public class Solution
{
    /// <summary>
    /// Determines the maximum money that can be robbed from circularly adjacent houses.
    /// </summary>
    public int Rob(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(RobRange(nums, 0, nums.Length - 2), RobRange(nums, 1, nums.Length - 1));
    }

    private static int RobRange(int[] nums, int start, int end)
    {
        var twoBack = 0;
        var oneBack = 0;

        for (var i = start; i <= end; i++)
        {
            var current = Math.Max(oneBack, twoBack + nums[i]);
            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
    }
}
