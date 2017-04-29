using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepCalmAndMIC.Models
{
	public class Day : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

		public List<Card> SelectedCards { get; set; } = new List<Card>();
		public List<Card> LivingEvents { get; set; } = new List<Card>();

		public int RemainingHours { get; set; }

		public int WeekId { get; set; }
		[ForeignKey("WeekId")]
		public Week Week { get; set; }

		public Day()
        {
            RemainingHours = 8;
        }
	}
}