public class Solution{

    public static long maximumQuality(List<int> packets, int channels)
    {
        List<List<int>> qualityCollection = new List<List<int>>(channels);
        for(int i = 0; i < channels; i++)
        {
            qualityCollection.Add(new List<int>());
        }
        
        //sort packets in ascending order
        packets.Sort();

        int channelIndex = channels - 1;
        for (int i = packets.Count() - 1; i >= 0; i--)
        {
            qualityCollection[channelIndex].Add(packets[i]);
            channelIndex = Math.Max(0, channelIndex - 1);
        }

        return SumMedian(qualityCollection);
    }

    public static long SumMedian(List<List<int>> qualityCollection)
    {
        long sum = 0;

        foreach (List<int> qualityItem in qualityCollection)
        {

            if (qualityItem.Count() > 2 && qualityItem.Count() % 2 == 0)
            { 
                //average out the two middle numbers
                decimal ans = qualityItem[qualityItem.Count() / 2] + qualityItem[qualityItem.Count() / 2 - 1] / 2;
                sum += (long)Math.Round(ans);
            }
            else
            { 
                //get the middle
                sum += qualityItem[qualityItem.Count() / 2];
            }
        }

        return sum;
    }
    public static int MaxQualitySum(int[] packets, int channels)
    {
        // Sort the packet sizes in non-decreasing order.
        Array.Sort(packets);
        int n = packets.Length;
        // We will “isolate” k-1 channels.
        int singletonCount = channels - 1;

        // Sum the quality of the singleton channels (each is just its packet’s value).
        long sumSingletons = 0;
        for (int i = n - singletonCount; i < n; i++)
        {
            sumSingletons += packets[i];
        }

        // The remaining packets go to one channel.
        int m = n - singletonCount;  // number of packets in the large channel
        double median = 0;
        if (m % 2 == 1)
        {
            // Odd number: the median is the middle element.
            median = packets[m / 2];
        }
        else
        {
            // Even number: the median is the average of the two middle elements.
            median = (packets[m / 2 - 1] + packets[m / 2]) / 2.0;
        }

        double totalQuality = sumSingletons + median;
        // Round to the nearest integer (using MidpointRounding.AwayFromZero).
        int answer = (int)Math.Round(totalQuality, MidpointRounding.AwayFromZero);
        return answer;
    }
}