namespace Permutations_II;

public class Solution2
{
    // _result stores all unique permutations found.
    private IList<IList<int>> _result = [];

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        // n is the number of elements in the input array.
        int n = nums.Length;
        // visited keeps track of which elements are in the current permutation.
        var visited = new bool[n];
        // Begin recursion with an empty current permutation (perm).
        Permute(nums, [], visited);
        return _result;
    }

    private void Permute(int[] nums, IList<int> perm, bool[] visited)
    {
        // If the current permutation has the same number of elements
        // as nums, we've built a complete permutation.
        if (perm.Count == nums.Length)
        {
            // Add a copy of the complete permutation to _result.
            _result.Add([.. perm]);
        }
        else
        {
            // seen is used to avoid processing duplicate numbers on the same recursion level,
            // ensuring that only unique permutations are generated.
            var seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // Continue only if nums[i] is not used in the current permutation (visited[i] is false)
                // and we haven't already used nums[i] (to avoid duplicates at this depth).
                if (!visited[i] && !seen.Contains(nums[i]))
                {
                    // Add the current number to the permutation.
                    perm.Add(nums[i]);
                    // Mark as visited.
                    visited[i] = true;
                    // Record the number as seen in this recursion level.
                    seen.Add(nums[i]);

                    // Recursively build the rest of the permutation.
                    Permute(nums, perm, visited);

                    // Backtrack: unmark the current number and remove it from the permutation.
                    visited[i] = false;
                    perm.RemoveAt(perm.Count - 1);
                }
            }
        }
    }
}
public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        List<IList<int>> asccumulator = [];
        Dictionary<int, int> counter = [];
        List<int> perm = [];

        foreach (var num in nums)
        {
            if (!counter.TryAdd(num, 1))
                counter[num] += 1;
        }

        Permute();

        return asccumulator;

        void Permute()
        {
            if (nums.Length == perm.Count)
            {
                asccumulator.Add([.. perm]);
            }
            else
            {
                foreach (var num in counter.Keys)
                {
                    if (counter[num] == 0)
                        continue;

                    perm.Add(num);
                    counter[num]--;

                    Permute();

                    perm.RemoveAt(perm.Count - 1);
                    counter[num]++;
                }
            }
        }
    }
}