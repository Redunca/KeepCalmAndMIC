using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Card : IBaseModel
    {
        public Card(TypeCard typeCard, string name, string description, double effectOnProduction, double effectOnMutualAid, double effectOnTechnicalSkills, double effectOnAmbiance, int timeCost, double internSkillsImprovement, int energyCost, double effectOnProductivity)
        {
            CardType = typeCard;
            Name = name;
            Description = description;
            EffectOnProduction = effectOnProduction;
            EffectOnMutualAid = effectOnMutualAid;
            EffectOnTechnicalSkills = effectOnTechnicalSkills;
            EffectOnAmbiance = effectOnAmbiance;
            TimeCostInHour = timeCost;
            InternSkillsImprovement = internSkillsImprovement;
            EnergyCost = energyCost;
            EffectOnProductivity = effectOnProductivity;
        }

        public TypeCard CardType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double EffectOnProduction { get; set; }
        public double EffectOnMutualAid { get; set; }
        public double EffectOnTechnicalSkills { get; set; }
        public double EffectOnAmbiance { get; set; }
        public double EffectOnProductivity { get; set; }
        public int TimeCostInHour { get; set; }

        public double InternSkillsImprovement { get; set; }
        public int EnergyCost { get; set; }

        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

    }

    public enum TypeCard
    {
        Event,
        Action
    }
    
}