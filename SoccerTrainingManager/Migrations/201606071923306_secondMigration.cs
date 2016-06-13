namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rosters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Player = c.String(),
                        JerseyNumber = c.Int(nullable: false),
                        Saves = c.Int(nullable: false),
                        Shots = c.Int(nullable: false),
                        ShotsOnTarget = c.Int(nullable: false),
                        Passes = c.Int(nullable: false),
                        PassesCompleted = c.Int(nullable: false),
                        Interceptions = c.Int(nullable: false),
                        Dribbles = c.Int(nullable: false),
                        DribblesCompleted = c.Int(nullable: false),
                        ParentOrGuardian = c.String(),
                        ParentOrGuardianEmail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rosters");
        }
    }
}
