using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
    public class DayRepository : BaseModelRepository<Day>
    {
        public DayRepository(ApplicationDbContext context) : base(context) { }
    }
}