use std::time::Instant;

mod solution;
use solution::Solution;

fn main() {
    let solution = Solution;
    
    // Test Case 1: Example 1 from LeetCode
    println!("=== Car Fleet Challenge Test Cases ===\n");
    
    // Test Case 1
    let target1 = 12;
    let position1 = vec![10, 8, 0, 5, 3];
    let speed1 = vec![2, 4, 1, 1, 3];
    let expected1 = 3;
    
    let start = Instant::now();
    let result1 = solution.car_fleet(target1, position1.clone(), speed1.clone());
    let duration1 = start.elapsed();
    
    println!("Test Case 1:");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target1, position1, speed1);
    println!("  Result: {}", result1);
    println!("  Expected: {}", expected1);
    println!("  Time: {:.4} ms", duration1.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result1 == expected1 { "PASS" } else { "FAIL" });
    
    // Test Case 2: Example 2 from LeetCode
    let target2 = 10;
    let position2 = vec![3];
    let speed2 = vec![3];
    let expected2 = 1;
    
    let start = Instant::now();
    let result2 = solution.car_fleet(target2, position2.clone(), speed2.clone());
    let duration2 = start.elapsed();
    
    println!("Test Case 2:");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target2, position2, speed2);
    println!("  Result: {}", result2);
    println!("  Expected: {}", expected2);
    println!("  Time: {:.4} ms", duration2.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result2 == expected2 { "PASS" } else { "FAIL" });
    
    // Test Case 3: Example 3 from LeetCode
    let target3 = 100;
    let position3 = vec![0, 2, 4];
    let speed3 = vec![4, 2, 1];
    let expected3 = 1;
    
    let start = Instant::now();
    let result3 = solution.car_fleet(target3, position3.clone(), speed3.clone());
    let duration3 = start.elapsed();
    
    println!("Test Case 3:");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target3, position3, speed3);
    println!("  Result: {}", result3);
    println!("  Expected: {}", expected3);
    println!("  Time: {:.4} ms", duration3.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result3 == expected3 { "PASS" } else { "FAIL" });
    
    // Test Case 4: Edge case - single car
    let target4 = 1;
    let position4 = vec![0];
    let speed4 = vec![1];
    let expected4 = 1;
    
    let start = Instant::now();
    let result4 = solution.car_fleet(target4, position4.clone(), speed4.clone());
    let duration4 = start.elapsed();
    
    println!("Test Case 4 (Edge Case - Single Car):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target4, position4, speed4);
    println!("  Result: {}", result4);
    println!("  Expected: {}", expected4);
    println!("  Time: {:.4} ms", duration4.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result4 == expected4 { "PASS" } else { "FAIL" });
    
    // Test Case 5: All cars at same position
    let target5 = 10;
    let position5 = vec![5, 5, 5];
    let speed5 = vec![1, 2, 3];
    let expected5 = 1;
    
    let start = Instant::now();
    let result5 = solution.car_fleet(target5, position5.clone(), speed5.clone());
    let duration5 = start.elapsed();
    
    println!("Test Case 5 (All Cars at Same Position):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target5, position5, speed5);
    println!("  Result: {}", result5);
    println!("  Expected: {}", expected5);
    println!("  Time: {:.4} ms", duration5.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result5 == expected5 { "PASS" } else { "FAIL" });
    
    println!("=== All Test Cases Completed ===");
}