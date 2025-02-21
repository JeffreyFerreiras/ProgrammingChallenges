namespace Permutations_II;

public class Program
{
    public static void Main()
    {
        Run([1, 1, 2]);
        Run([2, 2, 1, 1]);
    }

    static void Run(int[] nums)
    {
        var solution = new Solution();
        var result = solution.PermuteUnique(nums); 
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(", ", item));
        }
    }
}
