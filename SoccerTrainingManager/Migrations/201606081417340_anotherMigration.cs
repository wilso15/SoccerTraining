namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingSessions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WarmUp = c.String(),
                        TechnicalDrill = c.String(),
                        PossessionDrill = c.String(),
                        ShootingDrill = c.String(),
                        Fitness = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrainingSessions");
        }
    }
}
