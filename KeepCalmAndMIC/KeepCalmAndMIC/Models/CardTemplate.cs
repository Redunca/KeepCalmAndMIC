using System.ComponentModel.DataAnnotations;

namespace KeepCalmAndMIC.Models
{
	public enum TypeCard
	{
		Event,
		Action
	}

	public class CardTemplate
	{
		public TypeCard CardType { get; set; }

		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public double EffectOnProduction { get; set; }
		public double EffectOnMutualAid { get; set; }
		public double EffectOnTechnicalSkills { get; set; }
		public double EffectOnAmbiance { get; set; }
		public double EffectOnProductivity { get; set; }
		public int TimeCostInHour { get; set; }

		public int EnergyCost { get; set; }
		
		public CardTemplate() { }

		public CardTemplate(TypeCard typeCard, string name, string description, double effectOnProductivity, double effectOnMutualAid,
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
}