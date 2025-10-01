namespace Mini_Max_Sum
{
    class Program
    {
        /**
         * Given five positive integers, 
         * find the minimum and maximum values that can be calculated by summing exactly four of the five integers.
         * Then print the respective minimum and maximum values as a single line of two space-separated long integers
         * 
         * Sample:
         * 1, 2, 3, 4, 5
         * 
         */

        static void Main(string[] args)
        {
            var minMax = MiniMaxSum([1, 2, 3, 4, 5]);

            Console.WriteLine($"{minMax[0]} {minMax[1]}");
            minMax = MiniMaxSum([4, 4, 3, 8, 5]);

            Console.WriteLine($"{minMax[0]} {minMax[1]}");
            Console.Read();
        }

        static long[] MiniMaxSum(int[] arr)
        {
            bool maxFunc(long x, long y) => x > y;

            long max = GetMinMax(arr, maxFunc);

            bool minFunc(long x, long y) => x < y;
            long min = GetMinMax(arr, minFunc);

            return [min, max];
        }

        private static long GetMinMax(int[] arr, Func<long, long, bool> comparer)
        {
            var cache = new List<long>();

            for (int i = 0; i < arr.Length; i++)
            {
                long current = arr[i];

                if (cache.Count < 4)
                {
                    cache.Add(current);
                }
                else
                {
                    ReplaceMinMax(current, cache, comparer);
                }
            }

            return cache.Sum();
        }

        private static void ReplaceMinMax(long current, List<long> cache, Func<long, long, bool> comparer)
        {
            long target = cache[0];

            for (int i = 0; i < cache.Count; i++)
            {
                if (comparer(target, cache[i]))
                {
                    target = cache[i];
                }
            }

            if (comparer(current, target))
            {
                cache.Remove(target);
                cache.Add(current);
            }
        }
    }
}
