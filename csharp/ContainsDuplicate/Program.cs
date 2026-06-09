using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

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
        int[] ints = [.. Enumerable.Range(0, 100).Select(x => rand.Next(0, 100))];
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
}