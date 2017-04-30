namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dev_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Internships", "GameId", "dbo.Games");
            DropForeignKey("dbo.Weeks", "InternshipId", "dbo.Internships");
            DropIndex("dbo.Internships", new[] { "GameId" });
            DropColumn("dbo.Internships", "Id");
            RenameColumn(table: "dbo.Internships", name: "GameId", newName: "Id");
            DropPrimaryKey("dbo.Internships");
            AlterColumn("dbo.Internships", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Internships", "Id");
            CreateIndex("dbo.Internships", "Id");
            AddForeignKey("dbo.Internships", "Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Weeks", "InternshipId", "dbo.Internships", "Id", cascadeDelete: true);
            DropColumn("dbo.Games", "InternshipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "InternshipId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Weeks", "InternshipId", "dbo.Internships");
            DropForeignKey("dbo.Internships", "Id", "dbo.Games");
            DropIndex("dbo.Internships", new[] { "Id" });
            DropPrimaryKey("dbo.Internships");
            AlterColumn("dbo.Internships", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Internships", "Id");
            RenameColumn(table: "dbo.Internships", name: "Id", newName: "GameId");
            AddColumn("dbo.Internships", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Internships", "GameId");
            AddForeignKey("dbo.Weeks", "InternshipId", "dbo.Internships", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Internships", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
