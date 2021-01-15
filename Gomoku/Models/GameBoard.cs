using Gomoku.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Models
{
    class GameBoard
    {
        public PlayerId CurrentPlayer { get; set; } = PlayerId.Player1;
        
        public int[,] boardState = new int[15,15];
    }
}
