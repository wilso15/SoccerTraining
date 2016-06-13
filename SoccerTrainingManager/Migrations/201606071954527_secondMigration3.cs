namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rosters", "Guardian", c => c.String());
            AddColumn("dbo.Rosters", "GuardianEmail", c => c.String());
            DropColumn("dbo.Rosters", "ParentOrGuardian");
            DropColumn("dbo.Rosters", "ParentOrGuardianEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "ParentOrGuardianEmail", c => c.String());
            AddColumn("dbo.Rosters", "ParentOrGuardian", c => c.String());
            DropColumn("dbo.Rosters", "GuardianEmail");
            DropColumn("dbo.Rosters", "Guardian");
        }
    }
}
