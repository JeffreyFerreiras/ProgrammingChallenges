namespace ImplementTrie;

public class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Implement Trie (Prefix Tree)");
		Console.WriteLine(new string('=', 30));

		var prefixTree = new PrefixTree();

		Console.WriteLine("Scaffold created.");
		Console.WriteLine($"Instance type: {prefixTree.GetType().Name}");
		Console.WriteLine("Methods are intentionally left unimplemented.");
	}
}
