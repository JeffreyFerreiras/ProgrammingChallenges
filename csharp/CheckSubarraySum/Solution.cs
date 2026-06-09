namespace CheckSubarraySum
{
    public class Solution
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            var sumsSet = new HashSet<int>(nums.Length);
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int previousSum = sum;
                sum = (sum + nums[i]) % k;
                if (sumsSet.Contains(sum))
                {
                    return true;
                }

                sumsSet.Add(previousSum);
            }

            return false;
        }

        public bool CheckSubarraySum2(int[] nums, int k)
        {
            Dictionary<int, int> remainderDict = new()
            {
                [0] = -1
            };
            int runningSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];
                int remainder = k == 0 ? runningSum : runningSum % k;

                if (remainderDict.ContainsKey(remainder))
                {
                    if (i - remainderDict[remainder] > 1)
                    {
                        return true;
                    }
                }
                else
                {
                    remainderDict[remainder] = i;
                }
            }

            return false;
        }
    }
}