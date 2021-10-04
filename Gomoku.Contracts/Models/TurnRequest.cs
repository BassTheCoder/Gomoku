using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Contracts.Models
{
    public class TurnRequest
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
