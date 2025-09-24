namespace DailyTemperatures;

public static class Solution
{
    // 739. Daily Temperatures
    // Monotonic decreasing stack holding indices. O(n) time, O(n) space.
    public static int[] DailyTemperatures_Stack(int[] temperatures)
    {
        var days = new int[temperatures.Length];
        Stack<int> stack = new();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int idx = stack.Pop();
                days[idx] = i - idx;
            }
            stack.Push(i);
        }

        return days;
    }

    // Alternate two-pass approach storing next greater index using arrays
    public static int[] DailyTemperatures_TwoPass(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] ans = new int[n];
        int[] next = Enumerable.Repeat(int.MaxValue, 101).ToArray(); // temperatures range 30..100

        for (int i = n - 1; i >= 0; i--)
        {
            int t = temperatures[i];
            int warmerIndex = int.MaxValue;
            for (int temp = t + 1; temp <= 100; temp++)
            {
                warmerIndex = Math.Min(warmerIndex, next[temp]);
            }
            if (warmerIndex != int.MaxValue)
                ans[i] = warmerIndex - i;
            next[t] = i;
        }
        return ans;
    }
}
