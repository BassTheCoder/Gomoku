using Gomoku.Contracts.Responses;
using System.Collections.Generic;

namespace Gomoku.Interfaces
{
    public interface IStatisticsService
    {
        ICollection<PlayerResponse> GetPlayersData();
    }
}
