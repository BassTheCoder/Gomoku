namespace Gomoku.WebApi.Models
{
    public class TurnResponse
    {
        public bool IsGameFinished { get; set; }
        public bool IsGameTied { get; set; }
        public int CurrentPlayerId { get; set; }
        public int NextPlayerId { get; set; }
        public string TurnCountAsText { get; set; }
    }
}
