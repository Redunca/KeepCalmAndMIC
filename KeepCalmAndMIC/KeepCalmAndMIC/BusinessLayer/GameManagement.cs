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
            Game game = await UnitOfWork.Games.GetById(idGame);
            Day day = game.Internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek);

            Card card = null;

            Deck actionDeck = new Deck();

            if (game.Decks.TryGetValue(TypeDeck.Action, out actionDeck))
            {
                card = actionDeck.CardList.First(c => c.Id == cardId);
                // ici : Remettre une carte dans la main
            }
            else
            {
                // meeeeeerde !!!!
            }

            await UnitOfWork.Days.SetActionOnADay(day.Id, card);
            await UnitOfWork.SaveChangesAsync();
        }
        
        public async Task SetEventOnADay(int idGame, Card card, int weekNumber, int dayNumberOfWeek)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 3);

            if(number > 0)
            {
                Game game = await UnitOfWork.Games.GetById(idGame);
                Deck eventDeck = new Deck();

                if(game.Decks.TryGetValue(TypeDeck.Event, out eventDeck))
                {
                    for (int i = 0; i < number; i++)
                    {
                         game.Internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).LivingEvents.Add(await UnitOfWork.Decks.GetARandomCard(eventDeck.Id));
                    }
                }
                else
                {
                    // meeeeeerde !!!!
                }
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

            Deck handDeck = new Deck();
            Deck actionDeck = new Deck();

            if (game.Decks.TryGetValue(TypeDeck.Hand, out handDeck))
            {
                if (game.Decks.TryGetValue(TypeDeck.Action, out actionDeck))
                {
                    handDeck.CardList = await UnitOfWork.Decks.GetHandCard(actionDeck.Id, 8);
                }
                else
                {
                    // meeeeeerde !!!!
                }
            }
            else
            {
                // meeeeeerde !!!!
            }
            
            return await internshipManagement.NextDayAsync(game.Internship.Id);
        }

        public async Task StartGame(Game game)
        {
            Random rnd = new Random();										  
            
            game.Internship.CurrentWeek = 0;
            game.Internship.CurrentDayOfTheWeek = 0;
            
            Deck gameaction = new Deck();
            gameaction.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Action, 600);

            Deck gameevents = new Deck();
            gameevents.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Event, 75);

            Deck gamehand = new Deck();

            int numberOfRows = gameaction.CardList.Count();
            for (int i = 0; i < 8; i++)
            {
				int position = rnd.Next(0, numberOfRows);
				Card card = gameaction.CardList.ElementAt(position);
				gameaction.CardList.RemoveAt(position);
				numberOfRows -= 1;
				gamehand.CardList.Add(card);
            }

            game.Decks.Add(TypeDeck.Action, gameaction);
            game.Decks.Add(TypeDeck.Event, gameevents);
            game.Decks.Add(TypeDeck.Hand, gamehand);
            
            await UnitOfWork.SaveChangesAsync();
        }
    }
}