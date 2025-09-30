using System.Diagnostics;

namespace LruCacheNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("146. LRU Cache");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example sequence from prompt",
            () =>
            {
                var cache = new LruCache(2);
                var outputs = new List<int>();
                cache.Put(1, 1);
                cache.Put(2, 2);
                outputs.Add(cache.Get(1));
                cache.Put(3, 3);
                outputs.Add(cache.Get(2));
                cache.Put(4, 4);
                outputs.Add(cache.Get(1));
                outputs.Add(cache.Get(3));
                outputs.Add(cache.Get(4));
                return FormatOutputs(outputs);
            },
            "[1,-1,-1,3,4]"
        );

        RunScenario(
            "Edge: capacity one",
            () =>
            {
                var cache = new LruCache(1);
                var outputs = new List<int>();
                cache.Put(5, 5);
                outputs.Add(cache.Get(5));
                cache.Put(6, 6);
                outputs.Add(cache.Get(5));
                outputs.Add(cache.Get(6));
                return FormatOutputs(outputs);
            },
            "[5,-1,6]"
        );

        RunScenario(
            "Long: high churn workload",
            () =>
            {
                var cache = new LruCache(3);
                var outputs = new List<int>();
                cache.Put(1, 100);
                cache.Put(2, 200);
                cache.Put(3, 300);
                outputs.Add(cache.Get(1));
                cache.Put(4, 400);
                outputs.Add(cache.Get(2));
                cache.Put(5, 500);
                outputs.Add(cache.Get(3));
                cache.Put(1, 150);
                outputs.Add(cache.Get(1));
                outputs.Add(cache.Get(4));
                outputs.Add(cache.Get(5));
                return FormatOutputs(outputs);
            },
            "[100,-1,-1,150,-1,500]"
        );
    }

    private static void RunScenario(string name, Func<string> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            string result = action();
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {result}");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: NOT IMPLEMENTED [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: ERROR [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Message: {ex.Message}");
        }
    }

    private static string FormatOutputs(IReadOnlyList<int> outputs)
    {
        if (outputs.Count == 0)
        {
            return "[]";
        }

        return $"[{string.Join(",", outputs)}]";
    }
}
