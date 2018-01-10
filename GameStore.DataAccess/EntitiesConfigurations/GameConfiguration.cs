using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntitiesConfigurations
{
    static class GameConfiguration
    {
        public static void SetGameConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .ToTable("Game")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Game>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(x => x.Rate)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(x => x.Image)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(x => x.Description)
                .HasMaxLength(500)
                .IsOptional();

            modelBuilder.Entity<Game>()
                .HasMany(p => p.Producers)
                .WithMany(g => g.Games)
                .Map(m =>
                {
                    m.ToTable("GameProducer");
                    m.MapLeftKey("ProducerId");
                    m.MapRightKey("GameId");
                }
                );
        }
    }
}
