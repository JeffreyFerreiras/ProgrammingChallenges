use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

struct Scenario {
    name: &'static str,
    points: Vec<Vec<i32>>,
    k: i32,
    expected: Vec<Vec<i32>>,
}

fn main() {
    println!("973. K Closest Points to Origin");
    println!("===============================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            points: vec![vec![1, 3], vec![-2, 2]],
            k: 1,
            expected: vec![vec![-2, 2]],
        },
        Scenario {
            name: "Example 2",
            points: vec![vec![3, 3], vec![5, -1], vec![-2, 4]],
            k: 2,
            expected: vec![vec![3, 3], vec![-2, 4]],
        },
        Scenario {
            name: "K Equals Points",
            points: vec![vec![1, 0], vec![2, 0], vec![3, 0]],
            k: 3,
            expected: vec![vec![1, 0], vec![2, 0], vec![3, 0]],
        },
        Scenario {
            name: "Large Cloud",
            points: generate_circular_points(10_000, 100),
            k: 5,
            expected: generate_circular_points(5, 1),
        },
    ];

    for scenario in scenarios {
        run_scenario(&scenario);
    }
}

fn generate_circular_points(count: usize, radius: i32) -> Vec<Vec<i32>> {
    let mut points = Vec::with_capacity(count);
    for i in 0..count {
        let angle = i as f64 * (std::f64::consts::TAU / count.max(1) as f64);
        let x = (radius as f64 * angle.cos()).round() as i32;
        let y = (radius as f64 * angle.sin()).round() as i32;
        points.push(vec![x, y]);
    }
    points
}

fn run_scenario(scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  k: {}", scenario.k);
    println!("  Points Count: {}", scenario.points.len());
    println!("  Expected: {}", format_points(&scenario.expected));

    let start = Instant::now();
    let result = panic::catch_unwind(|| Solution::k_closest(clone_points(&scenario.points), scenario.k));
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(points) => println!("  Result: {}", format_points(&points)),
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

fn clone_points(points: &[Vec<i32>]) -> Vec<Vec<i32>> {
    points.iter().map(|point| point.clone()).collect()
}

fn format_points(points: &[Vec<i32>]) -> String {
    if points.is_empty() {
        return "[]".to_string();
    }

    let formatted = points
        .iter()
        .map(|point| format!("[{},{}]", point[0], point[1]))
        .collect::<Vec<_>>()
        .join(",");
    format!("[{formatted}]")
}
