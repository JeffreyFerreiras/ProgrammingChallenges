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

}