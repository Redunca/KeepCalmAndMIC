using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
    public class WeekRepository : BaseModelRepository<Week>
    {
        public WeekRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Week> GetById(int id, bool include)
		{
			return await Context.Weeks.Include("DaysOfTheWeek")
				.Where(w => w.Id == id).FirstOrDefaultAsync();
		}

    }
}