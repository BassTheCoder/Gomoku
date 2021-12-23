﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Storage.Models
{
    public class GameTurn
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}