


using ProductOfArrayExceptSelf;


var input = new int[] { 1, 2, 3, 4 };
var expected = new int[] { 24, 12, 8, 6 };

var result = Solution.ProductExceptSelf(input);
Console.WriteLine(string.Join(",", result));


//[1,-1]
input = new int[] { 1, -1 };
expected = new int[] { -1, 1 };
result = Solution.ProductExceptSelf(input);
//print result
Console.WriteLine(string.Join(",", result));


//[-1,1,0,-3,3]
input = new int[] { -1, 1, 0, -3, 3 };
expected = new int[] { 0, 0, 9, 0, 0 };
result = Solution.ProductExceptSelf(input);
//print result
Console.WriteLine(string.Join(",", result));

Console.ReadKey();