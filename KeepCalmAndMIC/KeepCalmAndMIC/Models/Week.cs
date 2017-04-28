using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Models
{
    public class Week
    {
        public Week()
        {
            for(int i = 0; i <= 4; i++)
            {
                DaysOfTheWeek.Add(new Day());
            }
            
        }

        private List<Day> DaysOfTheWeek = new List<Day>();
        private Stats WeeklyStats = new Stats();
    }
}