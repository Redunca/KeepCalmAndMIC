using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Day : IBaseModel
    {
        public Day()
        {
            RemainningHours = 8;
        }
        
        public List<Card> SelectedCards { get; set; } = new List<Card>();
        public List<Card> LivingEvents { get; set; } = new List<Card>();
        public int RemainningHours { get; set; }
        public Stats DailyStats { get; set; } = new Stats();
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }


		public int AddSelectedCard(Card card)
        {
            if(RemainningHours - card.TimeCostInHour >= 0)
            {
                RemainningHours -= card.TimeCostInHour;
                SelectedCards.Add(card);

                return 0;
            }
            return 1;
        }

        public void AddEvents(Card card)
        {
            LivingEvents.Add(card);
        }

        public Stats GetDailyStats()
        {
            Stats stats = DailyStats;

            foreach (Card card in SelectedCards)
            {
                stats.Ambiance += card.EffectOnAmbiance;
                stats.MutualAid += card.EffectOnMutualAid;
                stats.Productivity += card.EffectOnProduction;
                stats.TechnicalSkills += card.EffectOnTechnicalSkills;
            }

            foreach (Card card in LivingEvents)
            {
                stats.Ambiance += card.EffectOnAmbiance;
                stats.MutualAid += card.EffectOnMutualAid;
                stats.Productivity += card.EffectOnProduction;
                stats.TechnicalSkills += card.EffectOnTechnicalSkills;
            }
            
            return stats;
        }
    }
}