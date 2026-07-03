namespace TaskScheduler;

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] frequencies = new int[26];
        int maxFrequency = 0;

        foreach (char task in tasks)
        {
            int frequency = ++frequencies[task - 'A'];
            maxFrequency = Math.Max(maxFrequency, frequency);
        }

        int maxFrequencyCount = 0;
        foreach (int frequency in frequencies)
        {
            if (frequency == maxFrequency)
            {
                maxFrequencyCount++;
            }
        }

        int intervals = (maxFrequency - 1) * (n + 1) + maxFrequencyCount;
        return Math.Max(tasks.Length, intervals);
    }
}
