using System;
using System.IO;

namespace TicTacToeACA.Statistics
{
    public class StatisticsManager
    {
        private const string StatsFilePath = "statistics.txt";

        public int TotalGames;
        public int Player1Wins;
        public int Player2Wins;
        public int AiWins;
        public int Ties;

        public StatisticsManager()
        {
            LoadStatistics();
        }

        public void AddResult(string winner, bool isAiGame = false)
        {
            TotalGames++;

            if (winner == "Player1")
                Player1Wins++;
            else if (winner == "Player2")
                Player2Wins++;
            else if (winner == "AI" || (winner == "Player2" && isAiGame))
                AiWins++;
            else if (winner == "Tie")
                Ties++;

            SaveStatistics();
        }

        public void ResetStatistics()
        {
            TotalGames = 0;
            Player1Wins = 0;
            Player2Wins = 0;
            AiWins = 0;
            Ties = 0;
            SaveStatistics();
        }

        private void LoadStatistics()
        {
            if (!File.Exists(StatsFilePath)) return;

            var lines = File.ReadAllLines(StatsFilePath);
            if (lines.Length >= 5)
            {
                int.TryParse(lines[0], out TotalGames);
                int.TryParse(lines[1], out Player1Wins);
                int.TryParse(lines[2], out Player2Wins);
                int.TryParse(lines[3], out AiWins);
                int.TryParse(lines[4], out Ties);
            }
        }

        private void SaveStatistics()
        {
            string[] lines =
            {
                TotalGames.ToString(),
                Player1Wins.ToString(),
                Player2Wins.ToString(),
                AiWins.ToString(),
                Ties.ToString()
            };
            File.WriteAllLines(StatsFilePath, lines);
        }

        public void DisplayStatistics()
        {
            Console.Clear();  
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║      GAME STATISTICS     ║");
            Console.WriteLine("╚══════════════════════════╝\n");

            Console.WriteLine($"Total Games Played: {TotalGames}");
            Console.WriteLine($"Player 1 Wins: {Player1Wins}");
            Console.WriteLine($"Player 2 Wins: {Player2Wins}");
            Console.WriteLine($"AI Wins: {AiWins}");
            Console.WriteLine($"Ties: {Ties}");

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
