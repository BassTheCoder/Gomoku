using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Contracts.Models
{
    public class TurnResponse
    {
        public bool IsGameFinished { get; set; }
        public bool IsGameTied { get; set; }
        public PlayerResponse CurrentPlayer { get; set; }
        public PlayerResponse NextPlayer { get; set; }
        public string TurnCountAsText { get; set; }
    }
}
