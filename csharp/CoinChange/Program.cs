/*
You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

You may assume that you have an infinite number of each kind of coin.

 

Example 1:

Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1
Example 2:

Input: coins = [2], amount = 3
Output: -1
Example 3:

Input: coins = [1], amount = 0
Output: 0
 

Constraints:

1 <= coins.length <= 12
1 <= coins[i] <= 231 - 1
0 <= amount <= 104
*/

public class Program
{
    public static void Main(string[] args)
    {
        var coins = new int[] { 1, 2, 5 };
        var amount = 11;
        var expected = 3;
        var result = CoinChange(coins, amount);
        Console.WriteLine($"Expected: {expected}, Result: {result}");

        coins = [2];
        amount = 3;
        expected = -1;
        result = CoinChange(coins, amount);
        Console.WriteLine($"Expected: {expected}, Result: {result}");


        coins = [1];
        amount = 0;
        expected = 0;
        result = CoinChange(coins, amount);
        Console.WriteLine($"Expected: {expected}, Result: {result}");

        coins = [1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000];
        amount = 10000;
        expected = 5;
        result = CoinChange(coins, amount);
        Console.WriteLine($"Expected: {expected}, Result: {result}");

        //[186,419,83,408]
        //6249
        coins = [186, 419, 83, 408];
        amount = 6249;
        expected = 20;
        result = CoinChange(coins, amount);
        Console.WriteLine($"Expected: {expected}, Result: {result}");
    }

    public static int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
    public static int CoinChangeX(int[] coins, int amount)
    {
        if (amount == 0)
        {
            return 0;
        }

        Array.Sort(coins);

        int total = 0;
        int count = 0;
        int index = coins.Length - 1;

        while (total < amount && index > -1)
        {
            total += coins[index];
            if (total > amount)
            {
                total -= coins[index];
                index--;
            }
            else
            {
                count++;
            }
        }

        if (total != amount)
        {
            return -1;
        }

        return count;
    }
}