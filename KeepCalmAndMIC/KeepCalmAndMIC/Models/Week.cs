using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Week : IBaseModel
    {
        public Week()
        {
            for(int i = 0; i <= 4; i++)
            {
                DaysOfTheWeek.Add(new Day());
            }
            
        }

        public List<Day> DaysOfTheWeek { get; set; } = new List<Day>();
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

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