use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

enum Operation {
    PostTweet { user: i32, tweet: i32 },
    Follow { follower: i32, followee: i32 },
    Unfollow { follower: i32, followee: i32 },
    GetNewsFeed { user: i32, expected: Vec<i32> },
    Build,
}

struct Scenario {
    name: &'static str,
    operations: Vec<Operation>,
}

fn main() {
    println!("355. Design Twitter");
    println!("====================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            operations: vec![
                Operation::PostTweet { user: 1, tweet: 5 },
                Operation::GetNewsFeed { user: 1, expected: vec![5] },
                Operation::Follow { follower: 1, followee: 2 },
                Operation::PostTweet { user: 2, tweet: 6 },
                Operation::GetNewsFeed { user: 1, expected: vec![6, 5] },
                Operation::Unfollow { follower: 1, followee: 2 },
                Operation::GetNewsFeed { user: 1, expected: vec![5] },
            ],
        },
        Scenario {
            name: "Multiple Users",
            operations: vec![
                Operation::PostTweet { user: 2, tweet: 101 },
                Operation::PostTweet { user: 3, tweet: 102 },
                Operation::PostTweet { user: 1, tweet: 103 },
                Operation::Follow { follower: 1, followee: 2 },
                Operation::Follow { follower: 1, followee: 3 },
                Operation::GetNewsFeed { user: 1, expected: vec![103, 102, 101] },
                Operation::Unfollow { follower: 1, followee: 2 },
                Operation::PostTweet { user: 3, tweet: 104 },
                Operation::GetNewsFeed { user: 1, expected: vec![104, 103, 102] },
            ],
        },
        Scenario {
            name: "Heavy Timeline",
            operations: build_heavy_scenario(),
        },
    ];

    for scenario in scenarios {
        run_scenario(&scenario);
    }
}

fn build_heavy_scenario() -> Vec<Operation> {
    const USER_COUNT: i32 = 10;
    const TWEETS_PER_USER: i32 = 20;

    let mut operations = Vec::new();
    operations.push(Operation::Build);

    for user in 1..=USER_COUNT {
        for offset in 0..TWEETS_PER_USER {
            operations.push(Operation::PostTweet {
                user,
                tweet: user * 1_000 + offset,
            });
        }
    }

    operations.push(Operation::GetNewsFeed {
        user: 1,
        expected: Vec::new(),
    });

    for followee in 2..=USER_COUNT {
        operations.push(Operation::Follow {
            follower: 1,
            followee,
        });
    }

    let mut expected_tail = Vec::new();
    for i in 0..10 {
        expected_tail.push(10 * 1_000 + (TWEETS_PER_USER - 1 - i));
    }

    operations.push(Operation::GetNewsFeed {
        user: 1,
        expected: expected_tail,
    });

    operations
}

fn run_scenario(scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Operations: {}", scenario.operations.len());

    let start = Instant::now();
    let result = panic::catch_unwind(|| {
        let mut twitter = Solution::create_twitter();
        let mut feeds = Vec::new();

        for operation in &scenario.operations {
            match operation {
                Operation::PostTweet { user, tweet } => twitter.post_tweet(*user, *tweet),
                Operation::Follow { follower, followee } => twitter.follow(*follower, *followee),
                Operation::Unfollow { follower, followee } => twitter.unfollow(*follower, *followee),
                Operation::GetNewsFeed { user, .. } => {
                    let feed = twitter.get_news_feed(*user);
                    feeds.push(feed);
                }
                Operation::Build => {}
            }
        }

        feeds
    });
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(feeds) => {
            let display = feeds
                .iter()
                .map(|feed| format_vector(feed))
                .collect::<Vec<_>>()
                .join(",");
            println!("  Result: [{}]", display);
        }
        Err(payload) => {
            let message = if let Some(msg) = payload.downcast_ref::<&str>() {
                msg.to_string()
            } else if let Some(msg) = payload.downcast_ref::<String>() {
                msg.clone()
            } else {
                "panic".to_string()
            };
            println!("  Result: panic ({})", message);
        }
    }

    let expected_display = scenario
        .operations
        .iter()
        .filter_map(|op| match op {
            Operation::GetNewsFeed { expected, .. } if !expected.is_empty() => Some(format_vector(expected)),
            Operation::GetNewsFeed { expected, .. } if expected.is_empty() => Some("[]".to_string()),
            _ => None,
        })
        .collect::<Vec<_>>()
        .join(",");
    println!("  Expected Feeds: [{}]", expected_display);

    println!();
}

fn format_vector(values: &[i32]) -> String {
    if values.is_empty() {
        return "[]".to_string();
    }

    format!(
        "[{}]",
        values
            .iter()
            .map(|value| value.to_string())
            .collect::<Vec<_>>()
            .join(",")
    )
}
