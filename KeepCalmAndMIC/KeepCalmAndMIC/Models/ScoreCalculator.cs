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
                if (_dayStats == null)
                {
                    _dayStats = new List<Stats>();
                }
                return _dayStats;
            }
        }
        public static int Energy { get; set; }
        public static double IncreaseOfTechnicSkills {get;set;}
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
                foreach(Card eventCard in EventCards)
                {
                    //Scoring Value
                    if (actionCard.EffectOnAmbiance != 0)
                    {
                        eveningStats.Ambiance = (morningStats.Ambiance * (1 + actionCard.EffectOnAmbiance)) * (1 + eventCard.EffectOnAmbiance) + morningStats.MutualAid;
                    }
                    if (actionCard.EffectOnMutualAid != 0)
                    {
                        eveningStats.Ambiance = (morningStats.MutualAid*(1+actionCard.EffectOnMutualAid)) * (1 + eventCard.EffectOnMutualAid);
                    }
                    //Scoring value
                    if (actionCard.EffectOnProduction != 0)
                    {
                        eveningStats.Production = (morningStats.Production * (1 + actionCard.EffectOnProduction)) * (1 + eventCard.EffectOnProduction)+morningStats.Productivity;
                    }
                    if (actionCard.EffectOnProductivity != 0)
                    {
                        eveningStats.Productivity = (morningStats.Productivity*(1+actionCard.EffectOnProductivity)) * (1+eventCard.EffectOnProductivity);
                    }
                    if (actionCard.EffectOnTechnicalSkills != 0)
                    {
                        eveningStats.TechnicalSkills = (morningStats.TechnicalSkills*(1+actionCard.EffectOnTechnicalSkills)) * (1+eventCard.EffectOnTechnicalSkills);
                        //scoring value
                        IncreaseOfTechnicSkills += eveningStats.TechnicalSkills - morningStats.TechnicalSkills;
                    }
                    if (NumberOfHoursRemaining - actionCard.TimeCostInHour < 0)
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
            }
            return eveningStats;
        }
    }
}