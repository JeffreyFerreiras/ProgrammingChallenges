/*
Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

[4,5,6,7,0,1,2] if it was rotated 4 times.
[0,1,2,4,5,6,7] if it was rotated 7 times.
Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

Given the sorted rotated array nums of unique elements, return the minimum element of this array.

You must write an algorithm that runs in O(log n) time.

Example 1:

Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.
Example 2:

Input: nums = [4,5,6,7,0,1,2]
Output: 0
Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
Example 3:

Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 

Constraints:

n == nums.length
1 <= n <= 5000
-5000 <= nums[i] <= 5000
All the integers of nums are unique.
nums is sorted and rotated between 1 and n times.
*/
int [] nums;
int expected;
int result;

// [3,4,5,1,2]
nums = new int[] {3, 4, 5, 1, 2};
expected = 1;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");


//[4,5,6,7,0,1,2]
nums = new int[] {4, 5, 6, 7, 0, 1, 2};
expected = 0;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

//[11,13,15,17]
nums = new int[] {11, 13, 15, 17};
expected = 11;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

// [1]
nums = new int[] {1};
expected = 1;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

// [2,1]
nums = new int[] {2, 1};
expected = 1;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

// [1,2, -500]
nums = new int[] {1, 2, -500};
expected = -500;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

// [1,2,3,4,5,6,7,0]
nums = new int[] {1, 2, 3, 4, 5, 6, 7, 0};
expected = 0;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");

// all 1s
nums = new int[] {1, 1, 1, 1, 1, 1, 1, 1};
expected = 1;
result = FindMin(nums);
Console.WriteLine($"result: {result} expected: {expected}");


Console.ReadLine();
/**
 * 1. Start by looking at the middle of the array
 * 2. Check the first and last element.
 * 3. 
 */


static int FindMin(int[] nums) 
{
    int left = 0;
    int right = nums.Length - 1;
    int mid = nums.Length / 2;

    while(left <= right)
    {
        mid = (left + right) / 2;
        if (nums[left] > nums[right])
        {
            if (nums[mid] > nums[right]){
                left = mid + 1;
            }
            else if (nums[mid] < nums[right]){
                right = mid;
            }
        }
        else
        {
            return nums[left];
        }
    }

    return nums[left];

}