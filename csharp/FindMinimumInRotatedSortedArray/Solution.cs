namespace FindMinimumInRotatedSortedArray;

public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0,
            right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (right + left) / 2;

            if (nums[mid] < nums[right])
            {
                right = mid;
            }
            else if (nums[mid] > nums[left])
            {
                left = mid + 1;
            }
            else
                break;
        }

        return nums[right];
    }
}
