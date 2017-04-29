using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Card : IBaseModel
    {
        public Card(TypeCard typeCard, string name, string description, int effectOnProduction, int effectOnMutualAid, int effectOnTechnicalSkills, int effectOnAmbiance, int timeCost)
        {
            CardType = typeCard;
            Name = name;
            Description = description;
            EffectOnProduction = effectOnProduction;
            EffectOnMutualAid = effectOnMutualAid;
            EffectOnTechnicalSkills = effectOnTechnicalSkills;
            EffectOnAmbiance = effectOnAmbiance;
            TimeCostInHour = timeCost;
        }

        public TypeCard CardType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EffectOnProduction { get; set; }
        public int EffectOnMutualAid { get; set; }
        public int EffectOnTechnicalSkills { get; set; }
        public int EffectOnAmbiance { get; set; }
        public int TimeCostInHour { get; set; }

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