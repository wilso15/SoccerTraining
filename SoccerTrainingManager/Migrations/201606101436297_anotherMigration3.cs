namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingSessions", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingSessions", "Rating");
        }
    }
}
