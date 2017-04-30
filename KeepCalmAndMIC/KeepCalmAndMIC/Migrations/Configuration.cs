namespace KeepCalmAndMIC.Migrations
{
    using KeepCalmAndMIC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KeepCalmAndMIC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

			//Events
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Les étudiants néerlandais parlent mieux anglais que nous.", 0, 0.25, 0, -0.5, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Le maitre de stage joue à la switch sur le lieu de travail.", -0.25, 0, 0, 0.5, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Un personne insiste souvent pour faire des check, à en rendre mal à l'aise.", -0.1, 0, 0, -0.1, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Une visite du marché de Mons avec les maitre de stage où tout le monde fini saoul.", -0.75, 0, 0, 0.5, 4, 4, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Présentation de son projet personnel de manière improvisée.", -0.15, 0.25, 0.25, 0, 1, 1, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Découverte du stepmania.", -0.3, 0, 0, 0.2, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation de LAN.", 0, 0, 0, 0.5, 0, 2, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Un enfant est gardé par son parent dans l'établissement et dérange la quiétude des lieux.", -0.25, 0, 0, -0.25, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Présence d'agressivité orale entre certaines personnes.", 0, 0, 0, -0.25, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Incertitude des stagiaires", -0.3, 0, 0.1, 0, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Crise de nerf d'un stagiaire", -0.2, -0.5, 0, -0.5, 0, 1, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Absence de travail dût à une mauvaise répartition des parts.", -0.4, 0, 0, 0, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Présence d'experts technique", 0.5, 0, 0.5, 0, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation d'un co-lunching.", 0, 0.2, 0, 0.5, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Guerres à coups de NerfsGuns.", -0.5, 0, 0, 0.5, 1, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Les maitres de stages sont super disponibles.", 0.5, 0, 0.5, 0.2, 4, 4, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation de ses propres confèrences car la technologie est rare.", -0.5, 0.5, 0.8, 0, 2, 2, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation d'anniversaires.", -0.25, 0, 0, 0.6, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Connection à internet de mauvaise qualité", 0.6, 4, 0, -0.4, 2, 2, 0));
			//Actions
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Débugging", "", 0, 20, 20, -10, 4, 2, 10));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Sprint Review", "", 0, 0, 10, 0, 3, 2, 50));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Congé", "", 0, 0, 0, 0, 8, -10, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Aide technique d'un projet", "", 10, 0, 20, 0, 2, 4, 60));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation méthodologie", "", 20, 0, 30, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Structure Projet", "", 5, 0, 5, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Xamarin", "", 20, 0, 50, 0, 2, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation BotFramework", "", 20, 0, 50, 0, 2, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Outils", "", 5, 0, 50, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Séance de stress test", "", 1, 30, 0, 10, 3, 0, 5));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Déploiement en production", "", 5, 0, 15, -10, 3, 3, 30));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Présentations techniques", "", 0, 15, 40, 5, 4, 4, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Certifications", "", 10, 0, 50, 0, 3, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Lan-Party", "", 0, 5, 0, 20, 8, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Intervention d'un partenaire extérieur", "", 2, 0, 20, 0, 4, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "2valuation du stage", "", 0, 5, 0, 10, 4, 3, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Test d'utilisation en conditions réelles", "", 0, 0, 0, 0, 2, 1, 5));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Défense à blanc du mémoire", "", 0, 0, 10, 0, 8, 5, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Préparation aux entretiens d'embauches", "", 0, 0, 5, 0, 4, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Activité de fin de stage", "", 0, 0, 0, 10, 8, 4, 0));
		}
    }
}
