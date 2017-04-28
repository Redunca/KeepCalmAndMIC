using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Models
{
    public class Stage
    {
        public Stage ()
        {
            for(int i = 0; i <= 14; i ++)
            {
                WeeksOfTheStage.Add(new Week());
            }
        }
        private List<Week> WeeksOfTheStage = new List<Week>();
        private Stats PlayerStats = new Stats();
        private int CurrentWeek = 0;
        private int CurrentDayOfTheWeek = 0;
    }
}