# Grading Students

## Problem Description
HackerLand University has the following grading policy:

- Every student receives a grade in the inclusive range from 0 to 100.
- Any grade less than 40 is a failing grade.
- If the difference between the grade and the next multiple of 5 is less than 3, round up to the next multiple of 5.
- If the value of the grade is less than 38, no rounding occurs as the result will still be a failing grade.

For example:
- 84 rounds to 85 (85 - 84 is less than 3)
- 29 does not round (result is still less than 40)
- 57 does not round (60 - 57 is 3 or higher)

Given the initial value of grades for each student, write a function to automate the rounding process.

## Examples:
```
Input: [73, 67, 38, 33]
Output: [75, 67, 40, 33]

Explanation:
- 73 rounds to 75 (75 - 73 is less than 3)
- 67 does not round (70 - 67 is 3 or higher)
- 38 rounds to 40 (40 - 38 is less than 3)
- 33 does not round (result is less than 38)
```

## Constraints:
- 1 ≤ n ≤ 60 (where n is the number of students)
- 0 ≤ grades[i] ≤ 100

## Solution Approach
The solution uses a straightforward approach to implement the grading policy:

1. Iterate through each grade in the array
2. For each grade:
   - Check if the grade is less than 38 (failing grade threshold)
   - Calculate the remainder when divided by 5
   - If the remainder is 3 or more (i.e., the grade needs to be rounded up), round to the next multiple of 5
   - Otherwise, keep the grade as is
3. Return the modified grades array

This approach has:
- Time Complexity: O(n) where n is the number of grades
- Space Complexity: O(1) as we modify the input array in-place (excluding the input and output space)