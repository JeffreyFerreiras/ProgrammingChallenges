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
    println!("704. Binary Search");
    println!("===================\n");

    let large_array = generate_sequential_array(200_001, -100_000);

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            numbers: vec![-1, 0, 3, 5, 9, 12],
            target: 9,
            expected: 4,
        },
        Scenario {
            name: "Target Missing",
            numbers: vec![-1, 0, 3, 5, 9, 12],
            target: 2,
            expected: -1,
        },
        Scenario {
            name: "Single Element Hit",
            numbers: vec![5],
            target: 5,
            expected: 0,
        },
        Scenario {
            name: "Single Element Miss",
            numbers: vec![5],
            target: -5,
            expected: -1,
        },
        Scenario {
            name: "Negative Numbers",
            numbers: vec![-15, -9, -4, 0, 12, 18, 27],
            target: -4,
            expected: 2,
        },
        Scenario {
            name: "Large Ascending Array",
            numbers: large_array,
            target: 54_321,
            expected: 154_321,
        },
    ];

    for scenario in scenarios {
        run_scenario("search", &scenario);
    }
}

fn generate_sequential_array(length: usize, start: i32) -> Vec<i32> {
    let mut result = Vec::with_capacity(length);
    let mut value = start;
    for _ in 0..length {
        result.push(value);
        value += 1;
    }
    result
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
    const PREVIEW: usize = 10;
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
