using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
    public class WeekRepository : BaseModelRepository<Week>
    {
        public WeekRepository(ApplicationDbContext context) : base(context) { }
    }
}