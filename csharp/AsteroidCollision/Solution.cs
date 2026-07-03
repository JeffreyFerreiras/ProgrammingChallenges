namespace AsteroidCollision;

public static class Solution
{
    public static int[] ResolveCollisions(int[] asteroids)
    {
        var stack = new List<int>();

        foreach (int asteroid in asteroids)
        {
            bool destroyed = false;

            while (stack.Count > 0 && asteroid < 0 && stack[^1] > 0)
            {
                int top = stack[^1];

                if (top < -asteroid)
                {
                    stack.RemoveAt(stack.Count - 1);
                    continue;
                }

                if (top == -asteroid)
                {
                    stack.RemoveAt(stack.Count - 1);
                }

                destroyed = true;
                break;
            }

            if (!destroyed)
            {
                stack.Add(asteroid);
            }
        }

        return [.. stack];
    }
}
