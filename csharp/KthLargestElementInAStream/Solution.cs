namespace KthLargestElementInAStream;

public class Solution
{
    public KthLargest CreateKthLargest(int k, int[] nums)
    {
        return new KthLargest(k, nums);
    }

    public class KthLargest
    {
        private readonly int k;
        private readonly PriorityQueue<int, int> largest = new();

        public KthLargest(int k, int[] nums)
        {
            this.k = k;

            foreach (int num in nums)
            {
                Add(num);
            }
        }

        public int Add(int val)
        {
            largest.Enqueue(val, val);

            if (largest.Count > k)
            {
                largest.Dequeue();
            }

            return largest.Peek();
        }
    }
}
