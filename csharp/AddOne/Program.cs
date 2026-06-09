namespace AddOne
{
    // Add one number to the array as if doing addition on paper

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            int[] expected;

            int[] sample = [1, 3, 2, 4];
            expected = [1, 3, 2, 5];
            int[] result = solution.AddOne(sample);
            Console.WriteLine(
                "Expected: {0}, Result: {1}",
                string.Join(",", expected),
                string.Join(",", result)
            );

            int[] sample2 = [5, 4, 8, 9];
            int[] result2 = solution.AddOne(sample2);

            int[] sample3 = [9, 8, 9, 9];
            int[] result3 = solution.AddOne(sample3);

            int[] sample4 = [];
            int[] result4 = solution.AddOne(sample4);

            int[] sample5 = [9, 9, 9, 9];
            int[] result5 = solution.AddOne(sample5);
        }
    }
}
