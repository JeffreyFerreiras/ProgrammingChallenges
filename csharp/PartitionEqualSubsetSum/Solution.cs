namespace PartitionEqualSubsetSum;

public class Solution
{
    /// <summary>
    /// Determines whether the array can be partitioned into two subsets with equal sum.
    /// </summary>
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false;
        }

        var target = sum / 2;
        var reachable = new bool[target + 1];
        reachable[0] = true;

        foreach (var num in nums)
        {
            for (var total = target; total >= num; total--)
            {
                reachable[total] = reachable[total] || reachable[total - num];
            }
        }

        return reachable[target];
    }
}
