using Gomoku.Helpers;

namespace Gomoku.Models
{
    class GameBoard
    {
        public PlayerId CurrentPlayer { get; set; } = PlayerId.Player1;
        
        public int[,] boardState = new int[15,15];
    }
}
