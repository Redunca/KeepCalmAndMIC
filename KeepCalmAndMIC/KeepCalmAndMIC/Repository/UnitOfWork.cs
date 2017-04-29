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
		private DayRepository _dayRepository;
		private DeckRepository _deckRepository;
		private GameRepository _gameRepository;
		private WeekRepository _weekRepository;
        private InternshipRepository _internshipRepository;
		private UserRepository _userRepository;

        private UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> factory, IOwinContext context)
		{
			return new UnitOfWork(context.Get<ApplicationDbContext>());
		}

		public CardRepository Cards => _cardRepository ?? (_cardRepository = new CardRepository(_context));
		public DayRepository Days => _dayRepository ?? (_dayRepository = new DayRepository(_context));
		public DeckRepository Decks => _deckRepository ?? (_deckRepository = new DeckRepository(_context));
		public GameRepository Games => _gameRepository ?? (_gameRepository = new GameRepository(_context));
		public WeekRepository Weeks => _weekRepository ?? (_weekRepository = new WeekRepository(_context));
        public InternshipRepository Internship => _internshipRepository ?? (_internshipRepository = new InternshipRepository(_context));
		public UserRepository Users => _userRepository ?? (_userRepository = new UserRepository(_context));


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