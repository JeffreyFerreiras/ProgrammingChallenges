mod solution;

use solution::LruCache;
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("146. LRU Cache");
    println!("====================================================================");

    run_scenario(
        "Example sequence from prompt",
        || {
            let mut cache = LruCache::new(2);
            let mut outputs = Vec::new();
            cache.put(1, 1);
            cache.put(2, 2);
            outputs.push(cache.get(1));
            cache.put(3, 3);
            outputs.push(cache.get(2));
            cache.put(4, 4);
            outputs.push(cache.get(1));
            outputs.push(cache.get(3));
            outputs.push(cache.get(4));
            format_outputs(&outputs)
        },
        "[1,-1,-1,3,4]",
    );

    run_scenario(
        "Edge: capacity one",
        || {
            let mut cache = LruCache::new(1);
            let mut outputs = Vec::new();
            cache.put(5, 5);
            outputs.push(cache.get(5));
            cache.put(6, 6);
            outputs.push(cache.get(5));
            outputs.push(cache.get(6));
            format_outputs(&outputs)
        },
        "[5,-1,6]",
    );

    run_scenario(
        "Long: high churn workload",
        || {
            let mut cache = LruCache::new(3);
            let mut outputs = Vec::new();
            cache.put(1, 100);
            cache.put(2, 200);
            cache.put(3, 300);
            outputs.push(cache.get(1));
            cache.put(4, 400);
            outputs.push(cache.get(2));
            cache.put(5, 500);
            outputs.push(cache.get(3));
            cache.put(1, 150);
            outputs.push(cache.get(1));
            outputs.push(cache.get(4));
            outputs.push(cache.get(5));
            format_outputs(&outputs)
        },
        "[100,-1,-1,150,-1,500]",
    );
}

fn run_scenario<F>(name: &str, action: F, expected: &str)
where
    F: FnOnce() -> String + std::panic::UnwindSafe,
{
    let start = Instant::now();
    let result = catch_unwind(AssertUnwindSafe(action));
    let elapsed_ms = start.elapsed().as_secs_f64() * 1000.0;

    match result {
        Ok(output) => {
            println!("Scenario: {name}");
            println!("  Time: {elapsed_ms:.4} ms");
            println!("  Result: {output}");
            println!("  Expected: {expected}");
        }
        Err(_) => {
            println!("Scenario: {name}");
            println!("  Status: NOT IMPLEMENTED [{elapsed_ms:.4} ms]");
            println!("  Expected: {expected}");
        }
    }
}

fn format_outputs(values: &[i32]) -> String {
    if values.is_empty() {
        "[]".to_string()
    } else {
        format!("[{}]", values.iter().map(|v| v.to_string()).collect::<Vec<_>>().join(","))
    }
}
