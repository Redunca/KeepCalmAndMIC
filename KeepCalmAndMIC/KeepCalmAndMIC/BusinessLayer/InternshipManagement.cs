using KeepCalmAndMIC.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class InternshipManagement : BaseManagement<InternshipManagement>
    {
        public InternshipManagement(IOwinContext owinContext) : base(owinContext) { }

        public async Task<Stats> GetStageStatsAsync(int id)
        {
            Internship internship = await UnitOfWork.Internship.GetById(id);
            WeekManagement weekManagement = OwinContext.Get<WeekManagement>();

            Stats stats = new Stats();

            foreach (Week week in internship.WeeksOfTheInternship)
            {
                Stats tmpStats = await weekManagement.GetWeekStats(week.Id);

                stats.Ambiance += tmpStats.Ambiance;
                stats.MutualAid += tmpStats.MutualAid;
                stats.Productivity += tmpStats.Productivity;
                stats.TechnicalSkills += tmpStats.TechnicalSkills;
            }

            return stats;
        }

        public async Task<Stats> GetStatsOfAWeekAsync(int id)
        {
            WeekManagement weekManagement = OwinContext.Get<WeekManagement>();

            return await weekManagement.GetWeekStats(id);
        }

        public async Task<Stats> NextDayAsync(int id)
        {
            Internship internship = await UnitOfWork.Internship.GetById(id);
            InternshipManagement internshipManagement = OwinContext.Get<InternshipManagement>();

            if (internship.CurrentDayOfTheWeek + 1 <= 4)
            {
                internship.CurrentDayOfTheWeek += 1;
            }
            else
            {
                internship.CurrentDayOfTheWeek = 0;
                internship.CurrentWeek += 1;
            }
            
            return await internshipManagement.GetStageStatsAsync(id);
        }
    }
}