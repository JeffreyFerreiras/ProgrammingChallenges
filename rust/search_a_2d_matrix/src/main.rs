use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    matrix: Vec<Vec<i32>>,
    target: i32,
    expected: bool,
}

fn main() {
    println!("74. Search a 2D Matrix");
    println!("======================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            matrix: vec![
                vec![1, 3, 5, 7],
                vec![10, 11, 16, 20],
                vec![23, 30, 34, 60],
            ],
            target: 3,
            expected: true,
        },
        Scenario {
            name: "Example 2",
            matrix: vec![
                vec![1, 3, 5, 7],
                vec![10, 11, 16, 20],
                vec![23, 30, 34, 60],
            ],
            target: 13,
            expected: false,
        },
        Scenario {
            name: "Single Element Present",
            matrix: vec![vec![5]],
            target: 5,
            expected: true,
        },
        Scenario {
            name: "Single Element Missing",
            matrix: vec![vec![5]],
            target: 1,
            expected: false,
        },
        Scenario {
            name: "Empty Row",
            matrix: vec![Vec::new()],
            target: 1,
            expected: false,
        },
        Scenario {
            name: "Tall Matrix",
            matrix: vec![
                vec![1, 4, 7],
                vec![10, 13, 16],
                vec![19, 22, 25],
                vec![28, 31, 34],
                vec![37, 40, 43],
                vec![46, 49, 52],
                vec![55, 58, 61],
            ],
            target: 40,
            expected: true,
        },
        Scenario {
            name: "Wide Matrix",
            matrix: vec![vec![1, 2, 3, 4, 5, 6, 7, 8, 9, 10]],
            target: 11,
            expected: false,
        },
        Scenario {
            name: "Large Example",
            matrix: generate_large_matrix(50, 50, 2),
            target: 4897,
            expected: true,
        },
        Scenario {
            name: "Large Example Not Found",
            matrix: generate_large_matrix(50, 50, 2),
            target: 50001,
            expected: false,
        },
    ];

    for scenario in scenarios {
        run_scenario("search_matrix", &scenario);
    }
}

fn generate_large_matrix(rows: usize, columns: usize, step: i32) -> Vec<Vec<i32>> {
    let mut value = 1;
    let mut matrix = Vec::with_capacity(rows);
    for _ in 0..rows {
        let mut row = Vec::with_capacity(columns);
        for _ in 0..columns {
            row.push(value);
            value += step;
        }
        matrix.push(row);
    }
    matrix
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Target: {}", scenario.target);
    println!("  Expected: {}", scenario.expected);

    let matrix_preview = scenario
        .matrix
        .iter()
        .map(|row| {
            let values = row.iter().map(|value| value.to_string()).collect::<Vec<_>>();
            format!("[{}]", values.join(","))
        })
        .collect::<Vec<_>>()
        .join(", ");
    println!("  Matrix: {}", matrix_preview);

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::search_matrix(&scenario.matrix, scenario.target));
    let elapsed = start.elapsed();

    println!("  Method: {}", method_name);
    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(value) => {
            println!("  Result: {}", value);
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
        }
    }

    println!();
}
