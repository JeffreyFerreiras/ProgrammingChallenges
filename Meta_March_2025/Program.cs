// using System;

//original
// // To execute C#, please define "static void Main" on a class
// // named Solution.
// //Jeffrey
// class Solution
// {
//     static void Main(string[] args)
//     {
//         for (var i = 0; i < 5; i++)
//         {
//             Console.WriteLine("Hello, World");
//         }
//     }

//     void Run()
//     {

//     }
//     //approach 1
//     private int FindKth(int[] arr, int k)
//     {
//         // 2
//         Array.Sort(arr); // nlogn - run time
//         return arr[(arr.Length - 1) - k];
//     }

//     private int FindKth(int[] arr, int k)
//     {
//         // 2
//         // n * log (size of queue) = n * log (k)
//         var priorityQueue = new PriorityQueue<int, int>();

//         foreach (var elem in arr)
//         {
//             if (priorityQueue.Count >= k)
//             {
//                 var high = priorityQueue.Peek();
//                 if (elem > high)
//                 {
//                     priorityQueue.Enqueue(elem, elem);
//                     priorityQueue.Dequeue();
//                 }
//             }
//             else
//             {
//                 priorityQueue.Enqueue(elem, elem); // nlogn
//             }
//         }
//         return priorityQueue.Peek();

//         // for(int i = 0; i < k; i++){
//         //     (int value, int rank) = priorityQueue.Dequeu();
//         //     if(rank == (arr.Length - k)){
//         //         return value;
//         //     }
//         // }

//         // return -1;
//     }

//     private Dictionary<int, int[]> Clone(Dictionary<int, int[]> input)
//     {
//         Dictionary<int, int[]> clone = [];
//         foreach (var val in input)
//         {
//             if (!clone.ContainsKey(val.key))
//             {
//                 var cloneArr = new int[val.Value.Length];
//                 for (int i = 0; i < val.Value.Length; i++)
//                 {
//                     cloneArr[i] = val.Value[i];
//                 }
//                 clone.Add(val.Key, cloneArr);
//             }
//         }
//         // { 1':[2']; 2'':[1'']}
//         return clone;
//     }
// }


// // Your previous Plain Text content is preserved below:

// // Welcome to Meta!

// // This is just a simple shared plaintext pad, with no execution capabilities.

// // When you know what language you would like to use for your interview,
// // simply choose it from the dropdown in the left bar.

// // Enjoy your interview!

// // Find the kth largest element in an array
// // array = [-1,1,3,4,-2], 1st largest element = 4, 4th largest = -1. Assume there is no duplicate element. 

// // 1-2, 1-2-3
// // {
// //     node: arry[neighbour_nodes]
// // }
// // 1-2 -> 1'-2'
// // {
// //     1:[2]
// //     2:[1]
// // }
// // nodes, neighbours for each node; 
// // G