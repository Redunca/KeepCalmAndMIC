using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Internship : IBaseModel
    {
		[Key]
		public int Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }

        public List<Week> WeeksOfTheInternship { get; set; } = new List<Week>();
        public int CurrentWeek { get; set; }
        public int CurrentDayOfTheWeek { get; set; }

		public int GameId { get; set; }
		[ForeignKey("GameId")]
		public Game Game { get; set; }

		public Internship(int numberOfWeek)
		{
			for (int i = 1; i <= numberOfWeek; i++)
			{
				WeeksOfTheInternship.Add(new Week());
			}

			CurrentWeek = 0;
			CurrentDayOfTheWeek = 0;
		}
        
	}
}