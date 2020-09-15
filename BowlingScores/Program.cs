using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            var scores = new Dictionary<string, int>();
            while (true)
            {
                Console.Write("What is the Bowler's Name: ");
                var name = Console.ReadLine();
                if (scores.ContainsKey(name))
                {
                    Console.WriteLine($"You already gave me a score for {name}. Try Again.");
                    continue;
                }
                if (name == "")
                {
                    break;
                }
                Console.Write($"What was {name}'s score: ");
                var score = int.Parse(Console.ReadLine());
                scores.Add(name, score);
            }

            var highScore = -1;
            var lowScore = 301;
            var highScorer = new List<string>();
            var lowScorer = new List<string>();
            var total = 0;
            foreach (var kvp in scores)
            {
                if (kvp.Value > highScore)
                {
                    highScore = kvp.Value;
                    highScorer.Clear();
                    highScorer.Add(kvp.Key);
                }
                else if (kvp.Value == highScore)
                {
                    highScorer.Add(kvp.Key);
                }
                if (kvp.Value < lowScore)
                {
                    lowScore = kvp.Value;
                    lowScorer.Clear();
                    lowScorer.Add(kvp.Key);
                }
                else if (kvp.Value == lowScore)
                {
                    lowScorer.Add(kvp.Key);
                }
                total += kvp.Value;
            }

            if (highScorer.Count == 1)
            {
                Console.WriteLine($"{highScorer} had the high score of {highScore}");
            }
            else
            {
                Console.WriteLine($"There were ties for the high score of {highScore}");
                foreach (var person in highScorer)
                {
                    Console.WriteLine($"\t{person}");
                }
            }
            if (lowScorer.Count == 1)
            {
                Console.WriteLine($"{lowScorer} had the low score of {lowScore}");
            }
            else
            {
                Console.WriteLine($"There were ties for the low score of {lowScore}");
                foreach (var person in lowScorer)
                {
                    Console.WriteLine($"\t{person}");
                }
            }
            Console.WriteLine($"The average score was {total / scores.Count}");
        }
    }
}
