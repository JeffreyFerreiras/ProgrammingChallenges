use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    first: Vec<i32>,
    second: Vec<i32>,
    expected: f64,
}

fn main() {
    println!("4. Median of Two Sorted Arrays");
    println!("================================\n");

    let large_a = generate_range(0, 100_000);
    let large_b = generate_range(100_000, 100_000);

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            first: vec![1, 3],
            second: vec![2],
            expected: 2.0,
        },
        Scenario {
            name: "Example 2",
            first: vec![1, 2],
            second: vec![3, 4],
            expected: 2.5,
        },
        Scenario {
            name: "Zero Arrays",
            first: vec![0, 0],
            second: vec![0, 0],
            expected: 0.0,
        },
        Scenario {
            name: "Single Non-Empty",
            first: Vec::new(),
            second: vec![2],
            expected: 2.0,
        },
        Scenario {
            name: "Different Lengths",
            first: vec![1, 3, 8, 9, 15],
            second: vec![7, 11, 18, 19, 21, 25],
            expected: 11.0,
        },
        Scenario {
            name: "Large Balanced Arrays",
            first: large_a,
            second: large_b,
            expected: 99_999.5,
        },
    ];

    for scenario in scenarios {
        run_scenario("find_median_sorted_arrays", &scenario);
    }
}

fn generate_range(start: i32, count: usize) -> Vec<i32> {
    let mut result = Vec::with_capacity(count);
    let mut value = start;
    for _ in 0..count {
        result.push(value);
        value += 1;
    }
    result
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Method: {}", method_name);
    println!("  Expected: {:.4}", scenario.expected);
    println!("  First Length: {}", scenario.first.len());
    println!("  Second Length: {}", scenario.second.len());
    println!("  First Preview: {}", format_array_preview(&scenario.first));
    println!("  Second Preview: {}", format_array_preview(&scenario.second));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::find_median_sorted_arrays(scenario.first.clone(), scenario.second.clone()));
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(value) => println!("  Result: {:.4}", value),
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

fn format_array_preview(numbers: &[i32]) -> String {
    const PREVIEW: usize = 8;
    if numbers.is_empty() {
        return "[]".to_string();
    }

    if numbers.len() <= PREVIEW {
        return format!("[{}]", numbers.iter().map(|n| n.to_string()).collect::<Vec<_>>().join(","));
    }

    let mut parts = Vec::with_capacity(PREVIEW + 1);
    for value in &numbers[..PREVIEW] {
        parts.push(value.to_string());
    }
    parts.push(format!("..., {}", numbers[numbers.len() - 1]));
    format!("[{}]", parts.join(","))
}
