use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    numbers: Vec<i32>,
    target: i32,
    expected: i32,
}

fn main() {
    println!("33. Search in Rotated Sorted Array");
    println!("================================\n");

    let large_rotation = generate_rotated_array(120_000, 75_000);
    let large_target = 12_345;
    let large_expected = find_index(&large_rotation, large_target);

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            numbers: vec![4, 5, 6, 7, 0, 1, 2],
            target: 0,
            expected: 4,
        },
        Scenario {
            name: "Example 2",
            numbers: vec![4, 5, 6, 7, 0, 1, 2],
            target: 3,
            expected: -1,
        },
        Scenario {
            name: "Single Element Present",
            numbers: vec![1],
            target: 1,
            expected: 0,
        },
        Scenario {
            name: "Single Element Missing",
            numbers: vec![1],
            target: 0,
            expected: -1,
        },
        Scenario {
            name: "All Positive Rotation",
            numbers: vec![30, 34, 40, 2, 5, 8, 11],
            target: 5,
            expected: 4,
        },
        Scenario {
            name: "Negative and Positive",
            numbers: vec![9, 12, 17, -4, -1, 0, 3],
            target: -1,
            expected: 4,
        },
        Scenario {
            name: "Large Rotation",
            numbers: large_rotation,
            target: large_target,
            expected: large_expected,
        },
    ];

    for scenario in scenarios {
        run_scenario("search", &scenario);
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

fn find_index(numbers: &[i32], target: i32) -> i32 {
    for (index, value) in numbers.iter().enumerate() {
        if *value == target {
            return index as i32;
        }
    }
    -1
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Method: {}", method_name);
    println!("  Target: {}", scenario.target);
    println!("  Expected: {}", scenario.expected);
    println!("  Array Length: {}", scenario.numbers.len());
    println!("  Array Preview: {}", format_array_preview(&scenario.numbers));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::search(scenario.numbers.clone(), scenario.target));
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
