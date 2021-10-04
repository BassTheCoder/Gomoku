using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gomoku.Storage.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameTurn> GameTurns { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        [NotMapped]
        public int TotalGames { get => Wins+Losses+Ties; }
        [NotMapped]
        public string WinPercentage { get => TotalGames != 0 ? ((float)Wins/TotalGames*100).ToString("0.00") + "%" : "0" ; }
    }
}
