namespace KokoEatingBananas;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (GetEatingSpeedHours(piles, mid) <= h)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private int GetEatingSpeedHours(int[] piles, int speed)
    {
        int hours = 0;
        foreach (int pile in piles)
        {
            hours += (int)Math.Ceiling((decimal)pile / speed);
        }

        return hours;
    }
}
