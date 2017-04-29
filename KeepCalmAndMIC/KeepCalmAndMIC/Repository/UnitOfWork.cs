using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KeepCalmAndMIC.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace KeepCalmAndMIC.Repository
{
	public class UnitOfWork : IDisposable
	{
		private readonly ApplicationDbContext _context;
		private CardRepository _cardRepository;

		private UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> factory, IOwinContext context)
		{
			return new UnitOfWork(context.Get<ApplicationDbContext>());
		}

		public CardRepository Cards => _cardRepository ?? (_cardRepository = new CardRepository(_context));

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}