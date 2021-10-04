using Gomoku.Contracts.Models;
using Gomoku.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
