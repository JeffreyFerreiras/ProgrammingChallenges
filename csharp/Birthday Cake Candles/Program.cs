namespace Birthday_Cake_Candles
{
    class Program
    {
        /*
         * Colleen is turning n years old!
         * Therefore, she has  candles of various heights on her cake, and candle  has height.
         * Because the taller candles tower over the shorter ones, Colleen can only blow out the tallest candles.
         * Given the height for each individual candle, find and print the number of candles she can successfully blow out.
         */
        static int birthdayCakeCandles(int n, int[] ar)
        {
            int tallestCandleCount = 0;
            int tallest = 0;

            for (int i = 0; i < n; i++)
            {
                if (tallest < ar[i])
                {
                    tallest = ar[i];
                    tallestCandleCount = 1;
                }
                else if (tallest == ar[i])
                {
                    tallestCandleCount++;
                }
            }

            return tallestCandleCount;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int result = birthdayCakeCandles(n, ar);
            Console.WriteLine(result);
        }
    }
}
