namespace FindDuplicateNumberNeetCode;

public static class Solution
{
    public static int FindDuplicate(int[] nums)
    {
        int slow = nums[0];
        int fast = nums[0];

        // Phase 1: Finding the intersection point in the cycle
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // Phase 2: Finding the entrance to the cycle
        // assign slow to the start of the array
        // keep fast at the intersection point
        // move both one step at a time; the point they meet is the duplicate number
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}
