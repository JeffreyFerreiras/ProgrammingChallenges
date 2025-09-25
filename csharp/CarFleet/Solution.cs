namespace CarFleet;

public static class Solution
{
    /// <summary>
    /// Stack approach: Sort by position descending, use stack to track fleets
    /// Time: O(n log n), Space: O(n)
    /// </summary>
    public static int CarFleet_Stack(int target, int[] position, int[] speed)
    {
        int len = position.Length;
        if (len == 0)
            return 0;

        var cars = new (int position, double timeToTarget)[len];
        for (int i = 0; i < len; i++)
        {
            double timeToTarget = (double)(target - position[i]) / speed[i];
            cars[i] = (position[i], timeToTarget);
        }

        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        Stack<double> stack = new();

        foreach (var (pos, time) in cars)
        {
            // If stack is empty or current car takes longer than the previous fleet,
            // it forms a new fleet (can't catch up)
            if (stack.Count == 0 || time > stack.Peek())
            {
                stack.Push(time);
            }
            // Otherwise, current car catches up and joins the existing fleet
        }

        return stack.Count;
    }

    /// <summary>
    /// Array-based approach: No extra stack, count directly
    /// Time: O(n log n), Space: O(n)
    /// </summary>
    public static int CarFleet_Array(int target, int[] position, int[] speed)
    {
        int len = position.Length;
        if (len == 0)
            return 0;

        var cars = new (int position, double timeToTarget)[len];
        for (int i = 0; i < len; i++)
        {
            double timeToTarget = (double)(target - position[i]) / speed[i];
            cars[i] = (position[i], timeToTarget);
        }

        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        int fleetCount = 0;
        double slowestTime = 0;

        foreach (var (pos, time) in cars)
        {
            if (time > slowestTime)
            {
                fleetCount++;
                slowestTime = time;
            }
            // Else, this car joins the fleet ahead
        }

        return fleetCount;
    }

    public static int CarFleet_UseAllRestrictions(int target, int[] position, int[] speed)
    {
        // this for when the cars meet in the target or before the target
        float[] carsMeet = new float[target];

        // get the time when two cars meet and put it in the carsMeet
        for (int i = 0; i < position.Length; i++)
            carsMeet[position[i]] = (float)(target - position[i]) / speed[i];

        float previosFleet = 0;
        int numberOfFleet = 0;

        for (int i = carsMeet.Length - 1; i > -1; i--)
        {
            if (carsMeet[i] > previosFleet)
            {
                previosFleet = carsMeet[i];
                numberOfFleet++;
            }
        }

        return numberOfFleet;
    }
}
