# Pangram Alphabet Challenge

## Problem Description
A pangram is a sentence that contains every letter of the alphabet at least once. The classic example is "The quick brown fox jumps over the lazy dog."

This program identifies which letters are missing from a given sentence that prevent it from being a pangram. The output should be all lowercase letters in alphabetical order. If the input is already a pangram, the program outputs "NULL".

## Implementation
The program provides two different solutions to solve this challenge:

### 1. Array Counting Approach (`MissingLetters`)
- Uses a simple array of size 26 to count occurrences of each letter
- Iterates through each character in the input string
- For each letter, increments the corresponding counter in the array
- Finally, builds a string of letters whose count is zero
- Time Complexity: O(n), where n is the length of the input string

### 2. LINQ Approach (`FindMissingLetters`)
- Leverages LINQ methods for a concise, readable solution
- Converts input to lowercase
- Uses `Where` to find which alphabet letters are contained in the input
- Uses `Except` to find letters missing from the input
- Time Complexity: O(n²) due to the `Contains` operation inside `Where`

## Examples
```
Input: "The quick brown fox jumps over the lazy dog"
Output: "NULL" (It's already a pangram)

Input: "The quick brown fox jumps over the lzy"
Output: "a" (Missing the letter 'a')
```

## Performance Comparison
The implementation includes performance measurement using `Stopwatch` to compare the efficiency of both approaches:
- The array counting approach (`MissingLetters`) is more efficient, especially for longer inputs
- The LINQ approach (`FindMissingLetters`) is more concise and readable but less efficient due to nested iterations

## Notes
- The solution ignores case sensitivity
- The implementation handles edge cases such as null or empty inputs
- The program includes a sample test harness to demonstrate the functionality