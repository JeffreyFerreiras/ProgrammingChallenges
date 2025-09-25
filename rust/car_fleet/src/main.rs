use std::time::Instant;

mod solution;
use solution::Solution;

fn main() {
    // Test Case 1: Example 1 from LeetCode
    println!("=== Car Fleet Challenge Test Cases ===\n");
    
    // Test Case 1
    let target1 = 12;
    let position1 = vec![10, 8, 0, 5, 3];
    let speed1 = vec![2, 4, 1, 1, 3];
    let expected1 = 3;
    
    let start = Instant::now();
    let result1 = Solution::car_fleet(target1, position1.clone(), speed1.clone());
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
    let result2 = Solution::car_fleet(target2, position2.clone(), speed2.clone());
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
    let result3 = Solution::car_fleet(target3, position3.clone(), speed3.clone());
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
    let result4 = Solution::car_fleet(target4, position4.clone(), speed4.clone());
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
    let result5 = Solution::car_fleet(target5, position5.clone(), speed5.clone());
    let duration5 = start.elapsed();
    
    println!("Test Case 5 (All Cars at Same Position):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target5, position5, speed5);
    println!("  Result: {}", result5);
    println!("  Expected: {}", expected5);
    println!("  Time: {:.4} ms", duration5.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result5 == expected5 { "PASS" } else { "FAIL" });
    
    // Test Case 6: Larger sample with 10 cars
    let target6 = 50;
    let position6 = vec![5, 10, 15, 20, 25, 30, 35, 40, 45, 48];
    let speed6 = vec![1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    let expected6 = 6;
    
    let start = Instant::now();
    let result6 = Solution::car_fleet(target6, position6.clone(), speed6.clone());
    let duration6 = start.elapsed();
    
    println!("Test Case 6 (10 Cars - Various Speeds):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target6, position6, speed6);
    println!("  Result: {}", result6);
    println!("  Expected: {}", expected6);
    println!("  Time: {:.4} ms", duration6.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result6 == expected6 { "PASS" } else { "FAIL" });
    
    // Test Case 7: Mixed order positions with 12 cars
    let target7 = 80;
    let position7 = vec![70, 60, 50, 40, 30, 20, 10, 0, 75, 65, 55, 35];
    let speed7 = vec![1, 2, 3, 4, 5, 6, 7, 8, 2, 3, 4, 5];
    let expected7 = 8;
    
    let start = Instant::now();
    let result7 = Solution::car_fleet(target7, position7.clone(), speed7.clone());
    let duration7 = start.elapsed();
    
    println!("Test Case 7 (12 Cars - Mixed Order):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target7, position7, speed7);
    println!("  Result: {}", result7);
    println!("  Expected: {}", expected7);
    println!("  Time: {:.4} ms", duration7.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result7 == expected7 { "PASS" } else { "FAIL" });
    
    // Test Case 8: Large sample with 15 cars
    let target8 = 200;
    let position8 = vec![10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 25, 45, 65, 85, 105];
    let speed8 = vec![5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 8, 12, 18, 22, 28];
    let expected8 = 11;
    
    let start = Instant::now();
    let result8 = Solution::car_fleet(target8, position8.clone(), speed8.clone());
    let duration8 = start.elapsed();
    
    println!("Test Case 8 (15 Cars - Large Scale):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target8, position8, speed8);
    println!("  Result: {}", result8);
    println!("  Expected: {}", expected8);
    println!("  Time: {:.4} ms", duration8.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result8 == expected8 { "PASS" } else { "FAIL" });
    
    // Test Case 9: High-speed scenario with 8 cars
    let target9 = 1000;
    let position9 = vec![100, 200, 300, 400, 500, 600, 700, 800];
    let speed9 = vec![90, 80, 70, 60, 50, 40, 30, 20];
    let expected9 = 8;
    
    let start = Instant::now();
    let result9 = Solution::car_fleet(target9, position9.clone(), speed9.clone());
    let duration9 = start.elapsed();
    
    println!("Test Case 9 (8 Cars - High Speed):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target9, position9, speed9);
    println!("  Result: {}", result9);
    println!("  Expected: {}", expected9);
    println!("  Time: {:.4} ms", duration9.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result9 == expected9 { "PASS" } else { "FAIL" });
    
    // Test Case 10: Complex fleet formation with 20 cars
    let target10 = 500;
    let position10 = vec![10, 20, 30, 40, 50, 100, 110, 120, 130, 140, 200, 210, 220, 230, 240, 300, 310, 320, 330, 340];
    let speed10 = vec![50, 40, 30, 20, 10, 45, 35, 25, 15, 5, 40, 30, 20, 10, 50, 35, 25, 15, 5, 45];
    let expected10 = 6;
    
    let start = Instant::now();
    let result10 = Solution::car_fleet(target10, position10.clone(), speed10.clone());
    let duration10 = start.elapsed();
    
    println!("Test Case 10 (20 Cars - Complex Fleet Formation):");
    println!("  Method: car_fleet");
    println!("  Input: target={}, position={:?}, speed={:?}", target10, position10, speed10);
    println!("  Result: {}", result10);
    println!("  Expected: {}", expected10);
    println!("  Time: {:.4} ms", duration10.as_secs_f64() * 1000.0);
    println!("  Status: {}\n", if result10 == expected10 { "PASS" } else { "FAIL" });
    
    println!("=== All Test Cases Completed ===");
}