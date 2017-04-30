using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KeepCalmAndMIC.Models;
namespace KeepCalmAndMIC.Repository
{
	public class GameRepository : BaseModelRepository<Game>
	{
		public GameRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Game> GetById(int id, bool include)
		{
            return await Context.Games.Include(g => g.Internship).Include(g => g.Player).Include(g => g.Decks)
                .Include("Internship.WeeksOfTheInternship")
				.Where(g => g.Id == id).FirstOrDefaultAsync();
		}

		public async Task<List<int>> GetUserScoresSorted(string userId)
		{
			return await Context.Games.Where(g => g.PlayerId.Equals(userId))
			  .OrderByDescending(g => g.FinalScore).Select(g => g.FinalScore).ToListAsync();
		}

		public async Task<List<int>> GetTopGames(int nbGames)
		{
			return await Context.Games.OrderByDescending(g => g.FinalScore).Take(nbGames).Select(g => g.FinalScore).ToListAsync();
		}

	}
}