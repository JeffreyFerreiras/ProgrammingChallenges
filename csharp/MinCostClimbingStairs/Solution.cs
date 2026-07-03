namespace MinCostClimbingStairs;

public class Solution
{
    /// <summary>
    /// Determines the minimum cost required to climb to the top given step costs.
    /// </summary>
    public int MinCostClimbingStairs(int[] cost)
    {
        var twoStepsBack = 0;
        var oneStepBack = 0;

        for (var step = 2; step <= cost.Length; step++)
        {
            var current = Math.Min(oneStepBack + cost[step - 1], twoStepsBack + cost[step - 2]);
            twoStepsBack = oneStepBack;
            oneStepBack = current;
        }

        return oneStepBack;
    }
}
