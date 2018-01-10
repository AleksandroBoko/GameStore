namespace GameStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFieldToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "Image");
        }
    }
}
