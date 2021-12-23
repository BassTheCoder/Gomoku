using Gomoku.Contracts.Responses;
using Gomoku.Interfaces;
using Gomoku.Services;
using System.Collections.ObjectModel;

namespace Gomoku.ViewModels
{
    public class StatsViewModel
    {
        private readonly IStatisticsService _statisticsService;
        public ObservableCollection<PlayerResponse> PlayersCollection { get; set; }
        
        public StatsViewModel()
        {
            _statisticsService = new StatisticsService();
            PlayersCollection = new ObservableCollection<PlayerResponse>();
            var playersList = _statisticsService.GetPlayersData();

            if (playersList != null)
            {
                foreach (var player in playersList)
                {
                    PlayersCollection.Add(player);
                }
            }
        }
    }
}
