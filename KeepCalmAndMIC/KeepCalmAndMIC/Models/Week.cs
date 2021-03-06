﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Week
    {
        public Week()
        {
            for(int i = 0; i <= 4; i++)
            {
                DaysOfTheWeek.Add(new Day());
            }
            
        }

        public List<Day> DaysOfTheWeek { get; set; } = new List<Day>();

        public Stats GetWeekStats()
        {
            Stats stats = new Stats();

            foreach (Day day in DaysOfTheWeek)
            {
                stats.Ambiance += day.DailyStats.Ambiance;
                stats.MutualAid += day.DailyStats.MutualAid;
                stats.Productivity += day.DailyStats.Productivity;
                stats.TechnicalSkills += day.DailyStats.TechnicalSkills;
            }

            return stats;
        }
    }
}