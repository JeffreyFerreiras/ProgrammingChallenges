mod solution;

fn main() {
    let numbers = vec![3, 2, 1, 5, 6, 4];
    let k = 2;

    match solution::kth_largest(&numbers, k) {
        Some(value) => println!("The {k}th largest element is {value}"),
        None => println!("Could not determine the {k}th largest element"),
    }
}
