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
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Les �tudiants n�erlandais parlent mieux anglais que nous.", 0, 0.25, 0, -0.5, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Le maitre de stage joue � la switch sur le lieu de travail.", -0.25, 0, 0, 0.5, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Un personne insiste souvent pour faire des check, � en rendre mal � l'aise.", -0.1, 0, 0, -0.1, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Une visite du march� de Mons avec les maitre de stage o� tout le monde fini saoul.", -0.75, 0, 0, 0.5, 4, 4, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Pr�sentation de son projet personnel de mani�re improvis�e.", -0.15, 0.25, 0.25, 0, 1, 1, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "D�couverte du stepmania.", -0.3, 0, 0, 0.2, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation de LAN.", 0, 0, 0, 0.5, 0, 2, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Un enfant est gard� par son parent dans l'�tablissement et d�range la qui�tude des lieux.", -0.25, 0, 0, -0.25, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Pr�sence d'agressivit� orale entre certaines personnes.", 0, 0, 0, -0.25, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Incertitude des stagiaires", -0.3, 0, 0.1, 0, 2, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Crise de nerf d'un stagiaire", -0.2, -0.5, 0, -0.5, 0, 1, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Absence de travail d�t � une mauvaise r�partition des parts.", -0.4, 0, 0, 0, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Pr�sence d'experts technique", 0.5, 0, 0.5, 0, 0, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation d'un co-lunching.", 0, 0.2, 0, 0.5, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Guerres � coups de NerfsGuns.", -0.5, 0, 0, 0.5, 1, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Les maitres de stages sont super disponibles.", 0.5, 0, 0.5, 0.2, 4, 4, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation de ses propres conf�rences car la technologie est rare.", -0.5, 0.5, 0.8, 0, 2, 2, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Organisation d'anniversaires.", -0.25, 0, 0, 0.6, 1, 0, 0));
            context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Event, "", "Connection � internet de mauvaise qualit�", 0.6, 4, 0, -0.4, 2, 2, 0));
			//Actions
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "D�bugging", "", 0, 20, 20, -10, 4, 2, 10));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Sprint Review", "", 0, 0, 10, 0, 3, 2, 50));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Cong�", "", 0, 0, 0, 0, 8, -10, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Aide technique d'un projet", "", 10, 0, 20, 0, 2, 4, 60));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation m�thodologie", "", 20, 0, 30, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Structure Projet", "", 5, 0, 5, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Xamarin", "", 20, 0, 50, 0, 2, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation BotFramework", "", 20, 0, 50, 0, 2, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Formation Outils", "", 5, 0, 50, 0, 2, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "S�ance de stress test", "", 1, 30, 0, 10, 3, 0, 5));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "D�ploiement en production", "", 5, 0, 15, -10, 3, 3, 30));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Pr�sentations techniques", "", 0, 15, 40, 5, 4, 4, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Certifications", "", 10, 0, 50, 0, 3, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Lan-Party", "", 0, 5, 0, 20, 8, 2, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Intervention d'un partenaire ext�rieur", "", 2, 0, 20, 0, 4, 1, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "2valuation du stage", "", 0, 5, 0, 10, 4, 3, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Test d'utilisation en conditions r�elles", "", 0, 0, 0, 0, 2, 1, 5));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "D�fense � blanc du m�moire", "", 0, 0, 10, 0, 8, 5, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Pr�paration aux entretiens d'embauches", "", 0, 0, 5, 0, 4, 0, 0));
			context.CardTemplates.AddOrUpdate(new CardTemplate(TypeCard.Action, "Activit� de fin de stage", "", 0, 0, 0, 10, 8, 4, 0));
		}
    }
}
