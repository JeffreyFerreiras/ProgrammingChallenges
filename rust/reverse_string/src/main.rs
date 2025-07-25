mod solution;
use solution::reverse_char_vec;

fn main() {
    const TARGET: &str = "hello";
    
    println!("Original value: {TARGET}");

    let mut reversed: Vec<char> = TARGET.chars().collect::<Vec<char>>();
    
    reverse_char_vec(&mut reversed);

    println!("reversed: {:?}", reversed);
}
