using Gomoku.Helpers;
using Gomoku.Models;
using System;
using System.Diagnostics;

namespace Gomoku.Services
{
    class GameService
    {
        private GameBoard _gameBoard = new GameBoard();

        private readonly DataBaseManager _dataBaseManager;
        public Player Player1 { get; set; } = new Player() { PlayerId = PlayerId.Player1, Color = "#ffffff" };
        public Player Player2 { get; set; } = new Player() { PlayerId = PlayerId.Player2, Color = "#000000" };

        public Player currentPlayer;
        
        public int TurnCounter { get; set; }
        public const int LastTurn = 225;
        public string ButtonTextColor { get; set; } = "#000000";

        public GameService()
        {
            _dataBaseManager = new DataBaseManager();
            currentPlayer = Player1;
        }

        public void LoadPlayers()
        {
            try
            {
                _dataBaseManager.playersList = _dataBaseManager.ReadFromFile();

                foreach (Player player in _dataBaseManager.playersList)
                {
                    if (player.Name == Player1.Name)
                    {
                        Player1 = player;
                        Player1.PlayerId = PlayerId.Player1;
                        Player1.Color = "#ffffff";
                    }
                    else if (player.Name == Player2.Name)
                    {
                        Player2 = player;
                        Player2.PlayerId = PlayerId.Player2;
                        Player2.Color = "#000000";
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            currentPlayer = Player1;
        }

        public TurnResponse UpdateBoardState(int row, int column)
        {
            _gameBoard.boardState[row, column] = (int)_gameBoard.CurrentPlayer;

            bool isGameFinished = IsGameFinished(_gameBoard.boardState);
            TurnResponse turnResponse = new TurnResponse
            {
                CurrentPlayer = _gameBoard.CurrentPlayer,
                ButtonText = TurnCounter.ToString()
            };

            TurnCounter++;

            if (TurnCounter == LastTurn)
            {
                isGameFinished = true;
                turnResponse.IsGameTied = true;
            }

            if (!isGameFinished)
            {
                turnResponse.NextPlayer = _gameBoard.CurrentPlayer = _gameBoard.CurrentPlayer switch
                {
                    PlayerId.Player1 => PlayerId.Player2,
                    PlayerId.Player2 => PlayerId.Player1,
                    _ => throw new ArgumentOutOfRangeException("There's no such player.")
                };

                if (currentPlayer == Player1)
                {
                    currentPlayer = Player2;
                }
                else if (currentPlayer == Player2)
                {
                    currentPlayer = Player1;
                }

                ButtonTextColor = ButtonTextColor switch
                {
                    "#ffffff" => "#000000",
                    "#000000" => "#ffffff",
                    _ => throw new ArgumentOutOfRangeException("There is no such color.")
                };
            }
            else if (isGameFinished)
            {
                if (TurnCounter != LastTurn)
                {
                    if (currentPlayer.Name == Player1.Name)
                    {
                        Player1.Wins++;
                        Player2.Losses++;
                    }
                    else if (currentPlayer.Name == Player2.Name)
                    {
                        Player2.Wins++;
                        Player1.Losses++;
                    }
                }
                else
                {
                    Player1.Ties++;
                    Player2.Ties++;
                }
                _dataBaseManager.UpdateOrCreatePlayer(Player1);
                _dataBaseManager.UpdateOrCreatePlayer(Player2);

                try
                {
                    _dataBaseManager.SaveToFile();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            turnResponse.ButtonTextColor = this.ButtonTextColor;
            turnResponse.IsGameFinished = isGameFinished;
            return turnResponse;
        }

        public bool IsGameFinished(int[,] boardState)
        {
            boardState = _gameBoard.boardState;
            int Result1 = 0;
            int Result2 = 0;
            for (int row = 0; row < 15; row++)
            {
                for (int column = 0; column <= 10; column++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row, column + i] == 1)
                            Result1++;
                        if (boardState[row, column + i] == 2)
                            Result2++;

                        if (Result1 == 5 || Result2 == 5)
                            return true;
                    }
                    Result1 = 0;
                    Result2 = 0;
                }
            }
            for (int column = 0; column < 15; column++)
            {
                for (int row = 0; row <= 10; row++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column] == 1)
                            Result1++;
                        if (boardState[row + i, column] == 2)
                            Result2++;

                        if (Result1 == 5 || Result2 == 5)
                            return true;
                    }
                    Result1 = 0;
                    Result2 = 0;
                }
            }
            for (int row = 0; row <= 10; row++)
            {
                for (int column = 10; column >= 0; column--)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column + 4 - i] == 1)
                            Result1++;
                        if (boardState[row + i, column + 4 - i] == 2)
                            Result2++;

                        if (Result1 == 5 || Result2 == 5)
                            return true;
                    }
                    Result1 = 0;
                    Result2 = 0;
                }
            }
            for (int column = 0; column <= 10; column++)
            {
                for (int row = 0; row <= 10; row++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState[row + i, column + i] == 1)
                            Result1++;
                        if (boardState[row + i, column + i] == 2)
                            Result2++;

                        if (Result1 == 5 || Result2 == 5)
                            return true;
                    }
                    Result1 = 0;
                    Result2 = 0;
                }
            }
            return false;
        }
    }
}
