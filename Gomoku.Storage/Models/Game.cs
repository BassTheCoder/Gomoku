using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Storage.Models
{
    class Game
    {
        public Guid Id { get; set; }
        public GameBoard GameBoard { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public ICollection<GameTurn> Turns { get; set; }
        public Guid? WinnerId { get; set; }
    }
}
