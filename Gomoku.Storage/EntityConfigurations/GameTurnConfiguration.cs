using Gomoku.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Storage.EntityConfigurations
{
    public class GameTurnConfiguration : IEntityTypeConfiguration<GameTurn>
    {
        public void Configure(EntityTypeBuilder<GameTurn> builder)
        {
            builder.HasKey(gt => gt.Id);
            builder
                .HasOne(gt => gt.Player)
                .WithMany(p => p.GameTurns);
        }
    }
}
