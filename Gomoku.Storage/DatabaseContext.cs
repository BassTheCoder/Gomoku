using Gomoku.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Gomoku.Storage
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameTurn> GameTurns => Set<GameTurn>();
    }
}
