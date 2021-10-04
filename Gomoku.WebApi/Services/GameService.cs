using Gomoku.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gomoku.WebApi.Services
{
    public class GameService
    {
        public int TurnCounter { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; set; }

        private const int _turnLimit = 225;
        private GameBoard _gameBoard;

        public GameService()
        {
            _gameBoard = new GameBoard();
            Player1 = new Player() { Id = 1 };
            Player2 = new Player() { Id = 2 };
            CurrentPlayer = Player1;
            TurnCounter = 1;
        }

        public TurnResponse GetTurnResponse()
        {
            TurnResponse turnResponse = new TurnResponse
            {
                CurrentPlayerId = CurrentPlayer.Id,
                TurnCountAsText = TurnCounter.ToString()
            };

            TurnCounter++;

            bool isGameFinished = IsGameFinished(_gameBoard.Board);
            if (!isGameFinished)
            {
                turnResponse.NextPlayerId = CurrentPlayer.Id == 1 ? 2 : 1;

                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            }
            else
            {
                if (TurnCounter == _turnLimit)
                {
                    turnResponse.IsGameTied = true;
                }
            }

            turnResponse.IsGameFinished = isGameFinished;
            return turnResponse;
        }

        public void UpdateBoardState(int row, int column)
        {
            _gameBoard.Board[row, column] = CurrentPlayer.Id;
        }

        private bool IsGameFinished(int[,] boardState)
        {
            return DidTheGameTie() ? true : DidSomeoneWin(boardState);
        }

        private bool DidTheGameTie()
        {
            return TurnCounter == _turnLimit;
        }

        private bool DidSomeoneWin(int[,] boardState)
        {
            int player1InARow = 0;
            int player2InARow = 0;
            for (int row = 0; row < 15; row++)
            {
                for (int column = 0; column <= 10; column++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row, column + i] == 1)
                            player1InARow++;
                        if (boardState[row, column + i] == 2)
                            player2InARow++;

                        if (player1InARow == 5 || player2InARow == 5)
                            return true;
                    }
                    player1InARow = 0;
                    player2InARow = 0;
                }
            }
            for (int column = 0; column < 15; column++)
            {
                for (int row = 0; row <= 10; row++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column] == 1)
                            player1InARow++;
                        if (boardState[row + i, column] == 2)
                            player2InARow++;

                        if (player1InARow == 5 || player2InARow == 5)
                            return true;
                    }
                    player1InARow = 0;
                    player2InARow = 0;
                }
            }
            for (int row = 0; row <= 10; row++)
            {
                for (int column = 10; column >= 0; column--)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column + 4 - i] == 1)
                            player1InARow++;
                        if (boardState[row + i, column + 4 - i] == 2)
                            player2InARow++;

                        if (player1InARow == 5 || player2InARow == 5)
                            return true;
                    }
                    player1InARow = 0;
                    player2InARow = 0;
                }
            }
            for (int column = 0; column <= 10; column++)
            {
                for (int row = 0; row <= 10; row++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column + i] == 1)
                            player1InARow++;
                        if (boardState[row + i, column + i] == 2)
                            player2InARow++;

                        if (player1InARow == 5 || player2InARow == 5)
                            return true;
                    }
                    player1InARow = 0;
                    player2InARow = 0;
                }
            }
            return false;
        }
    }
}
