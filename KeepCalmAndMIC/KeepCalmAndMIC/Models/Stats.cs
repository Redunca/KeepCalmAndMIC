using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Stats
    {
        public Stats()
        {
            Productivity = 0;
            TechnicalSkills = 0;
            Ambiance = 0;
            MutualAid = 0;
        }

        public Stats(int productivity, int technicalSkills, int ambiance, int mutualAid)
        {
            Productivity = productivity;
            TechnicalSkills = technicalSkills;
            Ambiance = ambiance;
            MutualAid = mutualAid;
        }

        public int Productivity { get; set; }
        public int TechnicalSkills { get; set; }
        public int Ambiance { get; set; }
        public int MutualAid { get; set; }
    }
}