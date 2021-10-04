namespace Gomoku.WebApi.Models
{
    public class GameBoard
    {
        public int[,] Board { get; set; } = new int[15, 15];
    }
}
