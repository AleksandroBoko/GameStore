namespace GameStore.DataAccess.Migrations
{
    using EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore.DataAccess.EntityModels.GameStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore.DataAccess.EntityModels.GameStoreContext context)
        {
            /*Genres*/

            var genreActionId = Guid.NewGuid();
            var genreAction = new Genre() { Id = genreActionId, Name = "Action" };

            var genreRPGId = Guid.NewGuid();
            var genreRPG = new Genre() { Id = genreRPGId, Name = "RPG" };

            var genreStrategyId = Guid.NewGuid();
            var genreStrategy = new Genre() { Id = genreStrategyId, Name = "Strategy" };

            context.Genres.AddRange(new[] { genreAction, genreRPG, genreStrategy });

            /*Studios*/

            var studioPlariumId = Guid.NewGuid();
            var studioPlarium = new Studio() { Id = studioPlariumId, Name = "Plarium" };

            var studioG5Id = Guid.NewGuid();
            var studioG5 = new Studio() { Id = studioG5Id, Name = "G5" };

            var studioGameloftId = Guid.NewGuid();
            var studiogameLoft = new Studio() { Id = studioGameloftId, Name = "Gameloft" };

            context.Studios.AddRange(new[] { studioPlarium, studioG5, studiogameLoft });

            /*Producers*/

            var producerPlariumKharkivId = Guid.NewGuid();
            var producerPlariumKharkiv = new Producer() { Id = producerPlariumKharkivId, Name = "Plarium Kharkiv" };

            var producerPlariumKievId = Guid.NewGuid();
            var producerPlariumKiev = new Producer() { Id = producerPlariumKievId, Name = "Plarium Kiev" };

            var producerPlariumLvivId = Guid.NewGuid();
            var producerPlariumLviv = new Producer() { Id = producerPlariumLvivId, Name = "Plarium Lviv" };

            var producerGFiveKharkivId = Guid.NewGuid();
            var producerGFiveKharkiv = new Producer() { Id = producerGFiveKharkivId, Name = "G5 Kharkiv" };

            var producerGFiveOdessaId = Guid.NewGuid();
            var producerGFiveOdessa = new Producer() { Id = producerGFiveOdessaId, Name = "G5 Odessa" };

            var producerGameloftKharkivId = Guid.NewGuid();
            var producerGameloftKharkiv = new Producer() { Id = producerGameloftKharkivId, Name = "Gameloft Kharkiv" };

            var producerGameloftDneprId = Guid.NewGuid();
            var producerGameloftDnepr = new Producer() { Id = producerGameloftDneprId, Name = "Gameloft Dnipro" };

            var producerGameloftKievId = Guid.NewGuid();
            var producerGameloftKiev = new Producer() { Id = producerGameloftKievId, Name = "Gameloft Kiev" };

            context.Producers.AddRange(new[] 
            {
                producerPlariumKharkiv, producerPlariumKiev, producerPlariumLviv, producerGFiveKharkiv,
                producerGFiveOdessa, producerGameloftKharkiv, producerGameloftDnepr, producerGameloftKiev
            });

            /*Games*/

            var spartaId = Guid.NewGuid();
            var sparta = new Game()
            {
                Id = spartaId,
                Date = DateTime.Now,
                Description = "Historical",
                GenreId = genreStrategyId,
                StudioId = studioPlariumId,
                Name = "Sparta",
                Rate = 5,
                Producers = new[] { producerPlariumKharkiv, producerPlariumKiev },
                Image = string.Empty
            };

            var warClansId = Guid.NewGuid();
            var warClans = new Game()
            {
                Id = warClansId,
                Date = DateTime.Now,
                Description = "Historical",
                GenreId = genreStrategyId,
                StudioId = studioG5Id,
                Name = "War of Clans",
                Rate = 4,
                Producers = new[] { producerGFiveKharkiv, producerGFiveOdessa },
                Image = string.Empty
            };

            var hotSpeedId = Guid.NewGuid();
            var hotSpeed = new Game()
            {
                Id = hotSpeedId,
                Date = DateTime.Now,
                Description = "Action game. Cars and crimes.",
                GenreId = genreActionId,
                StudioId = studioGameloftId,
                Name = "Hot speed",
                Rate = 5,
                Producers = new[] { producerGameloftKharkiv},
                Image = string.Empty
            };

            context.Games.AddRange(new[] { sparta, hotSpeed, warClans });

            context.SaveChanges();
        }
    }
}
