using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntitiesConfigurations
{
    static class GenreConfiguration
    {
        public static void SetGenreConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .ToTable("Genre")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .HasMany(x => x.Games)
                .WithRequired(x => x.GameGenre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
