namespace TimeBasedKeyValueStore;

public class Solution
{
    public TimeMap CreateTimeMap()
    {
        throw new NotImplementedException("Return a new TimeMap instance that stores values by timestamp.");
    }

    public class TimeMap
    {
        public void Set(string key, string value, int timestamp)
        {
            throw new NotImplementedException("Store the value for the key at the given timestamp.");
        }

        public string Get(string key, int timestamp)
        {
            throw new NotImplementedException("Retrieve the value with the greatest timestamp less than or equal to the query time.");
        }
    }
}
