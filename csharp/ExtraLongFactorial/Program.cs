using System.Numerics;

/*
* You are given an integer N. Print the factorial of this number.
*/

Run(Factorial, nameof(Factorial));

void Run(Func<BigInteger, BigInteger> calc, string methodName = "")
{
    var scenarios = new BigInteger[] { 5, 19, 25 };

    Console.WriteLine($"Running {methodName} for scenarios: {string.Join(", ", scenarios)}");
    foreach (var scenario in scenarios)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var ans = calc(scenario);

        watch.Stop();
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Answer for {scenario}: {ans}");
        Console.WriteLine($"Execution Time for {scenario}: {watch.Elapsed}");
    }
}

BigInteger Factorial(BigInteger n)
{
    if (n == 1)
        return n;

    return n * Factorial(n - 1);
}
