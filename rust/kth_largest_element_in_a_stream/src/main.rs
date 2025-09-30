use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Operation {
    value: i32,
    expected: i32,
}

struct Scenario {
    name: &'static str,
    k: i32,
    initial: Vec<i32>,
    operations: Vec<Operation>,
}

fn main() {
    println!("703. Kth Largest Element in a Stream");
    println!("====================================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            k: 3,
            initial: vec![4, 5, 8, 2],
            operations: vec![
                Operation { value: 3, expected: 4 },
                Operation { value: 5, expected: 5 },
                Operation { value: 10, expected: 5 },
                Operation { value: 9, expected: 8 },
                Operation { value: 4, expected: 8 },
            ],
        },
        Scenario {
            name: "Single Element Stream",
            k: 1,
            initial: vec![5],
            operations: vec![
                Operation { value: 2, expected: 5 },
                Operation { value: 6, expected: 6 },
                Operation { value: 4, expected: 6 },
            ],
        },
        Scenario {
            name: "Growing Stream",
            k: 2,
            initial: vec![7],
            operations: vec![
                Operation { value: 0, expected: 7 },
                Operation { value: 3, expected: 7 },
                Operation { value: 4, expected: 7 },
                Operation { value: 10, expected: 7 },
                Operation { value: 12, expected: 10 },
            ],
        },
        Scenario {
            name: "Large Input",
            k: 3,
            initial: generate_descending(50_000),
            operations: vec![
                Operation { value: 1_000_000, expected: 999_998 },
                Operation { value: 1_000_001, expected: 1_000_000 },
            ],
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
    println!("  k: {}", scenario.k);
    println!("  Initial Length: {}", scenario.initial.len());
    println!("  Initial Preview: {}", format_preview(&scenario.initial));
    println!(
        "  Operations: {}",
        format!(
            "[{}]",
            scenario
                .operations
                .iter()
                .map(|op| format!("({}->{})", op.value, op.expected))
                .collect::<Vec<_>>()
                .join(",")
        )
    );

    let start = Instant::now();
    let result = panic::catch_unwind(|| {
        let mut tracker = Solution::create_kth_largest(scenario.k, scenario.initial.clone());
        scenario
            .operations
            .iter()
            .map(|op| tracker.add(op.value))
            .collect::<Vec<_>>()
    });
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(values) => {
            let result_display = format!(
                "[{}]",
                values
                    .iter()
                    .map(|value| value.to_string())
                    .collect::<Vec<_>>()
                    .join(",")
            );
            let expected_display = format!(
                "[{}]",
                scenario
                    .operations
                    .iter()
                    .map(|op| op.expected.to_string())
                    .collect::<Vec<_>>()
                    .join(",")
            );
            println!("  Result: {}", result_display);
            println!("  Expected: {}", expected_display);
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
            println!("  Expected: [not available]");
        }
    }

    println!();
}

fn format_preview(numbers: &[i32]) -> String {
    const PREVIEW: usize = 10;
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
