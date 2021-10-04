using Gomoku.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Interfaces
{
    public interface IStatisticsService
    {
        ICollection<PlayerResponse> GetPlayersData();
    }
}
