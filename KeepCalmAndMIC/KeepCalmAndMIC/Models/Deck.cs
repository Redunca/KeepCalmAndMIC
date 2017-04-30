using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace KeepCalmAndMIC.Models
{
    public class Deck : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public List<Card> CardList { get; set; } = new List<Card>();

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public Deck() {

        }
        
    }

    

	public enum TypeDeck
	{
		Action, Event, Hand
	}
}