namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "DeckId", "dbo.Decks");
            DropIndex("dbo.Cards", new[] { "DeckId" });
            AlterColumn("dbo.Cards", "DeckId", c => c.Int());
            CreateIndex("dbo.Cards", "DeckId");
            AddForeignKey("dbo.Cards", "DeckId", "dbo.Decks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "DeckId", "dbo.Decks");
            DropIndex("dbo.Cards", new[] { "DeckId" });
            AlterColumn("dbo.Cards", "DeckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "DeckId");
            AddForeignKey("dbo.Cards", "DeckId", "dbo.Decks", "Id", cascadeDelete: true);
        }
    }
}
