﻿using KeepCalmAndMIC.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class WeekManagement : BaseManagement<WeekManagement>
    {
        public WeekManagement(IOwinContext owinContext) : base(owinContext) { }

		public async Task<Week> AddWeek()
		{
			Week week = new Week();
			for (int i = 0; i < 5; i++)
			{
				Day day = await UnitOfWork.Days.Add(new Day());
				week.DaysOfTheWeek.Add(day);
			}
			return await UnitOfWork.Weeks.Add(week);
		}

        public async Task<Stats> GetWeekStats(int id)
        {
            Week week = await UnitOfWork.Weeks.GetById(id);
            Stats stats = new Stats();

            foreach (Day day in week.DaysOfTheWeek)
            {
                Stats dailyStats = UnitOfWork.Days.GetDailyStats(day.Id);
                
                stats.Ambiance += dailyStats.Ambiance;
                stats.MutualAid += dailyStats.MutualAid;
                stats.Productivity += dailyStats.Productivity;
                stats.TechnicalSkills += dailyStats.TechnicalSkills;
            }

            return stats;
        }
    }
}