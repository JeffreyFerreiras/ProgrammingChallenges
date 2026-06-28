namespace SingleNumber;

public class Solution
{
    // Brute Force — O(n²) time, O(1) space
    // For each element, scan the rest of the array to check if a duplicate exists.
    public int SingleNumber_BruteForce(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            bool foundMatch = false;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[j] == nums[i])
                {
                    foundMatch = true;
                    break;
                }
            }
            if (!foundMatch)
                return nums[i];
        }

        return -1; // unreachable given valid input
    }

    // Hash Map — O(n) time, O(n) space
    // Count occurrences; return the element appearing exactly once.
    public int SingleNumber_HashMap(int[] nums)
    {
        Dictionary<int, int> counts = [];

        foreach (int num in nums)
            counts[num] = counts.GetValueOrDefault(num, 0) + 1;

        foreach (var (num, count) in counts)
            if (count == 1)
                return num;

        return -1; // unreachable given valid input
    }

    // XOR — O(n) time, O(1) space
    // TODO: XOR all elements together. Duplicates cancel (a ^ a = 0), leaving the single number.
    public int SingleNumber_XOR(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            nums[0] ^= nums[i];
        }
        return nums[0];
    }
}
