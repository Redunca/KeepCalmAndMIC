using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepCalmAndMIC.Models
{
	public class Day : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

		public List<Card> SelectedCards { get; set; } = new List<Card>();
		public List<Card> LivingEvents { get; set; } = new List<Card>();

		public int RemainingHours { get; set; }

		public int WeekId { get; set; }
		[ForeignKey("WeekId")]
		public Week Week { get; set; }

		public Day()
        {
            RemainingHours = 8;
        }
        
		public int AddSelectedCard(Card card)
        {
            if(RemainingHours - card.TimeCostInHour >= 0)
            {
                RemainingHours -= card.TimeCostInHour;
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
            Stats stats = new Stats();

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