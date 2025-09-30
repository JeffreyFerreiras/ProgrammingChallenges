use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    tasks: Vec<char>,
    cooldown: i32,
    expected: i32,
}

fn main() {
    println!("621. Task Scheduler");
    println!("===================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            tasks: vec!['A', 'A', 'A', 'B', 'B', 'B'],
            cooldown: 2,
            expected: 8,
        },
        Scenario {
            name: "Example 2",
            tasks: vec!['A', 'A', 'A', 'B', 'B', 'B'],
            cooldown: 0,
            expected: 6,
        },
        Scenario {
            name: "Mixed Letters",
            tasks: vec!['A', 'A', 'A', 'B', 'C', 'C', 'D', 'D', 'D', 'E'],
            cooldown: 2,
            expected: 10,
        },
        Scenario {
            name: "Large Alphabet",
            tasks: generate_alphabet_workload(5),
            cooldown: 3,
            expected: 130,
        },
        Scenario {
            name: "Single Task",
            tasks: vec!['Z'],
            cooldown: 5,
            expected: 1,
        },
    ];

    for scenario in scenarios {
        run_scenario(&scenario);
    }
}

fn generate_alphabet_workload(repeats: usize) -> Vec<char> {
    let mut tasks = Vec::with_capacity(26 * repeats);
    for _ in 0..repeats {
        for code in b'A'..=b'Z' {
            tasks.push(code as char);
        }
    }
    tasks
}

fn run_scenario(scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Cooldown: {}", scenario.cooldown);
    println!("  Task Count: {}", scenario.tasks.len());
    println!("  Expected: {}", scenario.expected);
    println!("  Tasks Preview: {}", format_tasks(&scenario.tasks));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::least_interval(scenario.tasks.clone(), scenario.cooldown));
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

fn format_tasks(tasks: &[char]) -> String {
    const PREVIEW: usize = 16;
    if tasks.len() <= PREVIEW {
        return format!("[{}]", tasks.iter().map(|c| c.to_string()).collect::<Vec<_>>().join(","));
    }

    let prefix = tasks
        .iter()
        .take(PREVIEW)
        .map(|c| c.to_string())
        .collect::<Vec<_>>()
        .join(",");
    format!("[{prefix}, ... x{} more]", tasks.len() - PREVIEW)
}
