using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Internship : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

        public List<Week> WeeksOfTheInternship { get; set; } = new List<Week>();
        public int CurrentWeek { get; set; }
        public int CurrentDayOfTheWeek { get; set; }

		public int GameId { get; set; }
		[ForeignKey("GameId")]
		public Game Game { get; set; }

		public Internship(int numberOfWeek)
		{
			for (int i = 1; i <= numberOfWeek; i++)
			{
				WeeksOfTheInternship.Add(new Week());
			}

			CurrentWeek = 0;
			CurrentDayOfTheWeek = 0;
		}

		public int SetActionOnADay(Card card, int weekNumber, int dayNumberOfWeek)
        {
            if(WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).RemainingHours - card.TimeCostInHour >= 0)
            {
                WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);

                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void SetEventOnADay(Card card, int weekNumber, int dayNumberOfWeek)
        {
            WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);
        }

        public Stats GetStageStats()
        {
            Stats stats = new Stats();

            foreach (Week week in WeeksOfTheInternship)
            {
                Stats tmpStats = week.GetWeekStats();

                stats.Ambiance += tmpStats.Ambiance;
                stats.MutualAid += tmpStats.MutualAid;
                stats.Productivity += tmpStats.Productivity;
                stats.TechnicalSkills += tmpStats.TechnicalSkills;
            }

            return stats;
        }

        public Stats GetStatsOfAWeek(int week)
        {
            return WeeksOfTheInternship.ElementAt(week).GetWeekStats();
        }

        public Stats NextDay()
        {
            if(CurrentDayOfTheWeek + 1 <= 4)
            {
                CurrentDayOfTheWeek += 1;
            }
            else
            {
                CurrentDayOfTheWeek = 0;
                CurrentWeek += 1;
            }

            return GetStageStats();
        }
    
	}
}