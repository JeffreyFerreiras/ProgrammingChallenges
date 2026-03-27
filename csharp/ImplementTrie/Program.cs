namespace ImplementTrie;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Implement Trie (Prefix Tree)");
        Console.WriteLine(new string('=', 30));
        Console.WriteLine("Input:");
        Console.WriteLine(
            "[\"Trie\", \"insert\", \"dog\", \"search\", \"dog\", \"search\", \"do\", \"startsWith\", \"do\", \"insert\", \"do\", \"search\", \"do\"]"
        );
        Console.WriteLine();

        var prefixTree = new Trie();
        var output = new List<string> { "null" };

        prefixTree.Insert("dog");
        output.Add("null");

        bool searchDog = prefixTree.Search("dog");
        output.Add(searchDog.ToString().ToLowerInvariant());

        bool searchDoBeforeInsert = prefixTree.Search("do");
        output.Add(searchDoBeforeInsert.ToString().ToLowerInvariant());

        bool startsWithDo = prefixTree.StartsWith("do");
        output.Add(startsWithDo.ToString().ToLowerInvariant());

        prefixTree.Insert("do");
        output.Add("null");

        bool searchDoAfterInsert = prefixTree.Search("do");
        output.Add(searchDoAfterInsert.ToString().ToLowerInvariant());

        Console.WriteLine("Output:");
        Console.WriteLine($"[{string.Join(", ", output)}]");
        Console.WriteLine();
        Console.WriteLine("Explanation:");
        Console.WriteLine("PrefixTree prefixTree = new PrefixTree();");
        Console.WriteLine("prefixTree.Insert(\"dog\");");
        Console.WriteLine(
            $"prefixTree.Search(\"dog\");    // return {searchDog.ToString().ToLowerInvariant()}"
        );
        Console.WriteLine(
            $"prefixTree.Search(\"do\");     // return {searchDoBeforeInsert.ToString().ToLowerInvariant()}"
        );
        Console.WriteLine(
            $"prefixTree.StartsWith(\"do\"); // return {startsWithDo.ToString().ToLowerInvariant()}"
        );
        Console.WriteLine("prefixTree.Insert(\"do\");");
        Console.WriteLine(
            $"prefixTree.Search(\"do\");     // return {searchDoAfterInsert.ToString().ToLowerInvariant()}"
        );
    }
}
