namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Cards", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Days", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Days", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Weeks", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Weeks", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Internships", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Internships", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Games", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Games", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Decks", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Decks", "ModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Decks", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Decks", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Internships", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Internships", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Weeks", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Weeks", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Days", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Days", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cards", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cards", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
