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

        public async Task UseActionCardOnADayAsync(int idGame, Card card, int weekNumber, int dayNumberOfWeek)
        {
            Game game = await UnitOfWork.Games.GetById(idGame);
            Day day = game.Internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek);

            await UnitOfWork.Days.SetActionOnADay(day.Id, card);
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
            
            return await internshipManagement.NextDayAsync(game.InternshipId);
        }

        public async Task StartGame(int id)
        {
            Game game = await UnitOfWork.Games.GetById(id);
            GameManagement gameManagement = OwinContext.Get<GameManagement>();

            Deck eventDeck = new Deck();
            Deck actionDeck = new Deck();
            Deck handDeck = new Deck();

            game.Internship.CurrentWeek = 0;
            game.Internship.CurrentDayOfTheWeek = 0;

            if (game.Decks.TryGetValue(TypeDeck.Action, out actionDeck))
            {
                actionDeck.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Action, 600);
            }
            else
            {
                // meeeeeerde !!!!
            }

            if (game.Decks.TryGetValue(TypeDeck.Event, out eventDeck))
            {
                eventDeck.CardList = await UnitOfWork.Cards.GetRandomCardsAsync(TypeCard.Event, 75);
            }
            else
            {
                // meeeeeerde !!!!
            }

            await UnitOfWork.SaveChangesAsync();
            await NexDayAsync(game.Id);
        }
    }
}