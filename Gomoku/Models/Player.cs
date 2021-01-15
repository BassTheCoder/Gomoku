using Gomoku.Helpers;
using PropertyChanged;
using System.Text.Json.Serialization;

namespace Gomoku.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Player
    {
        [JsonIgnore]
        public PlayerId PlayerId { get; set; }
        [JsonIgnore]
        public string Color { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int TotalGames { get => Wins+Losses+Ties; }
        public string WinPercentage { get => TotalGames != 0 ? ((float)Wins/TotalGames*100).ToString("0.00") + "%" : "0" ; }
    }
}
