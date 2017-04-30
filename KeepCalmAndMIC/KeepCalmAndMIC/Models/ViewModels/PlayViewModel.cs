using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models.ViewModels
{
    public class PlayViewModel
    {
        public TimeViewModel timeViewModel { get; set; }
        public StatsOfWeekAndDayViewModel statsOfWeekAndDayViewModel { get; set; }
        public CardsViewModel cardsViewModel { get; set; }

        public int IdGame { get; set; }
    }
}