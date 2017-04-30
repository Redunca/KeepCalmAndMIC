namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod_momo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Decks", "DeckType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Decks", "DeckType");
        }
    }
}
