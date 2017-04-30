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
		public DateTime? CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }

		public List<Card> SelectedCards { get; set; } = new List<Card>();
		public List<Card> LivingEvents { get; set; } = new List<Card>();

		public int RemainingHours { get; set; }
        [NotMapped]
        public Stats DayStats { get; set; }
		public int WeekId { get; set; }
		[ForeignKey("WeekId")]
		public Week Week { get; set; }

		public Day()
        {
            RemainingHours = 8;
            DayStats = new Stats()
            {
                Ambiance = 0,
                MutualAid = 0,
                Production = 0,
                Productivity = 0,
                TechnicalSkills = 0
            };
        }
	}
}