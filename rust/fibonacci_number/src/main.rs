use std::io;

fn main() {
    println!("Enter a number to calculate its fibonacci position: ");
    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("Something went wrong reading input");
    
    let num: u64 = input
        .trim()
        .parse()
        .expect("Something went wrong while parsing the number");

    let result = fibonacci(num);

    println!("Your fibonacci number is: {result}");
}

fn fibonacci(num: u64) -> u64 {
    if num <= 0 {
        return 0;
    }
    if num == 1 {
        return 1;
    }

    let mut first = 0u64;
    let mut second = 1u64;

    for _ in 2..=num {
        let sum = first + second;
        first = second;
        second = sum;
    }
    second
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_fibonacci_base_cases() {
        assert_eq!(fibonacci(0), 0);
        assert_eq!(fibonacci(1), 1);
    }

    #[test]
    fn test_fibonacci_small_numbers() {
        assert_eq!(fibonacci(2), 1);
        assert_eq!(fibonacci(3), 2);
        assert_eq!(fibonacci(4), 3);
        assert_eq!(fibonacci(5), 5);
    }

    #[test]
    fn test_fibonacci_larger_numbers() {
        assert_eq!(fibonacci(10), 55);
        assert_eq!(fibonacci(15), 610);
        assert_eq!(fibonacci(20), 6765);
    }

    #[test]
    fn test_fibonacci_sequence() {
        let expected = vec![0, 1, 1, 2, 3, 5, 8, 13, 21, 34];
        for (i, &expected_value) in expected.iter().enumerate() {
            assert_eq!(fibonacci(i as u64), expected_value);
        }
    }
}
