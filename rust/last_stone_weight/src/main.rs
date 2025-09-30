use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    stones: Vec<i32>,
    expected: i32,
}

fn main() {
    println!("1046. Last Stone Weight");
    println!("=======================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            stones: vec![2, 7, 4, 1, 8, 1],
            expected: 1,
        },
        Scenario {
            name: "Single Stone",
            stones: vec![1],
            expected: 1,
        },
        Scenario {
            name: "Even Smash",
            stones: vec![9, 3, 2, 10],
            expected: 0,
        },
        Scenario {
            name: "All Equal",
            stones: vec![5; 6],
            expected: 0,
        },
        Scenario {
            name: "Large Input",
            stones: generate_descending(100_000),
            expected: 1,
        },
    ];

    for scenario in scenarios {
        run_scenario(&scenario);
    }
}

fn generate_descending(length: usize) -> Vec<i32> {
    (0..length).map(|i| (length - i) as i32).collect()
}

fn run_scenario(scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Stones: {}", format_preview(&scenario.stones));
    println!("  Expected: {}", scenario.expected);

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::last_stone_weight(scenario.stones.clone()));
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

fn format_preview(numbers: &[i32]) -> String {
    const PREVIEW: usize = 12;
    if numbers.is_empty() {
        return "[]".to_string();
    }

    if numbers.len() <= PREVIEW {
        return format!(
            "[{}]",
            numbers
                .iter()
                .map(|n| n.to_string())
                .collect::<Vec<_>>()
                .join(",")
        );
    }

    let mut parts = Vec::with_capacity(PREVIEW + 1);
    for value in &numbers[..PREVIEW] {
        parts.push(value.to_string());
    }
    parts.push(format!("..., {}", numbers[numbers.len() - 1]));
    format!("[{}]", parts.join(","))
}
