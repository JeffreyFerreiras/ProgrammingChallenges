namespace ImplementTrie;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = [];

    public char Value { get; private set; } = default;

    public bool IsWord { get; set; }

    public void Insert(string word)
    {
        TrieNode currentNode = this;

        foreach (char c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                currentNode.Children[c] = new TrieNode() { Value = c };
            }

            currentNode = currentNode.Children[c];
        }

        currentNode.IsWord = true;
    }
}

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        _root.Insert(word);
    }

    public bool Search(string word)
    {
        TrieNode currentNode = _root;

        foreach (char c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                return false;
            }

            currentNode = currentNode.Children[c];
        }

        return currentNode.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode currentNode = _root;

        foreach (char c in prefix)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                return false;
            }

            currentNode = currentNode.Children[c];
        }

        return true;
    }
}
