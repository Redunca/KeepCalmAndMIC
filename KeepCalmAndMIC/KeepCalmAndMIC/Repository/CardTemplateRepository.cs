using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
	public class CardTemplateRepository : BaseModelRepository<CardTemplate>
	{
		public CardTemplateRepository(ApplicationDbContext context) : base(context) { }

	}
}