/**
There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0 - indexed).For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.




Example 1:

Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 0
Output: 4

Example 2:

Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 3
Output: -1

Example 3:

Input: nums = [1], target = 0
Output: -1



Constraints:

1 <= nums.length <= 5000
-104 <= nums[i] <= 104
All values of nums are unique.
nums is an ascending array that is possibly rotated.
-104 <= target <= 104
*/

int[] nums;
int target;
int expected;
int result;

// [4, 5, 6, 7, 0, 1, 2]
nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
target = 0;
expected = 4;
result = Search(nums, target);

Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

//[4, 5, 6, 7, 0, 1, 2]
target = 3;
expected = -1;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

//[1]
nums = new int[] { 1 };
target = 0;
expected = -1;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

//[-1, -1, -1, -1, 0, 1, 2]
nums = new int[] { -1, -1, -1, -1, 0, 1, 2 };
target = 0;
expected = 4;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

//all 0
nums = new int[] { 0, 0, 0, 0, 0, 0, 0 };
target = 0;
expected = nums.Length / 2;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

// [7, 0, 1, 2, 4, 5, 6,]
nums = new int[] { 7, 0, 1, 2, 4, 5, 6 };
target = 0;
expected = 1;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

// [ 0, 1, 2, 4, 5, 6, 7]
nums = new int[] { 0, 1, 2, 4, 5, 6, 7 };
target = 0;
expected = 0;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

//Input: nums = [4,5,6,7,0,1,2], target = 0
//Output: 4
nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
target = 0;
expected = 4;
result = Search(nums, target);
Console.WriteLine($"RESULT: {result} EXPECTED: {expected}");

int Search(int[] nums, int target)
{
    int left = 0;
    int right = nums.Length - 1;
    int mid;

    while (left <= right)
    {
        mid = (left + right) / 2;

        if (nums[mid] == target)
        {
            return mid;
        }

        if (nums[left] < nums[right])
        {
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        else
        { // array is rotated
            if (nums[left] > nums[mid] && target >= nums[left])
            {
                right = mid - 1;
            }
            else if (nums[right] < nums[mid] && target <= nums[right])
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
    }

    return -1;
}