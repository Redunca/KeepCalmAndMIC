using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Game : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

		public string PlayerId { get; set; }
		[ForeignKey("PlayerId")]
		public ApplicationUser Player { get; set; }

		public int InternshipId { get; set; }
		[ForeignKey("InternshipId")]
		public Internship Internship { get; }

		public Dictionary<TypeDeck, Deck> Decks { get; set; }
		
		public bool InProgress { get; set; }

		public Game()
		{
			Internship = new Internship(15);
			Decks = new Dictionary<TypeDeck, Deck>();

			Deck action = new Deck();
			// action.FeedDeckAction(600);
			Decks.Add(TypeDeck.Action, action);

			Deck events = new Deck();
			// events.FeedDeckEvent(75);
			Decks.Add(TypeDeck.Event, events);

			Deck hand = new Deck();
			// hand.CardList = action.GetHandCard(8);
			Decks.Add(TypeDeck.Hand, new Deck());
		}
        
	}
}