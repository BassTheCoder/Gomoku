﻿namespace Gomoku.Storage.Models
{
    class GameBoard
    {
        public int[,] Board { get; set; } = new int[15, 15];
    }
}
