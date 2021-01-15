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

            foreach (Player player in _dataBaseManager.ReadFromFile())
            {
                PlayersCollection.Add(player);
            }
        }
    }
}
