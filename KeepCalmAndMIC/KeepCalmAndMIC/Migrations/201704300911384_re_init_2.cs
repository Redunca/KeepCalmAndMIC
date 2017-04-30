namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class re_init_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Name = c.String(),
                        Description = c.String(),
                        EffectOnProduction = c.Double(nullable: false),
                        EffectOnMutualAid = c.Double(nullable: false),
                        EffectOnTechnicalSkills = c.Double(nullable: false),
                        EffectOnAmbiance = c.Double(nullable: false),
                        EffectOnProductivity = c.Double(nullable: false),
                        TimeCostInHour = c.Int(nullable: false),
                        EnergyCost = c.Int(nullable: false),
                        DayActionId = c.Int(),
                        DayEventId = c.Int(),
                        DeckId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.DayEventId)
                .ForeignKey("dbo.Days", t => t.DayActionId)
                .ForeignKey("dbo.Decks", t => t.DeckId)
                .Index(t => t.DayActionId)
                .Index(t => t.DayEventId)
                .Index(t => t.DeckId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        RemainingHours = c.Int(nullable: false),
                        WeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weeks", t => t.WeekId, cascadeDelete: true)
                .Index(t => t.WeekId);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        InternshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Internships", t => t.InternshipId, cascadeDelete: true)
                .Index(t => t.InternshipId);
            
            CreateTable(
                "dbo.Internships",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CurrentWeek = c.Int(nullable: false),
                        CurrentDayOfTheWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        PlayerId = c.String(maxLength: 128),
                        InProgress = c.Boolean(nullable: false),
                        FinalScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeckType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Decks", "GameId", "dbo.Games");
            DropForeignKey("dbo.Cards", "DeckId", "dbo.Decks");
            DropForeignKey("dbo.Weeks", "InternshipId", "dbo.Internships");
            DropForeignKey("dbo.Internships", "Id", "dbo.Games");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "PlayerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Days", "WeekId", "dbo.Weeks");
            DropForeignKey("dbo.Cards", "DayActionId", "dbo.Days");
            DropForeignKey("dbo.Cards", "DayEventId", "dbo.Days");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Decks", new[] { "GameId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Games", new[] { "PlayerId" });
            DropIndex("dbo.Internships", new[] { "Id" });
            DropIndex("dbo.Weeks", new[] { "InternshipId" });
            DropIndex("dbo.Days", new[] { "WeekId" });
            DropIndex("dbo.Cards", new[] { "DeckId" });
            DropIndex("dbo.Cards", new[] { "DayEventId" });
            DropIndex("dbo.Cards", new[] { "DayActionId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Decks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Games");
            DropTable("dbo.Internships");
            DropTable("dbo.Weeks");
            DropTable("dbo.Days");
            DropTable("dbo.Cards");
        }
    }
}
