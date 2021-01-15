using Gomoku.Helpers;
using Gomoku.Models;
using Gomoku.Services;
using PropertyChanged;

namespace Gomoku.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GameViewModel
    {
        private readonly GameService _gameService;
        public string ButtonName { get; set; }
        public string CurrentPlayerName { get; set; }
        public string Player1Name { get => _gameService.Player1.Name; set => _gameService.Player1.Name = value; }
        public string Player2Name { get => _gameService.Player2.Name; set => _gameService.Player2.Name = value; }



        public GameViewModel()
        {
            _gameService = new GameService();
            CurrentPlayerName = _gameService.Player1.Name;
        }

        public void LoadPlayers()
        {
            _gameService.LoadPlayers();
        }

        public TurnResponse SendAction(int row, int column)
        {
            var turnResponse = _gameService.UpdateBoardState(row, column);

            if (_gameService.Player1.PlayerId == turnResponse.CurrentPlayer)
            {
                if (!turnResponse.IsGameFinished)
                {
                    CurrentPlayerName = _gameService.Player2.Name;
                }
                turnResponse.Color = _gameService.Player2.Color;
            }
            else
            {
                if (!turnResponse.IsGameFinished)
                {
                    CurrentPlayerName = _gameService.Player1.Name;
                }
                turnResponse.Color = _gameService.Player1.Color;
            }

            return turnResponse;
        }
    }
}
