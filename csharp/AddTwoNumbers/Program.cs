// See https://aka.ms/new-console-template for more information
;
var solution = new Solution();
var l1 = GenerateInputNode("[2,4,3]");
var l2 = GenerateInputNode("[5,6,4]");

var result = solution.AddTwoNumbers(l1, l2);

l1 = GenerateInputNode("[9,9,9,9,9,9,9]");
l2 = GenerateInputNode("[9,9,9,9]");
result = solution.AddTwoNumbers(l1, l2);

static ListNode? GenerateInputNode(string source)
{
    ListNode? root = null;
    source = source.Trim('[').Trim(']');
    var col = source.Split(',').Select(x => int.Parse(x)).ToArray();
    foreach (var item in col)
    {
        root = new ListNode(item, root);
    }
    return root;
}
