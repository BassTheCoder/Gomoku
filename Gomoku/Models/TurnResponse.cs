using Gomoku.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Models
{
    public class TurnResponse
    {
        public bool IsGameFinished { get; set; }
        public bool IsGameTied { get; set; }
        public PlayerId CurrentPlayer { get; set; }
        public PlayerId NextPlayer { get; set; }
        public string Color { get; set; }
        public string ButtonText { get; set; }
        public string ButtonTextColor { get; set; }
    }
}
