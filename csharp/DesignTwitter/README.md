# 355. Design Twitter (C#)

## Problem
Design a miniature Twitter clone supporting the following operations:
- postTweet(userId, tweetId): Compose a new tweet.
- getNewsFeed(userId): Retrieve up to ten most recent tweet IDs in the user’s news feed. The feed includes tweets posted by the user and everyone they follow, sorted from most recent to least recent.
- ollow(followerId, followeeId): Follower subscribes to followee’s tweets.
- unfollow(followerId, followeeId): Follower stops seeing followee’s tweets.

Tweets must retain creation order, so merging recent tweets can be solved with a max-heap that stores (timestamp, tweetId, userId) tuples.

## Examples
- **Example 1**
  - postTweet(1, 5) ? 
ull
  - getNewsFeed(1) ? [5]
  - ollow(1, 2) ? 
ull
  - postTweet(2, 6) ? 
ull
  - getNewsFeed(1) ? [6,5]
  - unfollow(1, 2) ? 
ull
  - getNewsFeed(1) ? [5]

## Edge Cases and Long Examples
- Following a user should not create duplicate relationships; unfollowing a user not currently followed should have no effect.
- Users may post many tweets; efficiently retrieving the ten most recent items across several timelines requires a heap.
- The harness includes a "Heavy Timeline" scenario with 10 users and 200 tweets to ensure heap-based merging performs efficiently.

## Constraints
- 1 <= userId, tweetId <= 500
- At most 10^4 operations will be performed.
- News feed should return at most 10 entries, even when more are available.

## Implementation Notes
- Implement Solution.CreateTwitter() so it returns a Twitter instance encapsulating all data structures.
- Twitter should track each user’s tweets with timestamps and maintain follower relations. GetNewsFeed should use a max-heap (priority queue) to pull the newest tweet from each relevant timeline.
- Program.cs drives multiple operation sequences, measures execution with a stopwatch (milliseconds, four decimal places), and prints the feeds returned alongside the expected outputs. All methods currently throw NotImplementedException so you can implement the data structures yourself.
