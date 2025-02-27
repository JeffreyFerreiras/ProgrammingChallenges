namespace StockPrices
{
    class Program
    {

        /*
         * Suppose we could access yesterday's stock prices as an array, where:
         * The index are the time in minutes past trade opening time, which was 9:30am local time.
         * The values are the price in dollars of Apple stock at that time.
         * So if the stock cost $500 at 10:30am, stockPricesYesterday[60] = 500.
         * Write an efficient method that takes stockPricesYesterday and returns the best profit I could have made
         * from 1 purchase and 1 sale of 1 Apple stock yesterday.
         */

            //find maximum diff
        static void Main(string[] args)
        {
            int[] stockPricesYesterday = [10, 7, 5, 8, 11, 9];
            double profit = GetMaxProfit(stockPricesYesterday);

            int[] stockPricesYesterday2 = [10, 7, 5, 4, 3, 2];
            double profit2 = GetMaxProfit(stockPricesYesterday2);

            //display profit
            Random rand = new Random();
            Console.WriteLine(GetMaxProfit2([.. Enumerable.Range(0, 1500).Select(i=> rand.Next())]));
            Console.WriteLine(GetMaxProfit(stockPricesYesterday));
        }

        //Brute Force
        //private static double GetMaxProfit(int[] stockPricesYesterday)
        //{
        //    int len = stockPricesYesterday.Length;
        //    int maxProfit = 0;

        //    for(int i = 0; i < len; i++)
        //    {
        //        for(int j = i + 1; j < len; j++)
        //        {
        //            int profit = stockPricesYesterday[i] - stockPricesYesterday[j];

        //            if(profit < maxProfit)
        //            {
        //                maxProfit = profit;
        //            }
        //        }
        //    }

        //    return maxProfit * -1;
        //}

            //Greedy O(n)
        private static double GetMaxProfit(int[] stockPricesYesterday)
        {
            if(stockPricesYesterday.Length < 2)
            {
                throw new ArgumentException("Getting a profit requires at least 2 prices");
            }

            int len = stockPricesYesterday.Length;
            int maxProfit = stockPricesYesterday[0] - stockPricesYesterday[1];
            int lowestPriceSeen = stockPricesYesterday[0];

            for(int i = 1; i < len; i++)
            {
                if(lowestPriceSeen > stockPricesYesterday[i])
                {
                    lowestPriceSeen = stockPricesYesterday[i];
                    continue;
                }

                int profit = lowestPriceSeen - stockPricesYesterday[i];

                if(profit < maxProfit)
                {
                    maxProfit = profit;
                }
            }

            return maxProfit * -1;
        }

        private static double GetMaxProfit2(int[] nums)
        {
            double maxProfit = 0.00;
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    double profit = nums[j] - nums[i];

                    if(profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            return maxProfit;
        }

		public int MaxProfit(int[] prices)
		{
			int minPrice = int.MaxValue;
			int maxProfit = 0;

			for (int i = 0; i < prices.Length - 1; i++)
			{
				if(minPrice > prices[i])
				{
					minPrice = prices[i];
				}
				else if (prices[i] - minPrice > maxProfit)
				{
					maxProfit = prices[i] - minPrice;
				}
			}
			 
			return maxProfit;
		}

		 
	}

	public class myclass
	{
		 
		private myclass() { }
	}
	
}
