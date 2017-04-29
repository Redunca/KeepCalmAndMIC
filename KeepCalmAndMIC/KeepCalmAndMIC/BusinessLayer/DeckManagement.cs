using KeepCalmAndMIC.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class DeckManagement : BaseManagement<DeckManagement>
    {
        public DeckManagement(IOwinContext owinContext) : base(owinContext) { }
        
        public async Task SeedDeckAsync(int id, TypeCard typeCard, int numberOfCards)
        {
            Deck deck = await UnitOfWork.Decks.GetById(id);
            deck.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(typeCard, numberOfCards);

            await UnitOfWork.SaveChangesAsync();
        }
    }
}