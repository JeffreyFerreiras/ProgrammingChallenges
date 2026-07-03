namespace LastStoneWeight;

public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> heaviest = new();

        foreach (int stone in stones)
        {
            heaviest.Enqueue(stone, -stone);
        }

        while (heaviest.Count > 1)
        {
            int first = heaviest.Dequeue();
            int second = heaviest.Dequeue();

            if (first != second)
            {
                int remaining = first - second;
                heaviest.Enqueue(remaining, -remaining);
            }
        }

        return heaviest.Count == 0 ? 0 : heaviest.Peek();
    }
}
