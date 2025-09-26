namespace TrappingRainWater;

public static class Solution
{
    public static int Trap(int[] height)
    {
        int n = height.Length;
        if (n == 0)
            return 0;

        Stack<int> stack = new();
        int totalWater = 0;

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && height[i] > height[stack.Peek()])
            {
                int bottomIndex = stack.Pop();
                if (stack.Count == 0)
                    break;

                int leftIndex = stack.Peek();
                int width = i - leftIndex - 1;
                int boundedHeight = Math.Min(height[leftIndex], height[i]) - height[bottomIndex];
                totalWater += width * boundedHeight;
            }
            stack.Push(i);
        }

        return totalWater;
    }

    public static int Trap_Helper_Arrays(int[] height)
    {
        // find the left max and right max for each index
        int n = height.Length;
        if (n == 0)
            return 0;

        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = height[0];
        for (int i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        rightMax[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        // calculate trapped water
        int totalWater = 0;
        for (int i = 0; i < n; i++)
        {
            totalWater += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return totalWater;
    }

    public static int Trap_2Pointer(int[] height)
    {
        int left = 0,
            right = height.Length - 1;
        int leftMax = 0,
            rightMax = 0;
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
