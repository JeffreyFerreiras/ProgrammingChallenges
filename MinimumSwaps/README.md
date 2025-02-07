# Minimum Swaps to Group All 1's Together

## Problem Description
The task is to find the minimum number of swaps required to group all 1's together in a binary array. Given an array consisting of only 0's and 1's, the goal is to rearrange the elements such that all 1's are contiguous, using the least number of swaps.

### Example
For the input array:
```
[0, 1, 0, 1, 0, 1]
```
The output should be `1`, as we can swap the first `0` with the last `1` to group all `1's` together.

## Optimal Solution Overview
The optimal solution involves counting the total number of `1's` in the array and then using a sliding window approach to determine the minimum number of `0's` in any window of size equal to the count of `1's`. The number of swaps required will be equal to the number of `0's` in that window.

### Steps
1. Count the total number of `1's` in the array.
2. Use a sliding window of size equal to the count of `1's` to find the minimum number of `0's` in that window.
3. The result will be the minimum number of `0's` found, which corresponds to the minimum swaps needed.

## Usage Instructions
1. Clone the repository.
2. Navigate to the project directory.
3. Build the project using the command:
   ```
   dotnet build
   ```
4. Run the application using the command:
   ```
   dotnet run
   ```
5. Input the binary array when prompted.

## Example Usage
Input:
```
[0, 1, 0, 1, 0, 1]
```
Output:
```
Minimum swaps required: 1
```

This project provides a clear and efficient solution to the problem of grouping all `1's` together in a binary array with minimal swaps.