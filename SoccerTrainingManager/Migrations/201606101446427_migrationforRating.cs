namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationforRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StarRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.TrainingSessions", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingSessions", "Rating", c => c.String());
            DropTable("dbo.Ratings");
        }
    }
}
