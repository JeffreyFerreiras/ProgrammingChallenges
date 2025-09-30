pub struct Solution;

impl Solution {
    pub fn min_eating_speed(piles: Vec<i32>, h: i32) -> i32 {
           let mut left = 1;
           let mut right = *piles.iter().max().unwrap();

           while left < right {
            let speed = left + (right - left) / 2;
            let hours = piles.iter()
             .map(|&pile| pile / speed + if pile % speed > 0 { 1 } else { 0 })
             .sum::<i32>();

            if hours <= h {
                right = speed;
            } else {
                left = speed + 1;
            }
           }
           left
    }
}
