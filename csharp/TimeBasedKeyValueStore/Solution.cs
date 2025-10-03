using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TimeBasedKeyValueStore;

public class Solution
{
    public static TimeMap CreateTimeMap()
    {
        return new();
    }

    public class TimeMap
    {
        private readonly Dictionary<string, List<(int timestamp, string value)>> _store = new();

        public void Set(string key, string value, int timestamp)
        {
            if (!_store.ContainsKey(key))
                _store[key] = new List<(int timestamp, string value)>();
            if (_store[key].Count == 0 || timestamp > _store[key][^1].timestamp)
                _store[key].Add((timestamp, value));
            else throw new ArgumentException("Timestamps must be strictly increasing for each key.");
        }

        public string Get(string key, int timestamp)
        {
            if (!_store.ContainsKey(key))
                return string.Empty;

            var timestampedValues = _store[key];
            int left = 0,
                right = timestampedValues.Count - 1;
            string result = string.Empty;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (timestampedValues[mid].timestamp == timestamp)
                    return timestampedValues[mid].value;
                else if (timestampedValues[mid].timestamp < timestamp)
                {
                    result = timestampedValues[mid].value;
                    left = mid + 1;
                }
                else right = mid - 1;
            }

            return result;
        }
    }
}
