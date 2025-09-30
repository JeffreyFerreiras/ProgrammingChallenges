using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DesignTwitter;

internal record Operation(string Command, int UserId, int? TargetUserId, int? TweetId, int[]? ExpectedFeed);
internal record TestScenario(string Name, Operation[] Operations);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.CreateTwitter);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[]
                {
                    Op.PostTweet(1, 5),
                    Op.GetNewsFeed(1, new[] { 5 }),
                    Op.Follow(1, 2),
                    Op.PostTweet(2, 6),
                    Op.GetNewsFeed(1, new[] { 6, 5 }),
                    Op.Unfollow(1, 2),
                    Op.GetNewsFeed(1, new[] { 5 }),
                }
            ),
            new(
                "Multiple Users",
                new[]
                {
                    Op.PostTweet(2, 101),
                    Op.PostTweet(3, 102),
                    Op.PostTweet(1, 103),
                    Op.Follow(1, 2),
                    Op.Follow(1, 3),
                    Op.GetNewsFeed(1, new[] { 103, 102, 101 }),
                    Op.Unfollow(1, 2),
                    Op.PostTweet(3, 104),
                    Op.GetNewsFeed(1, new[] { 104, 103, 102 }),
                }
            ),
            new(
                "Heavy Timeline",
                BuildHeavyScenario()
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static Operation[] BuildHeavyScenario()
    {
        const int userCount = 10;
        const int tweetsPerUser = 20;
        List<Operation> operations = new();
        operations.Add(Op.Build());
        for (int user = 1; user <= userCount; user++)
        {
            for (int i = 0; i < tweetsPerUser; i++)
            {
                operations.Add(Op.PostTweet(user, user * 1_000 + i));
            }
        }

        operations.Add(Op.GetNewsFeed(1, Array.Empty<int>()));
        for (int followee = 2; followee <= userCount; followee++)
        {
            operations.Add(Op.Follow(1, followee));
        }

        operations.Add(Op.GetNewsFeed(1, Enumerable.Range(0, 10).Select(i => 10 * 1_000 + (tweetsPerUser - 1 - i)).ToArray()));
        return operations.ToArray();
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Operation Count: {scenario.Operations.Length}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            Solution.Twitter twitter = solution.CreateTwitter();
            List<string> feeds = new();

            foreach (Operation operation in scenario.Operations)
            {
                switch (operation.Command)
                {
                    case nameof(Op.PostTweet):
                        twitter.PostTweet(operation.UserId, operation.TweetId!.Value);
                        break;
                    case nameof(Op.Follow):
                        twitter.Follow(operation.UserId, operation.TargetUserId!.Value);
                        break;
                    case nameof(Op.Unfollow):
                        twitter.Unfollow(operation.UserId, operation.TargetUserId!.Value);
                        break;
                    case nameof(Op.GetNewsFeed):
                        IList<int> feed = twitter.GetNewsFeed(operation.UserId);
                        feeds.Add(FormatFeed(feed));
                        break;
                    case nameof(Op.Build):
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown command: {operation.Command}");
                }
            }

            stopwatch.Stop();
            resultDisplay = $"[{string.Join(",", feeds)}]";
        }
        catch (NotImplementedException ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Not Implemented ({ex.Message})";
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Error ({ex.GetType().Name}: {ex.Message})";
        }

        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Result: {resultDisplay}");
        Console.WriteLine($"Expected Feeds: {FormatExpectedFeeds(scenario.Operations)}");
        Console.WriteLine();
    }

    private static string FormatFeed(IEnumerable<int> feed)
    {
        return $"[{string.Join(",", feed)}]";
    }

    private static string FormatExpectedFeeds(IEnumerable<Operation> operations)
    {
        var expected = operations.Where(op => op.Command == nameof(Op.GetNewsFeed) && op.ExpectedFeed is not null)
            .Select(op => FormatFeed(op.ExpectedFeed!));
        return $"[{string.Join(",", expected)}]";
    }

    private static class Op
    {
        public static Operation PostTweet(int userId, int tweetId) => new(nameof(PostTweet), userId, null, tweetId, null);
        public static Operation Follow(int followerId, int followeeId) => new(nameof(Follow), followerId, followeeId, null, null);
        public static Operation Unfollow(int followerId, int followeeId) => new(nameof(Unfollow), followerId, followeeId, null, null);
        public static Operation GetNewsFeed(int userId, int[] expectedFeed) => new(nameof(GetNewsFeed), userId, null, null, expectedFeed);
        public static Operation Build() => new(nameof(Build), 0, null, null, null);
    }
}
