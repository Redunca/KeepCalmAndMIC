using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class GameManagement : BaseManagement<GameManagement>
    {
        public GameManagement (IOwinContext owinContext) : base(owinContext) { }
    }
}