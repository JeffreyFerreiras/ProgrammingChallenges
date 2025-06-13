/*
Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

The test cases are generated so that the answer will fit in a 32-bit integer.

A subarray is a contiguous subsequence of the array.
Example 1:

Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
Example 2:

Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 

Constraints:

1 <= nums.length <= 2 * 104
-10 <= nums[i] <= 10
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
*/


//[0,1,2,3]
var nums = new int[] {0,1, 2, 3};
var result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

// write a test case for the folowing input array [-2,3,-4]
nums = new int[] {-2,3,-4};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");


//[0,2]
nums = new int[] {0,2};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[-3,0,1,-2]
nums = new int[] {-3,0,1,-2};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[2,-5,-2,-4,3]
nums = new int[] {2,-5,-2,-4,3};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[7,-2,-4]
nums = new int[] {7,-2,-4};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[1,-2,3,-4,-3,-4,-3]
//expected: 432
nums = new int[] {1,-2,3,-4,-3,-4,-3};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[1,2,-1,-2,2,1,-2,1,4,-5,4]
//expected: 1280
nums = new int[] {1,2,-1,-2,2,1,-2,1,4,-5,4};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[3,-2,-3,-3,1,3,0]
//expected: 27
nums = new int[] {3,-2,-3,-3,1,3,0};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[2,3,-1,1,-3,3,0]
nums = new int[] {2,3,-1,1,-3,3,0};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//[3,1,-2,2,2,1,-2,-3]
nums = new int[] {3,1,-2,2,2,1,-2,-3};
result = MaxProduct(nums);
Console.WriteLine($"result: {result} expected: {MaxProduct_Official(nums)}");

//write a method to solve Maximum Product Subarray
static int MaxProduct_Official(int[] nums) {
    int max = nums[0];
    int min = nums[0];
    int result = nums[0];
    for (int i = 1; i < nums.Length; i++) {
        int temp = max;
        max = Math.Max(
            Math.Max(max * nums[i], min * nums[i]),
            nums[i]
            );

        min = Math.Min(
            Math.Min(temp * nums[i], min * nums[i]),
            nums[i]
            );

        if (max > result) {
            result = max;
        }
    }
    return result;
}

static int MaxProduct_N2(int[] nums)
{
    var max = nums.Aggregate(1, (a, b) => a * b); ;
    var product = 1;

    for (int i = 1; i < nums.Length; i++)
    {
        product = nums[i..].Aggregate(1, (a, b) => a * b);

        if (max < product)
        {
            max = product;
        }
    }
    return max;
}

static int MaxProduct(int[] nums)
{
    var max = nums.Aggregate(1, (a, b) => a * b);
    var product = 1;

    for (int i = 0; i < nums.Length; i++)
    {
        product *= nums[i];

        // if negative number, then we need to check the product of the rest of the numbers
        if(nums[i] < 0 || (nums.Length > i + 1 && nums[i + 1] < 0))
        {
            var temp = nums[i];
            var j = i + 1;

            while (j < nums.Length)
            {
                temp *= nums[j];
                if (max < temp)
                {
                    max = temp;
                }
                j++;
            }
        }

        if (nums[i] > product && nums[i] > 0 && (nums.Length - 1 == i || i + 1 < nums.Length && product * nums[i + 1] < nums[i]))
        {
            var agg = nums[i..].Aggregate(1, (a, b) => a * b);
            if(agg < nums[i])
            {
                product = nums[i];
            }
            if(agg > max){
                max = agg;
            }
            //product = nums[i];
        }

        if(max < product)
        {
            max = product;
        }
    }

    return max;
}

