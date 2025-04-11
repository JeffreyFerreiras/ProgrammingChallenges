namespace TopKFrequentElements
{
    public class Solution
    {
        // This method will return the k most frequent elements in the array
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> counter = [];
            foreach (int num in nums)
            {
                if (!counter.TryAdd(num, 1))
                {
                    counter[num]++;
                }
            }

            int[] result = new int [k];
            PriorityQueue<int, int> queue = new();

            foreach (var item in counter)
            {
                queue.Enqueue(item.Key, item.Value);

                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            for (int i = 0; i < k; i++)
            {
                result[i] = queue.Dequeue();
            }

            return result;
        }
    }
}
