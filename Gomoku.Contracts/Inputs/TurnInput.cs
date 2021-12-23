using System;

namespace Gomoku.Contracts.Inputs
{
    public class TurnInput
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
