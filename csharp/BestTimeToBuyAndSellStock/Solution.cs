namespace BestTimeToBuyAndSellStock;

public class Solution
{
    /// <summary>
    /// Calculates the maximum profit from a single buy/sell transaction.
    /// TODO: Implement the sliding window strategy to track the minimum price.
    /// </summary>
    public int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int minPrice = int.MaxValue;

        foreach (var price in prices)
        {
            if (price < minPrice)
            {
                minPrice = price;
            }
            else if (price - minPrice > maxProfit)
            {
                maxProfit = price - minPrice;
            }
        }

        return maxProfit;
    }
}
