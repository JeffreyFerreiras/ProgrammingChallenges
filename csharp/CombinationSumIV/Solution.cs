namespace CombinationSumIV;

public class Solution
{
    /// <summary>
    /// Returns the number of ordered combinations that sum to the target.
    /// </summary>
    public int CombinationSum4(int[] nums, int target)
    {
        var dp = new long[target + 1];
        dp[0] = 1;

        for (var subtotal = 1; subtotal <= target; subtotal++)
        {
            foreach (var num in nums)
            {
                if (num <= subtotal)
                {
                    dp[subtotal] += dp[subtotal - num];
                }
            }
        }

        return (int)dp[target];
    }
}
