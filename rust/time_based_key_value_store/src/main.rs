use std::panic;
use std::time::Instant;

mod solution;
use solution::Solution;

#[derive(Clone, Copy)]
enum OperationKind {
    Set,
    Get,
}

struct Operation {
    kind: OperationKind,
    key: String,
    value: Option<String>,
    timestamp: i32,
}

struct Scenario {
    name: &'static str,
    operations: Vec<Operation>,
    expected: Vec<String>,
}

fn main() {
    println!("981. Time Based Key-Value Store");
    println!("================================\n");

    let scenarios = vec![
        Scenario {
            name: "Example 1",
            operations: vec![
                set_op("foo", "bar", 1),
                get_op("foo", 1),
                get_op("foo", 3),
                set_op("foo", "bar2", 4),
                get_op("foo", 4),
                get_op("foo", 5),
            ],
            expected: vec!["bar".to_string(), "bar".to_string(), "bar2".to_string(), "bar2".to_string()],
        },
        Scenario {
            name: "Key Missing",
            operations: vec![
                set_op("foo", "bar", 1),
                get_op("foo", 0),
                get_op("foo", 1),
                get_op("unknown", 5),
            ],
            expected: vec!["".to_string(), "bar".to_string(), "".to_string()],
        },
        Scenario {
            name: "Multiple Keys",
            operations: vec![
                set_op("love", "high", 10),
                set_op("love", "low", 20),
                set_op("hate", "mild", 30),
                get_op("love", 5),
                get_op("love", 10),
                get_op("love", 15),
                get_op("love", 25),
                get_op("hate", 35),
            ],
            expected: vec!["".to_string(), "high".to_string(), "high".to_string(), "low".to_string(), "mild".to_string()],
        },
        Scenario {
            name: "Dense Timeline",
            operations: build_dense_operations(),
            expected: build_dense_expected(),
        },
    ];

    for scenario in scenarios {
        run_scenario("create_time_map", &scenario);
    }
}

fn set_op(key: &str, value: &str, timestamp: i32) -> Operation {
    Operation {
        kind: OperationKind::Set,
        key: key.to_string(),
        value: Some(value.to_string()),
        timestamp,
    }
}

fn get_op(key: &str, timestamp: i32) -> Operation {
    Operation {
        kind: OperationKind::Get,
        key: key.to_string(),
        value: None,
        timestamp,
    }
}

fn build_dense_operations() -> Vec<Operation> {
    let mut operations = Vec::with_capacity(60);
    for t in 1..=20 {
        operations.push(set_op("key", &format!("v{t}"), t));
        operations.push(get_op("key", t));
        operations.push(get_op("key", t + 1));
    }
    operations
}

fn build_dense_expected() -> Vec<String> {
    let mut expected = Vec::with_capacity(40);
    for t in 1..=20 {
        expected.push(format!("v{t}"));
        expected.push(format!("v{t}"));
    }
    expected
}

fn run_scenario(method_name: &str, scenario: &Scenario) {
    println!("Scenario: {}", scenario.name);
    println!("  Method: {}", method_name);
    println!("  Operations: {}", scenario.operations.len());
    println!("  Expected: {}", format_outputs(&scenario.expected));

    let start = Instant::now();
    let result = panic::catch_unwind(|| execute_operations(&scenario.operations));
    let elapsed = start.elapsed();

    println!("  Elapsed: {:.4} ms", elapsed.as_secs_f64() * 1000.0);

    match result {
        Ok(outputs) => println!("  Result: {}", format_outputs(&outputs)),
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

fn execute_operations(operations: &[Operation]) -> Vec<String> {
    let mut time_map = Solution::create_time_map();
    let mut outputs = Vec::new();

    for operation in operations {
        match operation.kind {
            OperationKind::Set => {
                let value = operation.value.as_ref().expect("set requires a value");
                time_map.set(&operation.key, value, operation.timestamp);
            }
            OperationKind::Get => {
                let value = time_map.get(&operation.key, operation.timestamp);
                outputs.push(value);
            }
        }
    }

    outputs
}

fn format_outputs<T: AsRef<str>>(values: &[T]) -> String {
    if values.is_empty() {
        return "[]".to_string();
    }

    let parts: Vec<String> = values.iter().map(|value| format!("\"{}\"", value.as_ref())).collect();
    format!("[{}]", parts.join(","))
}
