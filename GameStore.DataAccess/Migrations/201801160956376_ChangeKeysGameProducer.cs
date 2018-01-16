namespace GameStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeysGameProducer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GameProducer", name: "ProducerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GameProducer", name: "GameId", newName: "ProducerId");
            RenameColumn(table: "dbo.GameProducer", name: "__mig_tmp__0", newName: "GameId");
            RenameIndex(table: "dbo.GameProducer", name: "IX_ProducerId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GameProducer", name: "IX_GameId", newName: "IX_ProducerId");
            RenameIndex(table: "dbo.GameProducer", name: "__mig_tmp__0", newName: "IX_GameId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GameProducer", name: "IX_GameId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GameProducer", name: "IX_ProducerId", newName: "IX_GameId");
            RenameIndex(table: "dbo.GameProducer", name: "__mig_tmp__0", newName: "IX_ProducerId");
            RenameColumn(table: "dbo.GameProducer", name: "GameId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GameProducer", name: "ProducerId", newName: "GameId");
            RenameColumn(table: "dbo.GameProducer", name: "__mig_tmp__0", newName: "ProducerId");
        }
    }
}
