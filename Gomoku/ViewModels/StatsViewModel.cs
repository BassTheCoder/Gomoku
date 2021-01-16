using Gomoku.Models;
using Gomoku.Helpers;
using System.Collections.ObjectModel;

namespace Gomoku.ViewModels
{
    public class StatsViewModel
    {
        private DataBaseManager _dataBaseManager;
        public ObservableCollection<Player> PlayersCollection { get; set; }
        
        public StatsViewModel()
        {            
            _dataBaseManager = new DataBaseManager();
            PlayersCollection = new ObservableCollection<Player>();
            var playersList = _dataBaseManager.ReadFromFile();
            if (playersList != null)
            {
                foreach (Player player in playersList)
                {
                    PlayersCollection.Add(player);
                }
            }
        }
    }
}
