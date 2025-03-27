public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = [.. nums];
        int result = 0;
        foreach (int num in set)
        {
            if (set.Contains(num - 1)) continue;
            
            int count = 1;
            while (set.Contains(num + count))
            {
                count += 1;
            }
            result = Math.Max(result, count);
        }

        return result;
    }
}
