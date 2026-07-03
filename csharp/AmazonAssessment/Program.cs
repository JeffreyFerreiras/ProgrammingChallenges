using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Amazon Assessment - Maximum Quality\n");

        var scenarios = new[]
        {
            ("packets=[1,2,3,4,5] ch=2", new List<int>{1,2,3,4,5}, 2, new int[]{1,2,3,4,5}, 2),
            ("packets=[1,2,3] ch=2",      new List<int>{1,2,3},     2, new int[]{1,2,3},     2),
            ("packets=[5] ch=1",           new List<int>{5},          1, new int[]{5},          1),
        };

        var solution = new Solution();

        foreach (var (name, packets, channels, packetsArr, channelsInt) in scenarios)
        {
            Console.WriteLine($"\n=== {name} ===");

            // maximumQuality (static, List<int>, int)
            {
                var sw = Stopwatch.StartNew();
                long result = 0;
                try { result = Solution.maximumQuality(new List<int>(packets), channels); }
                finally { sw.Stop(); }
                Console.WriteLine($"maximumQuality | {sw.Elapsed.TotalMilliseconds:0.0000} ms | {result}");
            }

            // MaxQualitySum (static, int[], int)
            {
                var sw = Stopwatch.StartNew();
                int result2 = 0;
                try { result2 = Solution.MaxQualitySum((int[])packetsArr.Clone(), channelsInt); }
                finally { sw.Stop(); }
                Console.WriteLine($"MaxQualitySum  | {sw.Elapsed.TotalMilliseconds:0.0000} ms | {result2}");
            }
        }

        Console.WriteLine();
    }
}
