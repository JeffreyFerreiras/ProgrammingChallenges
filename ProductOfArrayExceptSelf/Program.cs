


using ProductOfArrayExceptSelf;


var input = new int[] { 1, 2, 3, 4 };
var expected = new int[] { 24, 12, 8, 6 };

var result = Solution.ProductExceptSelf(input);
Console.WriteLine($"result: {string.Join(",", result)} expected: {string.Join(",", expected)}");


//[1,-1]
input = [1, -1];
expected = [-1, 1];
result = Solution.ProductExceptSelf(input);
//print result
Console.WriteLine($"result: {string.Join(",", result)} expected: {string.Join(",", expected)}");



//[-1,1,0,-3,3]
input = [-1, 1, 0, -3, 3];
expected = [0, 0, 9, 0, 0];
result = Solution.ProductExceptSelf(input);
//print result
Console.WriteLine($"result: {string.Join(",", result)} expected: {string.Join(",", expected)}");


Console.ReadKey();