namespace CopyListWithRandomPointerNeetCode;

public static class Solution
{
    public static RandomNode? CopyRandomList(RandomNode? head)
    {
        throw new NotImplementedException();
    }
}

public sealed class RandomNode(int val)
{
    public int Val { get; set; } = val;
    public RandomNode? Next { get; set; }
    public RandomNode? Random { get; set; }
}
