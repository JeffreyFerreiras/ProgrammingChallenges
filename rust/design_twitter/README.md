# 355. Design Twitter (Rust)

## Problem
Implement a simplified Twitter supporting:
- post_tweet(user_id, tweet_id)
- get_news_feed(user_id) ? up to ten most recent tweet IDs from the user and their followees
- ollow(follower_id, followee_id)
- unfollow(follower_id, followee_id)

Tweets must retain chronological order so efficiently merging feeds requires a max-heap keyed by timestamps.

## Examples
- Example sequence: post_tweet(1,5), get_news_feed(1) ? [5], ollow(1,2), post_tweet(2,6), get_news_feed(1) ? [6,5], unfollow(1,2), get_news_feed(1) ? [5].

## Edge Cases and Long Examples
- Users may follow themselves implicitly in the original problem statement; ensure you handle or disallow self-follow according to your design.
- Multiple follow/unfollow operations should not duplicate relationships.
- The harness includes a heavy workload where 10 users post 200 tweets before one user follows everyone; retrieving the feed should use a heap to avoid scanning every tweet.

## Constraints
- 1 <= user_id, tweet_id <= 500
- Up to 10^4 operations.
- get_news_feed should return at most 10 tweet IDs sorted by recency.

## Implementation Notes
- Implement Solution::create_twitter to return a Twitter instance holding tweet timelines and follower relationships.
- Twitter::get_news_feed should merge the relevant timelines with a heap or priority queue to retrieve the ten newest tweets.
- src/main.rs runs multiple operation sequences, measures run time with a stopwatch, prints the resulting feeds, and compares them to the expected values while catching 	odo!() panics from unimplemented methods.
