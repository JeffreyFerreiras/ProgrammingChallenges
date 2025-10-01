// See https://aka.ms/new-console-template for more information
using LinkedList_Palindrome;

Console.WriteLine("Hello, World!");

var root = CreateTestCase("12021");
var result = Solution.IsPalindrome(root);

Console.WriteLine(result);


// false scenario
root = CreateTestCase("11212");
result = Solution.IsPalindrome(root);
Console.WriteLine(result);

ListNode CreateTestCase(string data)
{
    ListNode root = new();
    ListNode head = root;

    for (int i = 0; i < data.Length; i++)
    {
        root.val = data[i];

        if (i != data.Length - 1)
        {
            root.next = new ListNode();
            root = root.next;
        }
    }

    return head;
}