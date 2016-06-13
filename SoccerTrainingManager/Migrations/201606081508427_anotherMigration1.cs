namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingSessions", "WarmUpJog", c => c.String());
            AddColumn("dbo.TrainingSessions", "WarmUpTag", c => c.String());
            AddColumn("dbo.TrainingSessions", "TechnicalDrillShalke", c => c.String());
            AddColumn("dbo.TrainingSessions", "TechnicalDrillChelsea", c => c.String());
            AddColumn("dbo.TrainingSessions", "PossessionDrillBlackJack", c => c.String());
            AddColumn("dbo.TrainingSessions", "PossessionDrillTwoTouch", c => c.String());
            AddColumn("dbo.TrainingSessions", "ShootingDrillCalebPorter", c => c.String());
            AddColumn("dbo.TrainingSessions", "ShootingDrillDynamo", c => c.String());
            AddColumn("dbo.TrainingSessions", "Fitness14", c => c.String());
            AddColumn("dbo.TrainingSessions", "FitnessSuicides", c => c.String());
            AddColumn("dbo.TrainingSessions", "CoolDown", c => c.String());
            DropColumn("dbo.TrainingSessions", "WarmUp");
            DropColumn("dbo.TrainingSessions", "TechnicalDrill");
            DropColumn("dbo.TrainingSessions", "PossessionDrill");
            DropColumn("dbo.TrainingSessions", "ShootingDrill");
            DropColumn("dbo.TrainingSessions", "Fitness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingSessions", "Fitness", c => c.String());
            AddColumn("dbo.TrainingSessions", "ShootingDrill", c => c.String());
            AddColumn("dbo.TrainingSessions", "PossessionDrill", c => c.String());
            AddColumn("dbo.TrainingSessions", "TechnicalDrill", c => c.String());
            AddColumn("dbo.TrainingSessions", "WarmUp", c => c.String());
            DropColumn("dbo.TrainingSessions", "CoolDown");
            DropColumn("dbo.TrainingSessions", "FitnessSuicides");
            DropColumn("dbo.TrainingSessions", "Fitness14");
            DropColumn("dbo.TrainingSessions", "ShootingDrillDynamo");
            DropColumn("dbo.TrainingSessions", "ShootingDrillCalebPorter");
            DropColumn("dbo.TrainingSessions", "PossessionDrillTwoTouch");
            DropColumn("dbo.TrainingSessions", "PossessionDrillBlackJack");
            DropColumn("dbo.TrainingSessions", "TechnicalDrillChelsea");
            DropColumn("dbo.TrainingSessions", "TechnicalDrillShalke");
            DropColumn("dbo.TrainingSessions", "WarmUpTag");
            DropColumn("dbo.TrainingSessions", "WarmUpJog");
        }
    }
}
