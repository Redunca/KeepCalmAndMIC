using KeepCalmAndMIC.Models;
using KeepCalmAndMIC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepCalmAndMIC.Controllers
{
    public class PlayController : Controller
    {
        public List<WeekViewModel> Weeks { get; set; }
        public static DayOfWeek SelectedDay { get; set; }
        // GET: Play
        public ActionResult Index()
        {
            Weeks = new List<WeekViewModel>();
            for(int i = 1; i <= 15; i++)
            {
                Weeks.Add(new WeekViewModel()
                {
                    WeekNumber = i,
                    IsPassed = (i < 6)
                });
            }
            ViewBag.ProgressViewModel = new ProgressViewModel();
            ViewBag.TimeViewModel = new TimeViewModel();
            ViewBag.CardsViewModel = new CardsViewModel();
            ViewBag.TimeViewModel.SelectedDay = SelectedDay;
            return View();
        }
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
            ViewBag.CardsViewModel = new CardsViewModel();
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
    }
}