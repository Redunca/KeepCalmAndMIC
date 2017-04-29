using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models.ViewModels
{
    public class CardsViewModel
    {
        public List<Card> Cards { get; set; }
        public CardsViewModel()
        {
            Cards = new List<Card>();
            Cards.Add(new Card(TypeCard.Action, "Default Card", "This card does some things...Maybe", 0, 0, 0, 0, 0,0));

            Cards.Add(new Card(TypeCard.Action, "Other Card", "This card does some things...Maybe", 0, 0, 0, 0, 0,0));

            Cards.Add(new Card(TypeCard.Action, "Last Card", "This card does some things...Maybe", 0, 0, 0, 0, 0,0));
            
        }
    }
}