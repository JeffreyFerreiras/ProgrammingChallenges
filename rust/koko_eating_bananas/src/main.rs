use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    piles: Vec<i32>,
    hours: i32,
    expected_speed: i32,
}

fn main() {
    println!("875. Koko Eating Bananas");
    println!("=======================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            piles: vec![3, 6, 7, 11],
            hours: 8,
            expected_speed: 4,
        },
        Scenario {
            name: "Example 2",
            piles: vec![30, 11, 23, 4, 20],
            hours: 5,
            expected_speed: 30,
        },
        Scenario {
            name: "Example 3",
            piles: vec![30, 11, 23, 4, 20],
            hours: 6,
            expected_speed: 23,
        },
        Scenario {
            name: "Single Gigantic Pile",
            piles: vec![1_000_000_000],
            hours: 1,
            expected_speed: 1_000_000_000,
        },
        Scenario {
            name: "Many Small Piles",
            piles: create_repeated_piles(30, 5),
            hours: 60,
            expected_speed: 3,
        },
        Scenario {
            name: "Large Stress Test",
            piles: create_ramp_piles(5_000, 1, 5),
            hours: 5_000,
            expected_speed: 24_996,
        },
    ];

    for scenario in scenarios {
        run_scenario("min_eating_speed", &scenario);
    }
}

fn create_repeated_piles(count: usize, size: i32) -> Vec<i32> {
    vec![size; count]
}

fn create_ramp_piles(count: usize, start: i32, step: i32) -> Vec<i32> {
    let mut piles = Vec::with_capacity(count);
    let mut value = start;
    for _ in 0..count {
        piles.push(value);
        value += step;
    }
    piles
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Method: {}", method_name);
    println!("  Hours: {}", scenario.hours);
    println!("  Expected Speed: {}", scenario.expected_speed);
    println!("  Pile Count: {}", scenario.piles.len());
    println!("  Piles Preview: {}", format_array_preview(&scenario.piles));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::min_eating_speed(scenario.piles.clone(), scenario.hours));
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
