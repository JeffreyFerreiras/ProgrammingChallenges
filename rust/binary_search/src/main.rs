mod solution;

use solution::Solution;

fn main() {
    let nums = vec![-1,0,3,5,9,12];
    
    let ans = Solution::search(nums.clone(), 9);

    println!("The numbers are: {:?}", nums);
    println!("Target is {}", 9);
    println!("Expected output is 4");
    println!("The index of 9 is: {}", ans);
}
