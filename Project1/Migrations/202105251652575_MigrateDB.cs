namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zakazs");
            DropTable("dbo.Workers");
            DropTable("dbo.Utilits");
            DropTable("dbo.Users");
            DropTable("dbo.TypeMashins");
            DropTable("dbo.Orders");
            DropTable("dbo.Moneys");
            DropTable("dbo.Details");
            DropTable("dbo.Credits");
            DropTable("dbo.Bazaars");
            DropTable("dbo.Autoes");
            DropTable("dbo.NameOfMashins");
        }
    }
}
