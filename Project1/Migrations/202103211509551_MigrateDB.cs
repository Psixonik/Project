namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        col = c.Int(nullable: false),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TypeMashins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        kyzov = c.String(),
                        colKyzov = c.Int(nullable: false),
                        koleso = c.String(),
                        colKoleso = c.Int(nullable: false),
                        motor = c.String(),
                        colMotor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Zakazs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        col = c.Int(nullable: false),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        typeMashiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zakazs");
            DropTable("dbo.TypeMashins");
            DropTable("dbo.Details");
        }
    }
}
