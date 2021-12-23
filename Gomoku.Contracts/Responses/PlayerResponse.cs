using System;

namespace Gomoku.Contracts.Responses
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int TotalGames { get => Wins + Losses + Ties; }
        public string WinPercentage { get => TotalGames != 0 ? ((float)Wins / TotalGames * 100).ToString("0.00") + "%" : "0"; }
    }
}
