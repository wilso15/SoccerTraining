namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fitnesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PossessionDrills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShootingDrills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TechnicalDrills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WarmUps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarmUps");
            DropTable("dbo.TechnicalDrills");
            DropTable("dbo.ShootingDrills");
            DropTable("dbo.PossessionDrills");
            DropTable("dbo.Fitnesses");
        }
    }
}
