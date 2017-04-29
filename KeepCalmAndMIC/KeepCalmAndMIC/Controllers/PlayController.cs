using KeepCalmAndMIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepCalmAndMIC.Controllers
{
    public class PlayController : Controller
    {
        public DayOfWeek SelectedDay { get; set; }
        // GET: Play
        public ActionResult Index()
        {
            SelectedDay = DayOfWeek.Sunday;
            List<WeekViewModel> weeks = new List<WeekViewModel>();
            for(int i = 1; i <= 15; i++)
            {
                weeks.Add(new WeekViewModel()
                {
                    WeekNumber = i,
                    IsPassed = (i < 6)
                });
            }
            return View();
        }
        [HttpPut]
        public void SelectDayOfWeek(DayOfWeek day)
        {
            if(day == DayOfWeek.Saturday)
            {
                day = DayOfWeek.Sunday;
            }
            SelectedDay = day;
        }
    }
}