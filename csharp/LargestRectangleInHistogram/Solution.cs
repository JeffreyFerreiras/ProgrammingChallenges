namespace LargestRectangleInHistogram;

public class Solution
{
    public static int LargestRectangleArea(int[] heights)
    {
        if (heights.Length == 0)
            return 0;

        Stack<int> stack = new(heights.Length);
        int maxArea = 0;

        for (int i = 0; i <= heights.Length; i++)
        {
            int currentHeight = (i == heights.Length) ? 0 : heights[i];

            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];
                int width = stack.Count > 0 ? i - stack.Peek() - 1 : i;
                maxArea = Math.Max(maxArea, height * width);
            }

            stack.Push(i);
        }

        return maxArea;
    }
}
