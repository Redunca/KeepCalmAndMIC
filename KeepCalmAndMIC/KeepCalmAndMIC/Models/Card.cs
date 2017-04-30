using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepCalmAndMIC.Models
{
	public class Card : IBaseModel
    {
        public TypeCard CardType { get; set; }

		[Key]
		public int Id { get; set; }

		public DateTime? CreatedOn { get; set; }

		public DateTime? ModifiedOn { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double EffectOnProduction { get; set; }
        public double EffectOnMutualAid { get; set; }
        public double EffectOnTechnicalSkills { get; set; }
        public double EffectOnAmbiance { get; set; }
        public double EffectOnProductivity { get; set; }
        public int TimeCostInHour { get; set; }
        												  
        public int EnergyCost { get; set; }
        
		public int? DayActionId { get; set; }
		[ForeignKey("DayActionId")]
		public Day DayAction { get; set; }
		public int? DayEventId { get; set; }
		[ForeignKey("DayEventId")]
		public Day DayEvent { get; set; }

		public int? DeckId { get; set; }
		[ForeignKey("DeckId")]
		public Deck Deck { get; set; }

		[NotMapped]
        public bool IsSelected { get; set; }

		public Card() { }

		public Card(CardTemplate fromTemplate)
		{
			this.Name = fromTemplate.Name;
			this.Description = fromTemplate.Description;
			this.TimeCostInHour = fromTemplate.TimeCostInHour;
			this.EnergyCost = fromTemplate.EnergyCost;
			this.EffectOnAmbiance = fromTemplate.EffectOnAmbiance;
			this.EffectOnMutualAid = fromTemplate.EffectOnMutualAid;
			this.EffectOnProduction = fromTemplate.EffectOnProduction;
			this.EffectOnProductivity = fromTemplate.EffectOnProductivity;
			this.EffectOnTechnicalSkills = fromTemplate.EffectOnTechnicalSkills;
		}

	}
    
}