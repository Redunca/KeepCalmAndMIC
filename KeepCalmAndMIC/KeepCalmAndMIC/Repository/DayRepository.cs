using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;
using System.Threading.Tasks;

namespace KeepCalmAndMIC.Repository
{
    public class DayRepository : BaseModelRepository<Day>
    {
        public DayRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> AddSelectedCard(int id, Card card)
        {
            Day day = Context.Days.First(d => d.Id == id);
            
            if (day.RemainingHours - card.TimeCostInHour >= 0)
            {
                day.RemainingHours -= card.TimeCostInHour;
                day.SelectedCards.Add(card);

                await Context.SaveChangesAsync();

                return 0;
            }
            return 1;
        }

        public async Task AddEvents(int id, Card card)
        {
            Day day = Context.Days.First(d => d.Id == id);
            day.LivingEvents.Add(card);
            await Context.SaveChangesAsync();
        }

        public Stats GetDailyStats(int id)
        {
            Day day = Context.Days.First(d => d.Id == id);

            Stats stats = new Stats();

            foreach (Card card in day.SelectedCards)
            {
                stats.Ambiance += card.EffectOnAmbiance;
                stats.MutualAid += card.EffectOnMutualAid;
                stats.Productivity += card.EffectOnProduction;
                stats.TechnicalSkills += card.EffectOnTechnicalSkills;
            }

            foreach (Card card in day.LivingEvents)
            {
                stats.Ambiance += card.EffectOnAmbiance;
                stats.MutualAid += card.EffectOnMutualAid;
                stats.Productivity += card.EffectOnProduction;
                stats.TechnicalSkills += card.EffectOnTechnicalSkills;
            }

            return stats;
        }

        public async Task SetActionOnADay(int id, Card card)
        {
			Day day = Context.Days.FirstOrDefault(d => d.Id == id);
			day.SelectedCards.Add(card);

            await Context.SaveChangesAsync();
        }

        public async Task SetEventOnADay(int id, Card card)
        {
            Context.Days.First(d => d.Id == id).LivingEvents.Add(card);

            await Context.SaveChangesAsync();
        }
    }
}