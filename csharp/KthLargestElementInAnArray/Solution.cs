namespace KthLargestElementInAnArray;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> largest = new();

        foreach (int num in nums)
        {
            largest.Enqueue(num, num);

            if (largest.Count > k)
            {
                largest.Dequeue();
            }
        }

        return largest.Peek();
    }
}
