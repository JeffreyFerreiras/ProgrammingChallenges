namespace HouseRobber;

public class Solution
{
    /// <summary>
    /// Determines the maximum money that can be robbed without alerting the police.
    /// </summary>
    public int Rob(int[] nums)
    {
        var twoBack = 0;
        var oneBack = 0;

        foreach (var num in nums)
        {
            var current = Math.Max(oneBack, twoBack + num);
            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
    }
}
