# Marble Probability Test

## Problem Description
Implement a marble probability simulator that generates random marbles based on specified probability ratios.

## Implementation Details
This project implements a program that:
1. Asks the user for ratio inputs for different colored marbles (red, green, blue, and orange)
2. Generates a random distribution of marbles based on the specified ratios
3. Displays statistics about the resulting distribution

## Features
- **Probability Table Generation**: Converts user-provided ratios into a probability distribution
- **Random Marble Generation**: Creates a lookup table for efficiently generating marbles with the correct distribution
- **Distribution Verification**: Displays statistics to verify the generated distribution matches the expected ratios
- **Thread-Safe Random**: Uses a synchronized random number generator for thread safety

## Solution Approach
The solution uses these key techniques:
- Probability calculation based on user-specified ratios
- A lookup table of size 100 for maintaining precise marble distribution
- Efficient random marble generation using the lookup table
- Time Complexity: O(n) where n is the number of marbles to generate
- Space Complexity: O(1) as the lookup table is a fixed size