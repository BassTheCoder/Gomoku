using Gomoku.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gomoku.Storage.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);
            builder.OwnsOne(g => g.GameBoard);
            builder
                .HasMany(g => g.Turns)
                .WithOne(t => t.Game);
        }
    }
}
