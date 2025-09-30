use std::vec::Vec;

pub struct Solution;

impl Solution {
    pub fn create_twitter() -> Twitter {
        todo!("Create and return a new Twitter instance that manages tweets with a heap.");
    }
}

pub struct Twitter;

impl Twitter {
    pub fn post_tweet(&mut self, _user_id: i32, _tweet_id: i32) {
        todo!("Record a new tweet for the user with an increasing timestamp.");
    }

    pub fn get_news_feed(&mut self, _user_id: i32) -> Vec<i32> {
        todo!("Merge timelines via a heap and return up to 10 recent tweet IDs.");
    }

    pub fn follow(&mut self, _follower_id: i32, _followee_id: i32) {
        todo!("Register the follow relationship.");
    }

    pub fn unfollow(&mut self, _follower_id: i32, _followee_id: i32) {
        todo!("Remove the follow relationship if it exists.");
    }
}
