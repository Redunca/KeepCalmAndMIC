namespace KeepCalmAndMIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "EffectOnProductivity", c => c.Double(nullable: false));
            AddColumn("dbo.Cards", "EnergyCost", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnProduction", c => c.Double(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnMutualAid", c => c.Double(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnTechnicalSkills", c => c.Double(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnAmbiance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "EffectOnAmbiance", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnTechnicalSkills", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnMutualAid", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "EffectOnProduction", c => c.Int(nullable: false));
            DropColumn("dbo.Cards", "EnergyCost");
            DropColumn("dbo.Cards", "EffectOnProductivity");
        }
    }
}
