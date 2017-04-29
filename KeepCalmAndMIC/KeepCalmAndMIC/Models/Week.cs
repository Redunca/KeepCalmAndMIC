﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepCalmAndMIC.Models
{
	public class Week : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

		public List<Day> DaysOfTheWeek { get; set; } = new List<Day>();

		public int InternshipId { get; set; }
		[ForeignKey("InternshipId")]
		public Internship Internship { get; set; }

		public Week()
        {
            for(int i = 0; i <= 4; i++)
            {
                DaysOfTheWeek.Add(new Day());
            }
            
        }

		public Stats GetWeekStats()
        {
            Stats stats = new Stats();

            foreach (Day day in DaysOfTheWeek)
            {
				Stats dailyStats = day.GetDailyStats();

                stats.Ambiance += dailyStats.Ambiance;
                stats.MutualAid += dailyStats.MutualAid;
                stats.Productivity += dailyStats.Productivity;
                stats.TechnicalSkills += dailyStats.TechnicalSkills;
            }

            return stats;
        }
    }
}