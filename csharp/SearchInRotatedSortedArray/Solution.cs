namespace SearchInRotatedSortedArray;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0,
            right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return mid;
            else if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            else // nums[mid] < nums[right]
            {
                if (nums[mid] < target && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return -1;
    }
}
