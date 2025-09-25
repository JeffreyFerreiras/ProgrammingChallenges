mod solution;

use solution::MinStack;
use std::time::Instant;

fn main() {
    println!("Running Min Stack tests...\n");

    // Test case 1: Basic operations
    println!("Test case 1: Basic operations");
    let mut min_stack = MinStack::new();
    min_stack.push(-2);
    min_stack.push(0);
    min_stack.push(-3);
    
    let start = Instant::now();
    let min1 = min_stack.get_min();
    let elapsed1 = start.elapsed();
    println!("  getMin(): {} (expected: -3)", min1);
    println!("  Time: {:.3} ms", elapsed1.as_secs_f64() * 1000.0);
    
    min_stack.pop();
    let top = min_stack.top();
    println!("  top(): {} (expected: 0)", top);
    
    let min2 = min_stack.get_min();
    println!("  getMin(): {} (expected: -2)", min2);
    println!();

    // Test case 2: Edge cases
    println!("Test case 2: Edge cases");
    let mut min_stack2 = MinStack::new();
    min_stack2.push(5);
    min_stack2.push(1);
    min_stack2.push(3);
    min_stack2.push(0);
    
    let start = Instant::now();
    let min = min_stack2.get_min();
    let elapsed = start.elapsed();
    println!("  getMin(): {} (expected: 0)", min);
    println!("  Time: {:.3} ms", elapsed.as_secs_f64() * 1000.0);
    
    min_stack2.pop();
    let min_after_pop = min_stack2.get_min();
    println!("  getMin() after pop: {} (expected: 1)", min_after_pop);
    println!();

    // Test case 3: Large dataset
    println!("Test case 3: Large dataset (1000 elements)");
    let mut min_stack3 = MinStack::new();
    let start = Instant::now();
    
    // Push 1000 elements
    for i in 0..1000 {
        min_stack3.push(i);
    }
    
    let push_time = start.elapsed();
    println!("  Push 1000 elements: {:.3} ms", push_time.as_secs_f64() * 1000.0);
    
    let start = Instant::now();
    let min = min_stack3.get_min();
    let get_min_time = start.elapsed();
    println!("  getMin(): {} (expected: 0)", min);
    println!("  getMin() time: {:.3} ms", get_min_time.as_secs_f64() * 1000.0);
    
    // Pop half the elements
    let start = Instant::now();
    for _ in 0..500 {
        min_stack3.pop();
    }
    let pop_time = start.elapsed();
    println!("  Pop 500 elements: {:.3} ms", pop_time.as_secs_f64() * 1000.0);
    
    let min_after_pops = min_stack3.get_min();
    println!("  getMin() after pops: {} (expected: 0)", min_after_pops);
    println!();

    // Test case 4: Negative numbers
    println!("Test case 4: Negative numbers");
    let mut min_stack4 = MinStack::new();
    min_stack4.push(-10);
    min_stack4.push(-5);
    min_stack4.push(-15);
    min_stack4.push(-1);
    
    let min = min_stack4.get_min();
    println!("  getMin(): {} (expected: -15)", min);
    
    min_stack4.pop();
    let min_after_pop = min_stack4.get_min();
    println!("  getMin() after pop: {} (expected: -15)", min_after_pop);
    println!();

    // Test case 5: Duplicate minimums
    println!("Test case 5: Duplicate minimums");
    let mut min_stack5 = MinStack::new();
    min_stack5.push(3);
    min_stack5.push(1);
    min_stack5.push(1);
    min_stack5.push(2);
    
    let min1 = min_stack5.get_min();
    println!("  getMin(): {} (expected: 1)", min1);
    
    min_stack5.pop();
    let min2 = min_stack5.get_min();
    println!("  getMin() after pop: {} (expected: 1)", min2);
    
    min_stack5.pop();
    let min3 = min_stack5.get_min();
    println!("  getMin() after another pop: {} (expected: 1)", min3);
    println!();

    // Test case 6: Single element
    println!("Test case 6: Single element");
    let mut min_stack6 = MinStack::new();
    min_stack6.push(42);
    
    let min = min_stack6.get_min();
    let top = min_stack6.top();
    println!("  getMin(): {} (expected: 42)", min);
    println!("  top(): {} (expected: 42)", top);
    println!();

    // Test case 7: Stress test - alternating push/pop
    println!("Test case 7: Stress test - alternating operations");
    let mut min_stack7 = MinStack::new();
    let start = Instant::now();
    
    for i in 0..100 {
        min_stack7.push(i);
        if i % 2 == 0 {
            let _ = min_stack7.get_min();
        }
    }
    
    for i in 0..50 {
        min_stack7.pop();
        if i % 3 == 0 {
            let _ = min_stack7.get_min();
        }
    }
    
    let elapsed = start.elapsed();
    println!("  Alternating operations (100 push, 50 pop): {:.3} ms", elapsed.as_secs_f64() * 1000.0);
    let final_min = min_stack7.get_min();
    println!("  Final getMin(): {} (expected: 0)", final_min);
    println!();

    println!("=== Min Stack Tests Complete ===");
}
