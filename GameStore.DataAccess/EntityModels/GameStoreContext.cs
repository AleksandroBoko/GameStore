using GameStore.DataAccess.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntityModels
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext() : base("GameStoreContext")
        { }

        private static readonly GameStoreContext Instance = new GameStoreContext();
        
        public static GameStoreContext GetInstance()
        {
            return Instance;
        } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 

            GenreConfiguration.SetGenreConfiguration(modelBuilder);
            StudioConfiguration.SetStudioConfiguration(modelBuilder);
            ProducerConfiguration.SetProducerConfiguration(modelBuilder);
            GameConfiguration.SetGameConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
