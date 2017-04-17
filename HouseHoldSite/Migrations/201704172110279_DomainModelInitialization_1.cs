namespace HouseHoldSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainModelInitialization_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ranges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.Int(nullable: false),
                        To = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Since = c.DateTime(),
                        Until = c.DateTime(),
                        Range_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ranges", t => t.Range_Id)
                .Index(t => t.Range_Id);
            
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Tariffs", "Range_Id", "dbo.Ranges");
            DropIndex("dbo.Tariffs", new[] { "Range_Id" });
            DropTable("dbo.Tariffs");
            DropTable("dbo.Ranges");
            DropTable("dbo.Measurements");
        }
    }
}
