using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Models
{
    public class PlayerDto
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int TotalGames { get; set; }
        public string WinPercentage { get; set; }

        public PlayerDto(Player player)
        {
            Name = player.Name;
            Wins = player.Wins;
            Losses = player.Losses;
            Ties = player.Ties;
            TotalGames = player.TotalGames;
            WinPercentage = player.WinPercentage;
        }
    }

}
