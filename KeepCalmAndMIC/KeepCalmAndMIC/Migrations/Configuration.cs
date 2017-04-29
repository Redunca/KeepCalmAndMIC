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

            context.Cards.Add(new Card(TypeCard.Event, "", "Les �tudiants n�erlandais parlent mieux anglais que nous.", 0, 0.25, 0, -0.5, 0, 0.15, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Le maitre de stage joue � la switch sur le lieu de travail.", -0.25, 0, 0, 0.5, 2, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Un personne insiste souvent pour faire des check, � en rendre mal � l'aise.", -0.1, 0, 0, -0.1, 0, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Une visite du march� de Mons avec les maitre de stage o� tout le monde fini saoul.", -0.75, 0, 0, 0.5, 4, 0, 4, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Pr�sentation de son projet personnel de mani�re improvis�e.", -0.15, 0.25, 0.25, 0, 1, 0.2, 1, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "D�couverte du stepmania.", -0.3, 0, 0, 0.2, 2, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Organisation de LAN.", 0, 0, 0, 0.5, 0, 0, 2, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Un enfant est gard� par son parent dans l'�tablissement et d�range la qui�tude des lieux.", -0.25, 0, 0, -0.25, 0, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Pr�sence d'agressivit� orale entre certaines personnes.", 0, 0, 0, -0.25, 0, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Incertitude des stagiaires", -0.3, 0, 0.1, 0, 2, 0.4, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Crise de nerf d'un stagiaire", -0.2, -0.5, 0, -0.5, 0, 0, 1, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Absence de travail d�t � une mauvaise r�partition des parts.", -0.4, 0, 0, 0, 1, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Pr�sence d'experts technique", 0.5, 0, 0.5, 0, 0, 0.5, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Organisation d'un co-lunching.", 0, 0.2, 0, 0.5, 1, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Guerres � coups de NerfsGuns.", -0.5, 0, 0, 0.5, 1, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Les maitres de stages sont super disponibles.", 0.5, 0, 0.5, 0.2, 4, 0.5, 4, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Possibilit� de faire des certifications.", -0.5, 0, 0.8, 0, 2, 0.8, 2, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Organisation de ses propres conf�rences car la technologie est rare.", -0.5, 0.5, 0.8, 0, 2, 0.8, 2, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Organisation d'anniversaires.", -0.25, 0, 0, 0.6, 1, 0, 0, 0));
            context.Cards.Add(new Card(TypeCard.Event, "", "Connection � internet de mauvaise qualit�", 0.6, 4, 0, -0.4, 2, 0, 2, 0));
        }
    }
}
