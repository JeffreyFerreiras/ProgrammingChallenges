using System.Diagnostics;

// To execute C#, please define "static void Main" on a class
// named Solution.
//Jeffrey
class RefinedSolution
{
    static void Main(string[] args)
    {
        var solution = new RefinedSolution();
        
        // Updated test scenarios: array, k (1-based), expected result
        var testCases = new[]
        {
            (new[] { -1, 1, 3, 4, -2 }, 1, 4),    // 1st largest is 4
            (new[] { -1, 1, 3, 4, -2 }, 2, 3),      // 2nd largest is 3
            (new[] { -1, 1, 3, 4, -2 }, 4, -1),     // 4th largest is -1
            (new[] { 5, 10, 15, 20, 25 }, 2, 20),    // 2nd largest is 20
            (new[] { 100, 50, 25, 75 }, 2, 75)       // 2nd largest is 75
        };
        
        var stopwatch = new Stopwatch();
        
        // Test FindKth1
        foreach (var (arr, k, expectedResult) in testCases)
        {
            var arrCopy = (int[])arr.Clone();
            stopwatch.Restart();
            int result1 = solution.FindKth1(arrCopy, k);
            stopwatch.Stop();
            
            Console.WriteLine($"Method: FindKth1, Time: {stopwatch.ElapsedMilliseconds}ms, Result: `{result1}`, Expected: `{expectedResult}`");
        }
        
        Console.WriteLine();
        
        // Test FindKth2
        foreach (var (arr, k, expected) in testCases)
        {
            var arrCopy = (int[])arr.Clone();
            stopwatch.Restart();
            int result2 = solution.FindKth2(arrCopy, k);
            stopwatch.Stop();
            
            Console.WriteLine($"Method: FindKth2, Time: {stopwatch.ElapsedMilliseconds}ms, Result: `{result2}`, Expected: `{expected}`");
        }
        
        Console.WriteLine();
        
        // Test Clone method
        Console.WriteLine("Testing Clone method:");
        var testDict = new Dictionary<int, int[]>
        {
            { 1, new[] { 2, 3 } },
            { 2, new[] { 1, 3, 4 } },
            { 3, new[] { 1, 2 } },
            { 4, new[] { 2 } }
        };
        
        stopwatch.Restart();
        var clonedDict = solution.Clone(testDict);
        stopwatch.Stop();
        
        // Verify it's a deep clone by changing original
        testDict[1][0] = 999;
        
        bool cloneSuccessful = testDict[1][0] == 999 && clonedDict[1][0] == 2;
        string expectedCloneResult = "Deep clone successful";
        string result = cloneSuccessful ? "Deep clone successful" : "Clone failed";
        
        Console.WriteLine($"Method: Clone, Time: {stopwatch.ElapsedMilliseconds}ms, Result: `{result}`, Expected: `{expectedCloneResult}`");
        
        // Print dictionaries for visual verification
        Console.WriteLine("Original dictionary after modification:");
        PrintDictionary(testDict);
        
        Console.WriteLine("Cloned dictionary (should be unchanged):");
        PrintDictionary(clonedDict);
    }
    
    static void PrintDictionary(Dictionary<int, int[]> dict)
    {
        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key}: [{string.Join(", ", kvp.Value)}]");
        }
    }

    //approach 1
    public int FindKth1(int[] arr, int k)
    {
        // 2
        Array.Sort(arr); // nlogn - run time
        return arr[arr.Length - k];
    }

    public int FindKth2(int[] arr, int k)
    {
        // 2
        // n * log (size of queue) = n * log (k)
        var priorityQueue = new PriorityQueue<int, int>(); // O(1)

        // foreach (var elem in arr) // O(n)
        // {
        //     priorityQueue.Enqueue(elem, elem); // nlogk

        //     if(priorityQueue.Count > Math.Max(k,1)) // O(1)
        //     {
        //         priorityQueue.Dequeue(); // O(logk)
        //     }
        // }
        // return priorityQueue.Count > 0 ? priorityQueue.Peek() : -1; // O(1)


        foreach (var elem in arr)
        {
            if (priorityQueue.Count >= k)
            {
                var high = priorityQueue.Peek();
                if (elem > high)
                {
                    priorityQueue.Enqueue(elem, elem);
                    priorityQueue.Dequeue();
                }
            }
            else
            {
                priorityQueue.Enqueue(elem, elem); // nlogn
            }
        }
        return priorityQueue.Peek();
    }

    public Dictionary<int, int[]> Clone(Dictionary<int, int[]> input)
    {
        Dictionary<int, int[]> clone = [];
        foreach (var val in input)
        {
            if (!clone.ContainsKey(val.Key))
            {
                var cloneArr = new int[val.Value.Length];
                for (int i = 0; i < val.Value.Length; i++)
                {
                    cloneArr[i] = val.Value[i];
                }
                clone.Add(val.Key, cloneArr);
            }
        }
        // { 1':[2']; 2'':[1'']}
        return clone;
    }
}


// Your previous Plain Text content is preserved below:

// Welcome to Meta!

// This is just a simple shared plaintext pad, with no execution capabilities.

// When you know what language you would like to use for your interview,
// simply choose it from the dropdown in the left bar.

// Enjoy your interview!

// Find the kth largest element in an array
// array = [-1,1,3,4,-2], 1st largest element = 4, 4th largest = -1. Assume there is no duplicate element. 

// 1-2, 1-2-3
// {
//     node: arry[neighbour_nodes]
// }
// 1-2 -> 1'-2'
// {
//     1:[2]
//     2:[1]
// }
// nodes, neighbours for each node; 
// G