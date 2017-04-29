using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;
using System.Threading.Tasks;

namespace KeepCalmAndMIC.Repository
{
    public class InternshipRepository : BaseModelRepository<Internship>
    {
        public InternshipRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> SetActionOnADay(int id, Card card, int weekNumber, int dayNumberOfWeek)
        {
            Internship internship = Context.Interships.First(i => i.Id == id);

            if (internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).RemainingHours - card.TimeCostInHour >= 0)
            {
                internship.WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);
                await Context.SaveChangesAsync();

                return 0;
            }
            else
            {
                return 1;
            }
        }

        public async Task SetEventOnADay(int id, Card card, int weekNumber, int dayNumberOfWeek)
        {
            Context.Interships.First(i => i.Id == id).WeeksOfTheInternship.ElementAt(weekNumber).DaysOfTheWeek.ElementAt(dayNumberOfWeek).SelectedCards.Add(card);
            await Context.SaveChangesAsync();
        }
    }
}