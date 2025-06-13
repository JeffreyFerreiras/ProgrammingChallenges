// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] input = "[-1,0,3,5,9,12]".Trim('[').Trim(']').Split(',').Select(x=>int.Parse(x)).ToArray();
int target = 9;
var index = Search(input, target);
Console.WriteLine(index);

int Search(int[] nums, int target)
{
    int low = 0;
    int high = nums.Length - 1;

    while (low <= high)
    {
        int mid = (low + high) / 2;

        if (nums[mid] > target)
        {
            high = mid-1;
        }
        else if (nums[mid] < target)
        {
            low = mid+1;
        }
        else
        {
            return mid;
        }
    }

    return -1;
}

