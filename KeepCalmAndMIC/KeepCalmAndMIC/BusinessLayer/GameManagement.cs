using KeepCalmAndMIC.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class GameManagement : BaseManagement<GameManagement>
    {
        public GameManagement (IOwinContext owinContext) : base(owinContext) { }
        
        public async Task UseActionCardOnADayAsync(int idGame, int cardId, int weekNumber, int dayNumberOfWeek)
        {
            Game game = await UnitOfWork.Games.GetById(idGame, true);
			int weekid = game.Internship.WeeksOfTheInternship.ElementAt(weekNumber).Id;
			Week week = await UnitOfWork.Weeks.GetById(weekid);
			Day day = week.DaysOfTheWeek.ElementAt(dayNumberOfWeek);

            Card card = null;

			Deck handDeck = null;
			foreach (Deck deck in game.Decks)
			{
				if (deck.DeckType.Equals(TypeDeck.Hand))
				{
					actionDeck = deck;
                    break;
				}
			}
            if (handDeck != null)
            {
                card = handDeck.CardList.First(c => c.Id == cardId);
				// ici : Remettre une carte dans la main

				await UnitOfWork.Days.SetActionOnADay(day.Id, card);
				
			}
            else
            {
				throw new Exception("On code avec le Q");
                // meeeeeerde !!!!
            }
            await UnitOfWork.SaveChangesAsync();
        }
        
        public async Task SetEventOnADay(int idGame, Card card, int weekNumber, int dayNumberOfWeek)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 3);

            if(number > 0)
            {
                Game game = await UnitOfWork.Games.GetById(idGame);
                Deck eventDeck = null;
				foreach (Deck deck in game.Decks)
				{
					if (deck.DeckType.Equals(TypeDeck.Action))
					{
						eventDeck = deck;
					}
				}
				if (eventDeck != null)
				{
                    for (int i = 0; i < number; i++)
                    {
                         game.Internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).LivingEvents.Add(await UnitOfWork.Decks.GetARandomCard(eventDeck.Id));
                    }
                }
                else
                {
					throw new Exception("On code avec le Q");
					// meeeeeerde !!!!
				}
                await UnitOfWork.SaveChangesAsync();
            }
        }

        public async Task<int> GetCurrentWeek(int id)
        {
            Game game = await UnitOfWork.Games.GetById(id);
            return game.Internship.CurrentWeek;
        }

        public async Task<int> GetCurrentDayOfTheWeek(int id)
        {
            Game game = await UnitOfWork.Games.GetById(id);
            return game.Internship.CurrentDayOfTheWeek;
        }

        public async Task<Stats> NexDayAsync(int id)
        {
            Game game = await UnitOfWork.Games.GetById(id);
            InternshipManagement internshipManagement = OwinContext.Get<InternshipManagement>();

			Deck handDeck = null;
			foreach (Deck deck in game.Decks)
			{
				if (deck.DeckType.Equals(TypeDeck.Action))
				{
					handDeck = deck;
				}
			}
			if (handDeck != null)
            {
				Deck actionDeck = null;
				foreach (Deck deck in game.Decks)
				{
					if (deck.DeckType.Equals(TypeDeck.Action))
					{
						actionDeck = deck;
					}
				}
				if (actionDeck != null)
                {
                    handDeck.CardList = await UnitOfWork.Decks.GetHandCard(actionDeck.Id, 8);
                }
                else
                {
					throw new Exception("On code avec le Q");
					// meeeeeerde !!!!
				}
            }
            else
            {
				throw new Exception("On code avec le Q");
				// meeeeeerde !!!!
			}
            await UnitOfWork.SaveChangesAsync();
            return await internshipManagement.NextDayAsync(game.Internship.Id);
        }

        public async Task StartGame(Game game)
        {
            Random rnd = new Random();

			Internship intern = new Internship(game.Id);
			intern = await (OwinContext.Get<InternshipManagement>()).AddInternship(intern);
			game.Internship = intern;
            
            Deck gameaction = new Deck();
			gameaction.DeckType = TypeDeck.Action;
            gameaction.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Action, 600);

            Deck gameevents = new Deck();
			gameevents.DeckType = TypeDeck.Event;
            gameevents.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Event, 75);

            Deck gamehand = new Deck();
			gamehand.DeckType = TypeDeck.Hand;

            int numberOfRows = gameaction.CardList.Count();
            for (int i = 0; i < 8; i++)
            {
				int position = rnd.Next(0, numberOfRows);
				Card card = gameaction.CardList.ElementAt(position);
				gameaction.CardList.RemoveAt(position);
				numberOfRows -= 1;
				gamehand.CardList.Add(card);
            }

			game.Decks = new System.Collections.Generic.List<Deck>();
            game.Decks.Add(gameaction);
            game.Decks.Add(gameevents);
            game.Decks.Add(gamehand);
            
            await UnitOfWork.SaveChangesAsync();
        }
    }
}