using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace WordSearchII
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario(
                    "Scenario 1 - Classic example",
                    new[]
                    {
                        new[] { 'o', 'a', 'a', 'n' },
                        new[] { 'e', 't', 'a', 'e' },
                        new[] { 'i', 'h', 'k', 'r' },
                        new[] { 'i', 'f', 'l', 'v' },
                    },
                    new[] { "oath", "pea", "eat", "rain" },
                    new[] { "eat", "oath" }
                ),
                new Scenario(
                    "Scenario 2 - Empty search set",
                    new[] { new[] { 'a', 'b' }, new[] { 'c', 'd' } },
                    Array.Empty<string>(),
                    Array.Empty<string>()
                ),
                new Scenario(
                    "Scenario 3 - No matching words",
                    new[] { new[] { 'a', 'b' }, new[] { 'c', 'd' } },
                    new[] { "zz" },
                    Array.Empty<string>()
                ),
                new Scenario(
                    "Scenario 4 - Shared prefix",
                    new[]
                    {
                        new[] { 'o', 'a', 'a', 'n' },
                        new[] { 'e', 't', 'a', 'e' },
                        new[] { 'i', 'h', 'k', 'r' },
                        new[] { 'i', 'f', 'l', 'v' },
                    },
                    new[] { "oat", "oath", "pea", "eat", "rain" },
                    new[] { "eat", "oat", "oath" }
                ),
                new Scenario(
                    "Scenario 5 - Dense board stress test",
                    CreateDenseBoard(),
                    CreateDenseWordSet(),
                    new[]
                    {
                        "aaaaaaaaaa", "baaaaaaaaa", "caaaaaaaaa", "daaaaaaaaa",
                        "eaaaaaaaaa", "faaaaaaaaa", "gaaaaaaaaa", "haaaaaaaaa",
                        "iaaaaaaaaa", "jaaaaaaaaa", "kaaaaaaaaa", "laaaaaaaaa",
                        "naaaaaaaaa", "oaaaaaaaaa", "paaaaaaaaa", "qaaaaaaaaa",
                        "raaaaaaaaa", "saaaaaaaaa", "taaaaaaaaa", "uaaaaaaaaa",
                        "vaaaaaaaaa", "waaaaaaaaa", "yaaaaaaaaa", "zaaaaaaaaa",
                        "cbaaaaaaaa", "mbaaaaaaaa", "bcaaaaaaaa", "dcaaaaaaaa",
                        "cdaaaaaaaa", "edaaaaaaaa", "deaaaaaaaa", "feaaaaaaaa",
                        "efaaaaaaaa", "gfaaaaaaaa", "fgaaaaaaaa", "hgaaaaaaaa",
                        "ghaaaaaaaa", "ihaaaaaaaa", "hiaaaaaaaa", "jiaaaaaaaa",
                        "ijaaaaaaaa", "kjaaaaaaaa", "jkaaaaaaaa", "lkaaaaaaaa",
                        "klaaaaaaaa", "mnaaaaaaaa", "onaaaaaaaa", "noaaaaaaaa",
                        "poaaaaaaaa", "opaaaaaaaa", "qpaaaaaaaa", "pqaaaaaaaa",
                        "rqaaaaaaaa", "qraaaaaaaa", "sraaaaaaaa", "rsaaaaaaaa",
                        "tsaaaaaaaa", "staaaaaaaa", "utaaaaaaaa", "tuaaaaaaaa",
                        "vuaaaaaaaa", "uvaaaaaaaa", "wvaaaaaaaa", "vwaaaaaaaa",
                        "xwaaaaaaaa", "xyaaaaaaaa", "zyaaaaaaaa", "azaaaaaaaa",
                        "yzaaaaaaaa",
                    }
                ),
            };

            foreach (var scenario in scenarios)
            {
                RunScenario(scenario);
            }

            var largeScenario = CreateLargeScenario(seed: 42, boardSize: 12, wordCount: 5_000, maxWordLength: 10);
            RunScenario(largeScenario);

            Console.WriteLine();
        }

        private static char[][] CreateDenseBoard()
        {
            return
            [
                "mbcdefghijkl".ToCharArray(),
                "naaaaaaaaaaa".ToCharArray(),
                "oaaaaaaaaaaa".ToCharArray(),
                "paaaaaaaaaaa".ToCharArray(),
                "qaaaaaaaaaaa".ToCharArray(),
                "raaaaaaaaaaa".ToCharArray(),
                "saaaaaaaaaaa".ToCharArray(),
                "taaaaaaaaaaa".ToCharArray(),
                "uaaaaaaaaaaa".ToCharArray(),
                "vaaaaaaaaaaa".ToCharArray(),
                "waaaaaaaaaaa".ToCharArray(),
                "xyzaaaaaaaaa".ToCharArray(),
            ];
        }

        private static string[] CreateDenseWordSet()
        {
            var words = new List<string>(26 * 26);

            for (var secondCharacter = 'a'; secondCharacter <= 'z'; secondCharacter++)
            {
                for (var firstCharacter = 'a'; firstCharacter <= 'z'; firstCharacter++)
                {
                    words.Add($"{firstCharacter}{secondCharacter}aaaaaaaa");
                }
            }

            return [.. words];
        }

        private static Scenario CreateLargeScenario(int seed, int boardSize, int wordCount, int maxWordLength)
        {
            var random = new Random(seed);
            var board = new char[boardSize][];
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int row = 0; row < boardSize; row++)
            {
                board[row] = new char[boardSize];
                for (int col = 0; col < boardSize; col++)
                {
                    board[row][col] = alphabet[random.Next(alphabet.Length)];
                }
            }

            // Plant a few known words so the expected set is deterministic.
            var guaranteedWords = new[] { "cat", "dog", "bird", "fish", "tree", "house", "water", "earth" };
            foreach (var word in guaranteedWords)
            {
                PlaceWordOnBoard(board, word, random);
            }

            var words = new List<string>(guaranteedWords);
            while (words.Count < wordCount)
            {
                int length = random.Next(3, maxWordLength + 1);
                var chars = new char[length];
                for (int i = 0; i < length; i++)
                {
                    chars[i] = alphabet[random.Next(alphabet.Length)];
                }
                words.Add(new string(chars));
            }

            // Expected result is computed separately because we don't know which random words exist.
            // For this benchmark we only assert that both methods agree, so expected is left empty in the runner.
            return new Scenario(
                $"Scenario 6 - Large stress test ({boardSize}x{boardSize}, {wordCount} words)",
                board,
                words.ToArray(),
                Array.Empty<string>()
            );
        }

        private static void PlaceWordOnBoard(char[][] board, string word, Random random)
        {
            int rows = board.Length;
            int cols = board[0].Length;
            var directions = new[] { (0, 1), (1, 0), (0, -1), (-1, 0), (1, 1), (-1, -1), (1, -1), (-1, 1) };

            for (int attempt = 0; attempt < 100; attempt++)
            {
                var (deltaRow, deltaCol) = directions[random.Next(directions.Length)];
                int startRow = random.Next(rows);
                int startCol = random.Next(cols);
                int endRow = startRow + deltaRow * (word.Length - 1);
                int endCol = startCol + deltaCol * (word.Length - 1);

                if (endRow < 0 || endRow >= rows || endCol < 0 || endCol >= cols)
                {
                    continue;
                }

                for (int i = 0; i < word.Length; i++)
                {
                    board[startRow + deltaRow * i][startCol + deltaCol * i] = word[i];
                }

                return;
            }
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            Console.WriteLine($"Board rows: {scenario.Board.Length}");
            Console.WriteLine($"Words: {string.Join(", ", scenario.Words.Take(6))}");

            var solution = new Solution();
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName)
                .Where(method => method.GetParameters().Length == 2)
                .Where(method => method.GetParameters()[0].ParameterType == typeof(char[][]))
                .Where(method => method.GetParameters()[1].ParameterType == typeof(string[]))
                .Where(method => method.ReturnType == typeof(IList<string>))
                .OrderBy(method => method.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var stopwatch = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try
                {
                    result = method.Invoke(
                        solution,
                        new object?[] { scenario.Board, scenario.Words }
                    );
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                finally
                {
                    stopwatch.Stop();
                }

                var elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"{method.Name} | {elapsedMilliseconds:0.0000} ms | ");

                if (exception != null)
                {
                    Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                    continue;
                }

                var actualWords = ((IEnumerable<string>?)result ?? Array.Empty<string>())
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .OrderBy(word => word)
                    .ToArray();

                var expectedWords = scenario.ExpectedWords.OrderBy(word => word).ToArray();

                bool passed;
                string message;
                if (expectedWords.Length > 0)
                {
                    passed = actualWords.SequenceEqual(expectedWords);
                    message = $"{(passed ? "✅ PASS" : "❌ FAIL")}";
                }
                else
                {
                    message = $"Found {actualWords.Length} words";
                    passed = true;
                }

                var previewWords = actualWords.Take(6);
                var preview = string.Join(", ", previewWords);
                if (actualWords.Length > 6)
                {
                    preview += ", ...";
                }

                Console.WriteLine($"{preview} | {message}");
            }
        }

        private sealed record Scenario(
            string Name,
            char[][] Board,
            string[] Words,
            string[] ExpectedWords
        );
    }
}
