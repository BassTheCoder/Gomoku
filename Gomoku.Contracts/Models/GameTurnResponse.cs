using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Contracts.Models
{
    public class GameTurnResponse
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerResponse Player { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
