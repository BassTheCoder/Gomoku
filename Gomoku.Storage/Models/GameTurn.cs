using System;

namespace Gomoku.Storage.Models
{
    public class GameTurn : EntityBase
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
