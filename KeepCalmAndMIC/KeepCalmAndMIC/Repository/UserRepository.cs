using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
	public class UserRepository : BaseModelRepository<ApplicationUser>
	{
		public UserRepository(ApplicationDbContext context) : base(context) { }

		public ApplicationUser GetByName(string name)
		{
			return Context.Users.Where(u => u.UserName.Equals(name)).FirstOrDefault();
		}

	}
}