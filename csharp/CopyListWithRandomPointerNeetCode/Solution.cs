namespace CopyListWithRandomPointerNeetCode;

public static class Solution
{
    public static RandomNode? CopyRandomList(RandomNode? head)
    {
        throw new NotImplementedException();
    }
}

public sealed class RandomNode
{
    public int Val { get; set; }
    public RandomNode? Next { get; set; }
    public RandomNode? Random { get; set; }

    public RandomNode(int val)
    {
        Val = val;
    }
}
