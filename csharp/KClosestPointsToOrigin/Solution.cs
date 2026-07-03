namespace KClosestPointsToOrigin;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], int> closest = new();

        foreach (int[] point in points)
        {
            int distance = point[0] * point[0] + point[1] * point[1];
            closest.Enqueue(point, -distance);

            if (closest.Count > k)
            {
                closest.Dequeue();
            }
        }

        int[][] result = new int[closest.Count][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = closest.Dequeue();
        }

        return result;
    }
}
