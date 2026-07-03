using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EncodeDecodeString;

internal class Program
{
    private static void Main(string[] args)
    {
        var solution = new Solution();

        var testCases = new[]
        {
            new[] { "neet","code","love","you" },
            new[] { "we","say",":","yes" },
            new[] { "" },
            new[] { "Hello","World" },
        };

        foreach (var words in testCases)
        {
            Console.WriteLine($"\n=== Input: [{string.Join(",", words.Select(w => $"\"{w}\""))}] ===");

            var sw = Stopwatch.StartNew();
            var encoded = solution.Encode(words.ToList());
            sw.Stop();
            Console.WriteLine($"Encode | {sw.Elapsed.TotalMilliseconds:0.0000} ms | \"{encoded}\"");

            sw.Restart();
            var decoded = solution.Decode(encoded);
            sw.Stop();

            var match = decoded.SequenceEqual(words);
            Console.WriteLine($"Decode | {sw.Elapsed.TotalMilliseconds:0.0000} ms | [{string.Join(",", decoded.Select(w => $"\"{w}\""))}] | {(match ? "✅ PASS" : "❌ FAIL")}");
        }

        Console.WriteLine();
    }
}
