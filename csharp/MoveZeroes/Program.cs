// See https://aka.ms/new-console-template for more information
/*
Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.
*/

Console.WriteLine("Hello, World!");


void MoveZeroes(int[] nums)
{
    int i = 0;
    int j = 0;

    // traverse the array and move all non-zero elements to the front
    while (j < nums.Length)
    {
        if (nums[j] != 0)
        {
            nums[i] = nums[j];
            i++;
        }
        j++;
    }

    // set the rest of the array to 0
    for (int k = i; k < nums.Length; k++)
    {
        nums[k] = 0;
    }
}