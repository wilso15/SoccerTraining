namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingSessions", "Rating", c => c.String());
            AlterColumn("dbo.Ratings", "StarRating", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "StarRating", c => c.Int(nullable: false));
            DropColumn("dbo.TrainingSessions", "Rating");
        }
    }
}
