using KeepCalmAndMIC.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class DeckManagement : BaseManagement<DeckManagement>
    {
        public DeckManagement(IOwinContext owinContext) : base(owinContext) { }

        public void SeedDeckAction(int id, int numberOfCards)
        {
            

            //UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Action, numberOfCards);
            //Repository Card :> GetRandomCards(TypeCard typeCard, int numberOfCards) => Type action
        }

        public void SeedDeckEvent(int numberOfCards)
        {
            //UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Event, numberOfCards);
            //Repository Card :> GetRandomCards(TypeCard typeCard, int numberOfCards) => Type Event  
        }
    }
}