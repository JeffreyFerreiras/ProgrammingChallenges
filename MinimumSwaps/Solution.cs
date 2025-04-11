using System;
using System.Linq;

namespace MinimumSwaps
{
    public class Solution
    {
        public int MinSwaps(int[] data)
        {
            int totalOnes = data.Sum();
            int currentOnesInWindow = 0, maxOnesInWindow = 0;
            int leftIndex = 0, rightIndex = 0;

            while (rightIndex < data.Length)
            {
                // Add the new element to the window count of ones
                currentOnesInWindow += data[rightIndex++];
                // Maintain the window length to exactly totalOnes
                if (rightIndex - leftIndex > totalOnes)
                {
                    // Remove the oldest element from the window count
                    currentOnesInWindow -= data[leftIndex++];
                }
                // Record the maximum number of ones found in any valid window
                maxOnesInWindow = Math.Max(maxOnesInWindow, currentOnesInWindow);
            }
            return totalOnes - maxOnesInWindow;
        }

        public int MinSwaps2(int[] data)
        {
            int totalOnes = data.Sum();
            int currentOnesInWindow = 0, maxOnesInWindow = 0;
            int low = 0, high = 0;

            while(high < data.Length)
            {
                currentOnesInWindow += data[high];
                high++;

                if(high - low > totalOnes) // total ones is the window
                {
                    currentOnesInWindow -= data[low];
                    low++;
                }

                maxOnesInWindow = Math.Max(maxOnesInWindow, currentOnesInWindow);
            }

            return totalOnes - maxOnesInWindow; // the number of swaps needed after finding the max number of ones in a window is the total ones minus the max number of ones found.
        }
    }
}