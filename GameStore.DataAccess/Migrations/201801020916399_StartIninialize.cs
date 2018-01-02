namespace GameStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartIninialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        GenreId = c.Guid(nullable: false),
                        StudioId = c.Guid(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Studio", t => t.StudioId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.StudioId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Studio",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameProducer",
                c => new
                    {
                        ProducerId = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProducerId, t.GameId })
                .ForeignKey("dbo.Game", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.Producer", t => t.GameId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameProducer", "GameId", "dbo.Producer");
            DropForeignKey("dbo.GameProducer", "ProducerId", "dbo.Game");
            DropForeignKey("dbo.Game", "StudioId", "dbo.Studio");
            DropForeignKey("dbo.Game", "GenreId", "dbo.Genre");
            DropIndex("dbo.GameProducer", new[] { "GameId" });
            DropIndex("dbo.GameProducer", new[] { "ProducerId" });
            DropIndex("dbo.Game", new[] { "StudioId" });
            DropIndex("dbo.Game", new[] { "GenreId" });
            DropTable("dbo.GameProducer");
            DropTable("dbo.Producer");
            DropTable("dbo.Studio");
            DropTable("dbo.Genre");
            DropTable("dbo.Game");
        }
    }
}
