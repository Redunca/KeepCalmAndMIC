using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Deck : IBaseModel
    {
        public List<Card> CardList { get; set; } = new List<Card>();
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }


		public List<Card> GetHandCard(int numberOfCards)
        {
            Random rnd = new Random();
            List<Card> handCards = new List<Card>();
            int positionOfTheCard;
            
            for (int i = 1; i <= numberOfCards; i++)
            {
                positionOfTheCard = rnd.Next(0, CardList.Count());
                handCards.Add(CardList.ElementAt(positionOfTheCard));
                CardList.RemoveAt(positionOfTheCard);
            }

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
            Random rnd = new Random();
            int positionOfTheCard = rnd.Next(0, CardList.Count());
            Card card = CardList.ElementAt(positionOfTheCard);

            CardList.RemoveAt(positionOfTheCard);

            return card;
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