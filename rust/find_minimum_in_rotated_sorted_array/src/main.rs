use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    numbers: Vec<i32>,
    expected: i32,
}

fn main() {
    println!("153. Find Minimum in Rotated Sorted Array");
    println!("========================================\n");

    let large_rotation = generate_rotated_array(100_000, 42_500);

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            numbers: vec![3, 4, 5, 1, 2],
            expected: 1,
        },
        Scenario {
            name: "Example 2",
            numbers: vec![4, 5, 6, 7, 0, 1, 2],
            expected: 0,
        },
        Scenario {
            name: "Example 3",
            numbers: vec![11, 13, 15, 17],
            expected: 11,
        },
        Scenario {
            name: "Single Element",
            numbers: vec![1],
            expected: 1,
        },
        Scenario {
            name: "Two Elements Rotated",
            numbers: vec![2, 1],
            expected: 1,
        },
        Scenario {
            name: "Already Sorted",
            numbers: vec![-9, -3, 0, 4, 7, 12],
            expected: -9,
        },
        Scenario {
            name: "Large Rotation",
            numbers: large_rotation,
            expected: -50_000,
        },
    ];

    for scenario in scenarios {
        run_scenario("find_min", &scenario);
    }
}

fn generate_rotated_array(length: usize, pivot: usize) -> Vec<i32> {
    let mut numbers = Vec::with_capacity(length);
    for i in 0..length {
        numbers.push(i as i32 - (length as i32 / 2));
    }

    let pivot = pivot % length;
    let mut rotated = Vec::with_capacity(length);
    rotated.extend_from_slice(&numbers[pivot..]);
    rotated.extend_from_slice(&numbers[..pivot]);
    rotated
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Method: {}", method_name);
    println!("  Expected: {}", scenario.expected);
    println!("  Array Length: {}", scenario.numbers.len());
    println!("  Array Preview: {}", format_array_preview(&scenario.numbers));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::find_min(scenario.numbers.clone()));
    let elapsed = start.elapsed();

    let elapsed_ms = elapsed.as_secs_f64() * 1000.0;
    println!("  Elapsed: {:.4} ms", elapsed_ms);

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

fn format_array_preview(numbers: &[i32]) -> String {
    const PREVIEW: usize = 12;
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
