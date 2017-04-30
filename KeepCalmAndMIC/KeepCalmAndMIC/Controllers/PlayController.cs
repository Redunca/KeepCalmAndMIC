using KeepCalmAndMIC.Models;
using KeepCalmAndMIC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KeepCalmAndMIC.BusinessLayer;

namespace KeepCalmAndMIC.Controllers
{
    [Authorize]
    public class PlayController : BaseController
    {
        public static int GameId { get; set; }
        public static int LookingWeek { get; set; }
        public static int LookingDay { get; set; }
        /*
        private ApplicationDbContext _appdb;

        public PlayController(ApplicationDbContext appdb)
        {
            _appdb = appdb;
        }
        */
        // GET: Play
        public async Task<ActionResult> Index()
        {
            GameManagement gameManagement = new GameManagement(HttpContext.GetOwinContext());

            Game game = new Game();
            
            await gameManagement.StartGame(game);

            PlayViewModel playViewModel = new PlayViewModel();
            playViewModel.IdGame = game.Id;

            playViewModel.timeViewModel = new TimeViewModel();
            playViewModel.timeViewModel.SelectedWeek = 0;
            playViewModel.timeViewModel.SelectedDay = 0;

            playViewModel.statsOfWeekAndDayViewModel = new StatsOfWeekAndDayViewModel();

            playViewModel.statsOfWeekAndDayViewModel.Global = new Stats(); // ici : generate global stats
            playViewModel.statsOfWeekAndDayViewModel.Weekly = new Stats(); // ici : generate Weekly stats
            playViewModel.statsOfWeekAndDayViewModel.Daily = new Stats(); // ici : generate daily stats
            
            playViewModel.cardsViewModel = new CardsViewModel();
            Deck handDeck = new Deck();
            if (game.Decks.TryGetValue(TypeDeck.Hand, out handDeck))
            {
                playViewModel.cardsViewModel.Cards = handDeck.CardList;
            }
            else
            {
                // meeeeeerde !!!!
            }

            await UnitOfWork.SaveChangesAsync();

            GameId = game.Id; // ici : Check if it is the same id as in the db
            LookingWeek = 0;
            LookingDay = 0;
            
            return View("Index", playViewModel);
        }

        public async Task<ActionResult> SetActionCards(string cards)
        {
            GameManagement gameManagement = new GameManagement(HttpContext.GetOwinContext());

            string[] cardId = cards.Split('_');

            foreach (string id in cardId)
            {
                int idInt = Convert.ToInt32(id);
                await gameManagement.UseActionCardOnADayAsync(GameId, idInt, LookingWeek, LookingDay);
            }
            
            Stats dailyStats = await gameManagement.NexDayAsync(GameId);
            
            Game game = await UnitOfWork.Games.GetById(GameId);

            PlayViewModel playViewModel = new PlayViewModel();
            playViewModel.IdGame = game.Id;

            playViewModel.timeViewModel = new TimeViewModel();
            playViewModel.timeViewModel.SelectedWeek = game.Internship.CurrentWeek;
            playViewModel.timeViewModel.SelectedDay = game.Internship.CurrentDayOfTheWeek;

            playViewModel.statsOfWeekAndDayViewModel = new StatsOfWeekAndDayViewModel();

            playViewModel.statsOfWeekAndDayViewModel.Global = new Stats(); // ici : generate global stats
            playViewModel.statsOfWeekAndDayViewModel.Weekly = new Stats(); // ici : generate Weekly stats
            playViewModel.statsOfWeekAndDayViewModel.Daily = new Stats(); // ici : generate daily stats

            playViewModel.cardsViewModel = new CardsViewModel();
            Deck handDeck = new Deck();
            if (game.Decks.TryGetValue(TypeDeck.Hand, out handDeck))
            {
                playViewModel.cardsViewModel.Cards = handDeck.CardList;
            }
            else
            {
                // meeeeeerde !!!!
            }
            
            await UnitOfWork.SaveChangesAsync();

            return View("Index", playViewModel);
        }

        public ActionResult GetWeek(int weekNumber)
        {
            LookingWeek = weekNumber;

            StatsOfWeekAndDayViewModel statsOfWeekAndDayViewModel = new StatsOfWeekAndDayViewModel();

            /* générer les stats sur base de (LookingWeek, LookingDay) */
            statsOfWeekAndDayViewModel.Global = new Stats(); // ici : generate global stats
            statsOfWeekAndDayViewModel.Weekly = new Stats(); // ici : generate Weekly stats
            statsOfWeekAndDayViewModel.Daily = new Stats(); // ici : generate daily stats
            
            return PartialView("_StatsOfWeekAndDay", statsOfWeekAndDayViewModel);
        }

        public ActionResult GetDay(int dayNumber)
        {
            LookingDay = dayNumber;

            StatsOfWeekAndDayViewModel statsOfWeekAndDayViewModel = new StatsOfWeekAndDayViewModel();

            /* générer les stats sur base de (LookingWeek, LookingDay) */
            statsOfWeekAndDayViewModel.Global = new Stats(); // ici : generate global stats
            statsOfWeekAndDayViewModel.Weekly = new Stats(); // ici : generate Weekly stats
            statsOfWeekAndDayViewModel.Daily = new Stats(); // ici : generate daily stats

            return PartialView("_StatsOfWeekAndDay", statsOfWeekAndDayViewModel);

        }
    }
}