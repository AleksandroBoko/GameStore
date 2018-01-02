using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntitiesConfigurations
{
    static class StudioConfiguration
    {
        public static void SetStudioConfiguration(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Studio>()
                .ToTable("Studio")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Studio>()
                .HasMany(x => x.Games)
                .WithRequired(x => x.GameStudio)
                .HasForeignKey(x => x.StudioId);
        }
    }
}
