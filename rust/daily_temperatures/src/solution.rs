/// 739. Daily Temperatures
///
/// Given an array of integers temperatures represents the daily temperatures,
/// return an array answer such that answer[i] is the number of days you have
/// to wait after the ith day to get a warmer temperature. If there is no future
/// day for which this is possible, keep answer[i] == 0 instead.
///
/// Constraints:
/// - 1 <= temperatures.length <= 10^5
/// - 30 <= temperatures[i] <= 100
///
/// Time Complexity: O(n) - Each element is pushed and popped from stack at most once
/// Space Complexity: O(n) - Stack can contain at most n elements in worst case
pub fn daily_temperatures(temperatures: Vec<i32>) -> Vec<i32> {
    // result array to store the number of days to wait for a warmer temperature
    let mut result = vec![0; temperatures.len()];
    let mut stack = Vec::new();

    // Iterate through each temperature
    for (i, &temp) in temperatures.iter().enumerate() {
        // While stack is not empty and current temperature is greater than
        // the temperature at the index stored at the top of the stack
        while stack.len() > 0 && temp > temperatures[*stack.last().unwrap()] {
            let idx = stack.pop().unwrap();
            result[idx] = (i - idx) as i32;
        }
        // Push the current index onto the stack
        stack.push(i);
    }

    result
}

pub fn daily_temperatures_fast(temperatures: Vec<i32>) -> Vec<i32> {
        let n = temperatures.len();
        let mut ans = vec![0; n];
        let mut stack = vec![];

        for (index, temp) in temperatures.into_iter().enumerate() {

            while let Some((_, top_temperature)) = stack.last() {
                if *top_temperature >= temp {
                    break;
                }
                let (j, _) = stack.pop().unwrap();
                ans[j] = (index - j) as i32;
            }
            stack.push((index, temp))
        }
        ans
    }

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example_1() {
        let temperatures = vec![73, 74, 75, 71, 69, 72, 76, 73];
        let expected = vec![1, 1, 4, 2, 1, 1, 0, 0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }

    #[test]
    fn test_example_2() {
        let temperatures = vec![30, 40, 50, 60];
        let expected = vec![1, 1, 1, 0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }

    #[test]
    fn test_example_3() {
        let temperatures = vec![30, 60, 90];
        let expected = vec![1, 1, 0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }

    #[test]
    fn test_single_element() {
        let temperatures = vec![30];
        let expected = vec![0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }

    #[test]
    fn test_decreasing_temperatures() {
        let temperatures = vec![90, 80, 70, 60, 50];
        let expected = vec![0, 0, 0, 0, 0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }

    #[test]
    fn test_increasing_temperatures() {
        let temperatures = vec![30, 40, 50, 60, 70];
        let expected = vec![1, 1, 1, 1, 0];
        assert_eq!(daily_temperatures(temperatures), expected);
    }
}
