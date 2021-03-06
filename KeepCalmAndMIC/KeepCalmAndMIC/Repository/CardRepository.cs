﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
    public class CardRepository : BaseModelRepository<Card>
    {
        public CardRepository(ApplicationDbContext context) : base(context) { }

        public List<Card> GetRandomCards(TypeCard typeCard, int numberOfCards)
        {
            Random rnd = new Random();
            List<Card> randomCards = new List<Card>();
            List<Card> BddCard = Context.Cards.Where(c => c.CardType == typeCard).ToList();
            int numberOfRows = BddCard.Count();

            for (int i = 1; i <= numberOfCards; i++)
            {
                randomCards.Add(Context.Cards.ElementAt(rnd.Next(0, numberOfRows)));
            }

            return randomCards;
        }
    }
}