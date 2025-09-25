pub struct Solution;

impl Solution {
    /// 853. Car Fleet
    /// 
    /// There are n cars going to the same destination along a one-lane road. 
    /// The destination is target miles away.
    /// 
    /// You are given two integer arrays position and speed, both of length n, 
    /// where position[i] is the position of the ith car and speed[i] is the 
    /// speed of the ith car (in miles per hour).
    /// 
    /// A car can never pass another car ahead of it, but it can catch up to it 
    /// and drive bumper to bumper at the same speed. The faster car will slow 
    /// down to match the slower car's speed. The distance between these two 
    /// cars is ignored (i.e., they are assumed to have the same position).
    /// 
    /// A car fleet is some non-empty set of cars driving at the same position 
    /// and same speed. Note that a single car is also a car fleet.
    /// 
    /// If a car catches up to a car fleet right at the destination point, 
    /// it will still be considered as one car fleet.
    /// 
    /// Return the number of car fleets that will arrive at the destination.
    pub fn car_fleet(target: i32, position: Vec<i32>, speed: Vec<i32>) -> i32 {
        let len = position.len();
        let mut cars: Vec<(i32, i32)> = Vec::new();
        
        // Create (position, time_to_reach_target) pairs
        for i in 0..len {
            let time = (target - position[i]) / speed[i];
            cars.push((position[i], time));
        }
        
        // Sort by position in descending order (closest to target first)
        cars.sort_by(|a, b| b.0.cmp(&a.0));
        
        let mut fleets = 0;
        let mut slowest_time = 0;
        
        for (_, time) in cars {
            if time > slowest_time {
                fleets += 1;
                slowest_time = time;
            }
        }
        
        fleets
    }

    
}
