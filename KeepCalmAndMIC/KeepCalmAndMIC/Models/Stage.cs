using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Stage
    {
        public Stage (int numberOfWeek)
        {
            for(int i = 1; i <= numberOfWeek; i ++)
            {
                WeeksOfTheStage.Add(new Week());
            }

            CurrentWeek = 0;
            CurrentDayOfTheWeek = 0;
        }

        public List<Week> WeeksOfTheStage { get; set; } = new List<Week>();
        public int CurrentWeek { get; set; }
        public int CurrentDayOfTheWeek { get; set; }

        public int SetActionOnADay(Card card, int weekNumber, int dayNumberOfWeek)
        {
            if(WeeksOfTheStage.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).RemainningHours - card.TimeCostInHour >= 0)
            {
                WeeksOfTheStage.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);

                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void SetEventOnADay(Card card, int weekNumber, int dayNumberOfWeek)
        {
            WeeksOfTheStage.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);
        }

        public Stats GetStageStats()
        {
            Stats stats = new Stats();

            foreach (Week week in WeeksOfTheStage)
            {
                Stats tmpStats = week.GetWeekStats();

                stats.Ambiance += tmpStats.Ambiance;
                stats.MutualAid += tmpStats.MutualAid;
                stats.Productivity += tmpStats.Productivity;
                stats.TechnicalSkills += tmpStats.TechnicalSkills;
            }

            return stats;
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