mod solution;

use solution::find_duplicate;
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("287. Find The Duplicate Number");
    println!("====================================================================");

    run_scenario(
        "Example: [1,3,4,2,2]",
        || find_duplicate(&[1, 3, 4, 2, 2]),
        2,
    );

    run_scenario(
        "Edge: minimal length",
        || find_duplicate(&[1, 1]),
        1,
    );

    run_scenario(
        "Long: duplicate in middle of range",
        || {
            let mut input: Vec<i32> = (1..=100).collect();
            input.push(73);
            find_duplicate(&input)
        },
        73,
    );
}

fn run_scenario<F>(name: &str, action: F, expected: i32)
where
    F: FnOnce() -> i32 + std::panic::UnwindSafe,
{
    let start = Instant::now();
    let result = catch_unwind(AssertUnwindSafe(action));
    let elapsed_ms = start.elapsed().as_secs_f64() * 1000.0;

    match result {
        Ok(value) => {
            println!("Scenario: {name}");
            println!("  Time: {elapsed_ms:.4} ms");
            println!("  Result: {value}");
            println!("  Expected: {expected}");
        }
        Err(_) => {
            println!("Scenario: {name}");
            println!("  Status: NOT IMPLEMENTED [{elapsed_ms:.4} ms]");
            println!("  Expected: {expected}");
        }
    }
}
