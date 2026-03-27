namespace ImplementTrie;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new();

    public bool IsWord { get; set; }
}

public class PrefixTree
{
    private readonly TrieNode _root;

    public PrefixTree()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        throw new NotImplementedException();
    }

    public bool Search(string word)
    {
        throw new NotImplementedException();
    }

    public bool StartsWith(string prefix)
    {
        throw new NotImplementedException();
    }
}