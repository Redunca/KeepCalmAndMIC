using KeepCalmAndMIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.Repository
{
    public class DeckRepository : BaseModelRepository<Deck>
    {
        public DeckRepository(ApplicationDbContext context) : base(context) { }

        
    }
}