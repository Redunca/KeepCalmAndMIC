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

		public Card() { }

		public Card(TypeCard typeCard, string name, string description, double effectOnProductivity, double effectOnMutualAid,
			double effectOnTechnicalSkills, double effectOnAmbiance, int timeCost, int energyCost, double effectOnProduction = 0)
		{
			CardType = typeCard;
			Name = name;
			Description = description;
			EffectOnProduction = effectOnProduction;
			EffectOnMutualAid = effectOnMutualAid;
			EffectOnTechnicalSkills = effectOnTechnicalSkills;
			EffectOnAmbiance = effectOnAmbiance;
			TimeCostInHour = timeCost;
			EnergyCost = energyCost;
			EffectOnProductivity = effectOnProductivity;
		}

	}

    public enum TypeCard
    {
        Event,
        Action
    }
    
}