mod solution;

use std::time::Instant;

fn format_ns(ns: u128) -> String {
    if ns >= 1_000_000 {
        format!("{:.3} ms", ns as f64 / 1_000_000.0)
    } else if ns >= 1_000 {
        format!("{:.3} µs", ns as f64 / 1_000.0)
    } else {
        format!("{} ns", ns)
    }
}

fn main() {
    // small sanity scenarios followed by larger inputs to show performance differences
    let mut scenarios: Vec<(&str, Vec<i32>, usize)> = vec![
        ("finds_kth_largest_in_unsorted_array", vec![3, 2, 1, 5, 6, 4], 2),
        ("handles_k_equal_to_one", vec![3, 2, 1], 1),
        ("returns_none_when_k_is_zero", vec![3, 1, 2], 0),
        ("returns_none_when_k_exceeds_length", vec![2, 4, 6], 4),
    ];

    // helper deterministic pseudo-random generator (LCG) producing values in 0..1000
    let make_random = |n: usize, seed: u64| {
        let mut state = seed;
        (0..n)
            .map(|_| {
                // LCG parameters (glibc-like): state = state * a + c
                state = state.wrapping_mul(6364136223846793005).wrapping_add(1);
                // map to 0..999
                (state % 1000) as i32
            })
            .collect::<Vec<i32>>()
    };

    // larger randomized scenarios (values in 0..1000 to make heap vs sort fair)
    scenarios.push(("large_rand_10k_seed1", make_random(10_000, 1), 100));
    scenarios.push(("large_rand_10k_seed2", make_random(10_000, 42), 100));
    scenarios.push(("large_rand_20k_seed3", make_random(20_000, 1337), 250));

    for (name, nums, k) in scenarios {
        // compute expected using the sort variant (definitive answer)
        let expected = solution::kth_largest_sort(&nums, k);
        // single-run timing for heap implementation
        let start_heap = Instant::now();
        let result_heap = solution::kth_largest(&nums, k);
        let elapsed_heap_ns = start_heap.elapsed().as_nanos();

        // single-run timing for sort implementation
        let start_sort = Instant::now();
        let result_sort = solution::kth_largest_sort(&nums, k);
        let elapsed_sort_ns = start_sort.elapsed().as_nanos();

    // single-run timing for stable sort implementation
    let start_sort_stable = Instant::now();
    let result_sort_stable = solution::kth_largest_sort_stable(&nums, k);
    let elapsed_sort_stable_ns = start_sort_stable.elapsed().as_nanos();

        // choose fewer iterations for large inputs to keep total run time reasonable
        let iterations = if nums.len() > 2_000 { 200usize } else { 10_000usize };

        // repeated runs for average timing
        let start_many_heap = Instant::now();
        for _ in 0..iterations {
            let _ = solution::kth_largest(&nums, k);
        }
        let avg_heap_ns = start_many_heap.elapsed().as_nanos() / iterations as u128;

        let start_many_sort = Instant::now();
        for _ in 0..iterations {
            let _ = solution::kth_largest_sort(&nums, k);
        }
        let avg_sort_ns = start_many_sort.elapsed().as_nanos() / iterations as u128;

        let start_many_sort_stable = Instant::now();
        for _ in 0..iterations {
            let _ = solution::kth_largest_sort_stable(&nums, k);
        }
        let avg_sort_stable_ns = start_many_sort_stable.elapsed().as_nanos() / iterations as u128;

        let pass_heap = result_heap == expected;
        let pass_sort = result_sort == expected;
    let pass_sort_stable = result_sort_stable == expected;
        let mark_heap = if pass_heap { "✓" } else { "✗" };
        let mark_sort = if pass_sort { "✓" } else { "✗" };
    let mark_sort_stable = if pass_sort_stable { "✓" } else { "✗" };

        println!(
            "[heap {}] {}: expected = {:?}, got = {:?}",
            mark_heap, name, expected, result_heap
        );
        println!(
            "    heap: single = {}, avg ({} runs) = {}",
            format_ns(elapsed_heap_ns),
            iterations,
            format_ns(avg_heap_ns),
        );

        println!(
            "[sort {}] {}: expected = {:?}, got = {:?}",
            mark_sort, name, expected, result_sort
        );
        println!(
            "    sort: single = {}, avg ({} runs) = {}",
            format_ns(elapsed_sort_ns),
            iterations,
            format_ns(avg_sort_ns),
        );

        println!(
            "[sort-stable {}] {}: expected = {:?}, got = {:?}",
            mark_sort_stable, name, expected, result_sort_stable
        );
        println!(
            "    sort-stable: single = {}, avg ({} runs) = {}",
            format_ns(elapsed_sort_stable_ns),
            iterations,
            format_ns(avg_sort_stable_ns),
        );
    }
}
