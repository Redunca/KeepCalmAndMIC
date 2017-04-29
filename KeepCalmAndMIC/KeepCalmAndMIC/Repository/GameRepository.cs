using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeepCalmAndMIC.Models;
namespace KeepCalmAndMIC.Repository
{
    public class GameRepository : BaseModelRepository<Game>
    {
        public GameRepository(ApplicationDbContext context) : base(context) { }

        
    }
}