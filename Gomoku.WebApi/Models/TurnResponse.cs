﻿using System;

namespace Gomoku.WebApi.Models
{
    public class TurnResponse
    {
        public bool IsGameFinished { get; set; }
        public bool IsGameTied { get; set; }
        public Guid CurrentPlayerId { get; set; }
        public Guid NextPlayerId { get; set; }
        public string TurnCountAsText { get; set; }
    }
}