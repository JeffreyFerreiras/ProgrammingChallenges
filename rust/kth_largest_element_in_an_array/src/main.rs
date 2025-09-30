use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    numbers: Vec<i32>,
    k: i32,
    expected: i32,
}

fn main() {
    println!("215. Kth Largest Element in an Array");
    println!("====================================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            numbers: vec![3, 2, 1, 5, 6, 4],
            k: 2,
            expected: 5,
        },
        Scenario {
            name: "Example 2",
            numbers: vec![3, 2, 3, 1, 2, 4, 5, 5, 6],
            k: 4,
            expected: 4,
        },
        Scenario {
            name: "All Identical",
            numbers: vec![7; 8],
            k: 3,
            expected: 7,
        },
        Scenario {
            name: "Large Ascending",
            numbers: generate_ascending(200_000),
            k: 1,
            expected: 200_000,
        },
        Scenario {
            name: "Large Descending",
            numbers: generate_descending(200_000),
            k: 200_000,
            expected: 1,
        },
    ];

    for scenario in scenarios {
        run_scenario(&scenario);
    }
}

fn generate_ascending(length: usize) -> Vec<i32> {
    (0..length).map(|i| (i + 1) as i32).collect()
}

fn generate_descending(length: usize) -> Vec<i32> {
    (0..length).map(|i| (length - i) as i32).collect()
}

fn run_scenario(scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  k: {}", scenario.k);
    println!("  Length: {}", scenario.numbers.len());
    println!("  Expected: {}", scenario.expected);

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::find_kth_largest(scenario.numbers.clone(), scenario.k));
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(value) => println!("  Result: {}", value),
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

    println!();
}
