using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Game
    {
        public Game()
        {
            stage = new Stage(15);
            EventDeck.FeedDeckEvent(75);
            ActionDeck.FeedDeckAction(600);
            
            HandDeck.CardList = ActionDeck.GetHandCard(8);
        }

        public Stage stage { get; }
        public Deck EventDeck { get; set; }
        public Deck ActionDeck { get; set; }
        public Deck HandDeck { get; set; }

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

        public int GetCurrentWeek()
        {
            return stage.CurrentWeek;
        }

        public int GetCurrentDayOfTheWeek()
        {
            return stage.CurrentDayOfTheWeek;
        }

        public Stats NexDay()
        {
            return stage.NextDay();
        }
    }
}