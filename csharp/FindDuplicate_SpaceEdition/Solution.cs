namespace FindDuplicate_SpaceEdition
{
    class Solution
    {
        /// <summary>
        /// LINQ approach using GroupBy
        /// Time: O(n), Space: O(n) - creates groups
        /// </summary>
        public int FindDuplicate_Linq(int[] arr)
        {
            return arr.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).First();
        }

        /// <summary>
        /// Floyd's Cycle Detection (Tortoise and Hare)
        /// Time: O(n), Space: O(1) ✓
        /// Works for all cases with duplicates
        /// </summary>
        public int FindDuplicate_FloydCycleDetection(int[] arr)
        {
            // Phase 1: Find intersection point in the cycle
            // Treat array as a linked list where arr[i] points to index arr[i]
            int slow = arr[0];
            int fast = arr[0];

            do
            {
                slow = arr[slow];
                fast = arr[arr[fast]];
            } while (slow != fast);

            // Phase 2: Find the entrance to the cycle (the duplicate)
            slow = arr[0];
            while (slow != fast)
            {
                slow = arr[slow];
                fast = arr[fast];
            }

            return slow;
        }

        /// <summary>
        /// Gauss's Formula approach
        /// Time: O(n), Space: O(1) ✓
        /// NOTE: Only works if there's EXACTLY ONE duplicate appearing EXACTLY TWICE
        /// Sum of 1..n = n(n+1)/2
        /// actual_sum - expected_sum = duplicate
        /// </summary>
        public int FindDuplicate_GaussFormula(int[] arr)
        {
            int n = arr.Length - 1;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;

            foreach (int num in arr)
            {
                actualSum += num;
            }

            return actualSum - expectedSum;
        }
    }
}
