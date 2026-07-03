namespace CoinChangeNeetCode;

public class Solution
{
    /// <summary>
    /// Computes the fewest coins needed to make up the given amount.
    /// </summary>
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (var subtotal = 1; subtotal <= amount; subtotal++)
        {
            foreach (var coin in coins)
            {
                if (coin <= subtotal)
                {
                    dp[subtotal] = Math.Min(dp[subtotal], dp[subtotal - coin] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
}
