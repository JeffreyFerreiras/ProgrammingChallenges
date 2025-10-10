using System.Linq;
using System;

namespace CopyListWithRandomPointerNeetCode;

public static class Solution
{
    public static Node? CopyRandomList(Node? head)
    {
        if (head == null) return null;
        Node? headCopy = head;
        Dictionary<Node, (Node?, int) > adj = [];
        
        int index = 0;
        while (headCopy != null)
        {
            adj[headCopy] = (headCopy.random, index);
            headCopy = headCopy.next;
            index += 1;
        }

        headCopy = head;
        Node? prev = null;
        List<Node> resultNodes = new(adj.Count);
        
        while (headCopy != null)
        {
            Node node = new(headCopy.val);
            if (prev == null)
            {
                prev = node;
                resultNodes.Add(prev);
            }
            else
            {
                prev.next = node;
                prev = prev.next;
                resultNodes.Add(node);
            }
            
            headCopy = headCopy.next;
        }

        headCopy = head;
        foreach (Node node in resultNodes)
        {
            var (rand, _) = adj[headCopy!];
            if (rand != null)
            {
                var (_, randomIdx) = adj[rand];
                node.random = resultNodes[randomIdx];
            }
            headCopy = headCopy!.next;
        }
        
        return resultNodes[0];
    }
}

public sealed class Node(int val)
{
    public int val { get; set; } = val;
    public Node? next { get; set; }
    public Node? random { get; set; }
}
