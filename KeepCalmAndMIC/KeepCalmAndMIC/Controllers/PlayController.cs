using KeepCalmAndMIC.Models;
using KeepCalmAndMIC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepCalmAndMIC.Controllers
{
    [Authorize]
    public class PlayController : BaseController
    {
        public static int GameId { get; set; }
        public static int LookingWeek { get; set; }
        public static int LookingDay { get; set; }
        
        // GET: Play
        public ActionResult Index()
        {
            Game game = new Game();

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
            playViewModel.cardsViewModel.Cards.Add(new Card(TypeCard.Action, "Débugging", "", 0, 20, 20, -10, 4, 2, 10)); // ici : Get cards from Deck Hand


            GameId = game.Id;
            LookingWeek = 0;
            LookingDay = 0;

            return View("Index", playViewModel);
        }


        /*
        public ActionResult GetWeek(int weekNumber)
        {
            //return week
            var ratings = UnitOfWork.Ratings.FindAllByServiceId(idService);

            return PartialView("../Account/_UserComments", ratings);

        }

        public ActionResult GetDay(int weekNumber)
        {
            //return week
            var ratings = UnitOfWork.Ratings.FindAllByServiceId(idService);

            return PartialView("../Account/_UserComments", ratings);

        }


        /Play/GetWeek
        */



        /*

        public ActionResult SelectDayOfWeek(DayOfWeek? day)
        {
            Weeks = new List<WeekViewModel>();
            for (int i = 1; i <= 15; i++)
            {
                Weeks.Add(new WeekViewModel()
                {
                    WeekNumber = i,
                    IsPassed = (i < 6)
                });
            }
            ViewBag.ProgressViewModel = new ProgressViewModel();
            ViewBag.TimeViewModel = new TimeViewModel();
            ViewBag.CardsViewModel = CardsViewModel;
            if (ViewBag.TimeViewModel == null)
            {
                ViewBag.TimeViewModel = new TimeViewModel();
            }
            if (day.HasValue)
            {
                ViewBag.TimeViewModel.SelectedDay = day.Value;
                SelectedDay = day.Value;
                if (day.Value == DayOfWeek.Saturday)
                {
                    ViewBag.TimeViewModel.SelectedDay = DayOfWeek.Sunday;
                }
            }
            else
            {
                ViewBag.TimeViewModel.SelectedDay = DayOfWeek.Sunday;
            }
            return View("Index");
        }
        public ActionResult ToggleCardSelected(Card card)
        {
            var tempCard = CardsViewModel.Cards.Find(c => c.Id == card.Id);
            tempCard.IsSelected = !tempCard.IsSelected;
            return View("Index");
        }
        */

        /*
        */
    }
}