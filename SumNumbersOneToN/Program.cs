namespace SumNumbersOneToN
{
    internal class Program
    {
        /*
    * Jeffrey E. Ferreiras.
    Programming Challenge Description:
Write a program that, given an integer, sums all the numbers from 1 through that integer (both inclusive). Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.
Input:
Your program should read lines from standard input. Each line contains a positive integer.
Output:
For each line of input, print to standard output the sum of the numbers from 1 through n, disregarding those divisible by 5 and 7. Print out each result on a new line.
    */
        public static void Main(string[] args)
        {
            Console.WriteLine(RecursiveAdder(10));
            Console.WriteLine(IterativeAdder(10));
            Console.WriteLine(LinqAdder(10));

            Console.ReadLine();
        }
        static int LinqAdder(int num) //SOLUTION 1
        {
            return Enumerable.Range(1, num).Sum(b => !(b % 5 == 0 || b % 7 == 0) ? b : 0);
        }
        private static int IterativeAdder(int num) //SOLUTION 2 - This is the ideal solution..Reason: It will be more widely understood and easy to read, and has the best performance.
        {
            int sum = 1;

            for (int i = 2; i < num; ++i)
            {
                if (i % 5 == 0 || i % 7 == 0) continue;
                sum += i;
            }

            return sum;
        }
        private static int RecursiveAdder(int num) //SOLUTION 3
        {
            if (num == 0) return 0;
            if (num % 5 == 0 || num % 7 == 0) return RecursiveAdder(num - 1);
            return num + RecursiveAdder(num - 1);
        }
    }
}