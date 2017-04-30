using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Hooks.Fluent;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace KeepCalmAndMIC.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

		public static ApplicationDbContext Create()
		{
			var context = new ApplicationDbContext();

			context.CreateHook().OnSave<IBaseModel>().When(r => r.Id > 0)
				.Do(r => r.CreatedOn = r.ModifiedOn = DateTime.Now);

			context.CreateHook().OnSave<IBaseModel>().When(r => r.Id > 0)
				.Do(r => r.ModifiedOn = DateTime.Now);

			return context;
		}
														   
		public DbSet<Card> Cards { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Deck> Decks { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Internship> Interships { get; set; }
		public DbSet<Week> Weeks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Day>().HasMany<Card>(d => d.SelectedCards).WithOptional(c => c.DayAction);
			modelBuilder.Entity<Day>().HasMany<Card>(d => d.LivingEvents).WithOptional(c => c.DayEvent);
			//modelBuilder.Entity<Game>().HasOptional<Internship>(g => g.Internship).WithOptionalPrincipal(i => i.Game);							   
		}

	}
}