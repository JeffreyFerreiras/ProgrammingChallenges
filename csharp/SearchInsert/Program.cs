// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int SearchInsert(int[] nums, int target)
{
    int low = 0;
    int high = nums.Length - 1;
    int mid = 0;

    while (low <= high)
    {
        mid = low + (high - low) / 2;

        if (nums[mid] > target)
        {
            high = mid - 1;
        }
        else if (nums[mid] < target)
        {
            low = mid + 1;
        }
        else
        {
            return mid;
        }
    }

    return low;
}