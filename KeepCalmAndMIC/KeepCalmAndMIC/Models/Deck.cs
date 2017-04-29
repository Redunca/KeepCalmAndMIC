using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Deck
    {
        public List<Card> CardList { get; } = new List<Card>();
       
        public List<Card> GetHandCard(int numberOfCards)
        {
            List<Card> handCards = new List<Card>();
            // Select x cards from CardList (and remove) and return these cards

            return handCards;
        } 

        public void ReturnUnusedCards(List<Card> unusedCards)
        {
            foreach(Card card in unusedCards)
            {
                CardList.Add(card);
            }
        }

        public Card GetARandomCard()
        {
            // Return a random Card From the card list (For events)
        }

        public void FeedDeckAction(int numberOfCards)
        {
            //Repository Card :> GetRandomCards(TypeCard typeCard, int numberOfCards) => Type action
        }

        public void FeedDeckEvent(int numberOfCards)
        {
            //Repository Card :> GetRandomCards(TypeCard typeCard, int numberOfCards) => Type Event  
        }
    }
}