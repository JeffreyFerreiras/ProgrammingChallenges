public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = [.. nums];
        int result = 0;
        foreach (int num in set)
        {
            if (set.Contains(num - 1))
                continue;

            int count = 1;
            while (set.Contains(num + count))
            {
                count += 1;
            }
            result = Math.Max(result, count);
        }

        return result;
    }

    // must run in O(n) time complexity
    public int LongestConsecutiveUnionFind(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        var unionFind = new UnionFind();
        var numSet = new HashSet<int>(nums);

        // Initialize each number as its own component
        foreach (int num in numSet)
        {
            unionFind.InitializeSet(num);
        }

        // Union consecutive numbers
        foreach (int num in numSet)
        {
            if (numSet.Contains(num + 1))
            {
                unionFind.Union(num, num + 1);
            }
        }

        // Find the maximum component size
        return unionFind.GetMaxComponentSize();
    }
}

public interface IUnionFind
{
    void InitializeSet(int x);
    void Union(int x, int y);
    int Find(int x);
    int GetMaxComponentSize();
}

public class UnionFind : IUnionFind
{
    private readonly Dictionary<int, int> _parent = [];
    private readonly Dictionary<int, int> _consecutiveCountTracker = [];

    public void InitializeSet(int number)
    {
        if (!_parent.ContainsKey(number))
        {
            _parent[number] = number;
            _consecutiveCountTracker[number] = 1;
        }
    }

    public int Find(int value)
    {
        if (_parent[value] != value)
        {
            _parent[value] = Find(_parent[value]);
        }
        return _parent[value];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY)
            return;

        // Union by size - attach smaller tree to larger tree
        if (_consecutiveCountTracker[rootX] < _consecutiveCountTracker[rootY])
        {
            _parent[rootX] = rootY;
            _consecutiveCountTracker[rootY] += _consecutiveCountTracker[rootX];
        }
        else
        {
            _parent[rootY] = rootX;
            _consecutiveCountTracker[rootX] += _consecutiveCountTracker[rootY];
        }
    }

    public int GetMaxComponentSize()
    {
        return _consecutiveCountTracker.Values.Max();
    }
}
