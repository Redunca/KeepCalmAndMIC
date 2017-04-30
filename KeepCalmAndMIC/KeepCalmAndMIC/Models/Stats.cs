using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Stats
    {
		public double Productivity { get; set; }
		public double TechnicalSkills { get; set; }
		public double Ambiance { get; set; }
		public double MutualAid { get; set; }
        public double Production { get; set; }

        public Stats()
        {
            Productivity = 0;
            TechnicalSkills = 0;
            Ambiance = 0;
            MutualAid = 0;
            Production = 0;
        }

        public Stats(double productivity, double technicalSkills, double ambiance, double mutualAid)
        {
            Productivity = productivity;
            TechnicalSkills = technicalSkills;
            Ambiance = ambiance;
            MutualAid = mutualAid;
            Production = 0;
        }	

	}
}