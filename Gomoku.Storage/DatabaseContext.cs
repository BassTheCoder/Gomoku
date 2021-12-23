﻿using Gomoku.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Gomoku.Storage
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<GameTurn> GameTurns => Set<GameTurn>();
    }
}