using Gomoku.Contracts.Models;
using Gomoku.Interfaces;
using Gomoku.Services;
using PropertyChanged;
using System;

namespace Gomoku.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GameViewModel
    {
        public string ButtonName { get; set; }
        public string CurrentPlayerName { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        private readonly IGameService _gameService;


        public GameViewModel()
        {
            _gameService = new GameService();
        }

        public TurnResponse SendAction(int row, int column)
        {
            var turnResponse = _gameService.SendGameTurnActionRequest(Guid.NewGuid(), row, column);

            if (!turnResponse.IsGameFinished)
            {
                CurrentPlayerName = turnResponse.NextPlayer.Name;
            }
            return turnResponse;
        }
    }
}
