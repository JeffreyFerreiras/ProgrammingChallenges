namespace TrappingRainWater;

public static class Solution
{
    public static int Trap(int[] height)
    {
        //find the first border
        //sum nums until a higher number is found then are in between
        //current sum from middle number minus the lower of 
    }

    public static int Trap2(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int totalWater = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    totalWater += leftMax - height[left];
                }
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                {
                    rightMax = height[right];
                }
                else
                {
                    totalWater += rightMax - height[right];
                }
                right--;
            }
        }

        return totalWater;
    }
}
