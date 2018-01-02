using GameStore.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntitiesConfigurations
{
    static class ProducerConfiguration
    {
        public static void SetProducerConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>()
                .ToTable("Producer")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Producer>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
