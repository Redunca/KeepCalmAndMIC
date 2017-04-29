using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;
using System.Threading.Tasks;

namespace KeepCalmAndMIC.Repository
{
    public class CardRepository : BaseModelRepository<Card>
    {
        public CardRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Card>> GetRandomCardsAsync(TypeCard typeCard, int numberOfCards)
        {
            Random rnd = new Random();
            List<Card> randomCards = new List<Card>();
            List<Card> BddCard = Context.Cards.Where(c => c.CardType == typeCard).ToList();
            int numberOfRows = BddCard.Count();

            for (int i = 1; i <= numberOfCards; i++)
            {
                randomCards.Add(Context.Cards.ElementAt(rnd.Next(0, numberOfRows)));
            }

            await Context.SaveChangesAsync();

            return randomCards;
        }

        public void seedEvents()
        {
            Context.Cards.Add(new Card(TypeCard.Event, "", "Les étudiants néerlandais parlent mieux anglais que nous.", 0, 0.25, 0, -0.5, 0, 0.15, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Le maitre de stage joue à la switch sur le lieu de travail.", -0.25, 0, 0, 0.5, 2, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Un personne insiste souvent pour faire des check, à en rendre mal à l'aise.", -0.1, 0, 0, -0.1, 0, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Une visite du marché de Mons avec les maitre de stage où tout le monde fini saoul.", -0.75, 0, 0, 0.5, 4, 0, 4, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Présentation de son projet personnel de manière improvisée.", -0.15, 0.25, 0.25, 0, 1, 0.2, 1, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Découverte du stepmania.", -0.3, 0, 0, 0.2, 2, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Organisation de LAN.", 0, 0, 0, 0.5, 0, 0, 2, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Un enfant est gardé par son parent dans l'établissement et dérange la quiétude des lieux.", -0.25, 0, 0, -0.25, 0, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Présence d'agressivité orale entre certaines personnes.", 0, 0, 0, -0.25, 0, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Incertitude des stagiaires", -0.3, 0, 0.1, 0, 2, 0.4, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Crise de nerf d'un stagiaire", -0.2, -0.5, 0, -0.5, 0, 0, 1, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Absence de travail dût à une mauvaise répartition des parts.", -0.4, 0, 0, 0, 1, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Présence d'experts technique", 0.5, 0, 0.5, 0, 0, 0.5, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Organisation d'un co-lunching.", 0, 0.2, 0, 0.5, 1, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Guerres à coups de NerfsGuns.", -0.5, 0, 0, 0.5, 1, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Les maitres de stages sont super disponibles.", 0.5, 0, 0.5, 0.2, 4, 0.5, 4, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Possibilité de faire des certifications.", -0.5, 0, 0.8, 0, 2, 0.8, 2, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Organisation de ses propres confèrences car la technologie est rare.", -0.5, 0.5, 0.8, 0, 2, 0.8, 2, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Organisation d'anniversaires.", -0.25, 0, 0, 0.6, 1, 0, 0, 0));
            Context.Cards.Add(new Card(TypeCard.Event, "", "Connection à internet de mauvaise qualité", 0.6, 4, 0, -0.4, 2, 0, 2, 0));
        }
    }
}