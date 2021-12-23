using Gomoku.Contracts.Responses;
using System;

namespace Gomoku.Interfaces
{
    public interface IGameService
    {
        TurnResponse SendGameTurnActionRequest(Guid gameId, int x, int y);
    }
}
