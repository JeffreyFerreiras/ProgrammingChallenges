using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace ContainsDuplicate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var rand = new Random();
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 16 };
            //arr with 100 random numbers
            //int[] arr = Enumerable.Range(0, 1000000).Select(x => rand.Next(0, 1000000)).ToArray();
            //var timer = Stopwatch.StartNew();
            //bool result;
            //bool expected = Solution.ContainsDuplicate_InsertionSort(arr);
            //timer.Restart();
            //result = Solution.ContainsDuplicate_SelectionSort(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_SelectionSort)} \t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");

            //timer.Restart();
            //result = Solution.ContainsDuplicate_InsertionSort(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_InsertionSort)} \t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");

            //timer.Restart();
            //result = Solution.ContainsDuplicate_QuickSort(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_QuickSort)} \t\t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");
            
            //timer.Restart();
            //result = Solution.ContainsDuplicate_HashSet(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_HashSet)} \t\t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");

            //timer.Restart();
            //result = Solution.ContainsDuplicate_HashSet2(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_HashSet2)}  \t\t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");

            //timer.Restart();
            //result = Solution.ContainsDuplicate_NetSort(arr);
            //Console.WriteLine($"{nameof(Solution.ContainsDuplicate_NetSort)}  \t\t\tresult: {result} expected: {expected} time: {timer.Elapsed} ms");


            BenchmarkRunner.Run<SolutionBenchmark>();
            
            Console.ReadKey();
        }
    }

    [MemoryDiagnoser(false)]
    //[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.SlowestToFastest)]
    [RankColumn]
    public class SolutionBenchmark
    {
        private readonly Solution solution = new();
        private static readonly Random rand = new(420);
        int[] ints = Enumerable.Range(0, 100).Select(x => rand.Next(0, 100)).ToArray();
		//int[] ints1 = Enumerable.Range(0, 10).Select(x => rand.Next(0, 10000)).ToArray();
		//int[] ints2 = Enumerable.Range(0, 15).Select(x => rand.Next(0, 50)).ToArray();
		public IEnumerable<int[]> Data()
		{

			yield return ints;
			//yield return ints1;
			//yield return ints2;
		}

		//public int[] Data()
		//{
		//	return ints;
		//}

		[Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void NetSort(int[] nums) => solution.ContainsDuplicate_NetSort(nums);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void SelectionSort(int[] nums) => solution.ContainsDuplicate_SelectionSort(nums);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void InsertionSort(int[] nums) => solution.ContainsDuplicate_InsertionSort(nums);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void QuickSort(int[] nums) => solution.ContainsDuplicate_QuickSort(nums);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void HashSet(int[] nums) => solution.ContainsDuplicate_HashSet(nums);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void HashSet2(int[] nums) => solution.ContainsDuplicate_HashSet2(nums);
    }

    public class Solution
    {
        public bool ContainsDuplicate_NetSort(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] == nums[i])
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsDuplicate_SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int smallest = i;
                int unsorted = i + 1;

                // find smallest number index to the right
                while(unsorted < nums.Length)
                {
                    if (nums[smallest] > nums[unsorted])
                    {
                        smallest = unsorted;
                    }
                    unsorted++;
                }

                //swap smallest and index
                var temp = nums[smallest];
                nums[smallest] = nums[i];
                nums[i] = temp;

                if (i != 0 && nums[i - 1] == nums[i])
                {
                    return true;
                }
            }
            if (nums[nums.Length - 2] == nums[nums.Length - 1])
            {
                return true;
            }
            return false;
        }

        
        public bool ContainsDuplicate_InsertionSort(int[] nums)
        {
            for(int i = 1; i < nums.Length; i++)
            {
                int j = i; //start with current index
                int val = nums[i]; //current value

                while (j > 0 && nums[j - 1] >= val) //while J -1 is greater than value shift bigger value up
                {
                    if (nums[j - 1] == val) return true;
                    nums[j] = nums[j - 1];
                    j--;
                }
                nums[j] = val;
            }

            return false;
        }

        public bool ContainsDuplicate_QuickSort(int[] nums)
        {
            bool hasDuplicate = false;
            QuickSort(nums, 0, nums.Length - 1);
            
            return hasDuplicate;
            void QuickSort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int i = Partition(arr, low, high);
                    if (hasDuplicate) return;
                    QuickSort(arr, low, i - 1);      //Sort left side
                    QuickSort(arr, i, high);         //Sort right side
                }
            }

            int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[(low + high) / 2];

                while (low <= high)
                {
                    while (arr[low] < pivot) low++;          //Check numbers until one needs to be swaped to right side of the pivot.
                    while (arr[high] > pivot) high--;         //Check numbers until one needs to be swaped to left side of the pivot.

                    if (arr[low] == pivot || arr[high] == pivot)
                    { 
                        hasDuplicate = true;
                        return -1;
                    }

                    if (low <= high)
                    {
                        var temp = arr[low];
                        arr[low] = arr[high];
                        low++;
                        high--;
                    }

                    
                }

                return low;
            }
        }

        public bool ContainsDuplicate_HashSet(int[] nums)
        {
            var hashSet = new HashSet<int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hashSet.Add(nums[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsDuplicate_HashSet2(int[] nums)
        {
            return new HashSet<int>(nums).Count != nums.Length;
        }
    }
}