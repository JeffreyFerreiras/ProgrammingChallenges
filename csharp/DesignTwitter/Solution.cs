using System.Collections.Generic;

namespace DesignTwitter;

public class Solution
{
    public Twitter CreateTwitter()
    {
        throw new NotImplementedException("Instantiate and return a Twitter service that maintains tweet timelines with a heap.");
    }

    public class Twitter
    {
        public Twitter()
        {
            throw new NotImplementedException("Initialize data structures for users, follows, and tweet ordering.");
        }

        public void PostTweet(int userId, int tweetId)
        {
            throw new NotImplementedException("Record a new tweet with the correct timestamp for the user.");
        }

        public IList<int> GetNewsFeed(int userId)
        {
            throw new NotImplementedException("Use a heap to merge the user and followee timelines, returning up to 10 tweet IDs.");
        }

        public void Follow(int followerId, int followeeId)
        {
            throw new NotImplementedException("Register that followerId now follows followeeId.");
        }

        public void Unfollow(int followerId, int followeeId)
        {
            throw new NotImplementedException("Remove followeeId from followerId's follow list if present.");
        }
    }
}
