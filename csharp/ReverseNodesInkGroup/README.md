# README.md

# Reverse Nodes in k-Group

## Problem Overview
The "Reverse Nodes in k-Group" problem is a classic algorithmic challenge that involves reversing nodes in a linked list in groups of size k. Given a linked list, you need to reverse the nodes in every k-group and return the modified list.

## Problem Statement
Given a linked list, reverse the nodes of a linked list k at a time and return its modified list. If the number of nodes is not a multiple of k then left-out nodes in the end should remain as they are.

You may not alter the values in the list's nodes, only nodes themselves may be changed.

### Example
Input: `1 -> 2 -> 3 -> 4 -> 5`, k = 2  
Output: `2 -> 1 -> 4 -> 3 -> 5`

Input: `1 -> 2 -> 3 -> 4 -> 5`, k = 3  
Output: `3 -> 2 -> 1 -> 4 -> 5`

## Instructions to Run the Application
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Build the project using the command:
   ```
   dotnet build
   ```
4. Run the application using the command:
   ```
   dotnet run
   ```

## Additional Notes
- Ensure that you have the .NET SDK installed on your machine.
- This project is designed to demonstrate the solution to the "Reverse Nodes in k-Group" problem using C#.