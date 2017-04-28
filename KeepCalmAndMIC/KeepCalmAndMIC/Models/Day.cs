using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Day
    {
        public Day()
        {

        }

        private int DailyProductivity = 0;
        private int DailyMutualAid = 0;
        private int TechnicalAptitudes = 0;
        private List<Card> SelectedCards = new List<Card>();
        private List<Event> LivingEvents = new List<Event>();
        private Stats DailyStats = new Stats();
    }
}