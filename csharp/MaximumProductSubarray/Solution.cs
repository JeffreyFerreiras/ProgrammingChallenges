namespace MaximumProductSubarray;

public class Solution
{
    /// <summary>
    /// Returns the maximum product of a contiguous subarray.
    /// </summary>
    public int MaxProduct(int[] nums)
    {
        var currentMax = nums[0];
        var currentMin = nums[0];
        var best = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var value = nums[i];

            if (value < 0)
            {
                (currentMax, currentMin) = (currentMin, currentMax);
            }

            currentMax = Math.Max(value, currentMax * value);
            currentMin = Math.Min(value, currentMin * value);
            best = Math.Max(best, currentMax);
        }

        return best;
    }
}
