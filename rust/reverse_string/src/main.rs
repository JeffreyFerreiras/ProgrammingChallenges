mod solution;
use solution::reverse_char_vec;

fn main() {
    const TARGET: &str = "hello";
    let mut reversed = TARGET.chars().collect::<Vec<char>>();
    
    reverse_char_vec(&mut reversed);

    println!("{:?}", reversed);
}
