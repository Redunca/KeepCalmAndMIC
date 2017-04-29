using KeepCalmAndMIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepCalmAndMIC.Repository
{
    public class DeckRepository : BaseModelRepository<Deck>
    {
        public DeckRepository(ApplicationDbContext context) : base(context) { }
        
        public async Task ReturnUnusedCards(int id, List<Card> unusedCards)
        {
            foreach (Card card in unusedCards)
            {
                Context.Decks.First(d => d.Id == id).CardList.Add(card);
            }

            await Context.SaveChangesAsync();
        }

        public async Task<Card> GetARandomCard(int id)
        {
            Random rnd = new Random();
            Deck deck = Context.Decks.First(d => d.Id == id);
            int numberOfCards = deck.CardList.Count();

            int positionOfTheCard = rnd.Next(0, numberOfCards);
            
            Card card = deck.CardList.ElementAt(positionOfTheCard);

            Context.Decks.First(d => d.Id == id).CardList.RemoveAt(positionOfTheCard);

            await Context.SaveChangesAsync();

            return card;
        }

        public async Task<List<Card>> GetHandCard(int id, int numberOfCards)
        {
            Random rnd = new Random();
            List<Card> handCards = new List<Card>();

            Deck deck = Context.Decks.First(d => d.Id == id);
            int numberOfCardsInDeck = deck.CardList.Count();

            int positionOfTheCard;

            for (int i = 1; i <= numberOfCards; i++)
            {
                positionOfTheCard = rnd.Next(0, deck.CardList.Count());
                handCards.Add(deck.CardList.ElementAt(positionOfTheCard));

                deck.CardList.RemoveAt(positionOfTheCard);
                Context.Decks.First(d => d.Id == id).CardList.RemoveAt(positionOfTheCard);
            }

            await Context.SaveChangesAsync();

            return handCards;
        }
    }
}