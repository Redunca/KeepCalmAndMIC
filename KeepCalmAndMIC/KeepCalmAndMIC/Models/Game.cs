using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Game : IBaseModel
    {
        public Game()
        {
            stage = new Internship(15);
            EventDeck.FeedDeckEvent(75);
            ActionDeck.FeedDeckAction(600);
            
            HandDeck.CardList = ActionDeck.GetHandCard(8);
        }

        public Internship stage { get; }
        public Deck EventDeck { get; set; }
        public Deck ActionDeck { get; set; }
        public Deck HandDeck { get; set; }
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }


		public int UseActionCardOnADay(Card card, int weekNumber, int dayNumberOfWeek)
        {
            return stage.SetActionOnADay(card, weekNumber, dayNumberOfWeek);
        }
        
        public void SetEventOnADay()
        {
            // Random => Event?
            // if (Y) => Number of event ? 1, 2 or 3?
            // Assign the events 
        }
    }
}