using Gomoku.Contracts.Responses;
using Gomoku.Interfaces;
using System;
using System.Net.Http;

namespace Gomoku.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;

        public GameService()
        {
            _httpClient = new HttpClient();
        }

        public TurnResponse SendGameTurnActionRequest(Guid gameId, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
