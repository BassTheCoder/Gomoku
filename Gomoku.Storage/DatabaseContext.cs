using Gomoku.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Gomoku.Storage
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder) { }

        public DatabaseContext()
        {
            
        }

        public DbSet<Player> Players { get; set; } 
        public DbSet<GameTurn> GameTurns { get; set; }
    }
}
