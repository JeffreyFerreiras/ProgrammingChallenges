using System;

namespace CombinationSum;
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        //[2,3,6,7]
        List<IList<int>> result = new(target);
        Combinations(new List<int>(), target, 0);
        return result;

        void Combinations(List<int> comb, int currentTarget, int index)
        {
            // base case
            if (comb.Count > 0 && currentTarget == 0)
            { // if 0 is reached then its a valid combination
                result.Add([.. comb]);
            }
            else if (currentTarget > 0)
            {
                for (int i = index; i < candidates.Length; i++)
                {
                    if (candidates[i] > currentTarget) continue;
                    comb.Add(candidates[i]);
                    // reduce the target by the current elem,
                    // dont increment index since the next loop 
                    // deeper in the stack will increment it, 
                    // but the same number can be reused towards the answer.
                    Combinations(comb, currentTarget - candidates[i], i);
                    comb.RemoveAt(comb.Count - 1); //backtrack
                }
            }
        }
    }
}