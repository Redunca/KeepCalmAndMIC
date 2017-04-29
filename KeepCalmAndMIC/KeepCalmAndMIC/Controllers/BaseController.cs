using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeepCalmAndMIC.Repository;
using Microsoft.AspNet.Identity.Owin;

namespace KeepCalmAndMIC.Controllers
{
	public class BaseController : Controller
	{
		protected UnitOfWork UnitOfWork { get; private set; }
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			UnitOfWork = HttpContext.GetOwinContext().Get<UnitOfWork>();
		}
	}
}