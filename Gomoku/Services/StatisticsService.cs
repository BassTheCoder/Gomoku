using Gomoku.Contracts.Models;
using Gomoku.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Gomoku.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HttpClient _httpClient;

        public StatisticsService()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };
        }

        public ICollection<PlayerResponse> GetPlayersData()
        {
            var response = _httpClient.GetAsync("/players").Result;
            var players = JsonSerializer.Deserialize<ICollection<PlayerResponse>>(response.Content.ReadAsStringAsync().Result);
            return players;
        }
    }
}
