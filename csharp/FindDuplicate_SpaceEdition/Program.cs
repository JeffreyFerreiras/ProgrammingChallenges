namespace FindDuplicate_SpaceEdition
{
    /*
     * Find a duplicate, Space Edition™.
     * We have a list of integers, where:
     * 1. The integers are in the range 1..n
     * 2. The list has a length of n + 1
     *
     * It follows that our list has at least one integer which appears at least twice.
     * But it may have several duplicates, and each duplicate may appear more than twice.
     * Write a function which finds an integer that appears more than once in our list.
     * (If there are multiple duplicates, you only need to find one of them.)
     *
     * We're going to run this function on our new, super-hip Macbook Pro With Retina Display™.
     * Thing is, the damn thing came with the RAM soldered right to the motherboard, so we can't upgrade our RAM.
     * So we need to optimize for space!
     */

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            // Test scenarios
            var scenarios = new[]
            {
                new
                {
                    Name = "Simple duplicate (2 appears twice)",
                    Array = new[] { 1, 3, 4, 2, 2 },
                    Expected = 2,
                },
                new
                {
                    Name = "Duplicate at start (1 appears twice)",
                    Array = new[] { 1, 1, 2, 3, 4 },
                    Expected = 1,
                },
                new
                {
                    Name = "Multiple duplicates (3 appears twice)",
                    Array = new[] { 3, 1, 3, 4, 2 },
                    Expected = 3,
                },
                new
                {
                    Name = "Larger array (5 appears twice)",
                    Array = new[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 4 },
                    Expected = 9,
                },
            };

            var methods = new[]
            {
                new { Name = "LINQ", Method = (Func<int[], int>)solution.FindDuplicate_Linq },
                new
                {
                    Name = "Floyd's Cycle Detection",
                    Method = (Func<int[], int>)solution.FindDuplicate_FloydCycleDetection,
                },
                new
                {
                    Name = "Gauss's Formula",
                    Method = (Func<int[], int>)solution.FindDuplicate_GaussFormula,
                },
            };

            Console.WriteLine("Testing Find Duplicate Solutions:\n");

            foreach (var method in methods)
            {
                Console.WriteLine($"═══ {method.Name} ═══");
                bool allPassed = true;

                foreach (var scenario in scenarios)
                {
                    try
                    {
                        int result = method.Method(scenario.Array);
                        bool passed = result == scenario.Expected;
                        allPassed &= passed;

                        string status = passed ? "✓" : "✗";
                        Console.WriteLine(
                            $"  {status} {scenario.Name}: {result} {(passed ? "" : $"(expected {scenario.Expected})")}"
                        );
                    }
                    catch (Exception ex)
                    {
                        allPassed = false;
                        Console.WriteLine($"  ✗ {scenario.Name}: Exception - {ex.Message}");
                    }
                }

                Console.WriteLine(
                    $"  Result: {(allPassed ? "✓ All tests passed" : "✗ Some tests failed")}\n"
                );
            }
        }
    }
}
