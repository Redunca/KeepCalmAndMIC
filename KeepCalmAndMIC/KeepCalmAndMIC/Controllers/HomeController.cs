using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

		public async Task<ActionResult> Games()
		{
			ApplicationUser user = UnitOfWork.Users.GetByName(User.Identity.Name);
			List<int> userGames = await UnitOfWork.Games.GetUserScoresSorted(user.Id);
			List<int> topGames = await UnitOfWork.Games.GetTopGames(5);
			Dictionary<string, List<int>> scores = new Dictionary<string, List<int>>();
			scores.Add("userGames", userGames);
			scores.Add("topGames", topGames);

			return View(scores);
		}

		public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}