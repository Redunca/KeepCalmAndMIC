using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models.ViewModels
{
    public class StatsOfWeekAndDayViewModel
    {
        public Stats Global { get; set; }
        public Stats Weekly { get; set; }
        public Stats Daily { get; set; }
    }
}