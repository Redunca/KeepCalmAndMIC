using KeepCalmAndMIC.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
            
            return await internshipManagement.NextDayAsync(game.InternshipId);
        }

        public async Task StartGame(int id)
        {
            Game game = await UnitOfWork.Games.GetById(id);
            InternshipManagement internshipManagement = OwinContext.Get<InternshipManagement>();

            game.Internship.CurrentWeek = 0;
            game.Internship.CurrentDayOfTheWeek = 0;
        }
    }
}