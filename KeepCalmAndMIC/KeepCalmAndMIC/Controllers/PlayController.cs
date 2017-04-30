﻿using KeepCalmAndMIC.Models;
using KeepCalmAndMIC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepCalmAndMIC.Controllers
{
    [Authorize]
    public class PlayController : Controller
    {
        public static List<WeekViewModel> Weeks { get; set; }
        public static CardsViewModel CardsViewModel { get; set; }
        public static DayOfWeek SelectedDay { get; set; }
        public static int UsedHoursForToday { get; set; }
        public PlayController()
        {
            CardsViewModel = new CardsViewModel();
        }
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
            ViewBag.CardsViewModel = CardsViewModel;
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
        public ActionResult SelectWeek(WeekViewModel week)
        {
            //Here we have to manage that
            ViewBag.TimeViewModel = new TimeViewModel();
            ViewBag.TimeViewModel.SelectedDay = SelectedDay;
            ViewBag.CardsViewModel = CardsViewModel;
            return View("Index");
        }
    }
}