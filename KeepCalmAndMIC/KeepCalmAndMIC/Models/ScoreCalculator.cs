using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public static class ScoreCalculator
    {
        private static List<Stats> _dayStats;
        public static List<Stats> DaysStats
        {
            get
            {
                if(_dayStats == null)
                {
                    _dayStats = new List<Stats>();
                }
                return _dayStats;
            }
        }
        public static int Energy { get; set; }
        public static Stats UpdateStatsForDay(List<Card> ActionCards, List<Card> EventCards, Stats morningStats)
        {
            Stats eveningStats = new Stats()
            {
                Ambiance = morningStats.Ambiance,
                MutualAid = morningStats.MutualAid,
                Productivity = morningStats.Productivity,
                TechnicalSkills = morningStats.TechnicalSkills
            };
            int NumberOfHoursRemaining = 8;
            foreach(Card actionCard in ActionCards)
            {
                if (actionCard.EffectOnAmbiance != 0)
                {

                }
                if(actionCard.EffectOnMutualAid != 0)
                {
                    
                }
                if(actionCard.EffectOnProduction != 0)
                {

                }
                if(actionCard.EffectOnProductivity != 0){

                }
                if(actionCard.EffectOnTechnicalSkills != 0)
                {

                }
                if(NumberOfHoursRemaining - actionCard.TimeCostInHour < 0)
                {
                    Energy -= actionCard.TimeCostInHour - NumberOfHoursRemaining;
                    NumberOfHoursRemaining = 0;
                }
                else
                {
                    NumberOfHoursRemaining -= actionCard.TimeCostInHour;
                }
                Energy -= actionCard.EnergyCost;
            }
            return eveningStats;
        }

    }
}