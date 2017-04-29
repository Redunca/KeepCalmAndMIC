using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models.ViewModels
{
    public class ProgressViewModel
    {
        public List<WeekViewModel> Weeks { get; set; }
        public ProgressViewModel()
        {
            Weeks = new List<WeekViewModel>();
            for(int i = 1; i <= 15; i++)
            {
                Weeks.Add(new WeekViewModel()
                {
                    WeekNumber = i,
                    IsPassed = (i<=5)
                });
            }
        }
    }
}