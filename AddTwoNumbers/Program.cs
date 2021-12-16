
// See https://aka.ms/new-console-template for more information
using System.Linq;

;
var l1 = GenerateInputNode("[2,4,3]");
var l2 = GenerateInputNode("[5,6,4]");

var result = AddTwoNumbers(l1, l2);


l1 = GenerateInputNode("[9,9,9,9,9,9,9]");
l2 = GenerateInputNode("[9,9,9,9]");
result = AddTwoNumbers(l1, l2);

static ListNode GenerateInputNode(string source)
{
    ListNode root = null;
    source = source.Trim('[').Trim(']');
    var col = source.Split(',').Select(x => int.Parse(x)).ToArray();
    foreach (var item in col)
    {
        root = new ListNode(item, root);
    }
    return root;
}

static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    // loop through each node from the ending num
    // exit loop when one of the nodes runs out of itmes.
    // append the remaining nums to the front

    ListNode iter = null;
    ListNode root = iter;
    
    var remainder = 0;

    while (l1 != null || l2 != null || remainder > 0)
    {
        int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + remainder;
        
        if(remainder > 0) remainder = 0;

        if (sum >= 10)
        {
            remainder = sum / 10;
            sum %= 10;
        }

        l1 = l1?.next;
        l2 = l2?.next;

        if(iter != null)
        {
            iter.next = new ListNode(sum, null);
            iter = iter.next;
        }
        else
        {
            iter = root = new ListNode(sum, null);
        }
    }

    return root;
}