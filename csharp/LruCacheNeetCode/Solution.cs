namespace LruCacheNeetCode;

public sealed class LruCache
{
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _nodeMap;
    private readonly LinkedList<(int key, int value)> _lruList;
    private readonly int _capacity;

    public LruCache(int capacity)
    {
        _nodeMap = new Dictionary<int, LinkedListNode<(int key, int value)>>(capacity);
        _lruList = new LinkedList<(int key, int value)>();
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_nodeMap.TryGetValue(key, out var node))
        {
            return -1;
        }

        // Move to front (most recently used)
        _lruList.Remove(node);
        _lruList.AddFirst(node);
        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (_nodeMap.TryGetValue(key, out var existingNode))
        {
            // Update existing key
            _lruList.Remove(existingNode);
            var newNode = _lruList.AddFirst((key, value));
            _nodeMap[key] = newNode;
        }
        else
        {
            // Add new key
            if (_nodeMap.Count >= _capacity)
            {
                // Evict least recently used (last in list)
                var lruNode = _lruList.Last!;
                _lruList.RemoveLast();
                _nodeMap.Remove(lruNode.Value.key);
            }

            var node = _lruList.AddFirst((key, value));
            _nodeMap[key] = node;
        }
    }
}
