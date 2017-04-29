using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
			var user = UnitOfWork.Users.GetByName(User.Identity.Name);
			var userGames = await UnitOfWork.Games.SearchFor(g => g.PlayerId.Equals(user.Id));

			return View();
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