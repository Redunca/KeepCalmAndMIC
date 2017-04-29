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

            
        }

        public Stage stage { get; }
        public Deck EventDeck { get; }
        public Deck ActionDeck { get; }

    }
}