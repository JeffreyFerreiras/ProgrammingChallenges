// See https://aka.ms/new-console-template for more information

/*
You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.
Find and return the maximum profit you can achieve. 


 */

Console.WriteLine("Hello, World!");

string? leetcodeInput = @"
[7, 1, 5, 3, 6, 4]
[1, 2, 3, 4, 5, 6]
";

int[][]? tests = leetcodeInput
        .Trim()
        .Split(Environment.NewLine)
        .Select(sample =>
        {
            string[]? arrStr = sample.TrimStart('[').TrimEnd(']').Split(',');
            return arrStr.Select(num => int.Parse(num.Trim())).ToArray();
        }).ToArray();

foreach (int[]? test in tests)
{
    Console.WriteLine(MaxProfit(test));
}

int MaxProfit(int[] source)
{
    int maxProfit = 0;

    for (int i = 1; i < source.Count(); i++)
    {
        if (source[i] > source[i - 1])
        {
            maxProfit += source[i] - source[i - 1];
        }
    }

    return maxProfit;
}